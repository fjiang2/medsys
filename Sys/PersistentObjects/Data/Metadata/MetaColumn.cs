//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        DPO(Data Persistent Object)                                                               //
//                                                                                                  //
//          Copyright(c) Datum Connect Inc.                                                         //
//                                                                                                  //
// This source code is subject to terms and conditions of the Datum Connect Software License. A     //
// copy of the license can be found in the License.html file at the root of this distribution. If   //
// you cannot locate the  Datum Connect Software License, please send an email to                   //
// datconn@gmail.com. By using this source code in any fashion, you are agreeing to be bound        //
// by the terms of the Datum Connect Software License.                                              //
//                                                                                                  //
// You must not remove this notice, or any other, from this software.                               //
//                                                                                                  //
//                                                                                                  //
//--------------------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sys.Data
{
    public interface IMetaColumn
    {
        string ColumnName { get;  }
        string DataType { get;  }
        short Length { get;  } 
        bool Nullable { get; }
        byte precision { get;  }
        byte scale { get;  }
        bool IsIdentity { get;  }
        bool IsComputed { get;  }
        int ColumnID { get; }

        IForeignKey ForeignKey { get; set; }
        SqlDbType SqlDbType { get; }
        int AdjuestedLength { get; }
    }


    public class MetaColumn : PersistentObject, IMetaColumn
    {

        [Column("ColumnName", SqlDbType.NVarChar, Primary = true)]
        public string ColumnName { get; set; }

        [Column("DataType", SqlDbType.NVarChar)]
        public string DataType { get; set; }

        [Column("Length", SqlDbType.Int)]
        public short Length { get; set; }    //length return from SQL Server

        [Column("Nullable", SqlDbType.Bit)]
        public bool Nullable { get; set; }

        [Column("precision", SqlDbType.TinyInt)]
        public byte precision { get; set; }

        [Column("scale", SqlDbType.TinyInt)]
        public byte scale { get; set; }

        [Column("IsIdentity", SqlDbType.Bit)]
        public bool IsIdentity { get; set; }

        [Column("IsComputed", SqlDbType.Bit)]
        public bool IsComputed { get; set; }

        [Column("ColumnID", SqlDbType.Int)]
        public int ColumnID { get; set; }    //column_id is from column dictionary
        
        [Column("label", SqlDbType.NVarChar)]
        public string label { get; set; }    //label used as caption to support internationalization

        private SqlDbType sqlDbType;
        private string fieldName;
        private bool isPrimary = false;
        private IForeignKey foreignKey;

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
            this.IsComputed = attr.Computed;
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

        public IForeignKey ForeignKey
        {
            get { return this.foreignKey; }
            set { this.foreignKey = value; }
        }


        public override string ToString()
        {
            return string.Format("Column={0}(Type={1}, Null={2}, Length={3})", ColumnName, DataType, Nullable, Length);
        }

        #region C# Dpo class Field

        internal bool IsImageField
        {
            get { return sqlDbType == System.Data.SqlDbType.Image; }
        }

        internal string FieldName
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



        internal static bool Oversize(IMetaColumn column, object value)
        {
            if (!(value is string))
                return false;

            if (column.SqlDbType == SqlDbType.NText || column.SqlDbType == SqlDbType.Text)
                return false;

            string s = (string)value;

            if (column.Length == -1)
            {
                if (column.SqlDbType == SqlDbType.NVarChar || column.SqlDbType == SqlDbType.NChar)
                    return s.Length > 4000;
                else
                    return s.Length > 8000;
            }
            else
                return s.Length > column.AdjuestedLength;
        }


        public bool Oversize(object value)
        {
            return Oversize(this, value);
        }
        
        #region Dpo field's Attribute
         
        internal string Attribute
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

            if (IsComputed)
                attribute += ", Computed = true";

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


       
        

        public static string GetSQLField(IMetaColumn column)
        {
            string ty = "";
            string DataType = column.DataType;
            int Length = column.Length;

            switch (column.SqlDbType)
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
                    ty = string.Format("{0}({1},{2})", DataType, column.precision, column.scale);
                    break;


                default:
                    ty = DataType;
                    break;
            }

            string line = string.Format("\t[{0}] {1} {2} ", column.ColumnName, ty, column.Nullable ? "NULL" : "NOT NULL");

            if (column.IsIdentity)
            {
                line += "IDENTITY(1,1)";
                return line;
            }

            if (column.IsComputed)
                throw new JException("not support computed column: {0} during creating table", column.ColumnName);

            return line;
        }
    
        #endregion


        public object ToObject(string val)
        {
            if (this.Nullable && val == "")
                return null;

            switch (sqlDbType)
            {
                case SqlDbType.VarChar:
                case SqlDbType.NVarChar:
                case SqlDbType.Char:
                case SqlDbType.NChar:
                    if (Oversize(val))
                        throw new JException("Column Name={0}, length of value \"{1}\" {2} > {3}", ColumnName, val, val.Length, this.AdjuestedLength);
                    else
                        return val;
           
                case SqlDbType.VarBinary:
                case SqlDbType.Binary:
                    throw new NotImplementedException(string.Format("cannot convert {0} into type of {1}", val, sqlDbType));
                    

                case SqlDbType.DateTime:
                    if(val.IndexOf("-") > 0)    //2011-10-30
                    {
                        string[] date = val.Split('-');
                        return new DateTime(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]));
                    }
                    else if(val.Length == 8)    //20111030
                    {
                        int month = Convert.ToInt32(val.Substring(4, 2));
                        int day = Convert.ToInt32(val.Substring(6, 2));
                        if(month==0)
                           month =1;
                        
                        if(day ==0)
                            day = 1;

                        return new DateTime(Convert.ToInt32(val.Substring(0, 4)), month, day);
                    }
                    else 
                    {
                        return Convert.ToDateTime(val);
                    }

                case SqlDbType.Float:
                    return Convert.ToDouble(val);

                case SqlDbType.Real:
                    return Convert.ToSingle(val);


                case SqlDbType.Bit:
                    if (val == "0")
                        return false;
                    else if (val == "1")
                        return true;
                    else 
                        return Convert.ToBoolean(val);

                case SqlDbType.Decimal:
                    return Convert.ToDecimal(val);

                case SqlDbType.TinyInt:
                    return Convert.ToByte(val);

                case SqlDbType.SmallInt:
                    return Convert.ToInt16(val);

                case SqlDbType.Int:
                    return Convert.ToInt32(val);
                
                case SqlDbType.BigInt:
                    return Convert.ToInt64(val);

                default:
                    throw new NotImplementedException(string.Format("cannot convert {0} into type of {1}", val, sqlDbType));
            }

        }
    }
}
