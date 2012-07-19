//
// Machine Packed Data
//   by devel at 7/9/2012 3:33:35 PM
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
	public class wfTransitionDpoPackage : BasePackage<wfTransitionDpo>
	{

		public wfTransitionDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new wfTransitionDpo();
			dpo.ID = 1;
			dpo.Workflow_Name = "W1";
			dpo.S1_Name = "S1";
			dpo.S2_Name = "S2";
			dpo.Directional = false;
			dpo.Expression = "this.s2.from(this.s1) && this.s1.Completed";
			list.Add(dpo);

			dpo = new wfTransitionDpo();
			dpo.ID = 2;
			dpo.Workflow_Name = "W1";
			dpo.S1_Name = "S1";
			dpo.S2_Name = "S3";
			dpo.Directional = false;
			dpo.Expression = "this.s1.Completed";
			list.Add(dpo);

			dpo = new wfTransitionDpo();
			dpo.ID = 3;
			dpo.Workflow_Name = "W1";
			dpo.S1_Name = "S1";
			dpo.S2_Name = "S4";
			dpo.Directional = false;
			dpo.Expression = "this.s1.Completed";
			list.Add(dpo);

			dpo = new wfTransitionDpo();
			dpo.ID = 4;
			dpo.Workflow_Name = "W1";
			dpo.S1_Name = "S2";
			dpo.S2_Name = "S5";
			dpo.Directional = false;
			dpo.Expression = "this.s1.Completed";
			list.Add(dpo);

			dpo = new wfTransitionDpo();
			dpo.ID = 5;
			dpo.Workflow_Name = "W1";
			dpo.S1_Name = "S2";
			dpo.S2_Name = "S9";
			dpo.Directional = false;
			dpo.Expression = "this.s1.Completed";
			list.Add(dpo);

			dpo = new wfTransitionDpo();
			dpo.ID = 6;
			dpo.Workflow_Name = "W1";
			dpo.S1_Name = "S3";
			dpo.S2_Name = "S5";
			dpo.Directional = false;
			dpo.Expression = "this.s1.Completed";
			list.Add(dpo);

			dpo = new wfTransitionDpo();
			dpo.ID = 7;
			dpo.Workflow_Name = "W1";
			dpo.S1_Name = "S3";
			dpo.S2_Name = "S6";
			dpo.Directional = false;
			dpo.Expression = "this.s1.Completed";
			list.Add(dpo);

			dpo = new wfTransitionDpo();
			dpo.ID = 8;
			dpo.Workflow_Name = "W1";
			dpo.S1_Name = "S4";
			dpo.S2_Name = "S6";
			dpo.Directional = false;
			dpo.Expression = "this.s1.Completed";
			list.Add(dpo);

			dpo = new wfTransitionDpo();
			dpo.ID = 9;
			dpo.Workflow_Name = "W1";
			dpo.S1_Name = "S5";
			dpo.S2_Name = "S7";
			dpo.Directional = false;
			dpo.Expression = "this.s1.Completed";
			list.Add(dpo);

			dpo = new wfTransitionDpo();
			dpo.ID = 10;
			dpo.Workflow_Name = "W1";
			dpo.S1_Name = "S6";
			dpo.S2_Name = "S8";
			dpo.Directional = false;
			dpo.Expression = "this.s1.Completed";
			list.Add(dpo);

			dpo = new wfTransitionDpo();
			dpo.ID = 11;
			dpo.Workflow_Name = "W1";
			dpo.S1_Name = "S7";
			dpo.S2_Name = "S10";
			dpo.Directional = false;
			dpo.Expression = "this.s1.Results.Yes";
			list.Add(dpo);

			dpo = new wfTransitionDpo();
			dpo.ID = 12;
			dpo.Workflow_Name = "W1";
			dpo.S1_Name = "S7";
			dpo.S2_Name = "S2";
			dpo.Directional = false;
			dpo.Expression = "this.s2.from(this.s1) && !this.s1.Results.Yes";
			list.Add(dpo);

			dpo = new wfTransitionDpo();
			dpo.ID = 13;
			dpo.Workflow_Name = "W1";
			dpo.S1_Name = "S8";
			dpo.S2_Name = "S10";
			dpo.Directional = false;
			dpo.Expression = "this.s1.Completed";
			list.Add(dpo);

			dpo = new wfTransitionDpo();
			dpo.ID = 14;
			dpo.Workflow_Name = "W1";
			dpo.S1_Name = "S9";
			dpo.S2_Name = "S7";
			dpo.Directional = false;
			dpo.Expression = "this.s1.Completed";
			list.Add(dpo);

		}

	}
}
