using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using Sys.Data;
using System.Reflection;
using System.Linq;
using Tie;


namespace Sys.Data.Manager
{
    class FieldDefinition
    {
        public readonly string Name;
        public readonly string Type;

        public FieldDefinition(string type, string name)
        {
            this.Name = name;
            this.Type = type;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Type, Name);
        }
    }

    class DpoClass
    {
        private string nameSpace;
        private string className;

        private MetaTable metaTable;
        private List<string> nonvalized;
        private List<string> nullableFields;

        public Dictionary<string, FieldDefinition> dict_column_field = new Dictionary<string, FieldDefinition>();
        public bool HasColumnAttribute = true;
        
        Dictionary<TableName, Type> dict;

        public DpoClass(MetaTable metaTable, ClassName cname,  Dictionary<TableName, Type> dict)
        {
            this.metaTable = metaTable;
            
            this.nameSpace = cname.Namespace;
            this.className = cname.Class;

            this.dict = dict;

            nonvalized = NonvalizedList(nameSpace, className);
            nullableFields = NullableList(nameSpace, className);
        }


        public Dictionary<TableName, Type> Dict
        {
            get { return this.dict; }
        }
        
        public MetaTable MetaTable
        {
            get { return this.metaTable; }
        }

        public List<string> Nonvalized
        {
            get
            {
                return this.nonvalized;
            }
        }

        public List<string> NullableFields
        {
            get
            {
                return this.nullableFields;
            }
        }

        private string DPObjectId()
        {

            string DPObjectId = @"
        //must override when logger is used
        protected override int DPObjectId
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        ";

            string DPObjectIdProperty = @"
        protected override int DPObjectId
        {{
            get
            {{
                return this.{0};
            }}
        }}
";
            

            if (metaTable.Identity.Length > 0)
            {
                return string.Format(DPObjectIdProperty, metaTable.Identity.Keys[0]);
            }
            else if (metaTable.Primary.Length == 1)
            {
                string key = metaTable.Primary.Keys[0];
                MetaColumn column = metaTable[key];

                if (column.SqlDbType == SqlDbType.Int)
                {
                    return string.Format(DPObjectIdProperty, dict_column_field[key].Name);
                }
                
            }

            return DPObjectId;
        }



        private string PrimaryKeys()
        {

            string prop1 = @"
        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[] {});
            }
        }
        ";

            string prop2 = @"
        public override PrimaryKeys Primary
        {{
            get
            {{
                return new PrimaryKeys(new string[]{{ {0} }});
            }}
        }}
";


            if (metaTable.Primary.Length == 0)
                return prop1;

            if (metaTable.Primary.Length > 0)
                return string.Format(prop2, stringQL(metaTable.Primary.Keys));

            return "";
        }


        private string IdentitiyKeys()
        {

            string prop1 = @"
        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys();
            }
        }
        ";

            string prop2 = @"
        public override IdentityKeys Identity
        {{
            get
            {{
                return new IdentityKeys(new string[]{{ {0} }});
            }}
        }}
