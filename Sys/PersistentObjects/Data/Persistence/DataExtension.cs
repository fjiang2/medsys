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
using Sys;

namespace Sys.Data
{
    public static class DataExtension
    {
        #region SqlCmd

        public static DataSet FillDataSet(this ISqlClause sql)
        {
            SqlCmd cmd = new SqlCmd(sql.Clause);
            return cmd.FillDataSet();
        }

        public static DataTable FillDataTable(this ISqlClause sql)
        {
            SqlCmd cmd = new SqlCmd(sql.Clause);
            return cmd.FillDataTable();
        }



        #endregion


        #region IsNull

        public static T IsNull<T>(this DataRow dataRow, string columnName, T defaultValue)
        {
            if (dataRow == null)
                return defaultValue;

            return dataRow[columnName] != System.DBNull.Value ? (T)dataRow[columnName] : defaultValue;
        }

        public static T IsNull<T>(this object value, T defaultValue)
        {
            if (value == null)
                return defaultValue;

            return value != System.DBNull.Value ? (T)value : defaultValue;
        }

        #endregion


        public static T Cell<T>(this DataTable dataTable, int row, int column, T defaultValue)
        {
            return dataTable.Rows[row][column].IsNull<T>(defaultValue);
        }

        public static T Cell<T>(this DataTable dataTable, int row, int column)
        {
            return (T)dataTable.Rows[row][column];
        }



        #region  DataTable.Rows[][x] -> Array[x]


        public static F[] ToArray<F>(this DataTable dataTable, string columnName)
        {
            F[] values = new F[dataTable.Rows.Count];
            int i = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                values[i++] = (F)row[columnName];
            }
            return values;
        }

