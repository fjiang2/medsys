using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;

namespace Sys.DataManager
{
    public class EnumTypeManager
    {
        List<EnumType> types;

        public EnumTypeManager()
        {
            IEnumerable<EnumTypeDpo> list = new TableReader<EnumTypeDpo>().ToList().OrderBy(field => field.Category);
              
            types = new List<EnumType>();

            var groups = list.GroupBy(field => field.Category);
            foreach (var group in groups)
            {
                EnumType type = new EnumType(group.Select(field => field).OrderBy(field => field.Value).ToList());
                    
                types.Add(type);
            }
        }

        /// <summary>
        /// replace existing EnumType or add new EnumType
        /// </summary>
        /// <param name="type"></param>
        public void Add(EnumType type)
        { 
            if(types.Exists(ty => ty.Name == type.Name))
            {
                types.RemoveAll(ty => ty.Name == type.Name);
            }

            types.Add(type);
        }

        public List<EnumType> Types
        {
            get
            {
                return types;
            }
        }
    }
}
