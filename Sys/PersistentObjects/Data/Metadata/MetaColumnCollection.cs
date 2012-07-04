using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    class MetaColumnCollection : List<MetaColumn>
    {

        public MetaColumnCollection()
        { 
        
        }

        public void UpdatePrimary(PrimaryKeys primary)
        {

            var columns = this.Where(column => Array.IndexOf<string>(primary.Keys, column.ColumnName) >= 0);
            foreach (MetaColumn column in columns)
            {
                column.IsPrimary = true;
            }

        }


    }
}
