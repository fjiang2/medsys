using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Builder
{
    class Field
    {
        string fieldSignature;

        public Field(Type type, string fieldName)
            : this(ModifierType.Private, type, fieldName)
        {
        }


        public Field(ModifierType modifier, Type type, string fieldName)
        {
            this.fieldSignature = string.Format("{0}{1} {2};",
                new Modifier(modifier),
                new TypeInfo(type),
                fieldName);
        }


        public Field(ModifierType modifier, Type type, string fieldName, object value)
        {
            this.fieldSignature = string.Format("{0}{1} {2} = {3};",
                new Modifier(modifier),
                new TypeInfo(type),
                fieldName, 
                value);
        }


        public string Text
        {
            get { return this.fieldSignature; }
        }

        public override string ToString()
        {
            return this.fieldSignature;
        }
    }
}
