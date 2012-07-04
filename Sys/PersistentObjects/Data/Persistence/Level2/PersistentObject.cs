using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
using Tie;

namespace Sys.Data
{


    public abstract class PersistentObject : PersistentValue, IDPObject, IValizable
    {
        public event DataRowChangeEventHandler AfterLoaded;
        public event RowChangedHandler BeforeSaving;

        enum SaveMode
        {
            Insert,
            Update,
            Save
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
                dataTableAttribute = new TableAttribute(type.Name);

            this.publicFields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);    //ignore public const fields

        }

        protected PersistentObject(DataRow dataRow)
            : this()
        {
            this.UpdateObject(dataRow);
        }


        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="source"></param>
        public void CopyFrom(PersistentObject source)
        {

            if (source == null)
                throw new SysException("source cannot be null");

            Type t1 = this.GetType();
            Type t2 = source.GetType();

            if (t1 != t2 && !t2.IsSubclassOf(t1))
                throw new SysException("class type {0} is not matched to {1}.", t2.FullName, t1.FullName);

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

                throw new SysException("There is no locator defined.");
            }
        }

        public void SetLocator(string[] columns)
        {
            this.locator = new Locator(columns);
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

                throw new SysException("There is no table name defined.");
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
                    FillAssoication(fieldInfo);
            }
        }




      

        public virtual void Collect(DataRow dataRow)
        {
            Reflex.CollectInstance(this, dataRow);
        }


    



        public void FillIdentity(DataRow dataRow)
        {

            Type type = this.GetType();
            foreach (string key in Identity.Keys)
            {
                FieldInfo fieldInfo = type.GetField(key, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if(fieldInfo!=null)
                {
                   object value = dataRow[key];
                   fieldInfo.SetValue(this, value);
                }
            }


            foreach (FieldInfo fieldInfo in this.publicFields)
            {
                ForeignKeyAttribute[] relations = (ForeignKeyAttribute[])fieldInfo.GetCustomAttributes(typeof(ForeignKeyAttribute), true);
                if (relations.Length == 0)
                    continue;

                foreach (ForeignKeyAttribute relation in relations)
                {
                    relation.value = dataRow[relation.ParentColumnName];
                }

                Type fieldType = fieldInfo.FieldType;
                if (fieldType.IsGenericType)
                {
                    InvokeGenericMethod(fieldInfo, "FillIdentityAssociationCollection", new object[] { fieldInfo, relations });
                }
                else
                {
                    //used for many-many relationship, 

                    //if (!fieldType.IsSubclassOf(typeof(DataPersistentObject)))
                    //    throw new ApplicationException(string.Format("ERROR: {0} is not DataPersistentObject", fieldInfo.Name));

                    //DataPersistentObject dpo = (DataPersistentObject)fieldInfo.GetValue(this);
                }
                

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
                    InvokeGenericMethod(fieldInfo, "SaveAssociationCollection", new object[] {fieldInfo });
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
        private bool FillAssoication(FieldInfo fieldInfo)
        {
            AssociationAttribute association = Reflex.GetAssociationAttribute(fieldInfo);
            if (association != null)
            {
                Type fieldType = fieldInfo.FieldType;
                if (fieldType.IsGenericType)
                {
                    Type T = GetCollectionGenericType(fieldInfo);
                    FillAssociationCollection(T, association, fieldInfo);
                }
                else
                    FillAssociationObject(association, fieldInfo);

                return true;
            }

            return false;
        }



        private Type GetCollectionGenericType(FieldInfo fieldInfo)
        {
            Type fieldType = fieldInfo.FieldType;
            if (!fieldType.IsGenericType)
                throw new SysException("DPCollection is not generic type");

            Type[] typeParameters = fieldType.GetGenericArguments();
            if (typeParameters.Length != 1)
                throw new SysException("Too many generic parameters, DPCollection must declare like DPCollection<T> Children");
            
            if(typeParameters[0].IsSubclassOf(typeof(PersistentObject)))
                return  typeParameters[0];

            return null;
        }

       
        private bool InvokeGenericMethod(FieldInfo fieldInfo, string methodName, object[] parameters)
        {
            Type T = GetCollectionGenericType(fieldInfo);
            MethodInfo methodInfo = typeof(PersistentObject).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            methodInfo = methodInfo.MakeGenericMethod(T);
            methodInfo.Invoke(this, parameters);

            return true;
        }

    
        /// <summary>
        /// (1..n) Association
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="association"></param>
        /// <param name="fieldInfo"></param>
        private void FillAssociationCollection(Type T, AssociationAttribute association, FieldInfo fieldInfo)
        {
            PersistentObject obj = (PersistentObject)Activator.CreateInstance(T, new object[] { });
            TableName tname = obj.TableName;
            string SQL = string.Format("SELECT * FROM {0} WHERE {1}", tname, association.Locator);
            if (association.OrderBy != "")
                SQL += " ORDER BY " + association.OrderBy;

            SqlCmd cmd = new SqlCmd(SQL);

            foreach (FieldInfo info in this.publicFields)
            {
                ColumnAttribute a = Reflex.GetColumnAttribute(info);
                if (a != null)
                {
                    object v = info.GetValue(this);
                    if (v == null)
                        v = System.DBNull.Value;
                    cmd.AddParameter(a.ColumnNameSaved, v);
                }
            }

            DataTable dataTable = cmd.FillDataTable();
            dataTable.TableName = tname.FullName; 

            fieldInfo.SetValue(this, Activator.CreateInstance(fieldInfo.FieldType, new object[] { dataTable }));
        }


        /// <summary>
        /// (1..1) Association
        /// </summary>
        /// <param name="association"></param>
        /// <param name="fieldInfo"></param>
        private void FillAssociationObject(AssociationAttribute association, FieldInfo fieldInfo)
        {
            Type fieldType = fieldInfo.FieldType;
            if (!fieldType.IsSubclassOf(typeof(PersistentObject)))
                throw new SysException("ERROR: {0} is not DataPersistentObject", fieldInfo.Name);


            ConstructorInfo constructorInfo= fieldType.GetConstructor(new Type[]{});
            if(constructorInfo == null)
                throw new SysException("ERROR: class {0} does not has default constructor", fieldType.FullName);

            PersistentObject dpo = (PersistentObject)Activator.CreateInstance(fieldType, null);

            string SQL = string.Format("SELECT * FROM {0} WHERE {1}", dpo.TableName, association.Locator);
            SqlCmd cmd = new SqlCmd(SQL);

            foreach (FieldInfo info in this.publicFields)
            {
                ColumnAttribute a = Reflex.GetColumnAttribute(info);
                if (a != null)
                {
                    object v = info.GetValue(this);
                    if (v == null)
                        v = System.DBNull.Value;
                    cmd.AddParameter(a.ColumnNameSaved, v);
                }
            }

            DataRow dataRow = cmd.FillDataRow();
            if (dataRow == null)
                return;

            dpo.Fill(dataRow);
            fieldInfo.SetValue(this, dpo);
        }


        private void FillIdentityAssociationCollection<T>(FieldInfo fieldInfo, ForeignKeyAttribute[] relations) where T : class, IDPObject, new()
        {
            Type fieldType = fieldInfo.FieldType;

            if (!fieldType.IsGenericType)
                return;

            PersistentCollection<T> collection = (PersistentCollection<T>)fieldInfo.GetValue(this);
            collection.FillIdentity(relations);

        }

        private void SaveAssociationCollection<T>(FieldInfo fieldInfo) where T : class, IDPObject, new()
        {
            Type fieldType = fieldInfo.FieldType;

            if (!fieldType.IsGenericType)
                return;

            PersistentCollection<T> collection = (PersistentCollection<T>)fieldInfo.GetValue(this);
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

            string SQL = string.Format("USE {0};", TableName.DatabaseName) + string.Format(this.CreateTableString, TableName.Name);
            SqlCmd.ExecuteNonQuery(SQL);

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


      

    }
}
