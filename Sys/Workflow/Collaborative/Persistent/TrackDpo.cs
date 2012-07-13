using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Tie;
using Sys.Data;
using Sys.Data.Manager;
using Sys.Workflow.Dpo;
using System.Windows.Forms;
using System.Drawing;
using Sys.PersistentObjects.Dpo;

namespace Sys.Workflow.Collaborative
{
    public class TrackDpo : wfTrackDpo 
    {
        public TrackDpo()
        {
        }

        public TrackDpo(DataRow dataRow)
            : base(dataRow)
        { 
        }


        public void Add(CollaborativeActivity activity)
        {
            this.WorkflowInstance_ID = activity.WorkflowInstance.Data.PIN;
            this.S2_Name = activity.State.StateName;
            this.User_ID = Sys.Security.Account.CurrentUser.UserID;
            this.Date_Created = DateTime.Now;

            foreach (VAL s in activity.Data.PS)
            {
                this.S1_Name = s.Str;
                Save();
            }
        }



        public static void AddTrack(CollaborativeActivity activity)
        {
            TrackDpo dpo = new TrackDpo();
            dpo.Add(activity);
        }
    }
}
