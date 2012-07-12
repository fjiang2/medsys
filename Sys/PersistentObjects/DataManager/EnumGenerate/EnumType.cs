using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data;
using System.Reflection;

namespace Sys.DataManager
{
    public class EnumType
    {
        List<EnumField> fields;
        string name;

        /// <summary>
        /// Used for reading from database
        /// </summary>
        /// <param name="fields"></param>
        public EnumType(List<EnumField> fields)
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
            this.name = name;
            this.fields = new List<EnumField>();
        }

        public EnumType(Type type)
        {
            this.name = type.Name;
            this.fields = new List<EnumField>();
            foreach (FieldInfo fieldInfo in type.GetFields())
            {
                if (fieldInfo.Name == "value__")
                    continue;

                EnumField field = new EnumField();
                field.Category = this.name;
                field.Feature = fieldInfo.Name;
                field.Value = (int)fieldInfo.GetValue(null);

                EnumFieldAttribute[] attributes = (EnumFieldAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumFieldAttribute), false);
                if (attributes.Length > 0)
                {
                    field.Label = attributes[0].Caption;
                }
                
                this.fields.Add(field);
            }
        }

        public void Save()
        {
            foreach (EnumField field in this.fields)
                field.Save();
        }


        public string Name
        {
            get { return this.name; }
        }

        public List<EnumField> Fields
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
