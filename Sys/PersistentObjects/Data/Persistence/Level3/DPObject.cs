using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;
using System.Data;
using Sys.Data.Manager;
using System.ComponentModel;

namespace Sys.Data
{
    public abstract class DPObject : PersistentObject, ILogable, ILockable, IEditableObject
    {
        private Logger logger = null;

        public DPObject()
        {
        }

        public DPObject(DataRow dataRow)
            : base(dataRow)
        { 
        
        }

        protected virtual int DPObjectId  
        {
            get
            {
                return -1;
            }
        }

        public int RowId
        { 
            get 
            {
                return this.DPObjectId; 
            } 
        }

        //public abstract int TableId { get; }
        //public abstract string CreateTableString { get; }
        public void AddLog(LogTransaction transaction)
        {
            AddLog(transaction.transaction);
        }

        protected void AddLog(Transaction transaction)
        {
            if (DPObjectId == -1)
                throw new ApplicationException(string.Format("must override DPObjectId{get} before log at {0}.", this.GetType().FullName));

            this.logger = new Logger(transaction, this);
        }

        public void RemoveLog()
        {
            this.logger = null;
        }

        public bool Logged()
        {
            if (this.logger != null)
                return this.logger.Logged;
            else
                return false;
        }


        public virtual void SaveAndLog(LogTransaction logTransaction)
        {
            logTransaction.Add(this);
            this.Save();
            //logTransaction.Remove(this);
        }

        protected override void RowChanged(object sender, RowChangedEventArgs e)
        {
            if (this.logger == null) return;

            logger.RowChanged(sender, e);
        }

        protected override void ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (this.logger == null) return;

            logger.ValueChanged(sender, e);
        }

        public int LockType
        {
            get
            {
                return this.TableId;
            }
        }

        public int LockID
        {
            get
            {
                return DPObjectId;
            }
        }

        public override string ToString()
        {
            return string.Format("TableName={0} RowID={1}", this.TableName, this.DPObjectId);
        }

        
        internal string SQL_CREATE_TABLE_STRING
        {
            get
            {
                return CreateTableString;
            }
        }


        #region IEditableObject

        //private void OnListChanged()
        //{
        //    collection.OnItemChanged(this);
        //}


        bool committed = false;
        public void BeginEdit()
        {
        }

        public void CancelEdit()
        {
            if (!committed)
            {
                collection.Remove(this);
            }
        }
        public void EndEdit()
        {
            committed = true;
            this.Save();
        }

        #endregion
      
    
    }
}
