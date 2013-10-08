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
using Sys.Foundation.DpoClass;

namespace Sys.Foundation.DpoPackage
{
	public class AssemblyDpoPackage : BasePackage<AssemblyDpo>
	{

		public AssemblyDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new AssemblyDpo();
			dpo.ID = 11;
			dpo.AssemblyName = "App.Data";
			dpo.FullName = "App.Data";
			dpo.Inactive = false;
			dpo.Location = "App\\Data";
			list.Add(dpo);

			dpo = new AssemblyDpo();
			dpo.ID = 18;
			dpo.AssemblyName = "PTA";
			dpo.FullName = "PTA";
			dpo.Label = "PTA";
			dpo.Inactive = false;
			dpo.Location = "App\\PTA";
			list.Add(dpo);

			dpo = new AssemblyDpo();
			dpo.ID = 15;
			dpo.AssemblyName = "Sys.BusinessRules";
			dpo.FullName = "Sys.BusinessRules";
			dpo.Label = "Rule";
			dpo.Inactive = false;
			dpo.Location = "Sys\\BusinessRules";
			list.Add(dpo);

			dpo = new AssemblyDpo();
			dpo.ID = 10;
			dpo.AssemblyName = "Sys.DataManager";
			dpo.FullName = "Sys.DataManager";
			dpo.Inactive = false;
			dpo.Location = "Sys\\DataManager";
			list.Add(dpo);

			dpo = new AssemblyDpo();
			dpo.ID = 12;
			dpo.AssemblyName = "Sys.Foundation";
			dpo.FullName = "Sys.Foundation";
			dpo.Inactive = false;
			dpo.Location = "Sys\\Foundation";
			list.Add(dpo);

			dpo = new AssemblyDpo();
			dpo.ID = 2;
			dpo.AssemblyName = "Sys.Messaging";
			dpo.FullName = "Sys.Messaging";
			dpo.Inactive = false;
			dpo.Location = "Sys\\Messaging";
			list.Add(dpo);

			dpo = new AssemblyDpo();
			dpo.ID = 14;
			dpo.AssemblyName = "Sys.PersistentObjects";
			dpo.FullName = "Sys.PersistentObjects";
			dpo.Label = "DPO";
			dpo.Inactive = false;
			dpo.Location = "Sys\\PersistentObjects";
			list.Add(dpo);

			dpo = new AssemblyDpo();
			dpo.ID = 3;
			dpo.AssemblyName = "Sys.Platform";
			dpo.FullName = "Sys.Platform";
			dpo.Inactive = false;
			dpo.Location = "Sys\\Platform";
			list.Add(dpo);

			dpo = new AssemblyDpo();
			dpo.ID = 6;
			dpo.AssemblyName = "Sys.Report";
			dpo.FullName = "Sys.Report";
			dpo.Label = "REPORT";
			dpo.Inactive = true;
			dpo.Location = "Sys\\Report";
			list.Add(dpo);

			dpo = new AssemblyDpo();
			dpo.ID = 4;
			dpo.AssemblyName = "Sys.SmartList";
			dpo.FullName = "Sys.SmartList";
			dpo.Label = "SMARTLIST";
			dpo.Inactive = false;
			dpo.Location = "Sys\\SmartList";
			list.Add(dpo);

			dpo = new AssemblyDpo();
			dpo.ID = 1;
			dpo.AssemblyName = "Sys.ViewManager";
			dpo.FullName = "Sys.ViewManager";
			dpo.Inactive = false;
			dpo.Location = "Sys\\ViewManager";
			list.Add(dpo);

			dpo = new AssemblyDpo();
			dpo.ID = 5;
			dpo.AssemblyName = "Sys.Workflow";
			dpo.FullName = "Sys.Workflow";
			dpo.Label = "WORKFLOW";
			dpo.Inactive = false;
			dpo.Location = "Sys\\Workflow";
			list.Add(dpo);

			dpo = new AssemblyDpo();
			dpo.ID = 16;
			dpo.AssemblyName = "X12";
			dpo.FullName = "X12";
			dpo.Label = "X12";
			dpo.Inactive = false;
			dpo.Location = "App\\X12";
			list.Add(dpo);

		}

	}
}
