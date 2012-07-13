using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.Data;
using Sys.Data.Manager;
using Sys.ViewManager.Dpo;

namespace Sys.ViewManager.Forms
{
    public partial class LogHistoryControl : JGridView
    {
        DPObject dpo;
        DefaultLogHistory log;

        public LogHistoryControl()
        {
            InitializeComponent();
            this.AllowEdit = false;
            GridView.OptionsBehavior.Editable = true;
        }


        public DefaultLogHistory LogHistory
        {
            get
            {
                return this.log;
            }
            set
            {
                this.log = value;
            }
        }

      
        public DPObject DPObject
        {
            get
            {
                return this.dpo;
            }
            set
            {
                this.dpo = value;
                log = new DefaultLogHistory(value);
            }
        }

        public void LoadHistory()
        {
            if(log != null)
                this.DataSource = log.HistoryTable();
        }

        public bool AllowCellMerge
        {
            get
            {
                return GridView.OptionsView.AllowCellMerge;
            }
            set
            {
                GridView.OptionsView.AllowCellMerge = value;
            }
        }



        private bool hideNotLogged = true;
        public bool HideNotLogged
        {
            get
            {
                return this.hideNotLogged;
            }
            set
            {
                hideNotLogged = !value;

                if (log == null)
                    return;

                foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in this.GridView.Columns)
                {
                    if (!log.ColumnLogged(gridColumn.FieldName))
                        gridColumn.Visible = hideNotLogged;
                }
            }
        }

        
    }
}
