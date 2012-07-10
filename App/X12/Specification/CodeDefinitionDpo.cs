using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys;

namespace X12.Specification
{
    public class CodeDefinitionDpo : Dpo.X12CodeDefinitionDpo
    {

        public CodeDefinitionDpo()
        { 
        
        }

        public CodeDefinitionDpo(DataRow dataRow)
            :base(dataRow)
        { 
        }

       
        public override string ToString()
        {
            return string.Format("{0} => {1}", Code, Definition);
        }
    }
}
