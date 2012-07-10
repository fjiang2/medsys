using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X12
{
    public class X12Exception : Exception
    {
        public X12Exception(string format, params object[] args)
            : base(string.Format(format, args))
        { 
        
        }
    }
}
