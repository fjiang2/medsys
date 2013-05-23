//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        DPO(Data Persistent Object)                                                               //
//                                                                                                  //
//          Copyright(c) Datum Connect Inc.                                                         //
//                                                                                                  //
// This source code is subject to terms and conditions of the Datum Connect Software License. A     //
// copy of the license can be found in the License.html file at the root of this distribution. If   //
// you cannot locate the  Datum Connect Software License, please send an email to                   //
// datconn@gmail.com. By using this source code in any fashion, you are agreeing to be bound        //
// by the terms of the Datum Connect Software License.                                              //
//                                                                                                  //
// You must not remove this notice, or any other, from this software.                               //
//                                                                                                  //
//                                                                                                  //
//--------------------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using Sys.Data;
using System.Reflection;
using Tie;


namespace Sys.Data.Manager
{
    class DpoField
    {
        DpoClass dpoClass;

        private MetaColumn column;
        
        
        public DpoField(DpoClass dpoClass, MetaColumn column)
        {
            this.dpoClass = dpoClass;
            this.column = column;
        }

       

        public string GenerateField()
        {
            string line = "";
            string tab = "        ";
            if (dpoClass.HasColumnAttribute || column.ColumnName != column.FieldName)
            {
                line = string.Format("{0}{1}", tab, column.Attribute);
                if(line.Length < 90)
                    line += new string(' ', 90 - line.Length);      //padding
            }

            line += "        ";
            if (dpoClass.Nonvalized.IndexOf(column.FieldName) != -1)
                line += "[NonValized] ";

            //When programmer make field Nullable, it must be Nullable
            //if(dgc.NullableFields.IndexOf(fieldName) != -1)
            //    nullable = true;


            string ty = MetaColumn.GetFieldType(column.DataType, column.Nullable);
            //string declare = string.Format("public {0} {1};", ty, column.FieldName);
            string declare = string.Format("public {0} {1} {{get; set;}} ", ty, column.FieldName);

            line += declare;
            if(declare.Length < 30)
                line += new string(' ', 30 - declare.Length);

            line += string.Format("//{0}({1}) {2}", column.DataType, column.AdjuestedLength, column.Nullable ? "null" : "not null");

            dpoClass.dict_column_field.Add(column.ColumnName, new FieldDefinition(ty, column.FieldName));

            if (column.ForeignKey != null && dpoClass.Dict != null)
            {
                if (dpoClass.Dict.ContainsKey(column.ForeignKey.TableName))
                {
                    Type type = dpoClass.Dict[column.ForeignKey.TableName];
                    line = string.Format("{0}{1}\r\n", tab, column.ForeignKey.GetAttribute(type)) + line;
                }
                else
                {
                    //ForeignKey check for external Dpo classes, they don't be load into dict
                    LogDpoClass log = new LogDpoClass(column.ForeignKey.TableName);
                    if (log.Exists)
                    {
                        string classFullName = string.Format("{0}.{1}", log.name_space, log.class_name);
                        line = string.Format("{0}{1}\r\n", tab, column.ForeignKey.GetAttribute(classFullName)) + line;
                    }
                    else
                        throw new JException("cannot generate Dpo class of FK {0} before generate Dpo class of PK {1}",
                            dpoClass.MetaTable.TableName,
                            column.ForeignKey.TableName);
                }
            }

            return line;
        }

       

        public string GetConstStringColumnName()
        {
            string line = "        ";
            line += string.Format("public const string _{0} = \"{1}\";", dpoClass.dict_column_field[column.ColumnName].Name, column.ColumnName);
            
            return line;
        }

        public string GenerateImageField()
        {
            string imageProperty = @"
        public Image {0}Image
        {{
            get
            {{
                if ({0} != null)
                {{
                    System.IO.MemoryStream stream = new System.IO.MemoryStream({0});
                    return System.Drawing.Image.FromStream(stream);
                }}
                
                return null;
            }}
            set
            {{
                if (value != null)
                {{
                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
                    value.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    {0} = stream.ToArray();
                }}
            }}
        }}
";
            return string.Format(imageProperty, column.FieldName);

        }
    

    }
}