        public static F[] ToArray<F>(this DataTable dataTable, int columnIndex)
        {
            F[] values = new F[dataTable.Rows.Count];
            int i = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                values[i++] = (F)row[columnIndex];
            }
            return values;
        }

        #endregion



        #region DataRow CopyTo/Clone/EqualTo
        public static DataRow CopyTo(this DataRow src, DataRow dst)
        {
            foreach (DataColumn c in src.Table.Columns)
                dst[c.ColumnName] = src[c.ColumnName];

            return dst;
        }

        public static DataRow Clone(this DataRow src)
        {
            DataRow dst = src.Table.NewRow();
            foreach (DataColumn c in src.Table.Columns)
                dst[c.ColumnName] = src[c.ColumnName];

            return dst;
        }


        public static bool EqualTo(this DataRow r1, DataRow r2)
        {
            return EqualTo(r1, r2, new string[] { });
        }

        /// <summary>
        /// Compare 2 rows 
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <returns></returns>
        public static bool EqualTo(this DataRow r1, DataRow r2, string[] ignoredColumns)
        {
            if (r1.Table.Columns.Count != r2.Table.Columns.Count)
                return false;

            foreach (DataColumn column in r2.Table.Columns)
            {
                string x = column.ColumnName;

                if (Array.IndexOf(ignoredColumns, x) >= 0)
                    continue;

                if (!r1.Table.Columns.Contains(x))
                    return false;

                object v1 = r1[x];
                object v2 = r2[x];

                if ((v1 == null && v2 != null) || (v1 != null && v2 == null))
                    return false;
                else if (v1 == null && v2 == null)
                    continue;

                if (v1.GetType() != v2.GetType())
                    return false;

                if (v1 is byte[] && v2 is byte[])
                {
                    byte[] b1 = (byte[])v1;
                    byte[] b2 = (byte[])v2;
                    if (b1.Length != b2.Length)
                        return false;

                    for (int i = 0; i < b1.Length; i++)
                    {
                        if (b1[i] != b2[i])
                            return false;
                    }
                }
                else if (!v1.ToString().Equals(v2.ToString()))
                {
                    return false;
                }
            }

            return true;

        }

        #endregion




        public static TableName TableName(this Type dpoType)
        {
            TableAttribute[] A = dpoType.GetAttributes<TableAttribute>();
            if (A.Length > 0)
                return A[0].TableName;
            else
                return null;
        }

        internal static Level Level(this Type dpoType)
        {
            TableAttribute[] A = dpoType.GetAttributes<TableAttribute>();
            if (A.Length > 0)
                return A[0].Level;

            throw new JException("Table Level is not defined");
        }

        internal static MetaTable GetCachedMetaTable(this TableName tname)
        {
            return MetaTable.GetCachedInstance(tname);
        }

        internal static MetaTable GetMetaTable(this TableName tname)
        {
            return MetaTable.GetInstance(tname);
        }


        public static void SqlDelete(this TableName tableName, string where, params object[] args)
        {
            string sql = string.Format("DELETE FROM {0} WHERE {1}", tableName, string.Format(where, args));
            SqlCmd.ExecuteNonQuery(tableName.Provider, sql);
        }

        internal static object Convert(object obj, Type type)
        {
            if (obj == null)
                return System.DBNull.Value;

            string s = obj.ToString().Trim();

            if (type == typeof(string))
                return s;

            if (s == "")
                return System.DBNull.Value;


            string g = "";
            int i = 0;

            if (type == typeof(int) || type == typeof(short) || type == typeof(bool))
            {
                if (s[0] == '-') g = "-";
                for (i = 0; i < s.Length; i++)
                {
                    if (s[i] >= '0' && s[i] <= '9')
                        g += s[i];
                    if (s[i] == '.')
                        break;
                }

                int result = int.Parse(g);

                if (type == typeof(bool))
                    return result != 0;
                else
                    return result;
            }
            else if (type == typeof(decimal) || type == typeof(double))
            {
                bool dot = false;
                if (s[0] == '-') g = "-";
                for (i = 0; i < s.Length; i++)
                {
                    if (s[i] >= '0' && s[i] <= '9')
                        g += s[i];
                    else if (s[i] == '.' && !dot)
                    {
                        g += s[i];
                        dot = true;
                    }
                }

                if (type == typeof(double))
                    return double.Parse(g);
                else
                    return decimal.Parse(g);
            }

            else if (type == typeof(DateTime))
            {
                // "2/16/1992 12:15:12"
                return DateTime.Parse(s);
            }

            else
                throw new ApplicationException("Data Type in Convert Function is not defined.");

        }





        #region ToSqlDbType / ToType

        public static SqlDbType ToSqlDbType(this Type type)
        {
            if (type == typeof(Boolean))
                return SqlDbType.Bit;

            else if (type == typeof(Int16))
                return SqlDbType.SmallInt;

            else if (type == typeof(Int32))
                return SqlDbType.Int;

            else if (type == typeof(Int64))
                return SqlDbType.BigInt;

            else if (type == typeof(Double))
                return SqlDbType.Float;

            else if (type == typeof(Decimal))
                return SqlDbType.Decimal;

            else if (type == typeof(String))
                return SqlDbType.NVarChar;

            else if (type == typeof(DateTime))
                return SqlDbType.DateTime;

            else if (type == typeof(Byte[]))
                return SqlDbType.Binary;

            else if (type == typeof(Guid))
                return SqlDbType.UniqueIdentifier;

            throw new JException("Type {0} cannot be converted into SqlDbType", type.FullName);
        }


        public static Type ToType(this SqlDbType type)
        {
            switch (type)
            {
                case SqlDbType.Bit:
                    return typeof(System.Boolean);

                case SqlDbType.TinyInt:
                    return typeof(byte);

                case SqlDbType.SmallInt:
                    return typeof(Int16);

                case SqlDbType.Int:
                    return typeof(Int32);

                case SqlDbType.BigInt:
                    return typeof(Int64);

                case SqlDbType.Float:
                case SqlDbType.Real:
                    return typeof(Double);

                case SqlDbType.Decimal:
                case SqlDbType.SmallMoney:
                case SqlDbType.Money:
                    return typeof(Decimal);

                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.VarChar:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.NText:
                    return typeof(String);

                case SqlDbType.SmallDateTime:
                case SqlDbType.DateTime:
                    return typeof(DateTime);

                case SqlDbType.Timestamp:
                case SqlDbType.VarBinary:
                case SqlDbType.Binary:
                case SqlDbType.Image:
                    return typeof(Byte[]);

                case SqlDbType.UniqueIdentifier:
                    return typeof(Guid);

                case SqlDbType.Variant:
                case SqlDbType.Xml:
                case SqlDbType.Udt:
                case SqlDbType.Date:
                case SqlDbType.Time:
                case SqlDbType.DateTime2:
                case SqlDbType.DateTimeOffset:
                    break;

            }

            throw new JException("SqlDbType {0} cannot be converted into Type", type);
        }
        
        #endregion

        #region ToINumerable<T>

        public static DataTable ToTable<T>(this IEnumerable<T> records) where T : class,  IDPObject, new()
        {
            DPList<T> list = new DPList<T>(records);
            return list.Table;
        }

        public static DPList<T> ToDPList<T>(this IEnumerable<T> collection) where T : class, IDPObject, new()
        {
            return new DPList<T>(collection);
        }

        public static DPList<T> ToDPList<T>(this TableReader<T> reader) where T : class, IDPObject, new()
        {
            return new DPList<T>(reader);
        }

        public static DPCollection<T> ToDPCollection<T>(this DPList<T> list) where T : class, IDPObject, new()
        {
            return new DPCollection<T>(list.Table);
        }


        #endregion


        #region SqlExpr/SqlClause: ColumName/ParameterName/AddParameter

        internal static string SqlParameterName(this string name)
        {
            return "@" + name.Replace(" ", "").Replace("#", "");
        }

        public static ident ToIdent(this string name)
        {
            return new ident(name);
        }

        /// <summary>
        /// "name" -> "[name]"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SqlExpr ColumnName(this string name)
        {
            return SqlExpr.ColumnName(name);
        }

        /// <summary>
        /// "name" -> "@name"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SqlExpr ParameterName(this string name)
        {
            return SqlExpr.ParameterName(name);
        }


        /// <summary>
        /// "name" -> "[name]=@name"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SqlExpr AddParameter(this string columnName)
        {
            return SqlExpr.AddParameter(columnName, columnName);
        }

        /// <summary>
        /// Add SQL parameter
        /// e.g. NodeDpo._ID.AddParameter(TaskDpo._ParentID) -> "[ID]=@ParentID"
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static SqlExpr AddParameter(this string columnName, string parameterName)
        {
            return SqlExpr.AddParameter(columnName, parameterName);
        }

        #endregion

    }
}
