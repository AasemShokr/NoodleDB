using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace NoodleDB
{
    public class NoodleDatabase
    {
        private string _filePath;
        private List<Table> _tables;

        public NoodleDatabase(string filePath)
        {
            _filePath = filePath;
            _tables = new List<Table>();
            LoadDatabase();
        }

        private void LoadDatabase()
        {
            if (!File.Exists(_filePath)) return;

            string[] lines = File.ReadAllLines(_filePath);
            Table currentTable = null;
            List<string> columns = null;

            foreach (string line in lines)
            {
                if (line.StartsWith("#") || string.IsNullOrWhiteSpace(line)) continue;

                if (line.StartsWith("[TABLE: "))
                {
                    string tableName = line.Replace("[TABLE: ", "").Replace("]", "").Trim();
                    currentTable = new Table(tableName, new List<string>());
                    _tables.Add(currentTable);
                }
                else if (line.StartsWith("columns: "))
                {
                    columns = line.Replace("columns: ", "").Split('|').Select(h => h.Trim()).ToList();
                    if (currentTable != null)
                        currentTable = new Table(currentTable.Name, columns);
                }
                else if (currentTable != null && columns != null)
                {
                    var values = line.Split('|').Select(v => v.Trim()).ToArray();
                    var record = new Dictionary<string, string>();
                    for (int i = 0; i < columns.Count; i++)
                    {
                        record[columns[i]] = values[i];
                    }
                    currentTable.AddRecord(record);
                }
            }
        }

        public void CreateTable(string name, List<string> columns)
        {
            if (!_tables.Any(t => t.Name == name))
            {
                _tables.Add(new Table(name, columns));
            }
        }

        public void InsertRecord(string tableName, Dictionary<string, string> record)
        {
            var table = _tables.FirstOrDefault(t => t.Name == tableName);
            if (table != null)
            {
                table.AddRecord(record);
            }
        }

        public List<Record> ReadTable(string tableName)
        {
            var table = _tables.FirstOrDefault(t => t.Name == tableName);
            return table != null ? table.GetRecords() : new List<Record>();
        }

        public void UpdateRecord(string tableName, string keyColumn, string keyValue, Dictionary<string, string> updatedValues)
        {
            var table = _tables.FirstOrDefault(t => t.Name == tableName);
            if (table != null)
            {
                table.UpdateRecord(keyColumn, keyValue, updatedValues);
            }
        }

        public void DeleteRecord(string tableName, string keyColumn, string keyValue)
        {
            var table = _tables.FirstOrDefault(t => t.Name == tableName);
            if (table != null)
            {
                table.DeleteRecord(keyColumn, keyValue);
            }
        }

        public void SaveDatabase()
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.WriteLine("# NoodleDB v1.0");
                foreach (var table in _tables)
                {
                    writer.WriteLine($"[TABLE: {table.Name}]");
                    writer.WriteLine("columns: " + string.Join(" | ", table.Columns));
                    foreach (var record in table.Records)
                    {
                        writer.WriteLine(record.ToString());
                    }
                }
            }
        }

        public void PrintTable(string tableName)
        {
            var table = _tables.FirstOrDefault(t => t.Name == tableName);
            if (table != null)
            {
                Console.WriteLine(table);
            }
        }
    }
}