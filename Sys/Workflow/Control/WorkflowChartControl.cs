using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Sys.ViewManager.Forms;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using Tie;
using Sys.ViewManager;
using Sys.Data;

namespace Sys.Workflow
{
    public class WorkflowChartControl : JGanttChart
    {
        private IWorkflowView workflowView;
        private WorkflowTracking workflowTracking;

        private string[] stateNames; //show these states only
        private ChartControl chartControl1;

        public WorkflowChartControl()
        {
            this.Initialize();
            this.chartControl1 = this.ChartControl;
            this.GanttChartEvent += new JGanttChart.JGanttChartHandler(ganttChart_GanttChartEvent);
            this.chartControl1.MouseClick += new MouseEventHandler(chartControl_MouseClick);
            this.stateNames = null;
        }

        void chartControl_MouseClick(object sender, MouseEventArgs e)
        {
            bool empty = true;
            foreach (Series s in this.Series)
            {
                if (s.Points.Count != 0)
                {
                    empty = false;
                    break;
                }

            }
            if (empty)
            {
                string argument = "";
                if (InputTool.InputBox("Input node's name", "Name", ref argument) == DialogResult.OK)
                {
                    SeriesPoint point = StatePoint.NewStatePoint(this.workflowView, argument, 0, 100);
                    this.Series0.Points.Add(point);
                    OnGanttChartEvent(SeriesPointOperation.AddSeriesPoint, this.Series0, point, null);
                }

                return;
            }
        }

        
        protected override void Dispose(bool disposing)
        {
            if (workflowView != null)
            {
                workflowView.DpcState.ObjectChanged -= this.StatePointHandler;
                workflowView.DpcTransition.ObjectChanged -= this.TransitionLinkHandler;
            }

            base.Dispose(disposing);
        }

        public void WorkflowView(IWorkflowView workflowView, string[] stateNames)
        {
            this.workflowView = workflowView;
            this.stateNames = stateNames;
            if(this.workflowView.Title != null)
                this.ChartTitle = this.workflowView.Title;
            FillWorkflow();
        }

     
        public void SetHour()
        {
            Diagram.AxisX.Range.Auto = false;
            Diagram.AxisX.Range.MinValueInternal = 0.0;
            Diagram.AxisX.Range.MaxValueInternal = 20.0;
            Diagram.AxisX.Range.ScrollingRange.SideMarginsEnabled = true;
            Diagram.AxisX.Range.SideMarginsEnabled = true;
            Diagram.AxisX.VisibleInPanesSerializable = "-1";
            
            Diagram.AxisY.Range.Auto = false;
            Diagram.AxisY.Range.MinValueInternal = 0.0;
            Diagram.AxisY.Range.MaxValueInternal = 20.0;
            Diagram.AxisY.DateTimeGridAlignment = DevExpress.XtraCharts.DateTimeMeasurementUnit.Hour;
            Diagram.AxisY.DateTimeMeasureUnit = DevExpress.XtraCharts.DateTimeMeasurementUnit.Hour;
            Diagram.AxisY.Label.Staggered = true;
            Diagram.AxisY.Range.ScrollingRange.SideMarginsEnabled = true;
            Diagram.AxisY.Range.SideMarginsEnabled = true;
            Diagram.AxisY.VisibleInPanesSerializable = "-1";

            Diagram.EnableAxisXScrolling = true;
            Diagram.EnableAxisYScrolling = true;
            Diagram.EnableAxisXZooming = true;
            Diagram.EnableAxisYZooming = true;
        }


      
        
        private void FillWorkflow()
        {

            BeginInit();
            
            Series0.Points.Clear();

            if (stateNames == null)
                BuildSeries0(Series0);
            else
                BuildSeries0(Series0, stateNames);

            workflowView.DpcState.ObjectChanged += this.StatePointHandler;
            workflowView.DpcTransition.ObjectChanged += this.TransitionLinkHandler;

            
            EndInit();
        }


        public void Tracking(WorkflowTracking tracking)
        {
            this.workflowTracking = tracking;
        }


