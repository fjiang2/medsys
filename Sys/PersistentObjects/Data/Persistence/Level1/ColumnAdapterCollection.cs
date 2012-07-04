using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sys.Data
{
    public class ColumnAdapterCollection : List<ColumnAdapter>
    {
        
        internal ColumnAdapterCollection()
        {
        }

        public void UpdateColumnValue(DataRow dataRow)
        {
            foreach (ColumnAdapter column in this)
            {
                column.UpdateValue(dataRow);
                column.Fill();
            }

        }

        public void UpdateDataRow(DataRow dataRow)
        {
            foreach (ColumnAdapter column in this)
            {
                column.Collect();
                column.UpdateDataRow(dataRow);
            }
        }

       

        public ColumnAdapter Connect(ColumnAdapter column)
        {
            foreach (ColumnAdapter adapter in this)
                if (adapter.Field.Name.Equals(column.Field.Name))
                    return adapter;

            base.Add(column);

            return column;
        }
       


     
    }
}
