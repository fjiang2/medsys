using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraCharts;


namespace Sys.ViewManager.Forms
{
    public interface ISeriesPointView
    {
        void Draw(DrawOptions drawOptions);
    }

    public interface ISeriesPoint : ISeriesPointView
    {
        SeriesPoint Duplicate(string name);
    }
}
