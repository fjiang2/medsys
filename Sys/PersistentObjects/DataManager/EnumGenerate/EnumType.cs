using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data;

namespace Sys.DataManager
{
    public class EnumType
    {
        List<EnumTypeDpo> fields;
        string name;

        /// <summary>
        /// Used for reading from database
        /// </summary>
        /// <param name="fields"></param>
        public EnumType(List<EnumTypeDpo> fields)
        {
            this.fields = fields;
            this.name = fields.FirstOrDefault().Category;
        }

        /// <summary>
        /// Used for creating new EnumType
        /// </summary>
        /// <param name="name"></param>
        public EnumType(string name)
        {
            this.fields = new List<EnumTypeDpo>();
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

        public List<EnumTypeDpo> Fields
        {
            get { return this.fields; }
        }


        public string ToCode()
        {
            string format =@"
using System;
using Sys.Data;

namespace App.Data
{{
    {0}
    public enum {1}
    {{
{2}
    }}
}}
";
            return string.Format(format, new EnumTypeAttribute(name), name, string.Join(",\r\n", fields.Select(field=>field.ToCode())));
        }

        public override string ToString()
        {
            return name;
        }
    }
}
