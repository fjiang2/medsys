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

namespace Sys.ViewManager.Forms
{
    enum DragMode
    {
        DragNone,
        DragMinValue,
        DragMaxValue,
        DragBlock
    }

    public enum SeriesPointOperation
    {
        AddSeriesPoint,
        InsertSeriesPoint,
        DeleteSeriesPoint,
        AddLink,
        DeleteLink,
        ChangeMinValue,
        ChangeMaxValue,
        MoveSeriesPoint,
        SwapSeriesPoint
    }

    public class JGanttChartEventArgs : EventArgs
    {
        public readonly SeriesPointOperation Operation;
        public readonly Series Series;
        public readonly SeriesPoint Point1;
        public readonly SeriesPoint Point2;

       
        public JGanttChartEventArgs(SeriesPointOperation operation, Series series, SeriesPoint seriesPoint1, SeriesPoint seriesPoint2)
        {
            this.Operation = operation;
            this.Series = series;
            this.Point1 = seriesPoint1;
            this.Point2 = seriesPoint2;
        }
    }


    public partial class JGanttChart : UserControl
    {
        private bool readOnly = false;
        private bool dragging = false;
        private SeriesPoint draggingPoint;
        private Series draggingSeries;
        private DateTime draggingInitialValue;
        private DragMode dragMode;
        private Cursor defaultCursor;
        private ToolTipController toolTipController = new ToolTipController();

        public delegate void JGanttChartHandler(object sender, JGanttChartEventArgs e);
        public event JGanttChartHandler GanttChartEvent;

        protected bool Busy = false;

        public bool OnGanttChartEvent(SeriesPointOperation operation, Series series, SeriesPoint seriesPoint1, SeriesPoint seriesPoint2)
        {
            if (Busy)
                return false;

            if (GanttChartEvent != null)
            {
                JGanttChartEventArgs args = new JGanttChartEventArgs(operation, series, seriesPoint1, seriesPoint2);
                GanttChartEvent(this, args);
                return true;
            }

            return false;
        }


        public JGanttChart()
        {
            InitializeComponent();
            this.chartControl1.MouseUp += new MouseEventHandler(this.chartControl_MouseUp);
            this.chartControl1.MouseMove += new MouseEventHandler(this.chartControl_MouseMove);
            this.chartControl1.MouseDown += new MouseEventHandler(this.chartControl_MouseDown);
            this.chartControl1.MouseClick += new MouseEventHandler(this.chartControl_MouseClick);
            this.chartControl1.MouseDoubleClick += new MouseEventHandler(this.chartControl_MouseDoubleClick);
            this.chartControl1.CustomDrawSeriesPoint += new CustomDrawSeriesPointEventHandler(this.chartControl_CustomDrawSeriesPoint);

            ReadOnly = true;
        }

        protected void BeginInit()
        {
            ((System.ComponentModel.ISupportInitialize)(chartControl1)).BeginInit();
        }

        protected void EndInit()
        {
            ((System.ComponentModel.ISupportInitialize)(chartControl1)).EndInit();
        }

