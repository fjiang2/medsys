//
// Machine Packed Data
//   by devel
//
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Sys;
using Sys.Data;
using Sys.Data.Manager;
using Sys.Workflow.DpoClass;

namespace Sys.Workflow.DpoPackage
{
	public class wfWorkflowDpoPackage : BasePackage<wfWorkflowDpo>
	{

		public wfWorkflowDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new wfWorkflowDpo();
			dpo.ID = 4;
			dpo.ParentID = 0;
			dpo.Name = "W1";
			dpo.Company = "BES";
			dpo.Label = "Workflow demo";
			dpo.Description = "";
			dpo.Metadata = @"{   
	Label : ""Workflow Demo"",   
	Description : ""This workflow is used for demo. Today is "" + System.DateTime.Now +""."",   
	Identifiers:    
		{              
		  SO:SO,          
		  TaskCard: ""N/A"",     
		  WorkTime: """"   
            } 
}";
			dpo.Released = true;
			dpo.Visible = true;
			dpo.Enabled = true;
			dpo.Deleted = false;
			dpo.Date_Created = new DateTime(2011,8,23,13,14,21);
			dpo.Creator = 1227;
			dpo.Date_Modified = new DateTime(2012,3,21,16,2,6);
			dpo.Modifier = 0;
			list.Add(dpo);

		}

	}
}
