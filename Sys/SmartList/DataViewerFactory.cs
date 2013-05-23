using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.SmartList
{


    class DataViewerFactory
    {

      

        public static IDataViewer NewInstance(Configuration configuration)
        {
            switch ((DataViewMode)configuration.ViewMode)
            {
                case DataViewMode.DataGrid :
                    return new GridViewer(configuration);

                case DataViewMode.PivotGrid :
                    return new PivotGridViewer(configuration);

                case DataViewMode.GanttChart:
                    return new GanttChartViewer(configuration);

                case DataViewMode.BandedGrid:
                    return new BandedGridViewer(configuration);

                case DataViewMode.ChartView :
                    return new ChartViewer(configuration);

                case DataViewMode.GenericView:
                    return new GenericViewer(configuration);

                case DataViewMode.WorkflowChart:
                    return new WorkflowViewer(configuration);

                case DataViewMode.Report:
                    return new ReportViewer(configuration);
            }
         
            return null;

        }
    }
}
