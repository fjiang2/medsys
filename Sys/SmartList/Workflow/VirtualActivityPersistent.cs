using System;
using System.Collections.Generic;
using System.Text;
using Sys.Workflow;
using Sys.Data;
using Sys.DataManager;

namespace Sys.SmartList
{
#pragma warning disable
    class VirtualActivityPersistent : DPObject, IActivityInstanceData
    {
        public string State_Name;
        public DateTime? AStart;
        public DateTime? AComplete;
        public decimal Actual;
        public int status;
        public int activity_status;

        public VirtualActivityPersistent()
        { 
        }


        public int PIN { get { return 0; } }

        public string StateName { get { return this.State_Name; } set { this.State_Name = value; } }


        public DateTime?[] WorkTime
        {
            get
            {
                return new DateTime?[] { this.AStart, this.AComplete };
            }
            set
            {
                this.AStart = value[0];
                this.AComplete = value[1];
            }
        }

        public double WorkDuration
        {
            get
            {
                return Convert.ToDouble(this.Actual);
            }
            set
            {
                this.Actual = Convert.ToDecimal(value);
            }
        }

        public TaskStatus TaskStatus
        {
            get
            {
                    return (TaskStatus)status;
            }

            set
            {
                ;
            }
        }

        public ActivityResult ActivityResult
        {
            get
            {
                return (ActivityResult)activity_status;
            }
            set { }
        }
    }

}
