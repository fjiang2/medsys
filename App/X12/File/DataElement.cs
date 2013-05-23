using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X12.File
{
    public class DataElement
    {
        int ordinal;
        object value;

        public DataElement(int ordinal)
            : this(ordinal, "")
        { 
        }

        public DataElement(int ordinal, object value)
        {
            this.ordinal = ordinal;
            this.value = value;
        }

        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public string Text
        {
            get 
            {
                if (this.value is string)
                    return (string)value; 

                return this.value.ToString(); 
            }
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
