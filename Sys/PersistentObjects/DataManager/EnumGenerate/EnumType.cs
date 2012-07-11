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
        IEnumerable<EnumTypeDpo> fields;
        string name;

        public EnumType(IEnumerable<EnumTypeDpo> fields)
        {
            this.fields = fields;
            this.name = fields.FirstOrDefault().Category;
        }

        public string Name
        {
            get { return this.name; }
        }

        public IEnumerable<EnumTypeDpo> Fields
        {
            get { return this.fields; }
        }


        public string ToCode()
        {
            string format =@"
using System;
using Sys.Data;

namespace App.Data
{
    {0}
    public enum {1}
    {
{2}
    }
}
";
            return string.Format(format, new EnumTypeAttribute(name), name, string.Join(",\r\n", fields.Select(field=>field.ToCode())));
        }

        public override string ToString()
        {
            return name;
        }
    }
}
