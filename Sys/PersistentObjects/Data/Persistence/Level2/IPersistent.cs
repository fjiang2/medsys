using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

namespace Sys.Data
{
    #region Persistent Object

    public interface IPersistentObject
    {
        DataRow Load();
        DataRow Save();
        DataRow Save(string[] columnNames);
        
        bool Delete();
        void Clear();

        TableName TableName { get; }
    }


    public interface IDPObject : IPersistentObject
    {
        void UpdateDataRow(DataRow dataRow);

        void Fill(DataRow dataRow);
        void Collect(DataRow dataRow);
        void FillIdentity(DataRow dataRow);

        RowAdapter NewRowAdapter(Selector columnNames);

        void SetCollection(IPersistentCollection collection);
    }

    #endregion



    #region Persistent Collection



    /// <summary>
    /// mainly used by class PersistentObject
    /// </summary>
    public interface IPersistentCollection : IEnumerable
    {
        DataTable Table { get; }
        void UpdateDataRow(IPersistentObject p);

        bool Add(IPersistentObject p);
        bool Remove(IPersistentObject p);
    }

 
    public interface IDPCollection :  IPersistentCollection
    {

        int Count { get; }
        bool Save();
        TableName TableName { get; }

        event PersistentHandler ObjectChanged;
        object Sender { set; }

        IPersistentObject GetObject(int index);
        IPersistentObject GetObject(DataRow dataRow);
        bool InsertAfter(IPersistentObject p1, IPersistentObject p2);
        void Swap(IPersistentObject p1, IPersistentObject p2);

        void AcceptChanges();
        IPersistentObject NewInstance();

    }


    #endregion



  
  
}
