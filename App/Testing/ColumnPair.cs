using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Testing
{
    class ColumnPair
    {
        public string ColumnName { get; set; }
        public object Value { get; set; }

        static string DELIMETER = "'";

        public ColumnPair()
        { 
        }

        private string ToScript()
        {
            if (Value == null || Value == DBNull.Value)
                return "NULL";
            else if (Value is DateTime)
                return DELIMETER + ((DateTime)Value).ToShortDateString() + DELIMETER;
            else if (Value is string)
                return "N" + DELIMETER + (Value as string).Replace("'", "''") + DELIMETER;
            else
                return Value.ToString();
        }

        public override string ToString()
        {
            return string.Format("[{0}]={1}", ColumnName, ToScript());
        }

    }
}
