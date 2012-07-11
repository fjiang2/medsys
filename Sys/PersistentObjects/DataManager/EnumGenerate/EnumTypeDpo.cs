using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.PersistentObjects.Dpo;
using Sys.Data;

namespace Sys.DataManager
{
    class EnumTypeDpo : sysEnumTypeDpo
    {
        public EnumTypeDpo()
        { 
        }

        public EnumTypeDpo(DataRow row)
            : base(row)
        { 
        }

        public string Caption
        {
            get
            {
                if (this.Label == null)
                    return this.Feature;
                else
                    return this.Label;
            }
        }

        public string ToCode()
        {
            return string.Format("\t\t{0}\t{1} = {2}", new EnumFieldAttribute(this.Caption), this.Feature, this.Value);
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}={2}", this.Category, this.Feature, this.Value);
        }
    }
}
