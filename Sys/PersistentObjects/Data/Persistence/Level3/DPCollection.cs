﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Sys.Data;
using Sys.Data.Manager;

namespace Sys.Data
{

    public class DPCollection<T> : PersistentCollection<T>, ILogable
        where T : class,  IDPObject, new()
    {

        private Logger logger = null;

        public DPCollection()
        {
        }

        public DPCollection(DataTable dataTable)
            :base(dataTable)
        {
        }


        private Transaction transaction = new Transaction();
        private bool logged = false;
        public void AddLog(LogTransaction transaction)
        {
            logged = false;
            this.transaction = transaction.transaction;
        }


        public void RemoveLog()
        {
            this.transaction = new Transaction(); 
            this.logger = null;
        }


        public bool Logged()
        {
           return logged;
        }


        protected override void BeforeSave(DataRow dataRow)
        {
            if (!transaction)
                return;

            this.logger = null;
            IPersistentObject d = this.GetObject(dataRow);
            if (d is DPObject)
            {
                DPObject dpo = (DPObject)d;
                if (dpo.RowId != -1)
                    this.logger = new Logger(transaction, dpo);
            }
        }

        protected override void AfterSave(DataRow dataRow)
        {
            if (this.logger != null && this.logger.Logged)
                this.logged = true;
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


        public DPList<T> ToList()
        {
            return new DPList<T>(this.Table);
        }
    }
}
