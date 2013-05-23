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
	public class RoleDpoPackage : BasePackage<RoleDpo>
	{

		public RoleDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new RoleDpo();
			dpo.Role_ID = 0;
			dpo.Role_Name = "Developer";
			dpo.Parent_Role_ID = -1;
			list.Add(dpo);

			dpo = new RoleDpo();
			dpo.Role_ID = 1;
			dpo.Role_Name = "Admin";
			dpo.Parent_Role_ID = -1;
			list.Add(dpo);

			dpo = new RoleDpo();
			dpo.Role_ID = 2;
			dpo.Role_Name = "Security";
			dpo.Parent_Role_ID = -1;
			list.Add(dpo);

			dpo = new RoleDpo();
			dpo.Role_ID = 3;
			dpo.Role_Name = "Xmpp Developer";
			dpo.Parent_Role_ID = 0;
			list.Add(dpo);

			dpo = new RoleDpo();
			dpo.Role_ID = 4;
			dpo.Role_Name = "Instant Messaging";
			dpo.Parent_Role_ID = 1;
			list.Add(dpo);

			dpo = new RoleDpo();
			dpo.Role_ID = 5;
			dpo.Role_Name = "ReportViewer";
			dpo.Parent_Role_ID = 1;
			list.Add(dpo);

			dpo = new RoleDpo();
			dpo.Role_ID = 6;
			dpo.Role_Name = "User";
			list.Add(dpo);

		}

	}
}
