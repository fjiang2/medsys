using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using System.Data;
using Sys.Xmpp;
using Sys.Data;

namespace Sys.Workflow
{

#pragma warning disable

    public class TaskNodeCollection  
    {
        ICollaborativeTask task;
        IDPCollection taskNodes;
        TaskNodeType ty;

        public TaskNodeCollection(ICollaborativeTask task,  TaskNodeType ty)
        {
            this.task = task;
            switch (ty)
            {
                case TaskNodeType.Assigned:
                    this.taskNodes =task.DpcAssigned;
                    break;
                
                case TaskNodeType.Receivers:
                    this.taskNodes = task.DpcReceived;
                    break;


                case TaskNodeType.Notifier:
                    this.taskNodes = task.DpcNotified;
                    break;

                case TaskNodeType.Replier:
                    this.taskNodes = task.DpcReplied;
                    break;

                case TaskNodeType.Associated:
                    this.taskNodes = task.DpcAssociated;
                    break;
            }
            

            this.ty = ty;
        }
        
        public void Add(VAL val)
        {
            if (val.Undefined)
                return;

            ITaskNodeData node;
            for (int i = 0; i < val.Size; i++)
            {
                node = task.NewTaskNode();
                node.TaskNodeType = ty;
                node.Offspring = val[i]["ID"].Intcon;
                taskNodes.Add((IPersistentObject)node);
            }
        }

        public void Add(int childID)
        {
            ITaskNodeData node = task.NewTaskNode();
            node.TaskNodeType = ty;
            node.Offspring = childID;
            taskNodes.Add((IPersistentObject)node);
        
        }

     

        internal bool ContainsChildID(int childID)
        {
            for (int i = 0; i < taskNodes.Count; i++)
            {
                ITaskNodeData node = (ITaskNodeData)taskNodes.GetObject(i);
                if (node.Offspring  == childID)
                    return true;
            }
            return false;
        }

        public void Clear()
        {
            taskNodes.Table.Clear();
        }

        public void Save()
        {
          taskNodes.Save();
       }



        internal VAL ChildrenNodeList()
        {
            VAL val = VAL.Array(taskNodes.Count); 
            for (int i = 0; i < taskNodes.Count; i++)
            {
                ITaskNodeData node = (ITaskNodeData)taskNodes.GetObject(i);
                val[i] = new VAL(node.Offspring);
            }
            return val;
        }

        internal UserCollectionProtocol UserCollectionProtocol
        {
            get
            {
                VAL userIDs = this.ChildrenNodeList();
                return XmppChannel.GetUserList(userIDs);
            }
        }


        public void SetValData(VAL val)
        {
            UserCollectionProtocol users = new UserCollectionProtocol(val);
            this.Clear();
            foreach (UserProtocol user in users)
                    this.Add(user.ID);
        }

        public override string ToString()
        {
            return string.Format("TaskNodeCollection(Type={0}, Count={1})", this.ty, this.taskNodes.Count);
        }
    }
}
