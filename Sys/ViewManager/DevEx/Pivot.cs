using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DevExpress.XtraPivotGrid;

namespace Sys.ViewManager.DevEx
{
    public class Pivot
    {
        

        public static void PivotGridSetting(PivotGridControl pivotGrid)
        {
           
           
           
        }

       



        public static void InitializePivotGridColumns(PivotGridControl pivotGrid, DataTable dataTable)
        {            
            pivotGrid.DataSource = dataTable;
            pivotGrid.RefreshData();
            pivotGrid.BestFit();



           


            foreach (DataColumn c in dataTable.Columns)
            {
                DevExpress.XtraPivotGrid.PivotGridField f = new PivotGridField(c.Caption, DevExpress.XtraPivotGrid.PivotArea.FilterArea);
                pivotGrid.Fields.Add(f);                                      
            }

         
        }

       

    }
}
