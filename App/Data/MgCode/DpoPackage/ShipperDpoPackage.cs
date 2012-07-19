//
// Machine Packed Data
//   by devel at 7/18/2012 10:55:30 PM
//
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Sys;
using Sys.Data;
using Sys.Data.Manager;
using App.Data.DpoClass;

namespace App.Data.DpoPackage
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
