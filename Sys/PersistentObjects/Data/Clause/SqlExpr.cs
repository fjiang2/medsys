using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    public sealed class SqlExpr : SqlClauseInfo
    {
        private StringBuilder script = new StringBuilder();

        private SqlExpr()
        {
        }

      

        private SqlExpr NextValue(object value)
        {
            script.Append(new SqlValue(value).Text);
            return this;
        }

        private SqlExpr Next(object x)
        {
            script.Append(x);
            return this;
        }

        internal static SqlExpr AddColumn(string name)
        {
            SqlExpr exp = new SqlExpr().Next("[" + name + "]");
            exp.Columns.Add(name);
            return exp;
        }

        internal static SqlExpr AddParameter(string name)
        {
            SqlExpr exp = new SqlExpr().Next("@" + name.SqlParameterName());
            exp.Parameters.Add(name);
            return exp;
        }


#if USE
        public static explicit operator string(SqlExpr x)
        {
            return x.ToString();
        }

        public static explicit operator bool(SqlExpr x)
        {
            return x.expr == "1";
        }

        public static explicit operator char(SqlExpr x)
        {
            return x.ToString()[0];
        }

        public static explicit operator byte(SqlExpr x)
        {
            return Convert.ToByte(x.expr);
        }

        public static explicit operator sbyte(SqlExpr x)
        {
            return Convert.ToSByte(x.expr);
        }

        public static explicit operator short(SqlExpr x)
        {
            return Convert.ToInt16(x.expr);
        }

        public static explicit operator ushort(SqlExpr x)
        {
            return Convert.ToUInt16(x.expr);
        }

        public static explicit operator uint(SqlExpr x)
        {
            return Convert.ToUInt32(x.expr);
        }
        public static explicit operator long(SqlExpr x)
        {
            return Convert.ToInt64(x.expr);
        }

        public static explicit operator ulong(SqlExpr x)
        {
            return Convert.ToUInt64(x.expr);
        }

        public static explicit operator float(SqlExpr x)
        {
            return Convert.ToSingle(x.expr);
        }

        public static explicit operator DateTime(SqlExpr x)
        {
            return Convert.ToDateTime(x.expr);
        }

        public static explicit operator DBNull(SqlExpr x)
        {
            if (script.ToString() == "NULL")
                return System.DBNull.Value;
            else
                throw new SysException("cannot cast value {0} to System.DBNull", x);
        }

#endif

        #region implicit section
        public static implicit operator SqlExpr(ident ident)
        {
            return new SqlExpr().Next(ident);
        }


        public static implicit operator SqlExpr(string value)
        {
            return new SqlExpr().NextValue(value);    // s= 'string'
        }

        public static implicit operator SqlExpr(bool value)
        {
            return new SqlExpr().NextValue(value);    // b=1 or b=0
        }


        public static implicit operator SqlExpr(char value)
        {
            return new SqlExpr().NextValue(value);    // ch= 'c'
        }

        public static implicit operator SqlExpr(byte value)
        {
            return new SqlExpr().NextValue(value);
        }

        public static implicit operator SqlExpr(sbyte value)
        {
            return new SqlExpr().NextValue(value);
        }


        public static implicit operator SqlExpr(int value)
        {
            return new SqlExpr().NextValue(value);
        }

        public static implicit operator SqlExpr(short value)
        {
            return new SqlExpr().NextValue(value);
        }

        public static implicit operator SqlExpr(ushort value)
        {
            return new SqlExpr().NextValue(value);
        }

        public static implicit operator SqlExpr(uint value)
        {
            return new SqlExpr().NextValue(value);
        }

        public static implicit operator SqlExpr(long value)
        {
            return new SqlExpr().NextValue(value);
        }

        public static implicit operator SqlExpr(ulong value)
        {
            return new SqlExpr().NextValue(value);
        }

        public static implicit operator SqlExpr(float value)
        {
            return new SqlExpr().NextValue(value);
        }

        public static implicit operator SqlExpr(DateTime value)
        {
            return new SqlExpr().NextValue(value);    //dt = '10/20/2012'
        }

        public static implicit operator SqlExpr(DBNull value)
        {
            return new SqlExpr().NextValue(value);    // NULL
        }

        public static implicit operator SqlExpr(Enum value)
        {
            return new SqlExpr().NextValue(Convert.ToInt32(value));    // NULL
        }

        #endregion


        /// <summary>
        /// string s = (string)expr;
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static explicit operator string(SqlExpr expr)
        {
            return expr.ToString();
        }

        public SqlExpr AS(SqlExpr alias)
        {
            this.Next(" AS ").Next(alias);
            return this;
        }
        
        
        public SqlExpr this[SqlExpr exp]
        {
            get
            {
                this.Next("[").Next(exp).Next("]");
                return this;
            }
        }


        public SqlExpr IN(SqlClause select)
        {
            this
                    .Next(" IN (")
                    .Next(select.Clause)
                    .Next(")");

            this.Merge(select);
            return this;
        }

        public SqlExpr IN(params SqlExpr[] collection)
        {
            return IN(collection);
        }

        public SqlExpr NOT
        {
            get
            {
                this.Next(" NOT");
                return this;
            }
        }

        public SqlExpr IN(IEnumerable collection)
        {
            this.Next(" IN (")
                .Next(string.Join(",", collection))
                .Next(")");

            return this;
        }



        public SqlExpr BETWEEN(SqlExpr exp1, SqlExpr exp2)
        {
            this.Next(" BETWEEN ")
                .Next(exp1)
                .Next(" AND ")
                .Next(exp2);

            return this;
        }

        #region +-*/, compare, logical operation

        private static SqlExpr OPR(SqlExpr exp1, string opr, SqlExpr exp2)
        {
            SqlExpr exp = new SqlExpr()
                .Next(string.Format("({0}) {1} ({2})", exp1, opr, exp2));

            exp.Merge(exp1).Merge(exp2);

            return exp;
        }

        private static SqlExpr OPR(string opr, SqlExpr exp1)
        {
            SqlExpr exp = new SqlExpr()
                .Next(string.Format("{0} ({1})", opr, exp1));

            exp.Merge(exp1);
            return exp;
        }

        public static SqlExpr operator +(SqlExpr exp1, SqlExpr exp2)
         {
             return OPR(exp1, "+", exp2);
         }

        public static SqlExpr operator -(SqlExpr exp1, SqlExpr exp2)
         {
             return OPR(exp1, "-", exp2);
         }

        public static SqlExpr operator *(SqlExpr exp1, SqlExpr exp2)
         {
             return OPR(exp1, "*", exp2);
         }

        public static SqlExpr operator /(SqlExpr exp1, SqlExpr exp2)
         {
             return OPR(exp1, "/", exp2);
         }


        public static SqlExpr operator ==(SqlExpr exp1, SqlExpr exp2)
        {
            if ((object)exp2 == null || exp2.ToString() == "NULL")
            {
                SqlExpr exp = new SqlExpr().Next(exp1).Next(" IS NULL");
                exp.Merge(exp1);
                return exp;
            }

            return OPR(exp1, "=", exp2);
        }


        public static SqlExpr operator !=(SqlExpr exp1, SqlExpr exp2)
        {
            if ((object)exp2 == null || exp2.ToString() == "NULL")
            {
                SqlExpr exp = new SqlExpr().Next(exp1).Next(" IS NOT NULL");
                exp.Merge(exp1);
                return exp;
            }

            return OPR(exp1, "<>", exp2);
        }

        public static SqlExpr operator >(SqlExpr exp1, SqlExpr exp2)
        {
            return OPR(exp1, ">", exp2);
        }

        public static SqlExpr operator <(SqlExpr exp1, SqlExpr exp2)
        {
            return OPR(exp1, "<", exp2);
        }

        public static SqlExpr operator >=(SqlExpr exp1, SqlExpr exp2)
        {
            return OPR(exp1, ">=", exp2);
        }

        public static SqlExpr operator <=(SqlExpr exp1, SqlExpr exp2)
        {
            return OPR(exp1, "<=", exp2);
        }


        public static SqlExpr operator &(SqlExpr exp1, SqlExpr exp2)
        {
            return OPR(exp1, "AND", exp2);
        }

        public static SqlExpr operator |(SqlExpr exp1, SqlExpr exp2)
        {
            return OPR(exp1, "OR", exp2);
        }

        public static SqlExpr operator ~(SqlExpr exp)
        {
            return OPR("NOT", exp);
        }
        
        #endregion


        #region SQL Function

        private static SqlExpr Func(string func, SqlExpr exp1)
        {
            SqlExpr exp = new SqlExpr()
                .Next(func)
                .Next("(")
                .Next(exp1)
                .Next(")");

            exp.Merge(exp1);
            return exp;
        }


        public static SqlExpr SUM(SqlExpr x)
        {
            return Func("SUM", x);
        }

        public static SqlExpr MAX(SqlExpr x)
        {
            return Func("MAX", x);
        }

        public static SqlExpr MIN(SqlExpr x)
        {
            return Func("MIN", x);
        }

        public static SqlExpr COUNT(SqlExpr x)
        {
            return Func("COUNT", x);
        }

        public static SqlExpr ISNULL(SqlExpr x)
        {
            return Func("ISNULL", x);
        }

        public static SqlExpr GETDATE(SqlExpr x)
        {
            return new SqlExpr().Next("GETDATE()");
        }

        #endregion


        public override bool Equals(object obj)
        {
            return script.Equals(((SqlExpr)obj).script);
        }

        public override int GetHashCode()
        {
            return script.GetHashCode();
        }

        public override string ToString()
        {
            return script.ToString();
        }
    }
}
