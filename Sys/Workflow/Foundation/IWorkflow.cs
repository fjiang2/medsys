using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tie;
using Sys.Data;
using Sys.DataManager;

namespace Sys.Workflow
{
    #region Workflow

    public interface IWorkflowView : IWorkflowData
    {
        string Title { get; }
        DateTime BaseDateTime { get; }

        Workflow Workflow { get; }
    }

    public interface IWorkflowData: IValizable   
    {
        string WorkflowName { get; }
        string CompanyName { get; }

        IDPCollection DpcState { get; }
        IDPCollection DpcTransition { get; }
        IStateData NewState();
        ITransitionData NewTransition();

    }



    public interface IStateView
    {
        string WorkflowName { get; set; }
        string StateName { get; set; }
        StateNodeType StateNodeType { get; set; }
        double PlanOffset { get; set; }
        double PlanDuration { get; set; }
    }

    public interface IStateData : IStateView, IValizable
    {
        string Title { get; }
        string StatePreaction { get; }
        string StateAction { get; }
        string StateAfterAction { get; }
        string StatePostaction { get; }
        string StateDependency { get; }
        int StateChannel { get; }
        string StateAgent { get; }
    }


    public interface ITransitionView
    {
        string S1Name { get; set; }
        string S2Name { get; set; }
        string WorkflowName { get; set; }

    }

    public interface ITransitionData : ITransitionView, IValizable
    {
        //ITransitionData NewInstance(VAL val);
        string Expr { get; }
    }



    #endregion











    #region Workflow Instance


    public interface ITaskNodeData
    {
        int Offspring { get; set; }
        TaskNodeType TaskNodeType { get; set; }
    }



    public interface IActivityInstanceData : ILockable
    {
        int PIN { get; }
        string StateName { get; set; }

        DateTime?[] WorkTime { get; set; }
        double WorkDuration { get; set; }

        TaskStatus TaskStatus { get; set; }
        ActivityResult ActivityResult { get; set; }
    
    }

    public interface ICollaborativeTask : IActivityInstanceData
    {
     
        string Subject { get; }

        DateTime?[] PlanTime { get; set; }
        int SenderID { get; set; }
        bool Activated { get; set; }
        bool Read { get; set; }
        string ActivityHeap { get; set; }

        ITaskNodeData NewTaskNode();
        IDPCollection DpcReceived { get; }
        IDPCollection DpcAssigned { get; }
        IDPCollection DpcReplied { get; }
        IDPCollection DpcNotified { get; }
        IDPCollection DpcAssociated { get; }

        VAL PS { get; set; }
        VAL NS { get; set; }

        DataRow Load();
        DataRow Save();
    }


    public interface IWorkflowInstanceData
    {
        IDPCollection DpcActivityInstance { get; }
    
    }

    public interface ICollaborativeWorkflowInstanceData : ILockable
    {
        int PIN { get; }
        string WorkflowName { get; set; }
        
        string MemoryStorage { get; set; }

        ICollaborativeTask NewInstance(CollaborativeWorkflowInstance workflowInstance, State state);
        string LoadHeap(string path);

        void CompleteWorkflowInstance();
        bool Completed { get; }

        DataRow Load();
        DataRow Save();
    }

    #endregion





    #region Activity Form

    public interface IActivityForm
    { 
        void BeginActivity();
        void EndActivity();

        bool SaveAsDraft();
        bool Submit();
    }


    public interface IReviewActivityForm : IActivityForm
    {
        bool Review();
        bool Request();
        bool Complete();
    }

    public interface IApprovalActivityForm : IActivityForm
    {
        bool Approve(State nextState);
        bool Reject(State nextState);
        bool Dispute(State nextState);
    }

    #endregion

}