        public void Initialize()
        {

            ReadOnly = false;

            DevExpress.XtraCharts.Series series0 = ChartControl.Series[0];
            GanttDiagram ganttDiagram1 = (GanttDiagram)chartControl1.Diagram;

            ganttDiagram1.AxisX.Range.ScrollingRange.SideMarginsEnabled = true;
            ganttDiagram1.AxisX.Range.SideMarginsEnabled = true;
            ganttDiagram1.AxisX.VisibleInPanesSerializable = "-1";

            ganttDiagram1.AxisY.Label.Angle = -33;
            ganttDiagram1.AxisY.Label.Antialiasing = true;
            ganttDiagram1.AxisY.Range.ScrollingRange.SideMarginsEnabled = true;
            ganttDiagram1.AxisY.Range.SideMarginsEnabled = true;
            ganttDiagram1.AxisY.VisibleInPanesSerializable = "-1";

            chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Bottom;
            chartControl1.Legend.EquallySpacedItems = false;
            chartControl1.Location = new System.Drawing.Point(-11, 19);

            RangeBarSeriesLabel rangeBarSeriesLabel1 = (RangeBarSeriesLabel)series0.Label;
            rangeBarSeriesLabel1.Kind = DevExpress.XtraCharts.RangeBarLabelKind.OneLabel;


            RangeBarPointOptions rangeBarPointOptions1 = (RangeBarPointOptions)series0.LegendPointOptions;
            rangeBarPointOptions1.PointView = DevExpress.XtraCharts.PointView.Argument;


            RangeBarPointOptions rangeBarPointOptions2 = (RangeBarPointOptions)series0.Label.PointOptions;
            rangeBarPointOptions2.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
            rangeBarPointOptions2.ValueAsDuration = true;

            series0.ValueScaleType = DevExpress.XtraCharts.ScaleType.DateTime;

            DevExpress.XtraCharts.OverlappedGanttSeriesView overlappedGanttSeriesView1 = new DevExpress.XtraCharts.OverlappedGanttSeriesView();
            overlappedGanttSeriesView1.ColorEach = true;
            overlappedGanttSeriesView1.LinkOptions.ArrowHeight = 10;
            overlappedGanttSeriesView1.LinkOptions.Color = System.Drawing.Color.White;
            overlappedGanttSeriesView1.LinkOptions.ColorSource = DevExpress.XtraCharts.TaskLinkColorSource.ChildColor;
            overlappedGanttSeriesView1.LinkOptions.MinIndent = 10;
            overlappedGanttSeriesView1.LinkOptions.Visible = true;
            overlappedGanttSeriesView1.Transparency = ((byte)(50));
            series0.View = overlappedGanttSeriesView1;


            DevExpress.XtraCharts.Series series1 = chartControl1.Series[1];
            series1.Visible = false;

        }

        #region Gantt Chart Properties

        public bool ReadOnly
        {
            get { return readOnly; }
            set { readOnly = value; }
        }
        public DevExpress.XtraCharts.ChartControl ChartControl
        {
            get { return chartControl1; }
        }
        public GanttDiagram Diagram
        {
            get { return ((GanttDiagram)chartControl1.Diagram); }
        }
        public DevExpress.XtraCharts.SeriesCollection Series
        {
            get { return chartControl1.Series; }
        }
        public Legend Legend
        {
            get { return chartControl1.Legend; }
        }
        public string[] SeriesNames
        {
            set
            {
                for (int i = 0; i < chartControl1.Series.Count; i++)
                    chartControl1.Series[i].Name = value[i];

            }
        }
        public string ChartTitle
        {
            set
            {
                this.chartControl1.Titles[0].Text = value;
            }
        }



        public Series Series0 { get { return chartControl1.Series[0]; } }
        public Series Series1 { get { return chartControl1.Series[1]; } }



        #endregion



        public void AddAxis(string axisXTitle)
        {
            this.Diagram.AxisX.Title.Visible = true;
            this.Diagram.AxisX.Title.Text = axisXTitle;
            this.Diagram.AxisY.Interlaced = true;
            this.Diagram.AxisY.GridSpacing = 10.0;
            this.Diagram.AxisY.Label.Angle = -30;
            this.Diagram.AxisY.Label.Antialiasing = true;
            this.Diagram.AxisY.DateTimeOptions.Format = DevExpress.XtraCharts.DateTimeFormat.MonthAndDay;

            this.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;
            this.chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;

        }



        public void AddDeadline(string title, DateTime deadLine)
        {
            var deadline = new DevExpress.XtraCharts.ConstantLine(title + " " + deadLine.ToShortDateString(), deadLine);
            deadline.ShowInLegend = false;
            deadline.Title.Alignment = DevExpress.XtraCharts.ConstantLineTitleAlignment.Far;
            deadline.Color = System.Drawing.Color.Red;

            this.Diagram.AxisY.ConstantLines.Add(deadline);
        }