        private ActivityPointType pointType = ActivityPointType.None;
        public ActivityPointType ActivityPointType
        {
            get
            {
                return this.pointType;
            }
            set
            {

                if (this.workflowTracking == null)
                    return;

                this.pointType = value;
                BeginInit();

                //Series0.View = new DevExpress.XtraCharts.OverlappedGanttSeriesView();
                //((OverlappedGanttSeriesView)Series0.View).BarWidth = 0.6;

                //Series1.View = new DevExpress.XtraCharts.OverlappedGanttSeriesView();
                //((OverlappedGanttSeriesView)Series1.View).BarWidth = 0.4;

                RangeBarPointOptions pointOptions = (RangeBarPointOptions)Series1.Label.PointOptions;
                RangeBarSeriesLabel serieslabel = (RangeBarSeriesLabel)Series1.Label;

                switch (pointType)
                {
                    case ActivityPointType.WorkTime:
                        serieslabel.Kind = DevExpress.XtraCharts.RangeBarLabelKind.TwoLabels;
                        break;
                    case ActivityPointType.ActualTime:
                        serieslabel.Kind = DevExpress.XtraCharts.RangeBarLabelKind.OneLabel;
                        pointOptions.PointView = DevExpress.XtraCharts.PointView.Values;
                        pointOptions.ValueAsDuration = true;
                        break;
                }

                Series1.Visible = true;
                Series1.Points.Clear();

                if (stateNames == null)
                    BuildSeries1(Series1, pointType);
                else
                    BuildSeries1(Series1, stateNames, pointType);

                //            workflowInstanceView.DpcActivityInstance.ObjectChanged += this.StatePointHandler;

                EndInit();
            }
        }

        #region event handler

        private bool UpdateStatePoint(IStateView state)
        {
            StatePoint p1 = StatePointCollection.SearchPoint(Series0, state.StateName);
            if (p1 != null)
            {
                BeginInit();
                p1.Fill();
                EndInit();
                return true;
            }
            
            return false;
        }

        //update Gantt Chart after XtraGrid changed
        private void StatePointHandler(object sender, PersistentEventArgs e)
        {

            if (this == e.Sender)
                return;

            DataRow dataRow = e.Row1;
            StatePoint p1, p2;

            IStateView state = (IStateView)e.Object1;
     
      
            switch(e.ObjectState)
            {
                case PersistentObjectState.Modified: 
                    UpdateStatePoint(state);
                    break;

                case PersistentObjectState.Added:
                    if (!UpdateStatePoint(state))       //new point does not exist
                    {
                        BeginInit();
                        this.Busy = true;

                        p1 = new StatePoint(workflowView, state);
                        Series0.Points.Add(p1);

                        state.WorkflowName = workflowView.Workflow.WorkflowName;
                        //this.workflowView.Workflow.AddState((IStateData)state);

                        this.Busy = false;
                        EndInit();
                    }
                    break;

                case PersistentObjectState.Deleted:
                    p1 = StatePointCollection.SearchPoint(Series0, state.StateName);
                    if (p1 != null)
                    {
                        BeginInit(); 
                        this.Busy = true;

                        this.DeleteSeriesPoint(p1);
                        //this.workflowView.Workflow.RemoveState(state.StateName);
                        
                        this.Busy = false;
                        EndInit();
                    }
                    break;

                case PersistentObjectState.Swapped :
                    this.Busy = true;
                    p1 = StatePointCollection.SearchPoint(Series0, ((IStateView)e.Object1).StateName);
                    p2 = StatePointCollection.SearchPoint(Series0, ((IStateView)e.Object2).StateName);
                    if (p1 != null && p2 != null && p1!=p2)
                    {
                        BeginInit();
                        Series0.Points.Swap(p1, p2);
                        EndInit();
                    }
                    this.Busy = false;
                    break;
                }
        }

        private void TransitionLinkHandler(object sender, PersistentEventArgs e)
        {
            ITransitionView transition = (ITransitionView)e.Object1;
            DataRow dataRow = e.Row1;

            if (this == e.Sender)
                return;

            this.Busy = true;
            SeriesPoint p1, p2;


             switch(e.ObjectState)
             {
                 case PersistentObjectState.Added: 
                    p1 = StatePointCollection.SearchPoint(Series0, transition.S1Name);
                    p2 = StatePointCollection.SearchPoint(Series0, transition.S2Name);


                    if (p1 == null) //because of some workflow Chart control partially dispaly SeriesPoint 
                    {
                        p1 = new StatePoint(workflowView, workflowView.Workflow.States[transition.S1Name].Data);
                        Series0.Points.Add(p1);
                    }
                    if (p2 == null) 
                    {
                        p2 = new StatePoint(workflowView, workflowView.Workflow.States[transition.S2Name].Data);
                        Series0.Points.Add(p2);
                    }

                    this.AddLink(Series0, p1, p2);
                    break;
            
                 case PersistentObjectState.Deleted:
                    p1 = StatePointCollection.SearchPoint(Series0, transition.S1Name);
                    p2 = StatePointCollection.SearchPoint(Series0, transition.S2Name);
                    
                    if (p1 != null && p2 != null)
                        this.DeleteLink(Series0, p1, p2);

                    break;
            }

            this.Busy = false;

        }


          
        void ganttChart_GanttChartEvent(object sender, JGanttChartEventArgs e)
        {
            if (ReadOnly)
                return;

            StatePoint p1, p2;
            if (!(e.Point1 is StatePoint))
                return;

            workflowView.DpcState.Sender = this;
            workflowView.DpcTransition.Sender = this;
            
            switch (e.Operation)
            { 
                case SeriesPointOperation.ChangeMaxValue:
                case SeriesPointOperation.ChangeMinValue:
                case SeriesPointOperation.MoveSeriesPoint:
                    p1 = (StatePoint)e.Point1;
                    p1.Collect();
                    workflowView.DpcState.UpdateDataRow((IPersistentObject)p1.State);
                    break;
                
                case SeriesPointOperation.SwapSeriesPoint:
                    p1 = (StatePoint)e.Point1;
                    p2 = (StatePoint)e.Point2;
                    workflowView.DpcState.Swap((IPersistentObject)p1.State, (IPersistentObject)p2.State);
                    break;

                case SeriesPointOperation.InsertSeriesPoint :
                    p1 = (StatePoint)e.Point1;
                    p2 = (StatePoint)e.Point2;
                    this.workflowView.DpcState.InsertAfter((IPersistentObject)p1.State, (IPersistentObject)p2.State);
                    break;

                case SeriesPointOperation.AddSeriesPoint:
                    p1 = (StatePoint)e.Point1;
                    this.workflowView.DpcState.Add((IPersistentObject)p1.State);
                    break;

                case SeriesPointOperation.DeleteSeriesPoint :
                    p1 = (StatePoint)e.Point1;
                    TransitionLink.DeleteLink(workflowView, Series0, p1);
                    this.workflowView.DpcState.Remove((IPersistentObject)p1.State);
                    break;

                case SeriesPointOperation.AddLink:
                    TransitionLink.AddLink(workflowView, e.Point1, e.Point2);
                    break;
                
                case SeriesPointOperation.DeleteLink:
                    TransitionLink.DeleteLink(workflowView, e.Point1, e.Point2);
                    break;
            
            }
           // throw new NotImplementedException();
        }

