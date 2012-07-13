using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tie;
using Sys.Data.Manager;

namespace Sys.Workflow
{
    public class Task 
    {
        protected IActivityInstanceData taskData;


        public Task()
        { 
        
        }

        public Task(IActivityInstanceData activityData)
        {
            this.taskData = activityData;
        }

        public IActivityInstanceData Data
        {
            get
            {
                return this.taskData;
            }
        }

        public override string ToString()
        {
            return string.Format("Task (ID={0}, State={1})", this.taskData.PIN, this.taskData.StateName);
        }

    }
}
