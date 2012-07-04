using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Builder
{
    class Argument
    {
        Type type;
        string name;

        public Argument(Type type, string name)
        {
            this.type = type;
            this.name = name;
        }

        public Argument(string name)
        {
            this.type = null;
            this.name = name;
        }


        public string Text
        {
            get
            {
                if (type == null)
                    return name;

                return string.Format("{0} {1}", new TypeInfo(type).Text, name);
            }
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
