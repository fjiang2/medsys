using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Builder
{
    class Method : Format
    {
        private string signature;

        Statements statements = new Statements(2);

        
        //internal string Method(....)
        public Method(ModifierType modifier, Type returnType, string methodName)
            : this(modifier, returnType, methodName, new Argument[] { })
        {
        }

        //protected void Method(....)
        public Method(ModifierType modifier, Type returnType, string methodName, Argument[] args)
        {
            this.signature = string.Format("{0}{1} {2}({3})", 
                new Modifier(modifier), 
                returnType == null ? "void" : new TypeInfo(returnType).Text, 
                methodName,
                string.Join(", ", args.Select(arg=>arg.Text))
                );
        }

      
        public Method(ModifierType modifier, string methodName)
            : this(modifier, methodName, new Argument[] { })
        {
        }

        public Method(ModifierType modifier, string methodName,  Argument[] args)
        {
            this.signature = string.Format("{0}void {1}({2})",
                new Modifier(modifier), 
                methodName,
                string.Join(", ", args.Select(arg => arg.Text))
                );
        }

        public Method AddStatements(string format, params object[] args)
        {
            statements.Add(string.Format(format, args));
            return this;
        }

        public Method AddStatements()
        {
            statements.Add("");
            return this;
        }

        public Method AddField(Field field)
        {
            statements.Add(field.ToString());
            return this;
        }



        public string Text
        {
            get 
            {
                this.tab = 2;

                this.Add(this.signature);
                code.Append(statements.Code);

                return code.ToString();
            }
        }

        public override string ToString()
        {
            return Text;
        }
        

    }
}
