using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Builder
{
    class Constructor
    {
        private string signature;

        List<string> statements = new List<string>();

        
        //public Constructor(...)
        public Constructor(string constructorName)
            : this(ModifierType.Public, constructorName, new Argument[] { })
        {
        }

        //public Constructor(...)
        public Constructor(ModifierType modifier, string constructorName)
            : this(modifier, constructorName, new Argument[] { })
        {
        }


        //protected Constructor(...)
        public Constructor(ModifierType modifier, string constructorName, Argument[] args)
        {
            this.signature = string.Format("{0}{1}({2})",
                new Modifier(modifier),
                constructorName,
                string.Join(", ", args.Select(arg => arg.ToString()))
                );
        }

        public Constructor AddStatements(string format, params object[] args)
        {
            statements.Add(string.Format(format, args));
            return this;
        }

        public Constructor AddStatements()
        {
            statements.Add("");
            return this;
        }

        public Constructor AddField(Field field)
        {
            statements.Add(field.ToString());
            return this;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            s.Append("\t\t").Append(this.signature).AppendLine()
                .AppendLine("\t\t{");

            foreach (string sent in statements)
            {
                if (sent == "")
                    s.AppendLine();
                else
                    s.Append("\t\t\t").Append(sent).AppendLine(";");
            }

            s.AppendLine("\t\t}");

            return s.ToString();
        }
        

    }
}
