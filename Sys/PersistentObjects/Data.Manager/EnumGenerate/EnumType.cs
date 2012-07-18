using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data;
using System.Reflection;
using Sys;

namespace Sys.Data.Manager
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

                FieldAttribute[] attributes = (FieldAttribute[])fieldInfo.GetCustomAttributes(typeof(FieldAttribute), false);
                if (attributes.Length > 0)
                {
                    field.Label = attributes[0].Caption;
                }
                
                this.fields.Add(field);
            }
        }

        public bool Validate(MessageManager manager)
        {
            DPList<EnumField> list = new DPList<EnumField>(this.fields);

            bool good = true;
            foreach (EnumField field in list)
            {
                if (!field.Validate(manager))
                    good = false;
            }

            if (list.Count == 0)
            {
                manager.Add(Message.Error("Enum fields not defined."));
                good = false;
            }

            if (list.ToArray<string>(EnumField._Feature).Distinct().Count() != list.Count)
            {
                manager.Add(Message.Error("Duplicated field names found."));
                good = false;
            }

            if (list.ToArray<int>(EnumField._Value).Distinct().Count() != list.Count)
            {
                manager.Add(Message.Error("Duplicated values found."));
                good = false;
            }

            return good;
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


        public string ToCode(string nameSpace)
        {
            string format = 
@"using System;
using Sys.Data;

namespace {0}
{{
    {1}
    public enum {2}
    {{
{3}
    }}
}}
";
            return string.Format(format, nameSpace, new DataEnumAttribute(), name, string.Join(",\r\n\r\n", fields.Select(field=>field.ToCode())));
        }

        public override string ToString()
        {
            return name;
        }
    }
}
