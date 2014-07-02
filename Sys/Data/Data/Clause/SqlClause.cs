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
    /// <summary>
    /// SQL clauses builder
    /// </summary>
    public class SqlClause : SqlClauseInfo, ISqlClause
    {
        private StringBuilder script = new StringBuilder();
        private DataProvider provider;

        public SqlClause()
        {
            this.provider = DataProviderManager.DefaultProvider;
        }
        public SqlClause(DataProvider privider)
        {
            this.provider = privider;
        }

        //public static implicit operator SqlClause(string sql)
        //{
        //    return new SqlClause(sql);
        //}

        public static explicit operator string(SqlClause sql)
        {
            return sql.Clause;
        }


        
        public DataProvider Provider
        {
            get
            {
                return provider;
            }
            set
            {
                this.provider = value;
            }
        }

        #region Table Name
        private SqlClause TABLE_NAME(string tableName, string alias)
        {
            script.Append(tableName);
            if (alias != null)
                script.Append(" ").Append(alias);
            
            return this;
        }

        public SqlClause TABLE_NAME(TableName tableName, string alias = null)
        {
            return TABLE_NAME(tableName.FullName, alias);
        }

     
        public SqlClause TABLE_NAME(DPObject dpo, string alias = null)
        {
            return TABLE_NAME(dpo.TableName, alias);
        }

        public SqlClause TABLE_NAME(Type dpoType, string alias = null)
        {
            return TABLE_NAME(dpoType.TableName(), alias);
        }

        public SqlClause TABLE<T>(string alias = null)
        {
            return TABLE_NAME(typeof(T).TableName(), alias);
        }


        
        #endregion

        public SqlClause USE(string database)
        {
            script.Append("USE ").AppendLine(database);
            return this;
        }

        public SqlClause USE(DatabaseName databaseName)
        {
            script.Append("USE ").AppendLine(databaseName.Name);
            return this;
        }


        #region SELECT clause

        public SqlClause SELECT
        {
            get
            {
                script.Append("SELECT");
                return this;
            }
        }

        public SqlClause DISTINCT
        {
            get
            {
                script.Append(" DISTINCT ");
                return this;
            }
        }

        public SqlClause ALL
        {
            get
            {
                script.Append(" ALL ");
                return this;
            }
        }


        public SqlClause TOP(int n)
        {
            script.Append(" TOP ").Append(n);
            return this;
        }


        //public SqlClause COLUMNS(params string[] columns)
        //{
        //    if (columns.Length == 0)
        //        script.Append(" * ");
        //    else
        //        script.Append(" ").Append(ConcatColumns(columns));

        //    return this;
        //}

        public SqlClause COLUMNS(params SqlExpr[] columns)
        {
            if (columns.Length == 0)
                script.Append(" * ");
            else
                script.Append(" ").Append(string.Join(",", columns.Select(column=>column.ToString())));

            return this;
        }


        public SqlClause INTO(string tableName)
        {
            script
                .Append(" INTO ")
                .Append(tableName);

            return this;
        }

        public SqlClause INTO(TableName tableName)
        {
            script
                .Append(" INTO ")
                .Append(tableName.FullName);

            return this;
        }

        #endregion


        #region FROM clause

        public SqlClause FROM(DPObject dpo, string alias = null)
        {
            return FROM(dpo.TableName, alias);
        }

        public SqlClause FROM(Type dpoType, string alias = null)
        {
            return FROM(dpoType.TableName(), alias);
        }


        public SqlClause FROM<T>(string alias = null)
        {
            return FROM(typeof(T).TableName(), alias);
        }


        public SqlClause FROM(TableName tableName, string alias = null)
        {
            this.provider = tableName.Provider;
            return FROM(tableName.FullName, alias);
        }

        private SqlClause FROM(string from, string alias)
        {
            script.Append(" FROM ").Append(from);
            if (alias != null)
                script.Append(" ").Append(alias);

            return this;
        }

        #endregion



        public SqlClause UPDATE(DPObject dpo, string alias = null)
        {
            return UPDATE(dpo.TableName, alias);
        }

        public SqlClause UPDATE<T>(string alias = null)
        {
            return UPDATE(typeof(T).TableName(), alias);
        }

        public SqlClause UPDATE(Type dpoType, string alias = null)
        {
            return UPDATE(dpoType.TableName(), alias);
        }

        public SqlClause UPDATE(TableName tableName, string alias = null)
        {
            this.provider = tableName.Provider;
            return UPDATE(tableName.FullName, alias);
        }


        private SqlClause UPDATE(string tableName, string alias)
        {
           script.Append("UPDATE ").Append(tableName);
            if(alias != null)
                script.Append(" ").Append(alias);
           
            return this;
        }


        public SqlClause SET(params string[] assignments)
        {
            script.Append("SET ").Append(string.Join(",",assignments));

            return this.CRLF;
        }

    

        public SqlClause SET(params SqlExpr[] assignments)
        {
            script.Append(" SET ");
            string s = string.Join<SqlExpr>(", ", assignments);
            script.Append(s);

            return this.CRLF;
        }


        public SqlClause INSERT<T>(params string[] columns)
        {
            return INSERT(typeof(T).TableName(), columns);
        }

        public SqlClause INSERT(TableName tableName, params string[] columns)
        {
            this.provider = tableName.Provider;
            script
                .Append("INSERT INTO")
                .Append(tableName);
            
            if(columns.Length >0)
                script.Append("(").Append(ConcatColumns(columns)).Append(")");

            return this;
        }


        public SqlClause VALUES(params object[] values)
        {
            script
                .Append("VALUES ")
                .Append("(").Append(ConcatValues(values)).Append(")");

            return this.CRLF;
        }

        public SqlClause DELETE(TableName tableName)
        {
            this.provider = tableName.Provider;

            script.Append("DELETE FROM ").Append(tableName);

            return this;
        }

        public SqlClause DELETE<T>()
        {
            return DELETE(typeof(T).TableName());
        }

        #region WHERE clause

        public SqlClause WHERE(SqlExpr exp)
        {
            script.Append(" WHERE ").Append(exp);
            this.Merge(exp);
            return this.CRLF;
        }

        #endregion


        #region INNER/OUT JOIN clause

        public SqlClause LEFT
        {
            get
            {
                script.Append(" LEFT");
                return this;
            }
        }

        public SqlClause RIGHT
        {
            get
            {
                script.Append(" RIGHT");
                return this;
            }
        }

        public SqlClause INNER
        {
            get
            {
                script.Append(" INNER");
                return this;
            }
        }

        public SqlClause OUTTER
        {
            get
            {
                script.Append(" OUTTER");
                return this;
            }
        }

     


        public SqlClause JOIN(DPObject dpo, string alias = null)
        {
            return JOIN(dpo.TableName, alias);
        }

        public SqlClause JOIN<T>(string alias = null)
        {
            return JOIN(typeof(T).TableName(), alias);
        }

        public SqlClause JOIN(Type dpoType, string alias = null)
        {
            return JOIN(dpoType.TableName(), alias);
        }

        public SqlClause JOIN(TableName tableName, string alias = null)
        {
            return JOIN(tableName.FullName, alias);
        }

        private SqlClause JOIN(string tableName, string alias)
        {
            script
                .Append(" JOIN ")
                .Append(tableName);

            if (alias != null)
                script.Append(" ").Append(alias);
                
            return this;
        }

        public SqlClause ON(SqlExpr exp)
        {
            script.Append(" ON ").Append(exp);
            this.Merge(exp);
            return this;
        }

        #endregion



        #region GROUP BY / HAVING clause
        public SqlClause GROUP_BY(params string[] columns)
        {
            script.Append(" GROUP BY ").Append(ConcatColumns(columns));
            return this;
        }

        public SqlClause HAVING(params string[] columns)
        {
            script.Append(" HAVING ").Append(ConcatColumns(columns));
            return this;
        }
        
        #endregion



        public SqlClause ORDER_BY(params string[] columns)
        {
            if (columns == null)
                return this;

            script.Append(" ORDER BY ").Append(ConcatColumns(columns));
            return this;
        }


        public SqlClause UNION
        {
            get
            {
                script.Append(" UNION ");
                return this;
            }
        }


        public SqlClause DESC
        {
            get
            {
                script.Append(" DESC");
                return this;
            }
        }




        private int tab = 0;
        private SqlClause TAB(int n)
        {
            tab += n;
            for (int i = 0; i < tab; i++)
                script.Append("\t");

            return this;
        }


        private SqlClause CRLF
        {
            get
            {
                script.AppendLine();
                return this;
            }
        }

        private SqlClause PAR(string exp)
        {
            script.Append("(").Append(exp).Append(")");
            return this;
        }

   

        #region Concatenate



        private static string ConcatColumns(string[] columns)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < columns.Length; i++)
            {
                if (i != 0)
                    sb.Append(",");

                sb.Append("[").Append(columns[i]).Append("]");
            }

            return sb.ToString();
        }

      
        private static string ConcatValues(object[] S)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < S.Length; i++)
            {
                if (i != 0)
                    sb.Append(",");

                sb.Append(new SqlValue(S[i]).Text);

            }

            return sb.ToString();
        }

   

     
        #endregion

        /// <summary>
        /// concatenate 2 clauses in TWO lines
        /// </summary>
        /// <param name="clause1"></param>
        /// <param name="clause2"></param>
        /// <returns></returns>
        public static SqlClause operator +(SqlClause clause1, SqlClause clause2)
        {
            var clause = new SqlClause();
                
            clause.script
                .Append(clause1)
                .AppendLine()
                .Append(clause2);
            return clause;
        }

        /// <summary>
        /// concatenate 2 clauses in one line
        /// </summary>
        /// <param name="clause1"></param>
        /// <param name="clause2"></param>
        /// <returns></returns>
        public static SqlClause operator -(SqlClause clause1, SqlClause clause2)
        {
            var clause = new SqlClause();

            clause.script
                .Append(clause1)
                .Append(" ")
                .Append(clause2);
            return clause;
        }

        

        public void AddParameterValue(string name, object value)
        { 
        }

        public string Clause
        {
            get 
            { 
                return script.ToString(); 
            }
        }
   

        public override string ToString()
        {
            return script.ToString();
        }


        public int ExecuteNonQuery()
        {
            SqlCmd cmd = new SqlCmd(this);
            return cmd.ExecuteNonQuery();
        }

        public object ExecuteScalar()
        {
            SqlCmd cmd = new SqlCmd(this);
            return cmd.ExecuteScalar();
        }

    }


  
}
