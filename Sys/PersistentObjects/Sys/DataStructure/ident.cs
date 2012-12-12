using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    public sealed class ident : IComparable, IComparable<string>, IEquatable<ident>
    {
        private string id;

        public ident(string id)
        {
            this.id = id;

            if (!Validate())
                throw new JException("Invalid ident: {0}", id);
        }


        /// <summary>
        /// valid ident:
        ///     "[Last Name#]"
        ///     "@LastName"
        ///     "_LastName"
        ///     "LastName2"
        /// </summary>
        /// <returns></returns>
        private bool Validate()
        {
            if (id[0] == '[' && id[id.Length - 1] == ']')
                return true;

            int i = 0;
            char ch = id[i++];

            if (!char.IsLetter(ch) && ch != '_' && ch != '@')
                return false;

            while (i < id.Length) 
            {
                ch = id[i++];

                if (ch != '_' && !char.IsLetterOrDigit(ch))
                    return false;
            } 

            return true;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return id.Equals(((ident)obj).id);
        }

        public bool Equals(ident obj)
        {
            return id.Equals(obj.id);
        }

        public override string ToString()
        {
            return this.id;
        }


        public static explicit operator string(ident ident)
        {
            return ident.id; 
        }

        public int CompareTo(object obj)
        {
            return this.id.CompareTo(obj);
        }

        public int CompareTo(string other)
        {
            return this.id.CompareTo(other);
        }

        internal static string Identifier(string s)
        {
            return s.Replace("-", "_").Replace(" ", "_").Replace("$", "_").Replace(".", "_");
        }
    }
}
