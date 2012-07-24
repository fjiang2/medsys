using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    /// <summary>
    /// SQL clauses builder
    /// </summary>
    public class SqlClause : ISqlScript
    {
        private StringBuilder script = new StringBuilder();

        public SqlClause()
        { 
        }

        //public static implicit operator SqlClause(string sql)
        //{
        //    return new SqlClause(sql);
        //}

        public static explicit operator string(SqlClause sql)
        {
            return sql.Script;
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


        public SqlClause COLUMNS(params string[] columns)
        {
            if (columns.Length == 0)
                script.Append(" * ");
            else
                script.Append(ConcatColumns(columns));

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

        public SqlClause FROM(string from)
        {
            return FROM(from, null);
        }

        public SqlClause FROM(DPObject dpo)
        {
            return FROM(dpo.TableName);
        }

        public SqlClause FROM(TableName tableName)
        {
            return FROM(tableName.FullName, null);
        }

        public SqlClause FROM(string from, string alias)
        {
            script.Append(" FROM ").Append(from);
            if (alias != null)
                script.Append(" ").Append(alias);

            return this;
        }

        #endregion


        public SqlClause UPDATE(string tableName)
        {
           script.Append("UPDATE ").Append(tableName);

            return this;
        }


        public SqlClause SET(params string[] assignments)
        {
            script.Append("SET ").Append(string.Join(",",assignments));

            return this.CRLF;
        }

        public SqlClause SET(string[] columns, string[] values)
        {
            string[] namesAndValues = new string[columns.Length];
            for (int i = 0; i < columns.Length; i++)
            {
                namesAndValues[i] = string.Format("[{0}]={1}", columns[i], new SqlValue(values[i]));
            }

            string s = string.Join(", ", namesAndValues);
            script.Append(s);

            return this.CRLF;
        }

     
        public SqlClause INSERT(string tableName, params string[] columns)
        {
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

        public SqlClause DELETE(string tableName)
        {
            script.Append("DELETE FROM ").Append(tableName);

            return this;
        }



        #region WHERE clause

        public SqlClause WHERE(SqlExpr exp)
        {
            script.Append(" WHERE ").Append(exp);
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

        public SqlClause JOIN(string tableName)
        {
            return JOIN(tableName, null);
        }

        public SqlClause JOIN(DPObject dpo)
        {
            return JOIN(dpo.TableName, null);
        }

        public SqlClause JOIN(DPObject dpo, string alias)
        {
            return JOIN(dpo.TableName, alias);
        }

        private SqlClause JOIN(TableName tableName, string alias)
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


        public SqlClause Append(object any)
        {
            script.Append(any);
            return this;
        }

        public string Script
        {
            get { return script.ToString(); }
        }
   

        public override string ToString()
        {
            return script.ToString();
        }
    }


  
}
