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
        /// <summary>
        /// empty list
        /// </summary>
        public DPList()
        { 
        }


        /// <summary>
        /// construct from data table
        /// </summary>
        /// <param name="dataTable"></param>
        public DPList(DataTable dataTable)
            :base(dataTable)
        {
        }


        /// <summary>
        /// contruct from table reader
        /// </summary>
        /// <param name="tableReader"></param>
        public DPList(TableReader tableReader)
            : base(tableReader.Table)
        {
        }


        /// <summary>
        /// construct from table reader
        /// </summary>
        /// <param name="tableReader"></param>
        public DPList(TableReader<T> tableReader)
            : base(tableReader.Table)
        {
        }


        /// <summary>
        /// construct from a list of records
        /// </summary>
        /// <param name="records"></param>
        public DPList(IEnumerable<T> records)
            :base(records)
        { 
        
        }
   

        /// <summary>
        /// clear all items in this DPList
        /// </summary>
        public new void Clear()
        {
            base.Clear();
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }


    }
}
