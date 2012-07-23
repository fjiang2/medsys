using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    /// <summary>
    /// SQL statement builder
    /// </summary>
    public class SqlBuilder : ISqlScript
    {
        private StringBuilder script = new StringBuilder();

        public SqlBuilder()
        { 
        }

        //public static implicit operator SqlBuilder(string sql)
        //{
        //    return new SqlBuilder(sql);
        //}

        //public static explicit operator string(SqlBuilder sql)
        //{
        //    return sql.Script;
        //}


        #region SELECT clause

        public SqlBuilder SELECT
        {
            get
            {
                script.Append("SELECT");
                return this;
            }
        }

        public SqlBuilder DISTINCT
        {
            get
            {
                script.Append(" DISTINCT ");
                return this;
            }
        }

        public SqlBuilder ALL
        {
            get
            {
                script.Append(" ALL ");
                return this;
            }
        }


        public SqlBuilder TOP(int n)
        {
            script.Append(" TOP ").Append(n);
            return this;
        }


        public SqlBuilder COLUMNS(params string[] columns)
        {
            if (columns.Length == 0)
                script.Append(" * ");
            else
                script.Append(ConcatColumns(columns));

            return this;
        }


        public SqlBuilder INTO(string tableName)
        {
            script
                .Append(" INTO ")
                .Append(tableName);

            return this;
        }

        public SqlBuilder INTO(TableName tableName)
        {
            script
                .Append(" INTO ")
                .Append(tableName.FullName);

            return this;
        }

        #endregion


        #region FROM clause

        public SqlBuilder FROM(string from)
        {
            return FROM(from, null);
        }

        public SqlBuilder FROM(DPObject dpo)
        {
            return FROM(dpo.TableName);
        }

        public SqlBuilder FROM(TableName tableName)
        {
            return FROM(tableName.FullName, null);
        }

        public SqlBuilder FROM(string from, string alias)
        {
            script.Append(" FROM ").Append(from);
            if (alias != null)
                script.Append(" ").Append(alias);

            return this;
        }

        #endregion


        public SqlBuilder UPDATE(string tableName)
        {
           script.Append("UPDATE ").Append(tableName);

            return this;
        }


        public SqlBuilder SET(params string[] assignments)
        {
            script.Append("SET ").Append(string.Join(",",assignments));

            return this.CRLF;
        }

        public SqlBuilder SET(string[] columns, string[] values)
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

        public SqlBuilder SET(ColumnValue[] assignments)
        {
            script.Append(string.Join<ColumnValue>(", ", assignments));

            return this.CRLF;
        }


   
        public SqlBuilder INSERT(string tableName, params string[] columns)
        {
            script
                .Append("INSERT INTO")
                .Append(tableName);
            
            if(columns.Length >0)
                script.Append("(").Append(ConcatColumns(columns)).Append(")");

            return this;
        }


        public SqlBuilder VALUES(params object[] values)
        {
            script
                .Append("VALUES ")
                .Append("(").Append(ConcatValues(values)).Append(")");

            return this.CRLF;
        }

        public SqlBuilder DELETE(string tableName)
        {
            script.Append("DELETE FROM ").Append(tableName);

            return this;
        }



        #region WHERE clause

        public SqlBuilder WHERE(SqlExpr exp)
        {
            script.Append(" WHERE ").Append(exp);
            return this.CRLF;
        }

        #endregion


        #region INNER/OUT JOIN clause

        public SqlBuilder LEFT
        {
            get
            {
                script.Append(" LEFT");
                return this;
            }
        }

        public SqlBuilder RIGHT
        {
            get
            {
                script.Append(" RIGHT");
                return this;
            }
        }

        public SqlBuilder INNER
        {
            get
            {
                script.Append(" INNER");
                return this;
            }
        }

        public SqlBuilder OUTTER
        {
            get
            {
                script.Append(" OUTTER");
                return this;
            }
        }

        public SqlBuilder JOIN(string tableName)
        {
            return JOIN(tableName, null);
        }

        public SqlBuilder JOIN(DPObject dpo)
        {
            return JOIN(dpo.TableName, null);
        }

        public SqlBuilder JOIN(DPObject dpo, string alias)
        {
            return JOIN(dpo.TableName, alias);
        }

        private SqlBuilder JOIN(TableName tableName, string alias)
        {
            return JOIN(tableName.FullName, alias);
        }
        
        private SqlBuilder JOIN(string tableName, string alias)
        {
            script
                .Append(" JOIN ")
                .Append(tableName);

            if (alias != null)
                script.Append(" ").Append(alias);
                
            return this;
        }

        public SqlBuilder ON(SqlExpr exp)
        {
            script.Append(" ON ").Append(exp);
            return this;
        }

        #endregion



        #region GROUP BY / HAVING clause
        public SqlBuilder GROUP_BY(params string[] columns)
        {
            script.Append(" GROUP BY ").Append(ConcatColumns(columns));
            return this;
        }

        public SqlBuilder HAVING(params string[] columns)
        {
            script.Append(" HAVING ").Append(ConcatColumns(columns));
            return this;
        }
        
        #endregion



        public SqlBuilder ORDER_BY(params string[] columns)
        {
            script.Append(" ORDER BY ").Append(ConcatColumns(columns));
            return this;
        }


        public SqlBuilder UNION
        {
            get
            {
                script.Append(" UNION ");
                return this;
            }
        }


        public SqlBuilder DESC
        {
            get
            {
                script.Append(" DESC");
                return this;
            }
        }




        private int tab = 0;
        public SqlBuilder TAB(int n)
        {
            tab += n;
            for (int i = 0; i < tab; i++)
                script.Append("\t");

            return this;
        }


        public SqlBuilder CRLF
        {
            get
            {
                script.AppendLine();
                return this;
            }
        }

        public SqlBuilder PAR(string exp)
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


        public SqlBuilder Append(object any)
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
