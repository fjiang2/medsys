using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Import
{
    public class MemberParametersAttribute : Attribute 
    {
        public readonly string[] parameters;

        public MemberParametersAttribute(params string[] parameters)
        {
            this.parameters = parameters;
        }
    }
}
