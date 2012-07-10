//
// Machine Packed Data
//   by devel at 5/9/2012 6:30:58 AM
//
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Sys;
using Sys.Data;
using Sys.DataManager;
using App.Data.Dpo;

namespace App.Data.Package
{
	public class RegionDpoPackage : BasePackage<RegionDpo>
	{

		public RegionDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new RegionDpo();
			dpo.RegionID = 1;
			dpo.RegionDescription = "Eastern                                           ";
			list.Add(dpo);

			dpo = new RegionDpo();
			dpo.RegionID = 2;
			dpo.RegionDescription = "Western                                           ";
			list.Add(dpo);

			dpo = new RegionDpo();
			dpo.RegionID = 3;
			dpo.RegionDescription = "Northern                                          ";
			list.Add(dpo);

			dpo = new RegionDpo();
			dpo.RegionID = 4;
			dpo.RegionDescription = "Southern                                          ";
			list.Add(dpo);

		}

	}
}
