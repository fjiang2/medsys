using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace X12.File
{
    enum ErrorLevel
    {
        Warning,
        Error,
        Message
    }

    class ErrorMessageItem
    {
        public readonly int line;
        public readonly ErrorLevel level;
        public readonly string message;

        public ErrorMessageItem(int line, ErrorLevel level, string message)
        {
            this.level = level;
            this.line = line;
            this.message = message;
        }

        
        public override int GetHashCode()
        {
            return line.GetHashCode() + level.GetHashCode() + message.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            ErrorMessageItem item = (ErrorMessageItem)obj;
            return this.line == item.line && this.level == item.level && this.message == item.message;
        }
    }



    class X12ErrorMessage: List<ErrorMessageItem>
    {
        private static X12ErrorMessage instance = null;
        
        private X12ErrorMessage()
        { 
        }

        private static X12ErrorMessage Instance
        {
            get
            {
                if (instance == null)
                    instance = new X12ErrorMessage();
                return instance;
            }
        }

        public static void Reset()
        {
            Instance.Clear();
        }

     

        public static void Error(int line, string message)
        {
            ErrorMessageItem item = new ErrorMessageItem(line, ErrorLevel.Error, message);
            //Instance.Clear();       //keep last error
            if(!Instance.Contains(item))
                Instance.Add(item);
        }

        public static void Warning(int line, string message)
        {
            ErrorMessageItem item = new ErrorMessageItem(line, ErrorLevel.Warning, message);
            if (!Instance.Contains(item))
                Instance.Add(item);
        }

        public static void Information(int line, string message)
        {
            ErrorMessageItem item = new ErrorMessageItem(line, ErrorLevel.Message, message);
            if (!Instance.Contains(item))
                Instance.Add(item);
        }


        public static DataTable ToTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Line", typeof(int)));
            dt.Columns.Add(new DataColumn("Type", typeof(string)));
            dt.Columns.Add(new DataColumn("Message", typeof(string)));
            
            foreach (ErrorMessageItem item in Instance)
            {
                DataRow row = dt.NewRow();
                row[0] = item.line;
                row[1] = item.level.ToString();
                row[2] = item.message;
                dt.Rows.Add(row);
            }


            return dt;
        }
    }
}
