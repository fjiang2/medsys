using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Tie;
using Sys.Data;
using Sys.DataManager;
using Sys.Workflow.Dpo;
using System.Windows.Forms;
using System.Drawing;
using Sys.Foundation.Dpo;

namespace Sys.Workflow.Collaborative
{
    public class NoteDpo : wfNoteDpo
    {
        CollaborativeActivity activity;

        /// <summary>
        /// Read note
        /// </summary>
        /// <param name="activity"></param>
        private NoteDpo(CollaborativeActivity activity)
        {
            this.activity = activity;
        }

        /// <summary>
        /// Create new note
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="toStateName"></param>
        public NoteDpo(CollaborativeActivity activity, string toStateName)
        {
            this.activity = activity;

            this.WorkflowInstance_ID = activity.WorkflowInstance.Data.PIN;
            this.S1_Name = activity.State.StateName;
            this.User_ID = Sys.Security.Account.CurrentUser.UserID;
            this.Date_Created = DateTime.Now;

            this.S2_Name = toStateName;
        }


        public static void LoadHistory(CollaborativeActivity activity, RichTextBox rtf)
        {
            NoteDpo dpo = new NoteDpo(activity);
            dpo.ReadHistory(rtf);
        }
      

        private void ReadHistory(RichTextBox rtf)
        {
            string SQL = @"
                SELECT U.User_Name, U.First_Name, U.Last_Name, N.*
                FROM {0} N
                INNER JOIN {1} U ON U.User_ID = N.User_ID
                WHERE WorkflowInstance_ID = {2}
                      AND ( S1_Name = '{3}' OR S2_Name='{3}')
                ORDER BY Date_Created
            ";
      
            DataTable dataTable = SqlCmd.FillDataTable(SQL, this.TableName, UserDpo.TABLE_NAME, activity.WorkflowInstance.Data.PIN, activity.State.StateName);

            NoteHistory history = new NoteHistory(rtf, activity.State.StateName);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                string name = string.Format("{0} {1} ({2})", dataRow[UserDpo._First_Name], dataRow[UserDpo._Last_Name], dataRow[UserDpo._User_Name]);
                DateTime time = (DateTime)dataRow[_Date_Created];
                string comment = (string)dataRow[_Comment];
                string S1_Name = (string)dataRow[_S1_Name];
                string S2_Name = (string)dataRow[_S2_Name];

                history.WriteNote(name, S1_Name, S2_Name, time, comment);

            }
            
            return ;
        }


        public void Add(string comment, RichTextBox rtf)
        {
            NoteHistory history = new NoteHistory(rtf, activity.State.StateName);
            this.Comment = comment;
            this.Save();

            history.AddNote(this);
        }

    
      

       

     
    }
}
