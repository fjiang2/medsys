using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;
using System.Data;
using System.Reflection;
using Tie;
using Sys.Builder;
using System.ComponentModel;


namespace Sys.DataManager
{
    public class Packing
    {
        private FieldInfo[] publicFields;
        
        private Type dpoType;
        PersistentObject instance;

        ClassBuilder clss;
        Method pack;

        public Packing(Type dpoType)
        {
            this.dpoType = dpoType;
            instance = (PersistentObject)Activator.CreateInstance(this.dpoType);

            this.publicFields = dpoType.GetFields(BindingFlags.Public | BindingFlags.Instance);    //ignore public const fields

            Type baseType = typeof(BasePackage<>);
            baseType = baseType.MakeGenericType(dpoType);

            this.clss = new ClassBuilder(dpoType.Assembly.GetName().Name + ".Package", ModifierType.Public, ClassName, new Type[] { baseType });
            
            this.clss.AddUsing("System")
            .AddUsing("System.Data")
            .AddUsing("System.Text")
            .AddUsing("System.Collections.Generic")
            .AddUsing("Sys")
            .AddUsing("Sys.Data")
            .AddUsing("Sys.DataManager")
            .AddUsing(dpoType.Namespace);

          

          

            //constructor
            this.clss.AddConstructor(new Constructor(ClassName));

            this.pack = new Method(ModifierType.Protected | ModifierType.Override, null, "Pack");
            this.clss.AddMethod(pack);

         
        }


        public string ClassName
        {
            get
            {
                return dpoType.Name + "Package";
            }
        }

        public TableName TableName
        {
            get 
            { 
                return instance.TableName; 
            }
        }

        private void PackRecord(DataRow dataRow)
        {
            PersistentObject dpo = (PersistentObject)Activator.CreateInstance(this.dpoType, new object[] { dataRow});
          
            foreach (FieldInfo fieldInfo in this.publicFields)
            {
                object obj = fieldInfo.GetValue(dpo);
                if (obj != null)
                {
                    VAL val = VAL.Boxing(obj);
                    string s = val.ToHostString();

                    if (obj is float)
                        s = obj.ToString() + "F";
                    else if (obj is string && s.Length > 100)
                    {
                        s = s
                            .Replace("\\r\\n", "\r\n")
                            .Replace("\\n", "\r\n")
                            .Replace("\\t", "\t")
                            .Replace("\\\"", "\"\"")
                            .Replace("\\\\", "\\")
                            ;


                        pack.AddStatements("dpo.{0} = @{1}", fieldInfo.Name, s);
                    }
                    else
                    {
                        pack.AddStatements("dpo.{0} = {1}", fieldInfo.Name, s);
                    }
                }
            }

            pack.AddStatements("list.Add(dpo)")
                .AddStatements();
                

         
        }




        int count = 0;
        public static bool operator !(Packing packing)
        {
            return packing.count == 0;
        }


        public bool Pack()
        {
            pack.AddStatements("var dpo = new {0}()", dpoType.Name);

            PersistentObject dpo = (PersistentObject)Activator.CreateInstance(this.dpoType);
            DataTable dt = new TableReader(dpo.TableName).Table;
            if (dt.Rows.Count == 0)
                return false;

            this.count = dt.Rows.Count;

            //Property property = new Property(typeof(string), "TableName");
            //this.clss.AddProperty(property);
            //property.AddGet("return \"{0}\"", this.instance.TableName.Name);

            //property = new Property(typeof(Level), "Level");
            //this.clss.AddProperty(property);
            //property.AddGet("return Level.{0}", this.instance.Level);


            int i = 0;
            foreach (DataRow dataRow in dt.Rows)
            {
                PackRecord(dataRow);
                if(i < dt.Rows.Count -1)
                    pack.AddStatements("dpo = new {0}()", dpoType.Name);
                
                i++;
            }

            return true;
        }



        public override string ToString()
        {
            string comment = @"//
// Machine Packed Data
//   by {0} at {1}
//
";
            comment = string.Format(comment, Active.Account.UserName, DateTime.Now);
            string classFormat = @"{0}{1}";

            return string.Format(classFormat, comment, this.clss);
        }

    }
}
