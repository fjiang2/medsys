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
using Sys.ViewManager.Dpo;

namespace Sys.ViewManager.Package
{
	public class DataImportDpoPackage : BasePackage<DataImportDpo>
	{

		public DataImportDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new DataImportDpo();
			dpo.ID = 1;
			dpo.Label = "Demo";
			dpo.DataSource = "SELECT * FROM Demo";
			dpo.ClassName = "Sys.Platform.ExcelImporter";
			dpo.Mapping = "{{\"Nomen\",{\"System.String\",\"\"}},{\"Location\",{\"System.String\",\"\"}}}";
			dpo.ActionButtonName = "";
			list.Add(dpo);

		}

	}
}
