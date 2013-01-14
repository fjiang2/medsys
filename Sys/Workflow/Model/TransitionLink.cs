using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraCharts;
using Sys.Data;
namespace Sys.Workflow
{
    public class TransitionLink : TaskLink
    {
        
        public static void AddLink(Series series, ITransitionView transition)
        {
            SeriesPoint point1 = StatePointCollection.SearchPoint(series, transition.S1Name);
            SeriesPoint point2 = StatePointCollection.SearchPoint(series, transition.S2Name);
            TaskLink link = new TaskLink(point1);
            point2.Relations.Add(link);
        }

        public static ITransitionView AddLink(IWorkflowView workflowView, SeriesPoint p1, SeriesPoint p2)
        {
            ITransitionView transition = workflowView.NewTransition();
            transition.WorkflowName = workflowView.Workflow.WorkflowName;
            transition.S1Name = p1.Argument;
            transition.S2Name = p2.Argument;

            workflowView.DpcTransition.Add((IPersistentObject)transition); 
            return transition;

        }



        public static void DeleteLink(IWorkflowView workflow, SeriesPoint p1, SeriesPoint p2)
        {

            for (int i = 0; i < workflow.DpcTransition.Count; i++)
            {
                ITransitionView transition = (ITransitionView)workflow.DpcTransition.GetObject(i);
                if (transition == null) //DataRow deleted
                    continue;

                if (transition.S1Name == p1.Argument && transition.S2Name == p2.Argument)
                {
                    workflow.DpcTransition.Remove((IPersistentObject)transition);
                }
            }
            
            //workflow.RemoveTransition(p1.Argument, p2.Argument); 
        }

        public static ITransitionView DeleteLink(IWorkflowView workflow, Series series, SeriesPoint p1)
        {

            //delete from xxx --> p1
            foreach(TaskLink taskLink in p1.Relations)
            {
                DeleteLink(workflow, taskLink.ChildPoint, p1);
            }

            //delete from p1 ---> xxxx
            foreach (SeriesPoint p2 in series.Points)
            {
                foreach (TaskLink taskLink in p2.Relations)
                {
                    if (taskLink.ChildPoint == p1)
                    {
                        DeleteLink(workflow, p1, p2);
                        break;
                    }
                }
            }

            return null;

        }

        public static bool ChangeLink(Series series, ITransitionView fromTransition, ITransitionView toTransition)
        {
            SeriesPoint fromPoint = null;
            SeriesPoint toPoint = null;
            
            foreach (SeriesPoint seriesPoint in series.Points)
            {
                if (seriesPoint.Argument == fromTransition.S1Name)
                    fromPoint = seriesPoint;
                else if (seriesPoint.Argument == fromTransition.S2Name)
                    fromPoint = toPoint;
            }

            if (fromPoint == null || toPoint == null)
                return false;


            //delete link
            foreach (TaskLink taskLink in toPoint.Relations)
            {
                if (taskLink.ChildPoint == fromPoint)
                {
                    toPoint.Relations.Remove(fromPoint);

                    return true;
                }

            }

            foreach (SeriesPoint seriesPoint in series.Points)
            {
                if (seriesPoint.Argument == toTransition.S1Name)
                    fromPoint = seriesPoint;
                else if (seriesPoint.Argument == toTransition.S2Name)
                    fromPoint = toPoint;
            }

            if (fromPoint == null || toPoint == null)
                return false;

            //add link
            foreach (TaskLink taskLink in toPoint.Relations)
            {
                if (taskLink.ChildPoint == fromPoint)
                    return false;
            }

            TaskLink link = new TaskLink(fromPoint);
            toPoint.Relations.Add(link);
            return true;

        }
    }
}
