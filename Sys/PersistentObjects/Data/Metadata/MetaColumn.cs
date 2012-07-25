using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sys.Data
{
    class MetaColumn : PersistentObject
    {
        public string ColumnName;
        public string DataType;
        public short Length;    //length return from SQL Server
        public bool Nullable;
        public byte precision;
        public byte scale;
        public bool IsIdentity;
        
        public int ColumnID;    //column_id is from column dictionary
        public string label;    //label used as caption to support internationalization

        private SqlDbType sqlDbType;
        private string fieldName;
        private bool isPrimary = false;
        private ForeignKey foreignKey;

        public MetaColumn(DataRow dataRow)
            : base(dataRow)
        {
            this.fieldName = GetFieldName(this.ColumnName);
            this.sqlDbType = GetSqlDbType(this.DataType);
        }

        internal MetaColumn(ColumnAttribute attr)
        {
            this.fieldName = GetFieldName(attr.ColumnName);

            this.ColumnName = attr.ColumnName;
            this.SqlDbType = attr.SqlDbType;
            this.AdjuestedLength = attr.Length;

            this.Nullable = attr.Nullable;
            this.precision = attr.Precision;
            this.scale = attr.Scale;
            this.IsIdentity = attr.Identity;
            this.isPrimary = attr.Primary;

            this.ColumnID = -1; //useless here
            this.label = attr.Caption;
        }

        public string Caption
        {
            get
            {
                if (string.IsNullOrEmpty(this.label))
                    return ColumnName;
                else
                    return this.label;
            }
        }

        public SqlDbType SqlDbType
        {
            get { return this.sqlDbType; }
            set
            {
                this.sqlDbType = value;
                this.DataType = value.ToString();
            }
        }

        /// <summary>
        /// Adjuested Length
        /// </summary>
        public int AdjuestedLength
        {
            get
            {
                if (this.Length == -1)
                    return -1;

                switch (this.sqlDbType)
                {
                    case SqlDbType.NChar:
                    case SqlDbType.NVarChar:
                        return this.Length / 2;
                }
         
                return this.Length;
            }
            set
            {
                this.Length = (short)value;
                if (this.Length == -1)
                    return;

                if (this.SqlDbType == SqlDbType.NVarChar || this.SqlDbType == SqlDbType.NChar)
                    this.Length *= 2;
                
           }
        }

        public bool IsPrimary
        {
            get { return this.isPrimary; }
            set { this.isPrimary = value; }
        }

        public ForeignKey ForeignKey
        {
            get { return this.foreignKey; }
            set { this.foreignKey = value; }
        }


        public override string ToString()
        {
            return string.Format("Column={0}(Type={1}, Null={2}, Length={3})", ColumnName, DataType, Nullable, Length);
        }

        #region C# Dpo class Field

        public bool IsImageField
        {
            get { return sqlDbType == System.Data.SqlDbType.Image; }
        }

        public string FieldName
        {
            get { return this.fieldName; }
        }


        private static string GetFieldName(string columnName)
        {
            string fieldName = columnName;
            if (   columnName.IndexOf("#") != -1 
                || columnName.IndexOf(" ") != -1 
                || columnName.IndexOf("/") != -1 
                || !Char.IsLetter(columnName[0]))
            {
                fieldName = columnName.Replace("#", "_").Replace(" ", "_").Replace("/", "_");

                if (!Char.IsLetter(columnName[0]))
                    fieldName = "_" + fieldName;
            }

            return fieldName;

        }

        #endregion



        public bool Oversize(object value)
        {
            if (!(value is string))
                return false;

            if (sqlDbType == SqlDbType.NText || sqlDbType == SqlDbType.Text)
                return false;

            string s = (string)value;

            if (this.Length == -1)
            {
                if (this.SqlDbType == SqlDbType.NVarChar || this.SqlDbType == SqlDbType.NChar)
                    return s.Length > 4000;
                else
                    return s.Length > 8000;
            }
            else
                return s.Length > this.AdjuestedLength;
        }

        
        #region Dpo field's Attribute
         
        public string Attribute
        {
            get
            {
                return  GetAttribute(this.sqlDbType);
            }
        }


        private string GetAttribute(SqlDbType type)
        {
            string attr = "";
            switch (type)
            {
                case SqlDbType.Char:
                case SqlDbType.VarChar:
                case SqlDbType.VarBinary:
                case SqlDbType.Binary:
                    attr = string.Format(", Length = {0}", AdjuestedLength);
                    break;

                case SqlDbType.NChar:
                case SqlDbType.NVarChar:
                    attr = string.Format(", Length = {0}", AdjuestedLength);
                    break;


                //case SqlDbType.Numeric:
                case SqlDbType.Decimal:
                    attr = string.Format(", Precision = {0}, Scale = {1}", precision, scale);
                    break;


            }

            string attribute = string.Format("[Column(_{0}, SqlDbType.{1}", fieldName, sqlDbType);

            if (Nullable)
                attribute += ", Nullable = true";   //see: bool Nullable = false; in class DataColumnAttribute

            if (IsIdentity)
                attribute += ", Identity = true";

            if (IsPrimary)
                attribute += ", Primary = true";


            if (attr != "")
                attribute += attr;

            attribute += ")]";

            return attribute;
        }
        
        #endregion



        #region SqlDataType -> System.SqlDbType / C# field type / SQL_Create_Table Type

        public static SqlDbType GetSqlDbType(string sqlType)
        {
            switch (sqlType.ToLower())
            {
                case "varchar":
                    return SqlDbType.VarChar;

                case "char":
                    return SqlDbType.Char;
         
                case "nvarchar":
                    return SqlDbType.NVarChar;

                case "nchar":
                    return SqlDbType.NChar;

                case "decimal":
                    return SqlDbType.Decimal;

                case "numeric":
                    return SqlDbType.Decimal;

                case "text":
                    return SqlDbType.Text;

                case "ntext":
                    return SqlDbType.NText;

                case "datetime":
                    return SqlDbType.DateTime;

                case "smalldatetime":
                    return SqlDbType.SmallDateTime;

                case "timestamp":
                    return SqlDbType.Timestamp;

                case "bit":
                    return SqlDbType.Bit;

                case "money":
                    return SqlDbType.Money;

                case "smallmoney":
                    return SqlDbType.SmallMoney;

                case "real":
                    return SqlDbType.Real;

                case "float":
                    return SqlDbType.Float;

                case "tinyint":
                    return SqlDbType.TinyInt;

                case "smallint":
                    return SqlDbType.SmallInt;

                case "int":
                    return SqlDbType.Int;

                case "bigint":
                    return SqlDbType.BigInt;

                case "varbinary":
                    return SqlDbType.VarBinary;

                case "binary":
                    return SqlDbType.Binary;


                case "image":
                    return SqlDbType.Image;

                case "uniqueidentifier":
                    return SqlDbType.UniqueIdentifier;


            }

            throw new JException("data type [{0}] is not supported", sqlType);
        }



        public static string GetFieldType(string sqlType, bool nullable)
        {
            string ty = "";
            switch (sqlType.ToLower())
            {
                case "varchar":
                case "char":
                case "text":
                case "nvarchar":
                case "nchar":
                case "ntext":
                    ty = "string";
                    break;

                case "datetime":
                case "smalldatetime":
                    ty = "DateTime";
                    if (nullable) ty += "?";
                    break;

                case "timestamp":
                    ty = "TimeSpan";
                    if (nullable) ty += "?";
                    break;

                case "bit":
                    ty = "bool";
                    if (nullable) ty += "?";
                    break;

                case "money":
                case "smallmoney":
                case "decimal":
                case "numeric":
                    ty = "decimal";
                    if (nullable) ty += "?";
                    break;

                case "real":
                    ty = "Single";
                    if (nullable) ty += "?";
                    break;

                case "float":
                    ty = "double";
                    if (nullable) ty += "?";
                    break;

                case "tinyint":
                    ty = "byte";
                    if (nullable) ty += "?";
                    break;

                case "smallint":
                    ty = "short";
                    if (nullable) ty += "?";
                    break;

                case "int":
                    ty = "int";
                    if (nullable) ty += "?";
                    break;

                case "bigint":
                    ty = "long";
                    if (nullable) ty += "?";
                    break;


                case "varbinary":
                case "binary":
                case "image":
                    ty = "byte[]";
                    break;

                case "uniqueidentifier":
                    ty = "Guid";
                    break;

                case "sql_variant":
                    ty = "object";
                    break;

                default:
                    ty = sqlType;
                    break;
            }
            return ty;
        }


       
        

        public string GetSQLField()
        {
            string ty = "";

            switch (sqlDbType)
            {
                case SqlDbType.VarChar:
                case SqlDbType.Char:
                case SqlDbType.VarBinary:
                case SqlDbType.Binary:
                    if (Length >= 0)
                        ty = string.Format("{0}({1})", DataType, Length);
                    else
                        ty = string.Format("{0}(max)", DataType);
                    break;

                case SqlDbType.NVarChar:
                case SqlDbType.NChar:
                    if (Length >= 0)
                        ty = string.Format("{0}({1})", DataType, Length / 2);
                    else
                        ty = string.Format("{0}(max)", DataType);
                    break;

                //case SqlDbType.Numeric:
                case SqlDbType.Decimal:
                    ty = string.Format("{0}({1},{2})", DataType, precision, scale);
                    break;


                default:
                    ty = DataType;
                    break;
            }

            string line = string.Format("\t[{0}] {1} {2} ", ColumnName, ty, Nullable ? "NULL" : "NOT NULL");

            if (this.IsIdentity)
            {
                line += "IDENTITY(1,1)";
                return line;
            }

            return line;
        }
    
        #endregion
    }
}
