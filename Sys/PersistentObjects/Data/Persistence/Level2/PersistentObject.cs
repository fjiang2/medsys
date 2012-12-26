//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        DPO(Data Persistent Object)                                                               //
//                                                                                                  //
//          Copyright(c) Datum Connect Inc.                                                         //
//                                                                                                  //
// This source code is subject to terms and conditions of the Datum Connect Software License. A     //
// copy of the license can be found in the License.html file at the root of this distribution. If   //
// you cannot locate the  Datum Connect Software License, please send an email to                   //
// datconn@gmail.com. By using this source code in any fashion, you are agreeing to be bound        //
// by the terms of the Datum Connect Software License.                                              //
//                                                                                                  //
// You must not remove this notice, or any other, from this software.                               //
//                                                                                                  //
//                                                                                                  //
//--------------------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
using Tie;

namespace Sys.Data
{

    /// <summary>
    /// represents a record in the table
    /// </summary>
    public abstract class PersistentObject : PersistentValue, IDPObject, IValizable
    {
        public event DataRowChangeEventHandler AfterLoaded;
        public event RowChangedHandler BeforeSaving;

        enum SaveMode
        {
            Insert,
            Update,
            Save,
            Validate
        }


        private TableAttribute dataTableAttribute;
        private FieldInfo[] publicFields;

        private bool insertIdentityOn = false;      //used for re-create table data during SQL Server updating


        protected PersistentObject()
        {
            Type type = this.GetType();

            TableAttribute[] attributes = GetAttributes<TableAttribute>();  //(DataTableAttribute[])GetType().GetCustomAttributes(typeof(DataTableAttribute), true);
            if (attributes.Length > 0)
                dataTableAttribute = attributes[0];
            else
                dataTableAttribute = new TableAttribute(type.Name, Level.Application);

            this.publicFields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);    //ignore public const fields

        }

        protected PersistentObject(DataRow dataRow)
            : this()
        {
            this.UpdateObject(dataRow);
        }

        /// <summary>
        /// Update object by unique identityId
        /// </summary>
        /// <param name="identityId"></param>
        public void UpdateObject(int identityId)
        {
            if (this.Identity.Length == 0)
                throw new JException("no identity columns found");

            if (this.Identity.Length > 1)
                throw new JException("multiple identity columns defined {0}", this.Identity);

            UpdateObject(this.Identity.ColumnNames[0].ColumnName() == identityId);
        }

