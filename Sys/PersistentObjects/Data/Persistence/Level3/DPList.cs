using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.ComponentModel;

namespace Sys.Data
{
    /// <summary>
    /// override Fill(DataRow) to initialize varibles in this class, 
    /// if typeof(T).BaseType != typeof(DPObject) and instantiate class from System.Data.DataTable or TableReader
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DPList<T> : PersistentList<T>, IBindingList
        where T: class,  IDPObject, new()
    {
        public DPList()
        { 
        }

        public DPList(DataTable dataTable)
            :base(dataTable)
        {
        }

        public DPList(TableReader tableReader)
            : base(tableReader.Table)
        {
        }

        public DPList(TableReader<T> tableReader)
            : base(tableReader.Table)
        {
        }

        public DPList(IEnumerable<T> records)
            :base(records)
        { 
        
        }
   
        public new void Clear()
        {
            base.Clear();
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }


    }
}
