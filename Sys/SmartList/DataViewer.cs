using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Tie;
using Sys.ViewManager;
using Sys.Data;
using Sys.ViewManager.Forms;

namespace Sys.SmartList
{
    class DataViewer : IDataViewer 
    {
        protected Control viewControl;
        protected bool editMode;
        protected TieScript script;
        private DataSet dataSet = new DataSet();
        
        protected Configuration configuration;

        protected CustomizedCode customizedCode;
        
        public DataViewMode ViewMode
        {
            get 
            {
                return (DataViewMode)configuration.ViewMode;
            }
        }

        public DataViewer(Configuration configuration)
        {
            

            this.viewControl = null;
            this.editMode = false;
            this.script = new TieScript();
            this.script.DS = new Memory();
            this.configuration = configuration;

            customizedCode = new CustomizedCode(this);

            HostType.Register(typeof(DataViewMode),true);
        }


        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    script.Dispose();
                }

                // Dispose UNMANAGED resources (like P/Invoke functions)

                // Note disposing has been done.
                disposed = true;

            }
        }

        public Control ViewControl
        {
            get { return viewControl; }
        }

        public TieScript Script
        {
            get { return script; }
        }

        public DataSet DataSet
        {
            get { return this.dataSet; }
            set { this.dataSet = value; }
        }

        public DataTable Table0
        {
            get 
            {
                try
                {
                    if (this.dataSet.Tables.Count > 0)
                        return this.dataSet.Tables[0];
                    else
                        return null;
                }
                catch (Exception) { return null; }
            }
        }

        public bool EditMode
        { 
            get { return editMode; }
            set 
            {
                editMode = value;
                SwitchViewEditMode(editMode);
            }
        }

            
        public virtual VAL UserViewLayout
        {
            get
            {
                return null;
            }
            set
            {
            }
        }


        public virtual void DataPrint() {}
        public virtual void DataPrintPreview() {}

        protected virtual void SwitchViewEditMode(bool editMode) {}
        public virtual string ActivateView() {  return null; }

        public virtual void InitializeViewLayout(VAL parameters) {}


        public bool DataSave()
        {
            return customizedCode.DataSave();
        }

        public void SaveDataTable(TableName tableName, VAL columns, Locator locator)
        {
            TableAdapter tableAdapter = new TableAdapter(Table0, tableName, locator);
            
            if (columns.IsNull)
            {
                tableAdapter.Fields.Add(tableAdapter.TableName);
            }
            else
            {
                for (int j = 0; j < columns.Size; j++)
                {
                    VAL c = columns[j];
                    VAL columnName = c["ColumnName"];
                    VAL alias = c["Alias"];
                    
                    
                    string name = columnName.Str;
                    ColumnAdapter adapter = new ColumnAdapter(tableAdapter.Fields.Add(name, Table0.Columns[name].DataType));
                    if(alias.Defined)
                        adapter.Alias = alias[1].Str;

                }
            }
            tableAdapter.Fields.UpdatePrimaryIdentity(tableName);
            tableAdapter.Save();
        }


      

    }
}
