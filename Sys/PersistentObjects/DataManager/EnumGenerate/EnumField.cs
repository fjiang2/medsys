﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.PersistentObjects.Dpo;
using Sys.Data;

namespace Sys.DataManager
{
    public class EnumField : dictEnumTypeDpo
    {
        public EnumField()
        { 
        }

        public EnumField(DataRow row)
            : base(row)
        { 
        }

        public EnumField(string category, string feature)
            :base(category, feature)
        {
        }

        private static string Identifier(string s)
        {
            s = s.Trim();
            if (!char.IsLetter(s[0]))
                s += "_" + s;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
                if (char.IsLetterOrDigit(s[i]))
                    sb.Append(s[i]);
            
            return sb.ToString();
        }

        public string Caption
        {
            get
            {
                if (this.Label == null)
                    return this.Feature;
                else
                    return this.Label;
            }
        }

        public string ToCode()
        {
            return string.Format("\t\t{0}\t{1} = {2}", new EnumFieldAttribute(this.Caption), Identifier(this.Feature), this.Value);
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}={2}", this.Category, Identifier(this.Feature), this.Value);
        }
    }
}