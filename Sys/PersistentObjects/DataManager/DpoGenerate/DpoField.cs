using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using Sys.Data;
using System.Reflection;
using Tie;


namespace Sys.DataManager
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

            if (dpoClass.HasColumnAttribute || column.ColumnName != column.FieldName)
            {
                line = string.Format("        {0}", column.Attribute);
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
            string declare = string.Format("public {0} {1};", ty, column.FieldName, column.DataType);
            line += declare;
            if(declare.Length < 30)
                line += new string(' ', 30 - declare.Length);

            line += string.Format("//{0}({1}) {2}", column.DataType, column.AdjuestedLength, column.Nullable ? "null" : "not null");

            dpoClass.dict_column_field.Add(column.ColumnName, new FieldDefinition(ty, column.FieldName));

            
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
