using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tie;
using Sys.ViewManager;
using Sys.ViewManager.Forms;

namespace Sys.SmartList
{
    public interface IDataViewer : IDisposable
    {
        System.Windows.Forms.Control ViewControl { get; }
        DataSet DataSet { get; set; }
        DataTable Table0 { get;  }
        TieScript Script { get; }
        bool EditMode { get; set; }

        void DataPrintPreview();
        void DataPrint();
        bool DataSave();

        void InitializeViewLayout(VAL parameters);
        string ActivateView();
        VAL UserViewLayout { get; set; }

    }
}