";


            if (metaTable.Identity.Length == 0)
                return prop1;

            if (metaTable.Identity.Length > 0)
                return string.Format(prop2, stringQL(metaTable.Identity.Keys));

            return "";
        }

        private string stringQL(string[] S)
        {
            string s = "";
            foreach (string p in S)
            {
                if (s != "")
                    s += ", ";

                s += "_" + dict_column_field[p].Name;
            }

            return s;
        }

        private string PrimaryConstructor()
        {

            string constructor = @"
        public @CLASSNAME(@PARM)
        {
           @ASSIGNMENT

           this.Load();
           if(!this.Exists)
           {
              @ASSIGNMENT    
           }
        }
        ";
            if (metaTable.Primary.Length == 0)
                return string.Empty;

            string[] keys = metaTable.Primary.Keys;
            string s1 = "";
            foreach (string p in keys)
            {
                if (s1 != "")
                    s1 += ", ";

                s1 += string.Format("{0} {1}", dict_column_field[p].Type, dict_column_field[p].Name.ToLower());
            }

            string s2 = "";
            foreach (string p in keys)
            {
                s2 += string.Format("this.{0} = {1}; ", dict_column_field[p].Name, dict_column_field[p].Name.ToLower());
            }

            return constructor
                .Replace("@PARM", s1)
                .Replace("@ASSIGNMENT", s2);

        }



        private string Fields()
        {
            List<DpoField> imageFields = new List<DpoField>();
            string fields = "";
            foreach (MetaColumn column in metaTable.Columns)
            {
                DpoField field = new DpoField(this, column);
                fields += field.GenerateField() + "\r\n";
                if (column.IsImageField)
                    imageFields.Add(field);
            }

            if (imageFields.Count > 0)
            {
                fields += "\r\n";
                fields += "        #region IMAGE PROPERTIES";
                foreach (DpoField field in imageFields)
                {
                    fields += field.GenerateImageField() + "\r\n";
                }
                fields += "        #endregion";
            }

            return fields;
        }


        private string ConstStringColumnNames()
        {
            string columns = "";
            foreach (MetaColumn column in metaTable.Columns)
            {
                DpoField field = new DpoField(this, column);
                columns += field.GetConstStringColumnName() + "\r\n";
            }

            return columns;
        }


        public string Generate(AccessModifier modifier, Level level, bool pack)
        {
            //must run it first to form Dictionary
            string fields = Fields();

            long revision = 0;

            Type type = GetType(nameSpace, className);
            if (type != null)
            { 
                RevisionAttribute[] attributes = type.GetAttributes<RevisionAttribute>();
                if(attributes.Length > 0)
                {
                    revision = attributes[0].Revision + 1;
                }
            }

            string rev = string.Format("[Revision({0})]", revision);

            string comment = @"//
// Machine Generated Code
//   by {0} at {1}
//
";
            string who = "devel";
            if (Active.Account != null)
                who = Active.Account.UserName;

            comment = string.Format(comment, who, DateTime.Now);
            string usingString = @"{0}
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;
";
            comment = string.Format(usingString, comment);
            if (nonvalized.Count > 0)
                comment += "using Tie;";
            
            string clss = @"@COMMENT

namespace @NAMESPACE
{
    @REVISION
    @ATTRIBUTE
    @MODIFIER class @CLASSNAME : DPObject
    {

#pragma warning disable

@FIELDS
#pragma warning restore

        public @CLASSNAME()
        {
        }

        public @CLASSNAME(DataRow dataRow)
            :base(dataRow)
        {
        }

@PRIMARYCONSTRUCTOR

@DPOOBJECTID

@PRIMARYKEYS

@IDENTITYKEYS

        public static string TABLE_NAME
        { 
            get
            {
              return new @CLASSNAME().TableName.FullName;
            }
        }


@CONSTANT

@CREATE_TABLE
    }
}

";

        //public DPCollection<@CLASSNAME> DPCollection(string where, params object[] args)
        //{ 
        //    return new DPCollection<@CLASSNAME>(SELECT(where, args));
        //}

  
            string constString = @"
        #region CONSTANT

{0}
       
        #endregion 
";

            string CONSTANT = string.Format(constString, ConstStringColumnNames());
            
            string CREATE_TABLE = @"
        #region CREATE TABLE 

        protected override string CreateTableString 
        {{ 
            get {{ return CREATE_TABLE_STRING; }}
        }}    
        
        private const string CREATE_TABLE_STRING =@""{0}"";


        #endregion 
";


            SQL_CREATE_TABLE_STRING = metaTable.GenerateCREATE_TABLE();
            CREATE_TABLE = string.Format(CREATE_TABLE, SQL_CREATE_TABLE_STRING);
            if(this.HasColumnAttribute)
                CREATE_TABLE = ""; 

            string m = "public";
            if (modifier == AccessModifier.Protected)
                m = "protected";
            else if (modifier == AccessModifier.Internal)
                m = "internal";
            else if (modifier == AccessModifier.Private)
                m = "private";

            clss = clss
                      .Replace("@COMMENT", comment)
                      .Replace("@NAMESPACE", nameSpace)
                      .Replace("@REVISION", rev)
                      .Replace("@ATTRIBUTE", metaTable.GetTableAttribute(level, pack))
                      .Replace("@MODIFIER", m)
                      .Replace("@PRIMARYCONSTRUCTOR", PrimaryConstructor())
                      .Replace("@CLASSNAME", className)
                      .Replace("@FIELDS", fields)
                      .Replace("@DPOOBJECTID", DPObjectId())
                      .Replace("@PRIMARYKEYS", PrimaryKeys())
                      .Replace("@IDENTITYKEYS", IdentitiyKeys())
                      .Replace("@CONSTANT", CONSTANT)
                      .Replace("@CREATE_TABLE", CREATE_TABLE);


            return clss;


        }

        private string SQL_CREATE_TABLE_STRING;
        public bool IsTableChanged(TableName name)
        {
            DPObject dpo = (DPObject)HostType.NewInstance(string.Format("{0}.{1}",nameSpace, className), new object[] {});
            if (dpo == null)
                return true;
            else
            {
                if (!dpo.TableName.Equals(name))
                    return true;

                if (dpo.SQL_CREATE_TABLE_STRING != SQL_CREATE_TABLE_STRING)
                    return true;

                if (dpo.TableName.Id == dpo.TableId)
                    return true;
            }

            return false;
        }


        private static Type GetType(string nameSpace, string className)
        {
            return HostType.GetType(string.Format("{0}.{1}", nameSpace, className));
        }

        private static List<string> NonvalizedList(string nameSpace, string className)
        {
            List<string> list = new List<string>();
            Type type = GetType(nameSpace, className);

            if (type == null)   //if class not existed
                return list;

            FieldInfo[] fields = type.GetFields();
            foreach (FieldInfo fieldInfo in fields)
            {
                Attribute[] attributes = (Attribute[])fieldInfo.GetCustomAttributes(typeof(NonValizedAttribute), true);
                if (attributes.Length != 0)
                    list.Add(fieldInfo.Name);
            }

            return list;
        }


        private static List<string> NullableList(string nameSpace, string className)
        {
            List<string> list = new List<string>();
            Type type = GetType(nameSpace, className);

            if (type == null)   //if class not existed
                return list;

            FieldInfo[] fields = type.GetFields();
            foreach (FieldInfo fieldInfo in fields)
            {
                if (fieldInfo.FieldType.IsGenericType && fieldInfo.FieldType != typeof(Nullable<DateTime>))
                {
                    if(fieldInfo.FieldType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        list.Add(fieldInfo.Name);
                }
            }

            return list;
        }
    }
}
