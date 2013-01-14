using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Tie;
using Sys.ViewManager;
using Sys.ViewManager.Forms;

namespace Sys.SmartList
{
    class CustomizedCode
    {
        TieScript script;
        DataViewer viewer;
        public const string SETTING = "Setting";

        public CustomizedCode(DataViewer viewer)
        {
            this.script = viewer.Script;
            this.viewer = viewer;
        }

        public static void Clear(Memory DS)
        {
            DS.Remove(SETTING);    ////each smart item has "Setting", delete it first.
        }

        public void Initialize()
        {
            script.DS.AddHostObject("viewer", viewer);
            string code = @"
                  if(Setting!=null)
                  {
                     setting = new Setting(viewer, dataViewContainer);
                     if(setting.Initialize!=void)
                       setting.Initialize();
                  }
                ";
            script.VolatileExecute(code);
        }


        public ContextMenuStrip ContextMenu()
        {
            script.DS.AddHostObject("viewer", viewer);
            string code = @"
                  if(Setting!=null)
                  {
                     if(setting!=void && setting.ContextMenu!=void)
                       contextMenu = setting.ContextMenu();
                  }
                ";
            script.VolatileExecute(code);
            VAL contextMenu = script.DS["contextMenu"];
            if (contextMenu.Defined)
            {
                return (ContextMenuStrip)contextMenu.HostValue;
            }
            
            return null;
        }

        public bool DataSave()
        {
            script.DS.AddHostObject("viewer", viewer);
            string code = @"
                  if(Setting!=null)
                  {
                     if(setting!=void && setting.DataSave != void)
                         setting.DataSave();
                  }
                ";
            script.VolatileExecute(code);

            VAL func = script.DS["setting"]["DataSave"];
            if (func.Defined)
                return true;

            return false;
        }

        public bool DataPrint()
        {
            script.DS.AddHostObject("viewer", viewer);
            string code = @"
                  if(Setting!=null)
                  {
                     if(setting!=void && setting.DataPrint != void)
                         setting.DataPrint();
                  }
                ";
            script.VolatileExecute(code);

            VAL func = script.DS["setting"]["DataPrint"];
            if (func.Defined)
                return true;

            return false;
        }

        public DataTable ProcessDataSource(DataTable dataTable)
        {
            script.DS.AddHostObject("viewer", viewer);
            string code = @"
                  if(Setting!=null)
                  {
                    if(setting!=void && setting.ProcessDataSource != void)
                       dataTable = setting.ProcessDataSource(dataTable);
                  }
                ";
            script.DS.AddHostObject("dataTable", dataTable);
            script.VolatileExecute(code);
            if (script.DS["dataTable"].Defined)
                dataTable = (DataTable)script.DS["dataTable"].HostValue;

            return dataTable;
        }
    }
}
