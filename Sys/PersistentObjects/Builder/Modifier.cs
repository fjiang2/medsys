using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Builder
{
    sealed class Modifier
    {
        public const string CRLF = "\r\n";

        ModifierType modifier;

        public Modifier(ModifierType modifier)
        {
            this.modifier = modifier;
        }

        public ModifierType ModifierType
        {
            get { return this.modifier; }
        }

        public string Text
        {
            get { return this.ToString(); }
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            if ((modifier & ModifierType.Public) == ModifierType.Public)
                s.Append("public ");
            else if ((modifier & ModifierType.Private) == ModifierType.Private)
                s.Append("private ");
            else if ((modifier & ModifierType.Internal) == ModifierType.Internal)
                s.Append("internal ");
            else if ((modifier & ModifierType.Protected) == ModifierType.Protected)
                s.Append("protected ");


            if ((modifier & ModifierType.Const) == ModifierType.Const)
                s.Append("const ");
            else if ((modifier & ModifierType.Static) == ModifierType.Static)
                s.Append("static ");
            else if ((modifier & ModifierType.Readonly) == ModifierType.Readonly)
                s.Append("readonly ");

            
            if ((modifier & ModifierType.Virtual) == ModifierType.Virtual)
                s.Append("virtual ");
            else if ((modifier & ModifierType.Override) == ModifierType.Override)
                s.Append("override ");

            if ((modifier & ModifierType.Abstract) == ModifierType.Abstract)
                s.Append("abstract ");
            else if ((modifier & ModifierType.Sealed) == ModifierType.Sealed)
                s.Append("sealed ");

            if ((modifier & ModifierType.Event) == ModifierType.Event)
                s.Append("event ");

            return s.ToString();
        }
    }
}
