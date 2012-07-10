using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace Sys.Data
{
    public abstract class PersistentList<T> : CollectionBase, IPersistentCollection, IEnumerable<T>, IEnumerable
        where T: class,  IDPObject, new()
    {
        protected PersistentList()
        { 
        }

        protected PersistentList(DataTable dataTable)
        {
            InitTable(dataTable);
        }

        protected PersistentList(IEnumerable<T> records)
        {
            foreach (T t in records)
            {
                this.Add(t);
            }
        }
      


        #region IEnumerable<T>, IEnumerable

        public new IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return base.GetEnumerator();
        }


        private class ListEnumerator : IDisposable, IEnumerator<T>, IEnumerator
        {
            PersistentList<T> list;
            int cursor = -1;

            public ListEnumerator(PersistentList<T> list)
            {
                this.list = list;
            }

            public T Current
            {
                get
                {
                    if (cursor > list.Count - 1)
                        throw new InvalidOperationException("Enumeration already finished");

                    if (cursor == -1)
                        throw new InvalidOperationException("Enumeration not started");

                    return this.list[cursor];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public bool MoveNext()
            {
                cursor++;

                if (cursor > list.Count - 1)
                    return false;
                else
                    return true;
            }


            public void Reset()
            {
                cursor = -1;
            }

            public void Dispose()
            {
                cursor = -1;
            }
        }


        #endregion



        private void InitTable(DataTable dataTable)
        {
            this.dataTable = dataTable;

            foreach (DataRow dataRow in dataTable.Rows)
            {
                T t = new T();
                t.Fill(dataRow);
                this.Add(t);
            }
        }

        public F[] ToArray<F>(string fieldName)
        {
            FieldInfo fieldInfo = typeof(T).GetField(fieldName, BindingFlags.Instance | BindingFlags.Public| BindingFlags.NonPublic);

            F[] values = new F[this.Count];
            int i = 0;
            foreach (T t in this)
            {
                values[i++] = (F)fieldInfo.GetValue(t);
            }
            return values;
        }

        public void Save()
        {
            foreach (T t in this)
            {
                t.Save();
            }
        }


        private DataTable dataTable = null;
        public DataTable Table
        {
            get
            {
                if (dataTable == null)
                    dataTable = Reflex.GetEmptyDataTable<T>();
                else
                    dataTable.Rows.Clear();

                foreach (T t in this)
                {
                    DataRow newRow = dataTable.NewRow();
                    t.UpdateDataRow(newRow);
                    dataTable.Rows.Add(newRow);
                }

                return dataTable;
            }
        }



        public T this[int index]
        {
            get { return (T)base.List[index]; }
        }

        public int IndexOf(T t)
        {
            return List.IndexOf(t);
        }


        public bool Add(IPersistentObject value)
        {
            return this.Add((T)value);
        }


        public bool Add(T value)
        {
            value.SetCollection(this);
            List.Add(value);

            return true;
        }

        public bool Remove(IPersistentObject value)
        {
            List.Remove((T)value);
            
            return true;
        }

        public bool Remove(T value)
        {
            List.Remove(value);

            return true;
        }

        public void UpdateDataRow(IPersistentObject value)
        {
            throw new NotSupportedException(); 
        }


        public override string ToString()
        {
            return string.Format("{0}=#{1}", typeof(T).FullName, this.Count);
        }
    }
}
