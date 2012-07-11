using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data;

namespace Sys.DataManager
{
    class EnumType
    {
        DataTable table;
        string category;

        public EnumType(string category)
        {
            this.category = category;
            table = new TableReader<EnumTypeDpo>(new ColumnValue(EnumTypeDpo._Category, category)).Table;
        }

        public EnumType(Type type)
            :this(type.Name)
        { 
        }

        public string ToCode()
        {
            string attribute = typeof(EnumTypeAttribute).Name.Replace("Attribute", "");

            EnumTypeDpo feature;
            List<string> features = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                feature = new EnumTypeDpo(row);
                features.Add(feature.ToCode());
            }

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
            return string.Format(format, new EnumTypeAttribute(category), category, string.Join(",", features));
        }

        public override string ToString()
        {
            return category;
        }
    }
}
