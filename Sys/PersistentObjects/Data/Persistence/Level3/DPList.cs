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

  
        //public void OnItemChanged(T t)
        //{
        //    int index = this.IndexOf(t);
        //    OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
        //}

        protected override void OnRemoveComplete(int index, object value)
        {
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
        }

        protected override void OnInsertComplete(int index, object value)
        {
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
        }


        private ListChangedEventHandler listChangedHandler;
        public event ListChangedEventHandler ListChanged
        {
            add { listChangedHandler += value; }
            remove { listChangedHandler -= value; }
        }

        public void OnListChanged(ListChangedEventArgs args)
        {
            if (listChangedHandler != null)
            {
                listChangedHandler(this, args);
            }
        }

        #region IBindingList

        public bool AllowEdit { get { return true; } }
        public bool AllowNew { get { return true; } }
        public bool AllowRemove { get { return true; } }
        public bool IsSorted   {  get { return false; } }
        public ListSortDirection SortDirection
        {
            get { throw new NotSupportedException(); }
        }

        public PropertyDescriptor SortProperty
        {
            get { throw new NotSupportedException(); }
        }

        public bool SupportsChangeNotification
        {
            get { return true; }
        }

        public bool SupportsSearching
        {
            get { return false; }
        }

        public bool SupportsSorting
        {
            get { return false; }
        }

        public void AddIndex(PropertyDescriptor pd)
        {
            throw new NotSupportedException();
        }

        public void ApplySort(PropertyDescriptor pd, ListSortDirection dir)
        {
            throw new NotSupportedException();
        }

        public int Find(PropertyDescriptor property, object key)
        {
            throw new NotSupportedException();
        }

        public void RemoveIndex(PropertyDescriptor pd)
        {
            throw new NotSupportedException();
        }

        public void RemoveSort()
        {
            throw new NotSupportedException();
        }

     

        public virtual object AddNew()
        {
            T t = new T();
            base.Add(t);
            return t;
        }

        #endregion

    }
}
