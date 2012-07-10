using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X12.Specification
{
    class Rule
    {
        string code;
        string definition;

        public Rule(string code, string definition)
        {
            this.code = code;
            this.definition = definition;
        }

        public string Code
        {
            get { return this.code; }
        }

        //public bool Validate(DataElement2 element)
        //{
        //    return code == element.Value;
        //}

        public override string ToString()
        {
            return string.Format("{0}={1}", this.code, this.definition);
        }
    }
}
