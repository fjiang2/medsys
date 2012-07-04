using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    /// <summary>
    /// a value can be used on SQL statement
    /// </summary>
    public class SqlValue
    {
        private object value;

        public SqlValue(object value)
        {
            this.value = value;
        }


        public string Text
        {
            get
            {
                if (value == null || value == DBNull.Value)
                    return "NULL";

                StringBuilder sb = new StringBuilder();

                if (value is string)
                {
                    sb.Append("'")
                      .Append((value as string).Replace("'", "''"))
                      .Append("'");
                }
                else if (value is bool || value is bool?)
                {
                    sb.Append((bool)value ? "1" : "0");
                }
                else if (value is DateTime || value is DateTime? || value is char)
                {
                    sb.Append("'").Append(value).Append("'");
                }
                else
                {
                    sb.Append(value);
                }

                return sb.ToString();
            }
        }

        public override string ToString()
        {
            return this.Text;
        }
      
    }
}
