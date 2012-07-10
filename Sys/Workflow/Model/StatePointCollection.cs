using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Sys.ViewManager.Forms;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using Tie;

namespace Sys.Workflow
{
    public class StatePointCollection :  List<StatePoint>
    {

        Series series;
        
        public StatePointCollection(Series series)
        {
            this.series = series;
        }


        public StatePoint SearchPoint(string argument)
        {

            return SearchPoint(this.series, argument);
        }


        public static StatePoint SearchPoint(Series series, string argument)
        {

            foreach (SeriesPoint point in series.Points)
            {
                if (point.Argument == argument)
                    return (StatePoint)point;

            }
            return null;
        }
    }
}
