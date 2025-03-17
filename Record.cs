using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoodleDB
{
    public class Record
    {
        public Dictionary<string, string> Data { get; private set; }

        public Record(Dictionary<string, string> data)
        {
            Data = new Dictionary<string, string>(data);
        }

        public string GetValue(string column)
        {
            return Data.ContainsKey(column) ? Data[column] : null;
        }

        public void SetValue(string column, string value)
        {
            if (Data.ContainsKey(column))
                Data[column] = value;
        }

        public override string ToString()
        {
            return string.Join(" | ", Data.Values);
        }
    }

}
