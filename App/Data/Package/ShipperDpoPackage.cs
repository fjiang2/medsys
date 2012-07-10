//
// Machine Packed Data
//   by devel at 7/9/2012 3:33:33 PM
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
	public class ShipperDpoPackage : BasePackage<ShipperDpo>
	{

		public ShipperDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new ShipperDpo();
			dpo.ShipperID = 1;
			dpo.CompanyName = "Speedy Express";
			dpo.Phone = "(503) 555-9831";
			list.Add(dpo);

			dpo = new ShipperDpo();
			dpo.ShipperID = 2;
			dpo.CompanyName = "United Package";
			dpo.Phone = "(503) 555-3199";
			list.Add(dpo);

			dpo = new ShipperDpo();
			dpo.ShipperID = 3;
			dpo.CompanyName = "Federal Shipping";
			dpo.Phone = "(503) 555-9931";
			list.Add(dpo);

		}

	}
}
