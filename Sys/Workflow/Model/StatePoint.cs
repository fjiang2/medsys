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
    public class StatePoint : SeriesPoint, ISeriesPoint
    {
        private IWorkflowView workflowView;
        private IStateView state;
        
        public StatePoint(IWorkflowView workflow, IStateView state)
        {
            this.workflowView = workflow;
            this.state = state;
            Fill();
        }

      


        public IStateView State { get { return this.state; } }
        public string Name { get { return this.state.StateName; } }
        
        public void Fill()
        {
            this.Argument = state.StateName;

            this.DateTimeValues = new DateTime[2];
            this.DateTimeValues[0] = this.workflowView.BaseDateTime + TimeSpan.FromHours(state.PlanOffset);
            this.DateTimeValues[1] = this.DateTimeValues[0] + TimeSpan.FromHours(state.PlanDuration);
            //this.Tag = state;
        }

        public void Collect()
        {
            state.PlanOffset = (this.DateTimeValues[0] - this.workflowView.BaseDateTime).TotalHours;
            state.PlanDuration = (this.DateTimeValues[1] - this.DateTimeValues[0]).TotalHours;
        }



        public override string ToString()
        {
            return string.Format("StatePoint(State={0}, Offset={1}, Duration={2})", this.state.StateName, this.state.PlanOffset, this.state.PlanDuration);
        }


        public void Draw(DrawOptions drawOptions)
        {
            BarDrawOptions options = (BarDrawOptions)drawOptions;
            options.FillStyle.FillMode = FillMode.Solid;

            switch(state.StateNodeType)
            {
                case StateNodeType.Initial:
                    options.Border.Color = Color.Blue;
                    options.Border.Thickness = 3;
                    break;

                case StateNodeType.Final: 
                    options.Border.Color = Color.Blue;
                    options.Border.Thickness = 5;
                    break;

                case StateNodeType.Initial | StateNodeType.Final:
                    options.Color = Color.Azure;
                    options.Border.Color = Color.Blue;
                    options.Border.Thickness = 7;
                    break;
                
                case StateNodeType.Normal :
                    options.Border.Thickness = 1;
                    break;
            }

            
            //RectangleGradientFillOptions options = drawOptions.FillStyle.Options as RectangleGradientFillOptions;
            //if (options == null)
            //    options.GradientMode = RectangleGradientMode.BottomToTop; 
            //    return;
        }



        //public StatePoint(Workflow workflow, SeriesPoint point)
        //{
        //    this.workflow = workflow;

        //    this.Argument = point.Argument;
        //    this.DateTimeValues = point.DateTimeValues;

        //    this.state = new StatePersistent();
        //    state.Name = point.Argument;
        //    state.Workflow_Name = this.workflow.Name;

        //    Collect();
        //}



        public SeriesPoint Duplicate(string name)
        {
            IStateView persistent = workflowView.NewState();
            persistent.WorkflowName = this.workflowView.Workflow.WorkflowName;
            persistent.StateName = name;
            persistent.PlanOffset = this.state.PlanOffset;
            persistent.PlanDuration = this.state.PlanDuration;

            return new StatePoint(this.workflowView, persistent);
        }


        public static SeriesPoint NewStatePoint(IWorkflowView workflowView, string name, double offset, double duration)
        {
            IStateView persistent = workflowView.NewState();
            persistent.WorkflowName = workflowView.Workflow.WorkflowName;
            persistent.StateName = name;
            persistent.PlanOffset = offset;
            persistent.PlanDuration = duration;

            return new StatePoint(workflowView, persistent);
        }

    }
}
