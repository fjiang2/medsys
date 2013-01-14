using System;
using System.Collections.Generic;
using System.Text;
using Sys.Security;
using Sys.ViewManager.Forms;
using Sys.Data;
using System.Data;
using Sys.Platform.Forms;

namespace Sys.Platform
{
    public class MailKeyWord
    {
        Dictionary<string, string> keywords = new Dictionary<string, string>();
        DataRow dataRow;

        public MailKeyWord(DataRow dataRow)
        {
            this.dataRow= dataRow;
        }

        public void Parse(int mailID, SendMailForm email, string formName)
        {
            dataRow["MailID"] = mailID;

            email.From = dataRow["MailFrom"] as string;
            email.To = dataRow["MailTo"] as string;
            email.Cc = dataRow["Cc"] as string;
            email.Subject  = dataRow["Subject"] as string;
            email.Body = dataRow["Body"] as string;


            Sys.Security.Account me = Sys.Security.Account.CurrentUser;
            Sys.Security.Account supervisor = new Sys.Security.Account(me.Supervisor);

            keywords.Add("<%EmployeeID%>", me.UserName);
            keywords.Add("<%EmployeeName%>", me.Name);
            keywords.Add("<%EmployeeFirstName%>", me.FirstName);
            keywords.Add("<%EmployeeLastName%>", me.LastName);
            keywords.Add("<%EmployeeEmail%>",  me.FullEmailAddress);

            keywords.Add("<%SupervisorID%>", supervisor.UserName);
            keywords.Add("<%SupervisorName%>", supervisor.Name);
            keywords.Add("<%SupervisorFirstName%>", supervisor.FirstName);
            keywords.Add("<%SupervisorLastName%>", supervisor.LastName);
            keywords.Add("<%SupervisorEmail%>", supervisor.FullEmailAddress);

            keywords.Add("<%FormName%>", formName);
            keywords.Add("<%Date%>", DateTime.Now.ToShortDateString());

            foreach (KeyValuePair<string, string> kvp in keywords)
            {
                email.From      = email.From.Replace(kvp.Key, kvp.Value);
                email.To        = email.To.Replace(kvp.Key, kvp.Value);
                email.Subject   = email.Subject.Replace(kvp.Key, kvp.Value);
                email.Body      = email.Body.Replace(kvp.Key, kvp.Value);
                email.Cc        = email.Cc.Replace(kvp.Key, kvp.Value);
                email.Attachment = email.Attachment.Replace(kvp.Key, kvp.Value);
            
            }
            email.Body = email.Body.Replace("\\n", "\n");

            
        }
    }
}