        #endregion


        private void BuildSeries0(DevExpress.XtraCharts.Series series, string[] stateNames)
        {
            Workflow workflow = workflowView.Workflow;
            List<string> names = new List<string>();
            foreach (State state in workflow.States.Values)
            {
                foreach (string stateName in stateNames)
                {
                    if (state.StateName == stateName)
                    {
                        if (names.IndexOf(stateName) < 0)
                        {
                            StatePoint statePoint = new StatePoint(workflowView, state.Data);
                            series.Points.Add(statePoint);
                            names.Add(stateName);
                        }

                        foreach (Transition transition in state.Transitions)
                        {
                            if (names.IndexOf(transition.S1Name) < 0)
                            {
                                StatePoint statePoint = new StatePoint(workflowView, transition.State1.Data);
                                series.Points.Add(statePoint);
                                names.Add(transition.S1Name);
                            }
                            if (names.IndexOf(transition.S2Name) < 0)
                            {
                                StatePoint statePoint = new StatePoint(workflowView, transition.State2.Data);
                                series.Points.Add(statePoint);
                                names.Add(transition.S2Name);
                            }

                            TransitionLink.AddLink(series, transition.Data);
                        }
                    }
                }
            }
        }

        private void BuildSeries0(DevExpress.XtraCharts.Series series)
        {
            Workflow workflow = workflowView.Workflow;

            foreach (State state in workflow.States.Values)
            {
                StatePoint statePoint = new StatePoint(workflowView, state.Data);
                series.Points.Add(statePoint);
            }

            foreach (Transition transition in workflow.Transitions.Values)
            {
                TransitionLink.AddLink(series, transition.Data);
            }
        }








        private void BuildSeries1(DevExpress.XtraCharts.Series series, string[] stateNames, ActivityPointType pointType)
        {
            Workflow workflow = workflowView.Workflow;
            List<string> names = new List<string>();

            foreach (Task task in workflowTracking.Tasks.Values)
            {
                //not started yet
                if (task.Data.WorkTime[0] == null)
                    continue;

                foreach (string stateName in stateNames)
                {
                    if (task.Data.StateName == stateName)
                    {
                        if (names.IndexOf(stateName) < 0)
                        {
                            ActivityInstancePoint statePoint = new ActivityInstancePoint(workflowView, workflowTracking, task.Data, pointType);
                            series.Points.Add(statePoint);
                            names.Add(stateName);
                        }

                    }
                }
            }
        }


        private void BuildSeries1(DevExpress.XtraCharts.Series series, ActivityPointType pointType)
        {
            Workflow workflow = workflowView.Workflow;

            foreach (Task task in workflowTracking.Tasks.Values)
            {
                //not started yet
                if (task.Data.WorkTime[0] != null)
                {
                    ActivityInstancePoint activityPoint = new ActivityInstancePoint(workflowView, workflowTracking, task.Data, pointType);
                    series.Points.Add(activityPoint);
                }

                DateTime planTime0 = workflowView.BaseDateTime + TimeSpan.FromHours(workflow.States[task.Data.StateName].Data.PlanOffset);  
            }

        }


    }
}
