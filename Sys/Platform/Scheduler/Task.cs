using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;
using Sys.Platform.DpoClass;
using Sys.Data.Manager;
using Sys.Data;

namespace Sys.Platform.Scheduler
{

    public class Task : AppointmentDpo
    {
        public Task()
        {
            this.UniqueID = -1;
            this.User_ID = ActiveAccount.Account.UserID;
        }

     
        public DateTime xStartTime 
        { 
            get { return StartDate; } 
            set { StartDate = value; } 
        }

        public DateTime xEndTime 
        { 
            get { return EndDate; } 
            set { EndDate = value; } 
        }

        public string xSubject 
        {
            get { return Subject; }
            set { Subject = value; } 
        }

        public int xStatus 
        {
            get { return Status; }
            set { Status = value; } 
        }

        public string xDescription 
        {
            get { return Description; }
            set { Description = value; } 
        }

        public int xLabel 
        {
            get { return (int)Label; }
            set { Label = value; } 
        }

        public string xLocation 
        {
            get { return Location; }
            set { Location = value; }
        }

        public bool xAllDay 
        {
            get { return AllDay; }
            set { AllDay = value; }
        }

        public int xEventType 
        {
            get { return Type; }
            set { Type = value; } 
        }

        public string xRecurrenceInfo 
        {
            get { return RecurrenceInfo; }
            set { RecurrenceInfo = value; }
        }

        public string xReminderInfo 
        {
            get { return ReminderInfo; }
            set { ReminderInfo = value; }
        }

        public object xResourceId 
        {
            get { return ResourceID; }
            set 
            { 
                if(value is int)
                    ResourceID = (int)value; 
            }
        }

    }

   
}
