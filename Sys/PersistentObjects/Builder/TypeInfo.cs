using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Builder
{
    class TypeInfo
    {
        Type type;

        public TypeInfo(Type type)
        {
            this.type = type;
        }

        public string NewInstance(params Argument[] args)
        {
            return string.Format("new {0}({1})", 
                this.Text, 
                string.Join(
                    ",", 
                    args.Select(arg => arg.ToString())
                    )
                );
        }

        public string Text
        {
            get
            {
                string ty = type.Name;
                if (type.IsGenericType)
                {
                    ty = type.Name.Substring(0, ty.IndexOf("`"));
                    ty = string.Format("{0}<{1}>", ty, string.Join(",", type.GetGenericArguments().Select(T => T.Name)));
                }

                return ty;
            }
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