        #region Chart Control

        private void SetCursor(DateTime dateTime)
        {
            if (defaultCursor == null)
                defaultCursor = Cursor.Current;

            toolTipController.ShowHint(String.Format("{0:d}", dateTime));

            if (dragMode == DragMode.DragMaxValue || dragMode == DragMode.DragMinValue)
                Cursor.Current = Cursors.VSplit;
            else if (dragMode == DragMode.DragBlock)
                Cursor.Current = Cursors.Hand;

        }

        private void RestoreCursor()
        {
            if (defaultCursor != null)
            {
                Cursor.Current = defaultCursor;
                defaultCursor = null;
                toolTipController.HideHint();
            }
        }

        private void SetProjectProgress(DiagramCoordinates coords, Series series)
        {
            if (dragging)
            {
                DateTime dateTime = coords.DateTimeValue;
                DateTime maxAllowedDate = (DateTime)Diagram.AxisY.Range.MaxValue;
                //if (DateTime.Compare(dateTime, maxAllowedDate) > 0)
                //    dateTime = maxAllowedDate;
                ((ISupportInitialize)chartControl1).BeginInit();

                switch (dragMode)
                {
                    case DragMode.DragMaxValue:
                        draggingPoint.DateTimeValues[1] = dateTime;
                        OnGanttChartEvent(SeriesPointOperation.ChangeMaxValue, series, draggingPoint, null);
                        break;

                    case DragMode.DragMinValue:
                        draggingPoint.DateTimeValues[0] = dateTime;
                        OnGanttChartEvent(SeriesPointOperation.ChangeMinValue, series, draggingPoint, null);
                        break;

                    case DragMode.DragBlock:
                        if (draggingPoint.Argument == coords.QualitativeArgument)
                        {
                            TimeSpan timeSpan = dateTime - draggingInitialValue; //draggingPoint.DateTimeValues[0];

                            if (timeSpan.Ticks != 0)
                            {
                                draggingPoint.DateTimeValues[0] += timeSpan;
                                draggingPoint.DateTimeValues[1] += timeSpan;
                                draggingInitialValue = dateTime;
                                OnGanttChartEvent(SeriesPointOperation.MoveSeriesPoint, series, draggingPoint, null);
                            }
                        }
                        else
                        {
                            SeriesPoint p = null;
                            foreach (SeriesPoint point in draggingSeries.Points)
                            {
                                if (point.Argument == coords.QualitativeArgument)
                                {
                                    p = point;
                                    break;
                                }
                            }

                            if (p != null && p != draggingPoint)
                            {
                                draggingSeries.Points.Swap(draggingPoint, p);
                                OnGanttChartEvent(SeriesPointOperation.SwapSeriesPoint, draggingSeries, draggingPoint, p);
                            }


                        }
                        break;
                }
                ((ISupportInitialize)chartControl1).EndInit();
            }
        }

        private void chartControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (Diagram == null)
                return;

            if (readOnly)
                return;

            ChartHitInfo hitInfo = chartControl1.CalcHitInfo(e.Location);
            if (hitInfo.Series != null && (hitInfo.Series == this.Series0 || hitInfo.Series == Series1))
            {
                DiagramCoordinates coords = Diagram.PointToDiagram(e.Location);
                if (hitInfo.SeriesPoint == null)
                    return;

                draggingPoint = hitInfo.SeriesPoint;
                draggingSeries = (Series)hitInfo.Series;

                if (coords.DateTimeValue == hitInfo.SeriesPoint.DateTimeValues[0] || coords.DateTimeValue == hitInfo.SeriesPoint.DateTimeValues[1])
                {
                    if (coords.DateTimeValue == draggingPoint.DateTimeValues[1])
                        dragMode = DragMode.DragMaxValue;
                    else
                        dragMode = DragMode.DragMinValue;

                    dragging = true;
                    chartControl1.Capture = true;
                    SetCursor(coords.DateTimeValue);
                }
                else if (coords.DateTimeValue > hitInfo.SeriesPoint.DateTimeValues[0] && coords.DateTimeValue < hitInfo.SeriesPoint.DateTimeValues[1])
                {
                    dragMode = DragMode.DragBlock;
                    draggingInitialValue = coords.DateTimeValue;
                    dragging = true;
                    chartControl1.Capture = true;
                    SetCursor(coords.DateTimeValue);
                }
            }
        }

