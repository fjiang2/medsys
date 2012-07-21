using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.CodeBuilder
{
    class Property :Format
    {
        private string signature;

        Statements gets = new Statements(3);
        Statements sets = new Statements(3);

        
        public Property(Type returnType, string methodName)
            : this(ModifierType.Public, returnType, methodName)
        {
        }

        public Property(ModifierType modifier, Type returnType, string propertyName)
        {
            this.signature = string.Format("{0}{1} {2}", 
                new Modifier(modifier), 
                new TypeInfo(returnType), 
                propertyName
                );
        }

        public Property AddGet(string format, params object[] args)
        {
            gets.Add(string.Format(format, args));
            return this;
        }

        public Property AddGet()
        {
            gets.Add("");

            return this;
        }


        public Property AddSet(string format, params object[] args)
        {
            sets.Add(string.Format(format, args));
            return this;
        }

        public Property AddSet()
        {
            sets.Add("");
            return this;
        }

        public Property AddGetField(Field field)
        {
            gets.Add(field.ToString());
            return this;
        }

        public Property AddSetField(Field field)
        {
            gets.Add(field.ToString());
            return this;
        }


        public override string ToString()
        {
            this.tab = 2;

            this.Add(this.signature);
            this.Add("{");
            
            this.tab++;
            if (gets.Count != 0)
            {
                this.Add("get");
                code.Append(gets.Code);
               
            }

            if (sets.Count != 0)
            {
                this.Add("set");
                code.Append(sets.Code);
            }
            
            this.tab--;
            this.Add("}");

            return code.ToString();
        }
        

    }
}
