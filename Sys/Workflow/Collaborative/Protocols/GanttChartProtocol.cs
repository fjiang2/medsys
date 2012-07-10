using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraCharts;
using Tie;

namespace Sys.Workflow.Collaborative.Protocols
{

    public enum DataFormat
    {
        DateTimeValues,
        OffsetDuration,
        Workflow
    }

    public class GanttChartProtocol
    {
        private DevExpress.XtraCharts.ChartControl chartControl1;

        public GanttChartProtocol(ChartControl chartControl1)
        {
            this.chartControl1 = chartControl1;
        }

        public VAL GetValData(DataFormat dataFormat, DateTime baseDateTime)
        {
            VAL val = new VAL();
            val["DataFormat"] = new VAL((int)dataFormat);
            val["Series"] = new VAL();


            VAL v0 = new VAL();
            val["Series"] = v0;
            foreach (Series series in chartControl1.Series)
            {
                v0[series.Name] = new VAL();
                VAL v1 = VAL.Array();

                if (dataFormat == DataFormat.OffsetDuration)
                    v0[series.Name]["BaseTime"] = VAL.Boxing(baseDateTime);

                v0[series.Name]["Points"] = v1;
                foreach (SeriesPoint point in series.Points)
                {
                    VAL v2 = new VAL();
                    switch (dataFormat)
                    {
                        case DataFormat.DateTimeValues:
                            v2 = SeriesPoint2VAL(point);
                            break;
                        case DataFormat.OffsetDuration:
                            v2 = GetValData(baseDateTime, point);
                            break;
                    }

                    v1.Add(v2);
                }
            }

            return val;
        }


        public void SetValData(VAL val)
        {

            ((System.ComponentModel.ISupportInitialize)(chartControl1)).BeginInit();

            DateTime baseDateTime = DateTime.Now;

            DataFormat dataFormat = DataFormat.DateTimeValues;
            if (val["DataFormat"].Defined)
                dataFormat = (DataFormat)(val["DataFormat"].Intcon);

            VAL v0 = val["Series"];
            foreach (Series series in chartControl1.Series)
            {
                VAL v1 = v0[series.Name];

                if (dataFormat == DataFormat.OffsetDuration)
                    baseDateTime = (DateTime)v1["BaseTime"];

                v1 = v1["Points"];
                series.Points.Clear();
                for (int i = 0; i < v1.Size; i++)
                {
                    VAL v2 = v1[i];
                    SeriesPoint point = new SeriesPoint();
                    point.Argument = v2["Name"].Str;

                    switch (dataFormat)
                    {
                        case DataFormat.DateTimeValues:
                            VAL v3 = v2["Values"];
                            DateTime[] values = new DateTime[v3.Size];
                            for (int j = 0; j < v3.Size; j++)
                                values[j] = (DateTime)v3[j];
                            point.DateTimeValues = values;
                            break;

                        case DataFormat.OffsetDuration:
                            point.DateTimeValues = new DateTime[2];
                            point.DateTimeValues[0] = baseDateTime + TimeSpan.FromHours(v2["Offset"].Doublecon);
                            point.DateTimeValues[1] = point.DateTimeValues[0] + TimeSpan.FromHours(v2["Duration"].Doublecon);
                            break;
                    }

                    series.Points.Add(point);
                }

            }

            foreach (Series series in chartControl1.Series)
            {
                VAL v1 = v0[series.Name]["Points"];
                for (int i = 0; i < v1.Size; i++)
                {
                    VAL v2 = v1[i];
                    string name = v2["Name"].Str;
                    SeriesPoint point1 = this.SearchSeriesPoint(series, name);
                    point1.Relations.Clear();

                    VAL PS = v2["PS"];
                    for (int j = 0; j < PS.Size; j++)
                    {
                        string name1 = PS[j].Str;
                        foreach (SeriesPoint point2 in series.Points)
                        {
                            if (point2.Argument != name1)
                                continue;
                            else
                            {
                                TaskLink link = new TaskLink(point2);
                                point1.Relations.Add(link);
                                break;
                            }
                        }
                    }
                }
            }

            ((System.ComponentModel.ISupportInitialize)(chartControl1)).EndInit();

        }


        private static VAL GetValData(DateTime baseDateTime, SeriesPoint point)
        {
            VAL val = new VAL();
            val["Name"] = new VAL(point.Argument);

            VAL v;
            TimeSpan timeSpan = point.DateTimeValues[0] - baseDateTime;
            val["Offset"] = new VAL(timeSpan.TotalHours);
            timeSpan = point.DateTimeValues[1] - point.DateTimeValues[0];
            val["Duration"] = new VAL(timeSpan.TotalHours);

            v = VAL.Array();
            val["PS"] = v;      //previous states
            foreach (TaskLink link in point.Relations)
            {
                v.Add(new VAL(link.ChildPoint.Argument));
            }

            return val;
        }


        private static VAL SeriesPoint2VAL(SeriesPoint point)
        {
            VAL val = new VAL();
            val["Name"] = new VAL(point.Argument);

            VAL v;
            v = VAL.Array();
            val["Values"] = v;
            foreach (DateTime dateTime in point.DateTimeValues)
            {
                v.Add(VAL.Boxing(dateTime));
            }

            v = VAL.Array();
            val["PS"] = v;      //previous states
            foreach (TaskLink link in point.Relations)
            {
                v.Add(new VAL(link.ChildPoint.Argument));
            }
            return val;
        }

        //private static SeriesPoint VAL2SeriesPoint(VAL val)
        //{
        //   SeriesPoint point = new SeriesPoint();
        //    point.Argument = val["Name"].Str;

        //    VAL v = val["Values"];
        //    point.DateTimeValues = new DateTime[v.Size];
        //    for (int i = 0; i < v.Size; i++)
        //        point.DateTimeValues[i] = v[i].Datetimecon;

        //    return point;
        //}



        private SeriesPoint SearchSeriesPoint(Series series, string argument)
        {

            foreach (SeriesPoint point in series.Points)
            {
                if (point.Argument == argument)
                    return point;

            }
            return null;
        }



        public VAL DateTimeRangeValData
        {
            get
            {
                return GetValData(DataFormat.DateTimeValues, DateTime.Now);
            }
            set
            {
                SetValData(value);
            }
        }

        public VAL OffsetDurationValData
        {
            get
            {
                return GetValData(DataFormat.OffsetDuration, this.DateTimeRange[0]);
            }
            set
            {
                SetValData(value);
            }
        }



        public DateTime[] DateTimeRange
        {
            get
            {
                DateTime[] values = new DateTime[2];
                values[0] = DateTime.MaxValue;
                values[1] = DateTime.MinValue;

                foreach (Series series in chartControl1.Series)
                {
                    foreach (SeriesPoint point in series.Points)
                    {
                        if (point.DateTimeValues[0] < values[0])
                            values[0] = point.DateTimeValues[0];

                        if (point.DateTimeValues[1] > values[1])
                            values[1] = point.DateTimeValues[1];
                    }
                }
                return values;
            }
        }

    }
}
