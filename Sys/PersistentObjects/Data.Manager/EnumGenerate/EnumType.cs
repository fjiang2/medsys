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
    
    /// <summary>
    /// represents Enum Type generated from database
    /// </summary>
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
        /// Used to build new EnumType
        /// </summary>
        /// <param name="name"></param>
        public EnumType(string name)
        {
            this.name = name;
            this.fields = new List<EnumField>();
        }

        /// <summary>
        /// Retrieve Field Attributes by reflection
        /// </summary>
        /// <param name="type"></param>
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

        /// <summary>
        /// Validate all fields, field not defined, duplicated field, duplicated value
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public bool Validate(MessageBuilder builder)
        {
            DPList<EnumField> list = new DPList<EnumField>(this.fields);

            bool good = true;
            foreach (EnumField field in list)
            {
                if (!field.Validate(builder))
                    good = false;
            }

            if (list.Count == 0)
            {
                builder.Add(Message.Error("Enum fields not defined."));
                good = false;
            }

            if (list.ToArray<string>(EnumField._Feature).Distinct().Count() != list.Count)
            {
                builder.Add(Message.Error("Duplicated field names found."));
                good = false;
            }

            if (list.ToArray<int>(EnumField._Value).Distinct().Count() != list.Count)
            {
                builder.Add(Message.Error("Duplicated values found."));
                good = false;
            }

            return good;
        }


        /// <summary>
        /// Save DataEnum into database
        /// </summary>
        public void Save()
        {
            foreach (EnumField field in this.fields)
                field.Save();
        }

        /// <summary>
        /// return name of date enum
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// return all fields of enum type
        /// </summary>
        public List<EnumField> Fields
        {
            get { return this.fields; }
        }


        /// <summary>
        /// returns DataEnum class name 
        /// </summary>
        public string ClassName
        {
            get
            {
                if (!name.ToLower().EndsWith("enum"))
                    return name + Setting.ENUM_SUFFIX_STRUCT_NAME;
                else
                    return name;
            }
        }


        /// <summary>
        /// generate DataEnum C# code in namespace defined
        /// </summary>
        /// <param name="nameSpace"></param>
        /// <returns></returns>
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

            return string.Format(format, 
                nameSpace, 
                new DataEnumAttribute(), 
                ClassName, 
                string.Join(",\r\n\r\n", fields.Select(field => field.ToCode()))
                );
        }


        /// <summary>
        /// generate DataEnum C# code in local drive
        /// </summary>
        /// <param name="path"></param>
        /// <param name="nameSpace"></param>
        public void GenerateCode(string path, string nameSpace)
        {
            string sourceCode = this.ToCode(nameSpace);
                string fileName = string.Format("{0}\\{1}.cs", path, this.ClassName);
                SysExtension.WriteFile(fileName, sourceCode);
        }


        /// <summary>
        /// returns name of DataEnum 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name;
        }
    }
}
