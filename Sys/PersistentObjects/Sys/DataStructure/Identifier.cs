using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    public class Identifier : IComparable,IComparable<string>
    {
        private string id;

        public Identifier(string id)
        {
            this.id = id;

            if (!Validate())
                throw new SysException("Invalid Identifier: {0}", id);
        }

        private bool Validate()
        {
            int i = 0;
            char ch = id[i++];

            if (!char.IsLetter(ch) && ch != '_')
                return false;

            while (i < id.Length) 
            {
                ch = id[i++];

                if (!char.IsLetterOrDigit(ch))
                    return false;
            } 

            return true;
        }

        public override string ToString()
        {
            return this.id;
        }


        public static implicit operator Identifier(string ident)
        {
            return new Identifier(ident); 
        }

        public int CompareTo(object obj)
        {
            return this.id.CompareTo(obj);
        }

        public int CompareTo(string other)
        {
            return this.id.CompareTo(other);
        }

    }
}
