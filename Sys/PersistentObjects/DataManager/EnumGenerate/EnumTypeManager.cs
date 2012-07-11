using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;

namespace Sys.DataManager
{
    public class EnumTypeManager
    {
        IEnumerable<EnumTypeDpo> list;

        public EnumTypeManager()
        {
            this.list = new TableReader<EnumTypeDpo>().ToList().OrderBy(field => field.Category);

        }


        public List<EnumType> Types
        {
            get
            {
                var groups = list.GroupBy(field => field.Category);
                List<string> typenames = groups.Select(group => group.Key).OrderBy(key => key).ToList();

                List<EnumType> types = new List<EnumType>();
                foreach (var group in groups)
                {
                    EnumType type = new EnumType(group.Select(field=>field).OrderBy(field=>field.Value));
                    
                    types.Add(type);
                }

                return types;

            }
        }
    }
}
