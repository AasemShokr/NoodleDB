using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoodleDB
{
    public class Table
    {
        public string Name { get; private set; }
        public List<string> Columns { get; private set; }
        public List<Record> Records { get; private set; }

        public Table(string name, List<string> columns)
        {
            Name = name;
            Columns = new List<string>(columns);
            Records = new List<Record>();
        }

        public void AddRecord(Dictionary<string, string> recordData)
        {
            Records.Add(new Record(recordData));
        }

        public List<Record> GetRecords()
        {
            return Records;
        }

        public void UpdateRecord(string keyColumn, string keyValue, Dictionary<string, string> updatedValues)
        {
            foreach (var record in Records)
            {
                if (record.GetValue(keyColumn) == keyValue)
                {
                    foreach (var kvp in updatedValues)
                    {
                        record.SetValue(kvp.Key, kvp.Value);
                    }
                }
            }
        }

        public void DeleteRecord(string keyColumn, string keyValue)
        {
            Records.RemoveAll(r => r.GetValue(keyColumn) == keyValue);
        }

        public override string ToString()
        {
            return $"Table: {Name}, Columns: {string.Join(", ", Columns)}\n" +
                   string.Join("\n", Records.Select(r => r.ToString()));
        }
    }

}
