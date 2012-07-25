using System;
using System.Collections;
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
            return new SqlExpr().Append(value);
        }

        public static implicit operator SqlExpr(sbyte value)
        {
            return new SqlExpr().Append(value);
        }


        public static implicit operator SqlExpr(int value)
        {
            return new SqlExpr().Append(value);
        }

        public static implicit operator SqlExpr(short value)
        {
            return new SqlExpr().Append(value);
        }

        public static implicit operator SqlExpr(ushort value)
        {
            return new SqlExpr().Append(value);
        }

        public static implicit operator SqlExpr(uint value)
        {
            return new SqlExpr().Append(value);
        }

        public static implicit operator SqlExpr(long value)
        {
            return new SqlExpr().Append(value);
        }

        public static implicit operator SqlExpr(ulong value)
        {
            return new SqlExpr().Append(value);
        }

        public static implicit operator SqlExpr(float value)
        {
            return new SqlExpr().Append(value);
        }

        public static implicit operator SqlExpr(DateTime value)
        {
            return new SqlExpr().AppendValue(value);    //dt = '10/20/2012'
        }

        public static implicit operator SqlExpr(DBNull value)
        {
            return new SqlExpr().AppendValue(value);    // NULL
        }

        public static implicit operator SqlExpr(Enum value)
        {
            return new SqlExpr().Append(Convert.ToInt32(value));    // NULL
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

        public SqlExpr AS(SqlExpr alias)
        {
            script.Append(" AS ").Append(alias);
            return this;
        }
        
        
        public SqlExpr this[SqlExpr exp]
        {
            get
            {
                script.Append("[").Append(exp).Append("]");
                return this;
            }
        }


        public SqlExpr IN(SqlClause select)
        {
            script
                    .Append(" IN (")
                    .Append(select.Clause)
                    .Append(")");

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
                script.Append(" NOT");
                return this;
            }
        }

        public SqlExpr IN(IEnumerable collection)
        {
            script
                .Append(" IN ");

            script
                .Append("(")
                .Append(string.Join(",", collection))
                .Append(")");

            return this;
        }



        public SqlExpr BETWEEN(SqlExpr exp1, SqlExpr exp2)
        {
            script
                .Append(" BETWEEN ")
                .Append(exp1)
                .Append(" AND ")
                .Append(exp2);

            return this;
        }

        #region +-*/, compare, logical operation

        private static SqlExpr OPR(SqlExpr exp1, string opr, SqlExpr exp2)
        {
            SqlExpr exp = new SqlExpr()
                .Append(string.Format("({0}) {1} ({2})", exp1, opr, exp2));
            
            return exp;
        }

        private static SqlExpr OPR(string opr, SqlExpr s)
        {
            SqlExpr exp = new SqlExpr()
                .Append(string.Format("{0} ({1})", opr, s));
            
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
                return new SqlExpr().Append(exp1).Append(" IS NULL");
            }

            return OPR(exp1, "=", exp2);
        }


        public static SqlExpr operator !=(SqlExpr exp1, SqlExpr exp2)
        {
            if ((object)exp2 == null || exp2.ToString() == "NULL")
            {
                return new SqlExpr().Append(exp1).Append(" IS NOT NULL");
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

        private static SqlExpr Func(string func, SqlExpr x)
        {
            SqlExpr exp = new SqlExpr()
                .Append(func)
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
            return new SqlExpr().Append("GETDATE()");
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