        /// <summary>
        /// Instantiate an instant from select a record from database
        /// </summary>
        /// <param name="where"></param>
        public void UpdateObject(SqlExpr where)
        {
            DataRow row = SqlCmd.FillDataRow(this.TableName.Provider, new SqlClause().SELECT.COLUMNS().FROM(TableName).WHERE(where).Clause);
            this.exists = row != null;
            
            if(exists)
                this.UpdateObject(row);
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="source"></param>
        public void CopyFrom(PersistentObject source)
        {

            if (source == null)
                throw new JException("source cannot be null");

            Type t1 = this.GetType();
            Type t2 = source.GetType();

            if (t1 != t2 && !t2.IsSubclassOf(t1))
                throw new JException("class type {0} is not matched to {1}.", t2.FullName, t1.FullName);

            foreach (FieldInfo fieldInfo in this.publicFields)
            {
                object value = fieldInfo.GetValue(source);
                fieldInfo.SetValue(this, value);
            }
        }


        /// <summary>
        /// Get values from persistentObject instance and fresh dataRow
        /// </summary>
        /// <param name="dataRow"></param>
        public void UpdateDataRow(DataRow dataRow)
        {
            Collect(dataRow);
        }


        /// <summary>
        /// Get values from dataRow and update persistentObject instance
        /// </summary>
        /// <param name="dataRow"></param>
        public void UpdateObject(DataRow dataRow)
        {
            Fill(dataRow);

            //RowLoaded(dataRow);
            if (AfterLoaded != null)
                AfterLoaded(this, new DataRowChangeEventArgs(dataRow, DataRowAction.Nothing));
        }


        /// <summary>
        /// DataRow <==> persistentObject instance, return new row
        /// </summary>
        public DataRow Row
        {
            get
            {
                DataRow dataRow = this.NewRow;
                Collect(dataRow);
                return dataRow;
            }
            set
            {
                UpdateObject(value);
            }
        }



        public bool HasAttribute<T>() where T : Attribute
        {
            return this.GetType().HasAttribute<T>();
        }

        public T[] GetAttributes<T>() where T : Attribute
        {
            return this.GetType().GetAttributes<T>();
        }

        public bool BeforeSavingHooked
        {
            get { return BeforeSaving != null; }
        }

        public override string ToString()
        {
            return string.Format("Table={0} Locator={1}", TableName, Locator);
        }


        #region Exists/Changed

        private bool exists = false;
        public virtual bool Exists { get { return exists; } }


        /// <summary>
        /// this dpo Compares to the Reocrd in the SQL Server
        /// </summary>
        public bool Changed(params string[] ignoredColumns)
        {
            RowObjectAdapter d = new RowObjectAdapter(this);
            d.Apply();
            bool exists = d.Load();
            if (!exists)
                return true;

            return !d.Row.EqualTo(this.Row, ignoredColumns);
        }

        #endregion



    


        #region Locator/TableName/TableId/DataRow

        private Locator locator = null;
        public virtual Locator Locator
        {
            get
            {
                if (locator != null)
                    return locator;

                LocatorAttribute[] attributes = this.GetAttributes<LocatorAttribute>();
                if (attributes.Length > 0)
                    return attributes[0].Locator;

                if(this.Primary.Length != 0)
                    return new Locator(this.Primary);

                throw new JException("There is no locator defined.");
            }
        }

        /// <summary>
        /// set new locator and return old locator
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public Locator SetLocator(string[] columns)
        {
            Locator old = this.locator;
            this.locator = new Locator(columns);
            
            return old;
        }

        /// <summary>
        /// User defined locator(where clause), use exact ColumnName(case sensitive)
        /// </summary>
        /// <param name="where"></param>
        public void SetLocator(Locator locator)
        {
            this.locator = locator;
        }


        public virtual TableName TableName
        {
            get
            {
                if (dataTableAttribute != null)
                    return dataTableAttribute.TableName;

                throw new JException("There is no table name defined.");
            }
        }


        public virtual Level Level
        {
            get
            {
                if (dataTableAttribute != null)
                    return dataTableAttribute.Level;

                return Level.Fixed;
            }
        }

        public bool IsPack
        {
            get
            {
                if (dataTableAttribute != null)
                    return dataTableAttribute.Pack;

                return true;
            }
        }

        public bool HasProvider
        {
            get
            {
                if (dataTableAttribute != null)
                    return !TableName.Provider.Equals(DataProvider.DefaultProvider);

                return false;
            }
        }
      
        public virtual int TableId
        {
            get 
            {
               return TableName.Id;
            }
        }

        public bool DefaultValueUsed
        {
            get
            {
                return dataTableAttribute.DefaultValueUsed;
            }
            set
            {
                dataTableAttribute.DefaultValueUsed = value;
            }
        }


        public virtual IdentityKeys Identity
        {
            get
            {
                return Meta.Identity;
            }
        }

        public virtual PrimaryKeys Primary
        {
            get
            {
                return Meta.Primary;
            }
        }


        public virtual ComputedColumns ComputedColumns
        {
            get
            {
                return Meta.ComputedColumns;
            }
        }

        protected virtual string CreateTableString
        {
            get
            {
                string f = "";
                foreach (FieldInfo fieldInfo in this.publicFields)
                {
                    ColumnAttribute attr = Reflex.GetColumnAttribute(fieldInfo);
                    if (attr != null)
                    {
                        if (f != "")
                            f += ",\r\n";

                        MetaColumn column = new MetaColumn(attr);
                        f += column.GetSQLField();
                    }
                }

                return MetaTable.CREATE_TABLE(f, this.Primary); 
            }
        }

     
        #endregion


        #region Fill/Collect
        public virtual void Fill(DataRow dataRow)
        {

            foreach (FieldInfo fieldInfo in this.publicFields)
            {
                if (Reflex.FillField(this, fieldInfo, dataRow, dataTableAttribute.DefaultValueUsed) == null)
                { 
                    Mapping mapping = new Mapping(this, fieldInfo);
                    mapping.SetValue();
                }
            }
        }




      

        public virtual void Collect(DataRow dataRow)
        {
            Reflex.CollectInstance(this, dataRow);
        }


    



        public void FillIdentity(DataRow dataRow)
        {

            Type type = this.GetType();
            foreach (string key in Identity.ColumnNames)
            {
                FieldInfo fieldInfo = type.GetField(key, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if(fieldInfo != null)
                {
                   object value = dataRow[key];
                   if(value != System.DBNull.Value)
                       fieldInfo.SetValue(this, value);
                }
            }

            foreach (string key in ComputedColumns.ColumnNames)
            {
                FieldInfo fieldInfo = type.GetField(key, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (fieldInfo != null)
                {
                    object value = dataRow[key];
                    if (value != System.DBNull.Value)
                        fieldInfo.SetValue(this, value);
                    else
                        fieldInfo.SetValue(this, null);
                }
            }


            foreach (FieldInfo fieldInfo in this.publicFields)
            {
              Mapping mapping = new Mapping(this, fieldInfo);
              mapping.FillIdentity();
            }
        }

        #endregion


     


        
        #region Load/Save/Delete/Clear

        protected SqlTrans transaction = null;
        internal SqlTrans Transaction
        {
            get { return transaction; }    //used in SqlObject
        }

        public void SetTransaction(SqlTrans transaction)
        {
            this.transaction = transaction;
        }


        public virtual DataRow Save()
        {
            return save(new Selector(), SaveMode.Save);
        }


        public virtual DataRow Save(string[] columnNames)
        {
            return save(new Selector(columnNames), SaveMode.Save);
        }

        public virtual DataRow Insert()
        {
            return save(new Selector(), SaveMode.Insert);
        }

        public virtual DataRow Update()
        {
            return save(new Selector(), SaveMode.Insert);
        }

        public virtual DataRow Validate()
        {
            return save(new Selector(), SaveMode.Validate);
        }

        public virtual DataRow Update(string[] columnNames)
        {
            return save(new Selector(columnNames), SaveMode.Insert);
        }


        private DataRow save(Selector columnNames, SaveMode mode)
        {
            RowObjectAdapter d = new RowObjectAdapter(this, columnNames);
            d.Apply();

            d.InsertIdentityOn = this.insertIdentityOn;

            d.ValueChangedHandler = ValueChanged;
            d.RowChanged += RowChanged;
            if (BeforeSaving != null)
                d.RowChanged += BeforeSaving;

            switch (mode)
            {
                case SaveMode.Insert:
                    d.Insert();
                    break;

                case SaveMode.Update:
                    d.Update();
                    break;

                case SaveMode.Save:
                    d.Save();
                    break;

                case SaveMode.Validate:
                    d.Validate();
                    break;
            }

            FillIdentity(d.Row);    //because of Identity retrieved

            return d.Row;
        }


      

        protected virtual void RowChanged(object sender, RowChangedEventArgs e)
        {

        }

        protected virtual void ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }

        protected virtual void RowLoaded(DataRow dataRow)
        {
            return ;
        }

        public virtual void SaveAssociations()
        {
            foreach (FieldInfo fieldInfo in this.publicFields)
            {
                Attribute[] association = (Attribute[])fieldInfo.GetCustomAttributes(typeof(AssociationAttribute), true);
                if (association.Length != 0)
                {
                    SaveAssociationCollection(fieldInfo);
                }
            }
        }



        public virtual DataRow Load()
        {
            RowObjectAdapter d = new RowObjectAdapter(this);
            d.Apply();

            exists = d.Load();      
            Fill(d.Row);
            
            //RowLoaded(d.Row);

            if (AfterLoaded != null)
                AfterLoaded(this, new DataRowChangeEventArgs(d.Row, DataRowAction.Nothing));


            return d.Row;
        }



        public virtual bool Delete()
        {
            RowObjectAdapter d = new RowObjectAdapter(this);
            d.Apply();

            //check 1..many table dependency
            foreach (FieldInfo fieldInfo in this.publicFields)
            {
                AssociationAttribute association = Reflex.GetAssociationAttribute(fieldInfo);
                if (association == null)
                    continue;

                if (!fieldInfo.FieldType.IsGenericType)
                    continue;

                IDPCollection collection = (IDPCollection)fieldInfo.GetValue(this);
                if (collection.Count == 0)
                    continue ;
            
                Type[] typeParameters = fieldInfo.FieldType.GetGenericArguments();
                if (typeParameters.Length == 1 && typeParameters[0].IsSubclassOf(typeof(PersistentObject)))
                {
                    throw new ApplicationException(string.Format(
                        "Error: data persistent object on Table {0} cannot be deleted because Table {1} depends on it.", 
                        TableName,
                        collection.TableName));
                }
                    
                
            }

            d.RowChanged += RowChanged;

            return d.Delete();
        }

        public virtual void Clear()
        {
            foreach (FieldInfo fieldInfo in this.publicFields)
            {
                object value = null;

                if (fieldInfo.FieldType.IsValueType)
                    value = DefaultRowValue.SystemDefaultValue(fieldInfo.FieldType);

                fieldInfo.SetValue(this, value);
            }

        }

        public bool InsertIdentityOn
        {
            get { return this.insertIdentityOn; }
            set { this.insertIdentityOn = value; }
        }


        public RowAdapter NewRowAdapter(Selector columnNames)
        {
            RowObjectAdapter d = new RowObjectAdapter(this, columnNames);
            d.InsertIdentityOn = this.insertIdentityOn;
            return d;
        }


        private void Apply(RowAdapter d)
        {
            foreach (FieldInfo fieldInfo in this.publicFields)
            {
                ColumnAttribute a = Reflex.GetColumnAttribute(fieldInfo);
                if (a != null && d.Row.Table.Columns.Contains(a.ColumnNameSaved))
                {
                    if (fieldInfo.GetValue(this) == null)
                        d.Row[a.ColumnNameSaved] = System.DBNull.Value;
                    else
                        d.Row[a.ColumnNameSaved] = fieldInfo.GetValue(this);
                }

            }

            d.Fill();
        }
        #endregion


        
        
        #region Assoication Field
      
        internal static Type GetCollectionGenericType(FieldInfo fieldInfo)
        {
            Type fieldType = fieldInfo.FieldType;
            if (!fieldType.IsGenericType)
                throw new JException("DPCollection is not generic type");

            Type[] typeParameters = fieldType.GetGenericArguments();
            if (typeParameters.Length != 1)
                throw new JException("Too many generic parameters, DPCollection must declare like DPCollection<T> Children");
            
            if(typeParameters[0].IsSubclassOf(typeof(PersistentObject)))
                return  typeParameters[0];

            return null;
        }

       
     


        //Invoked by methodname(string), don't change method name
        private void SaveAssociationCollection(FieldInfo fieldInfo)
        {
            Type fieldType = fieldInfo.FieldType;

            if (!fieldType.IsGenericType)
                return;

            IDPCollection collection = (IDPCollection)fieldInfo.GetValue(this);
            collection.Save();

        }

        #endregion

     


        #region Collection

        protected IPersistentCollection collection = null;

        //called by DataPersistentCollection
        public void SetCollection(IPersistentCollection collection)
        {
            this.collection = collection;
        }

        /// <summary>
        /// Update DataPersistentCollection(DPC)'s DataRow when DataPersistentObject(DPO) is from DPC
        /// </summary>
        public void AcceptChanges()
        {
            if (this.collection == null)
                return;

            this.collection.UpdateDataRow(this);
        }

        #endregion


        /// <summary>
        /// Create Table in the SQL Server if the table does not exist
        /// </summary>
        /// <returns></returns>
        public bool CreateTable()
        {
            if (MetaDatabase.TableExists(this.TableName))
                return false;

            string SQL = string.Format("USE [{0}];", TableName.DatabaseName.Name) + string.Format(this.CreateTableString, TableName.Name);
            SqlCmd.ExecuteNonQuery(this.TableName.Provider, SQL);

            return true;
        }
        
      

        private MetaTable Meta
        {
            get
            {
                return this.TableName.GetCachedMetaTable();
            }
        }

        public DataRow NewRow
        {
            get 
            {
                if (this.collection != null)
                {
                    return collection.Table.NewRow();
                }

                //FROM SQL SERVER
                return Meta.NewRow(); 

                //or FROM ColumnAttribute
                //return Reflex.GetEmptyDataTable(this.GetType()).NewRow();
            }
        }

        /// <summary>
        /// return value of column
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public T GetColumnValue<T>(string columnName)
        {
            foreach (FieldInfo field in this.publicFields)
            {
                if (field.Name == columnName)
                    return (T)field.GetValue(this);
            }

            throw new JException("Column name ({0}) not found.");
        }

        public object GetColumnValue(string columnName)
        {
            foreach (FieldInfo field in this.publicFields)
            {
                if (field.Name == columnName)
                    return field.GetValue(this);
            }

            throw new JException("Column name ({0}) not found.");
        }
      
    }
}
