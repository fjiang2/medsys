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

namespace Sys.Workflow
{
    public enum ActivityPointType
    { 
        None,
        WorkTime,
        ActualTime
    }

    class ActivityInstancePoint : SeriesPoint, ISeriesPointView
    {

        private WorkflowTracking workflowTracking;
        private IActivityInstanceData activityInstance;
        private IWorkflowView workflowView;

        public ActivityInstancePoint(IWorkflowView workflowView, WorkflowTracking workflowTracking, IActivityInstanceData activity, ActivityPointType pointType)
        {
            this.workflowView = workflowView;
            this.workflowTracking = workflowTracking;
            this.activityInstance = activity;
            Fill(pointType);
        }


        public IActivityInstanceData Activity { get { return this.activityInstance; } }
        public string Name { get { return this.activityInstance.StateName; } }


        public void Fill(ActivityPointType pointType)
        {
            this.Argument = this.activityInstance.StateName;

            this.DateTimeValues = new DateTime[2];
            switch (pointType)
            {
                case ActivityPointType.WorkTime:
                    this.DateTimeValues[0] = (DateTime)this.activityInstance.WorkTime[0];
                    this.DateTimeValues[1] = (DateTime)this.activityInstance.WorkTime[1];
                    break;
             
                case ActivityPointType.ActualTime:
                    State state = this.workflowTracking.Workflow.States[activityInstance.StateName];
                    this.DateTimeValues[0] = workflowView.BaseDateTime + TimeSpan.FromHours(state.Data.PlanOffset);
                    this.DateTimeValues[1] = this.DateTimeValues[0] + TimeSpan.FromHours(activityInstance.WorkDuration);
                    break;
            }
        }

        public void Collect()
        {
            activityInstance.WorkTime[0] = this.DateTimeValues[0];
            activityInstance.WorkTime[0] = this.DateTimeValues[1];
        }



        public override string ToString()
        {
            return string.Format("ActivityInstancePoint(ID={0}, State={1}, Offset={2}, Duration={3})",
                this.activityInstance.PIN,
                this.activityInstance.StateName,
                ((DateTime)this.activityInstance.WorkTime[0]).ToShortTimeString(),
                ((DateTime)this.activityInstance.WorkTime[1]).ToShortTimeString()
                );
        }


        public void Draw(DrawOptions drawOptions)
        {
            BarDrawOptions options = (BarDrawOptions)drawOptions;
            options.FillStyle.FillMode = FillMode.Solid;

            switch (activityInstance.TaskStatus)
            {
                case TaskStatus.NotStarted:
                    options.Border.Color = Color.Gray;
                    options.Border.Thickness = 3;
                    break;

                case TaskStatus.Opened:
                    options.Border.Color = Color.Yellow;
                    options.Border.Thickness = 5;
                    break;

                case TaskStatus.Completed:
                    options.Color = Color.Azure;
                    options.Border.Color = Color.Green;
                    options.Border.Thickness = 7;
                    break;

                default:
                    options.Border.Thickness = 1;
                    break;
            }
        }



        //public SeriesPoint Duplicate(string name)
        //{
        //    IActivityInstanceView persistent = workflowInstanceView.NewInstance();
        //    persistent.StateName = name;
        //    persistent.WorkTime[0] = this.activityInstance.WorkTime[0];
        //    persistent.WorkTime[1] = this.activityInstance.WorkTime[1];

        //    return new ActivityInstancePoint(this.workflowInstanceView, persistent);
        //}



    }
}
