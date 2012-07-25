using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Reflection;

namespace Sys.Data
{
    public class DataField
    {
        private string fieldName;
        private string caption;
       
        private SqlDbType sqlDbType;

        private bool saved = true;
        private bool identity = false;
        private bool primary = false;


        public DataField(string columnName, SqlDbType sqlDbType)
        {
            this.fieldName = columnName;
            this.Caption = columnName;

            this.sqlDbType = sqlDbType;
        }

      
        public override string ToString()
        {
            return fieldName;
        }

       

        public string Name
        {
            get
            {
                return this.fieldName;
            }
        }

        public string Caption
        {
            get { return caption; }
            set { caption = value; }
        }

        public bool Saved
        {
            get { return this.saved; }
            set { this.saved = value; }
        }


        public bool Identity
        {
            get { return this.identity; }
            set
            {
                this.identity = value;
                if (this.identity)
                    saved = false;
            }
        }

        public bool Primary
        {
            get
            {
                return this.primary;
            }
            set
            {
                this.primary = value;
            }
        }

      


        public Type DataType
        {
            get { return this.sqlDbType.ToType(); }
        }

        public SqlDbType SqlDbType
        {
            get { return this.sqlDbType; }
        }

        public string ParameterName
        {
            get
            {
                return fieldName.SqlParameterName();
            }
        }

        public SqlParameter SqlParameter
        {
            get
            {
                return new SqlParameter(this.ParameterName, this.sqlDbType);
            }
        }

        internal string[] InsertString()
        {
            string[] s = new string[2];
            s[0] = "[" + fieldName + "]";
            s[1] =  ParameterName;
            return s;
        }



        internal string UpdateString()
        {
            return string.Format("[{0}]={1}", fieldName, ParameterName);
        }

    }
}