        private void chartControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (Diagram == null)
                return;

            dragging = false;
            chartControl1.Capture = false;
        }

        private void chartControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (Diagram == null)
                return;

            if (readOnly)
                return;

            if (dragging && (e.Button & MouseButtons.Left) == 0)
            {
                dragging = false;
                chartControl1.Capture = false;
            }

            DiagramCoordinates coords = Diagram.PointToDiagram(e.Location);
            if (coords.IsEmpty)
                RestoreCursor();
            else
            {
                ChartHitInfo hitInfo = chartControl1.CalcHitInfo(e.Location);
                if (dragging)
                    SetProjectProgress(coords, (Series)hitInfo.Series);

                if (dragging ||
                    (hitInfo.Series != null && (hitInfo.Series == Series0 || hitInfo.Series == Series1)))
                {
                    if (hitInfo.SeriesPoint != null)
                    {
                        if (coords.DateTimeValue == hitInfo.SeriesPoint.DateTimeValues[0])
                            dragMode = DragMode.DragMinValue;
                        else if (coords.DateTimeValue == hitInfo.SeriesPoint.DateTimeValues[1])
                            dragMode = DragMode.DragMaxValue;
                        else if (coords.DateTimeValue > hitInfo.SeriesPoint.DateTimeValues[0] && coords.DateTimeValue < hitInfo.SeriesPoint.DateTimeValues[1])
                            dragMode = DragMode.DragBlock;
                        else
                            dragMode = DragMode.DragNone;

                        SetCursor(coords.DateTimeValue);
                    }
                    else
                    {

                    }
                }
                else
                    RestoreCursor();
            }
        }

        public Tie.VAL Selected = new Tie.VAL();
        public ContextMenuStrip contextMenuStrip = null;
        private void chartControl_MouseClick(object sender, MouseEventArgs e)
        {
            Selected = new Tie.VAL();

            if (Diagram == null)
                return;

            BuildEditContextMenu();

            ChartHitInfo hitInfo = chartControl1.CalcHitInfo(e.Location);
            if (hitInfo.Series != null && hitInfo.SeriesPoint != null && (hitInfo.Series == this.Series0 || hitInfo.Series == Series1))
            {
                DiagramCoordinates coords = Diagram.PointToDiagram(e.Location);
                if (hitInfo.SeriesPoint == null)
                    return;

                if (coords.DateTimeValue >= hitInfo.SeriesPoint.DateTimeValues[0] && coords.DateTimeValue <= hitInfo.SeriesPoint.DateTimeValues[1])
                {
                    ((System.ComponentModel.ISupportInitialize)(chartControl1)).BeginInit();
                    draggingPoint = hitInfo.SeriesPoint;
                    ((System.ComponentModel.ISupportInitialize)(chartControl1)).EndInit();

                    Selected["Series"] = Tie.VAL.Boxing(hitInfo.Series);
                    Selected["SeriesPoint"] = Tie.VAL.Boxing(hitInfo.SeriesPoint);

                    if (e.Button == MouseButtons.Right)
                    {
                        if (contextMenuStrip != null)
                        {
                            Point point = (sender as Control).PointToClient(Control.MousePosition);
                            contextMenuStrip.Show((Control)sender, point.X, point.Y);
                        }
                    }
                }
            }
        }


        private void chartControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }



        private void chartControl_CustomDrawSeriesPoint(object sender, DevExpress.XtraCharts.CustomDrawSeriesPointEventArgs e)
        {
            if (e.SeriesPoint is ISeriesPoint)
            {
                ((ISeriesPoint)e.SeriesPoint).Draw(e.SeriesDrawOptions as BarDrawOptions);
            }

            if (e.SeriesPoint == markedPoint)
            {
                (e.SeriesDrawOptions as BarDrawOptions).Border.Color = Color.Black;
                (e.SeriesDrawOptions as BarDrawOptions).Border.Thickness = 3;
            }
            else if (e.SeriesPoint == draggingPoint)
                e.SeriesDrawOptions.Color = Color.Black;


            //if (e.SeriesPoint.Relations.Count > 0)
            //{
            //    TaskLink taskLink = (TaskLink)e.SeriesPoint.Relations[0];
            //}

            //BarDrawOptions drawOptions = e.SeriesDrawOptions as BarDrawOptions;
            //if (drawOptions == null)
            //    return;

            //// Get the fill options for the series point.
            //drawOptions.FillStyle.FillMode = FillMode.Solid;
            //RectangleGradientFillOptions options =
            //drawOptions.FillStyle.Options as RectangleGradientFillOptions;
            //if (options == null)
            //    return;




        }



        #endregion






        public bool AllowAddNode = true;
        SeriesPoint markedPoint = null;
        private ContextMenuStrip BuildEditContextMenu()
        {

            if (readOnly || this.contextMenuStrip != null)
                return null;

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            if (AllowAddNode)
            {
                ToolStripMenuItem menuAddState = new ToolStripMenuItem("Add Node");
                ToolStripMenuItem menuDeleteState = new ToolStripMenuItem("Delete Node");
                contextMenuStrip.Items.Add(menuAddState);
                contextMenuStrip.Items.Add(menuDeleteState);
                contextMenuStrip.Items.Add(new ToolStripSeparator());
            }
            ToolStripMenuItem menuMark = new ToolStripMenuItem("Mark Node");
            ToolStripMenuItem menuClearMark = new ToolStripMenuItem("Clear Mark");
            ToolStripMenuItem menuAddTransition = new ToolStripMenuItem("Add Link");
            ToolStripMenuItem menuDeleteTransition = new ToolStripMenuItem("Delete Link");
            ToolStripMenuItem menuReverseTransition = new ToolStripMenuItem("Reverse Link");

            contextMenuStrip.Items.Add(menuMark);
            contextMenuStrip.Items.Add(menuClearMark);
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            contextMenuStrip.Items.Add(menuAddTransition);
            contextMenuStrip.Items.Add(menuDeleteTransition);
            contextMenuStrip.Items.Add(menuReverseTransition);

            //menuAddState.Image = global::ViewManager.Properties.Resources.EditTableHS;
            //menuDeleteState.Image = global::ViewManager.Properties.Resources.Edit_UndoHS;
            //menuAddTransition.Image = global::ViewManager.Properties.Resources.CutHS;
            //menuDeleteTransition.Image = global::ViewManager.Properties.Resources.CopyHS;


            //menuDeleteState.Enabled = this.draggingPoint != null;
            //menuAddTransition.Enabled = this.markedPoint != null;
            //menuDeleteTransition.Enabled =this.markedPoint!=null;
            //menuClearMark.Enabled = this.markedPoint != null;


            //menuCut.ShortcutKeys = (Keys)Shortcut.CtrlX;
            //menuCopy.ShortcutKeys = (Keys)Shortcut.CtrlC;
            //menuPaste.ShortcutKeys = (Keys)Shortcut.CtrlV;

            EventHandler evenetHandler = delegate(object sender, EventArgs e)
            {

                Series series = (Series)(Selected["Series"].HostValue);
                SeriesPoint point = (SeriesPoint)(Selected["SeriesPoint"].HostValue);

                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
                switch (menuItem.Text)
                {
                    case "Add Node":
                        try
                        {
                            string argument = "";
                            if (InputTool.InputBox("Input node's name", "Name", ref argument) == DialogResult.OK)
                                AddSeriesPoint(series, point, argument);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;

                    case "Delete Node":
                        DeleteSeriesPoint(point);
                        point = null;
                        break;

                    case "Mark Node":
                        ((System.ComponentModel.ISupportInitialize)(chartControl1)).BeginInit();
                        markedPoint = point;
                        ((System.ComponentModel.ISupportInitialize)(chartControl1)).EndInit();
                        break;

                    case "Clear Mark":
                        ((System.ComponentModel.ISupportInitialize)(chartControl1)).BeginInit();
                        markedPoint = null;
                        ((System.ComponentModel.ISupportInitialize)(chartControl1)).EndInit();
                        break;

                    case "Add Link":
                        if (markedPoint != null)
                            AddLink(series, markedPoint, point);
                        break;

                    case "Delete Link":
                        if (markedPoint != null)
                        {
                            DeleteLink(series, markedPoint, point);
                            DeleteLink(series, point, markedPoint);
                        }
                        break;

                    case "Reverse Link":
                        if (markedPoint != null)
                        {
                            if (DeleteLink(series, markedPoint, point))
                                AddLink(series, point, markedPoint);
                            else if (DeleteLink(series, point, markedPoint))
                                AddLink(series, markedPoint, point);
                        }
                        break;
                }


            };

            foreach (ToolStripItem menuItem in contextMenuStrip.Items)
            {
                if (menuItem is ToolStripMenuItem)
                    menuItem.Click += evenetHandler;
            }

            return this.contextMenuStrip = contextMenuStrip;
        }


  












        protected virtual SeriesPoint AddSeriesPoint(Series series, SeriesPoint seriesPoint, string argument)
        {
            if(argument ==null)
                throw new ApplicationException(string.Format("SeriesPoint's Argument cannot be empty.", argument));

            foreach (SeriesPoint sp in series.Points)
            {
                if (sp.Argument == argument)
                    throw new ApplicationException(string.Format("SeriesPoint {0} already exist.", argument));
            }

            SeriesPoint point;
            if (seriesPoint is ISeriesPoint)
            {
                point = ((ISeriesPoint)seriesPoint).Duplicate(argument);
            }
            else
            {
                point = new SeriesPoint();
                point.Argument = argument;
                point.DateTimeValues = new DateTime[2];
                point.DateTimeValues[0] = seriesPoint.DateTimeValues[0];
                point.DateTimeValues[1] = seriesPoint.DateTimeValues[1];
            }

            int index = series.Points.IndexOf(seriesPoint);
            series.Points.Insert(index + 1, point);
            OnGanttChartEvent(SeriesPointOperation.InsertSeriesPoint, series, point, seriesPoint);

            return point;
        }





        protected virtual bool DeleteSeriesPoint(SeriesPoint point)
        {
            if (point != null)
            {
                foreach (Series series in chartControl1.Series)
                {
                    int index = series.Points.IndexOf(point);
                    if (index >= 0)
                    {
                        OnGanttChartEvent(SeriesPointOperation.DeleteSeriesPoint, series, point, null);
                        series.Points.Remove(point);
                        return true;
                    }
                }
            }

            return false;
        }

        protected virtual void AddLink(Series series, SeriesPoint fromPoint, SeriesPoint toPoint)
        {
            foreach (TaskLink taskLink in toPoint.Relations)
            {
                if (taskLink.ChildPoint == fromPoint)
                    return;
            }

            TaskLink link = new TaskLink(fromPoint);
            toPoint.Relations.Add(link);

            OnGanttChartEvent(SeriesPointOperation.AddLink, series, fromPoint, toPoint);
        }

        protected virtual bool DeleteLink(Series series, SeriesPoint fromPoint, SeriesPoint toPoint)
        {
            foreach (TaskLink taskLink in toPoint.Relations)
            {
                if (taskLink.ChildPoint == fromPoint)
                {
                    toPoint.Relations.Remove(fromPoint);

                    OnGanttChartEvent(SeriesPointOperation.DeleteLink, series, fromPoint, toPoint);
                    return true;
                }

            }
            return false;
        }





    }
}
