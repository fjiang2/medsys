using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Data.Comparison
{
    class ColumnPair
    {
        public string ColumnName { get; set; }
        public object Value { get; set; }

        private const string DELIMETER = "'";

        public ColumnPair()
        { 
        }

        public string ToScript()
        {
            if (Value == null || Value == DBNull.Value)
                return "NULL";
            else if (Value is DateTime)
            {
                var d = DELIMETER + ((DateTime)Value).ToShortDateString() + DELIMETER;
                return d;
                //return string.Format("CAST(N'2012-01-01 00:00:00.000' AS DateTime)", d);
            }
            else if (Value is string)
                return "N" + DELIMETER + (Value as string).Replace("'", "''") + DELIMETER;
            else if (Value is Guid)
                return "N" + DELIMETER + Value.ToString() + DELIMETER;
            else if (Value is bool)
                return (bool)Value ? "1" : "0";
            else if (Value is byte[])
            {
                return "0x" + ByteArrayToHexString((byte[])Value);
            }
            else
                return Value.ToString();
        }

        public static string ByteArrayToHexString(byte[] bytes)
        {
            char[] c = new char[bytes.Length * 2];
            byte b;
            for (int i = 0; i < bytes.Length; ++i)
            {
                b = ((byte)(bytes[i] >> 4));
                c[i * 2] = (char)(b > 9 ? b + 0x37 : b + 0x30);

                b = ((byte)(bytes[i] & 0xF));
                c[i * 2 + 1] = (char)(b > 9 ? b + 0x37 : b + 0x30);
            }

            return new string(c);
        }


        public override string ToString()
        {
            return string.Format("[{0}] = {1}", ColumnName, ToScript());
        }

    }
}
