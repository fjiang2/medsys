using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace Sys.Platform.DataImporter
{
    class ImportWork : Sys.OS.Callback
    {
        DataImportManager dataImportManager;

        public ImportWork(Control sender, DataImportManager dataImportManager)
            : base(sender)
        {
            this.dataImportManager = dataImportManager;
        }

        protected override object DoWorkFunction(object args)
        {
            try
            {
                object result = true;

                DataTable dataTable = dataImportManager.DataSource;

                int i = 0;
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (WorkCancelled)
                        return false;

                    dataImportManager.ImportDataRow(dataRow);

                    object middleResult = string.Format("{0}/{1}", i++, dataTable.Rows.Count);
                    WorkDoingFunction(middleResult);
                }


                return result;
            }
            catch (Exception e)
            {
                WorkCancelled = true;
                return e;
            }
        }

    }
}
