//
// Machine Packed Data
//   by devel at 7/19/2012 2:59:10 PM
//
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Sys;
using Sys.Data;
using Sys.Data.Manager;
using Sys.Foundation.DpoClass;

namespace Sys.Foundation.DpoPackage
{
	public class ConfigurationDpoPackage : BasePackage<ConfigurationDpo>
	{

		public ConfigurationDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new ConfigurationDpo();
			dpo.ID = 1;
			dpo.ParentID = 0;
			dpo.OrderBy = 0;
			dpo.key_name = "Path.Document";
			dpo.value = "\"\\\\\\\\nas\\\\data\\\\Documents\"";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 2;
			dpo.ParentID = 0;
			dpo.OrderBy = 0;
			dpo.key_name = "Path.Executable.Install";
			dpo.value = "\"http://www.datconn.com/medsys/setup.exe\"";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 3;
			dpo.ParentID = 0;
			dpo.OrderBy = 0;
			dpo.key_name = "Path.Image";
			dpo.value = "\"\\\\\\\\nas\\\\data\\\\Images\"";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 4;
			dpo.ParentID = 0;
			dpo.OrderBy = 0;
			dpo.key_name = "Policy.Password.Default";
			dpo.value = "\"default\"";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 5;
			dpo.ParentID = 0;
			dpo.OrderBy = 0;
			dpo.key_name = "Policy.Password.Expired.Days";
			dpo.value = "30";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 6;
			dpo.ParentID = 0;
			dpo.OrderBy = 0;
			dpo.key_name = "Revision";
			dpo.value = "0";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 7;
			dpo.ParentID = 0;
			dpo.OrderBy = 0;
			dpo.key_name = "Security.Classes";
			dpo.value = @"{""System.Windows.Forms.Button"",""System.Windows.Forms.LinkLabel"",""System.Windows.Forms.ToolStripButton"",""System.Windows.Forms.ToolStripSplitButton"",""System.Windows.Forms.TextBox"",""System.Windows.Forms.ToolStripMenuItem"",""System.Windows.Forms.CheckBox"",""DevExpress.XtraEditors.SimpleButton""}";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 8;
			dpo.ParentID = 0;
			dpo.Label = "Imap";
			dpo.OrderBy = 0;
			dpo.key_name = "server.imap";
			dpo.value = "{host:\"imap.1and1.com\", port:143, ssl:false}";
			dpo.Inactive = true;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 9;
			dpo.ParentID = 0;
			dpo.Label = "Pop3";
			dpo.OrderBy = 0;
			dpo.key_name = "server.pop3";
			dpo.value = "{host:\"pop.1and1.com\", port:110, ssl:false}";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 10;
			dpo.ParentID = 0;
			dpo.Label = "Smtp";
			dpo.OrderBy = 0;
			dpo.key_name = "server.smtp";
			dpo.value = "{host:\"smtp.1and1.com\", port:587, ssl:false}";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 11;
			dpo.ParentID = 0;
			dpo.OrderBy = 0;
			dpo.key_name = "URL.ReleaseNotes";
			dpo.value = "\"http://www.datconn.com/medsys/releasenotes.html\"";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 12;
			dpo.ParentID = 0;
			dpo.OrderBy = 0;
			dpo.key_name = "URL.ReportIssue";
			dpo.value = "\"http://www.datconn.com/issues\"";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 13;
			dpo.ParentID = 0;
			dpo.OrderBy = 0;
			dpo.key_name = "Version.Database";
			dpo.value = "\"1.0.0.0\"";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 14;
			dpo.ParentID = 0;
			dpo.Label = "Active";
			dpo.OrderBy = 0;
			dpo.key_name = "Xmpp.Active";
			dpo.value = "false";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 15;
			dpo.ParentID = 0;
			dpo.Label = "Caps";
			dpo.OrderBy = 0;
			dpo.key_name = "Xmpp.Caps";
			dpo.value = " \"http://www.datconn.com/med/caps\"";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 16;
			dpo.ParentID = 0;
			dpo.Label = "Host";
			dpo.OrderBy = 0;
			dpo.key_name = "Xmpp.Host";
			dpo.value = "\"www.datconn.com\"";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 17;
			dpo.ParentID = 0;
			dpo.Label = "MucServices";
			dpo.OrderBy = 0;
			dpo.key_name = "Xmpp.MucServices";
			dpo.value = "{\"conference.datconn.coml\",\"chat.datconn.com\"}";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 18;
			dpo.ParentID = 0;
			dpo.Label = "Port";
			dpo.OrderBy = 0;
			dpo.key_name = "Xmpp.Port";
			dpo.value = "5222";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 19;
			dpo.ParentID = 0;
			dpo.Label = "Priority";
			dpo.OrderBy = 0;
			dpo.key_name = "Xmpp.Priority";
			dpo.value = "10";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 20;
			dpo.ParentID = 0;
			dpo.Label = "ReceivedFiles";
			dpo.OrderBy = 0;
			dpo.key_name = "Xmpp.ReceivedFiles";
			dpo.value = "\"C:\\\\Received Files\"";
			dpo.Inactive = false;
			list.Add(dpo);

			dpo = new ConfigurationDpo();
			dpo.ID = 21;
			dpo.ParentID = 0;
			dpo.Label = "Resource";
			dpo.OrderBy = 0;
			dpo.key_name = "Xmpp.Resource";
			dpo.value = "\"MED\"";
			dpo.Inactive = false;
			list.Add(dpo);

		}

	}
}
