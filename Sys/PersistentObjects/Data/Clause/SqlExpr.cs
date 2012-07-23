using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    public sealed class SqlExpr
    {
        private StringBuilder script = new StringBuilder();

        private SqlExpr()
        {
        }


        private SqlExpr(object obj)
        {
            script.Append(obj);
        }


        private SqlExpr AppendValue(object value)
        {
            script.Append(new SqlValue(value).Text);
            return this;
        }

        private SqlExpr Append(object x)
        {
            script.Append(x);
            return this;
        }

        private string expr
        {
            get
            {
                return this.ToString();
            }
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
       // ----------------------------------------------


        public static implicit operator SqlExpr(ident ident)
        {
            return new SqlExpr().Append(ident);    // s= ident
        }

        public static implicit operator SqlExpr(string value)
        {
            return new SqlExpr().AppendValue(value);    // s= 'string'
        }

        public static implicit operator SqlExpr(bool value)
        {
            return new SqlExpr().AppendValue(value);    // b=1 or b=0
        }


        public static implicit operator SqlExpr(char value)
        {
            return new SqlExpr().AppendValue(value);    // ch= 'c'
        }

        public static implicit operator SqlExpr(byte value)
        {
            return new SqlExpr(value);
        }

        public static implicit operator SqlExpr(sbyte value)
        {
            return new SqlExpr(value);
        }


        public static implicit operator SqlExpr(int value)
        {
            return new SqlExpr(value);
        }

        public static implicit operator SqlExpr(short value)
        {
            return new SqlExpr(value);
        }

        public static implicit operator SqlExpr(ushort value)
        {
            return new SqlExpr(value);
        }

        public static implicit operator SqlExpr(uint value)
        {
            return new SqlExpr(value);
        }

        public static implicit operator SqlExpr(long value)
        {
            return new SqlExpr(value);
        }

        public static implicit operator SqlExpr(ulong value)
        {
            return new SqlExpr(value);
        }

        public static implicit operator SqlExpr(float value)
        {
            return new SqlExpr(value);
        }



        public static implicit operator SqlExpr(DateTime value)
        {
            return new SqlExpr().AppendValue(value);    //dt = '10/20/2012'
        }

        public static implicit operator SqlExpr(DBNull value)
        {
            return new SqlExpr().AppendValue(value);    // NULL
        }


        /// <summary>
        /// string s = (string)expr;
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static explicit operator string(SqlExpr expr)
        {
            return expr.ToString();
        }

        public SqlExpr AS(string alias)
        {
            script.Append(" AS ").Append(alias);
            return this;
        }
        
        
        public SqlExpr this[SqlExpr obj]
        {
            get
            {
                script.Append("[").Append(obj).Append("]");
                return this;
            }
        }


        public SqlExpr IN(SqlExpr exp, SqlBuilder select)
        {
            script
                    .Append(exp)
                    .Append(" IN (")
                    .Append(select.Script)
                    .Append(" )");

            return this;
        }

        public SqlExpr IN(SqlExpr exp, params SqlExpr[] expr)
        {
            script
                .Append(exp)
                .Append(" IN ");
            if (expr.Length == 0)
                return this;

            script
                .Append("(")
                .Append(string.Join<SqlExpr>(",", expr))
                .Append(")");

            return this;
        }



        public SqlExpr BETWEEN(SqlExpr exp, SqlExpr exp1, SqlExpr exp2)
        {
            script
                .Append(exp)
                .Append(" BETWEEN ")
                .Append(exp1)
                .Append(" AND ")
                .Append(exp2);

            return this;
        }

        #region +-*/, compare, logical operation

        private static SqlExpr OPR(SqlExpr s1, string opr, SqlExpr s2)
        {
            SqlExpr exp = new SqlExpr()
                .Append(string.Format("({0}) {1} ({2})", s1, opr, s2));
            
            return exp;
        }

        private static SqlExpr OPR(string opr, SqlExpr s)
        {
            SqlExpr exp = new SqlExpr()
                .Append(string.Format("{0} ({1})", opr, s));
            
            return exp;
        }

        public static SqlExpr operator +(SqlExpr s1, SqlExpr s2)
         {
             return OPR(s1, "+", s2);
         }

        public static SqlExpr operator -(SqlExpr s1, SqlExpr s2)
         {
             return OPR(s1, "-", s2);
         }

        public static SqlExpr operator *(SqlExpr s1, SqlExpr s2)
         {
             return OPR(s1, "*", s2);
         }

        public static SqlExpr operator /(SqlExpr s1, SqlExpr s2)
         {
             return OPR(s1, "/", s2);
         }


        public static SqlExpr operator ==(SqlExpr s1, SqlExpr s2)
        {
            if ((object)s2 == null || s2.ToString() == "NULL")
            {
                return new SqlExpr(s1).Append(" IS NULL");
            }

            return OPR(s1, "=", s2);
        }


        public static SqlExpr operator !=(SqlExpr s1, SqlExpr s2)
        {
            if ((object)s2 == null || s2.ToString() == "NULL")
            {
                return new SqlExpr(s1).Append(" IS NOT NULL");
            }

            return OPR(s1, "<>", s2);
        }

        

        public static SqlExpr operator >(SqlExpr s1, SqlExpr s2)
        {
            return OPR(s1, ">", s2);
        }

        public static SqlExpr operator <(SqlExpr s1, SqlExpr s2)
        {
            return OPR(s1, "<", s2);
        }

        public static SqlExpr operator >=(SqlExpr s1, SqlExpr s2)
        {
            return OPR(s1, ">=", s2);
        }

        public static SqlExpr operator <=(SqlExpr s1, SqlExpr s2)
        {
            return OPR(s1, "<=", s2);
        }


        public static SqlExpr operator &(SqlExpr s1, SqlExpr s2)
        {
            return OPR(s1, "AND", s2);
        }

        public static SqlExpr operator |(SqlExpr s1, SqlExpr s2)
        {
            return OPR(s1, "OR", s2);
        }

        public static SqlExpr operator ~(SqlExpr s1)
        {
            return OPR("NOT", s1);
        }
        
        #endregion


        #region SQL Function

        private static SqlExpr Func(string func, SqlExpr x)
        {
            SqlExpr exp = new SqlExpr(func)
                .Append("(")
                .Append(x)
                .Append(")");
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
            return new SqlExpr("GETDATE()");
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
