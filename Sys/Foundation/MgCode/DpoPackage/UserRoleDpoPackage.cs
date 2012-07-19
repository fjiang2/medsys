//
// Machine Packed Data
//   by devel at 7/19/2012 12:14:09 AM
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
	public class UserRoleDpoPackage : BasePackage<UserRoleDpo>
	{

		public UserRoleDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new UserRoleDpo();
			dpo.UR_ID = 1;
			dpo.User_ID = 0;
			dpo.Role_ID = 0;
			list.Add(dpo);

			dpo = new UserRoleDpo();
			dpo.UR_ID = 2;
			dpo.User_ID = 1;
			dpo.Role_ID = 1;
			list.Add(dpo);

			dpo = new UserRoleDpo();
			dpo.UR_ID = 3;
			dpo.User_ID = 1;
			dpo.Role_ID = 2;
			list.Add(dpo);

			dpo = new UserRoleDpo();
			dpo.UR_ID = 5;
			dpo.User_ID = 3;
			dpo.Role_ID = 3;
			list.Add(dpo);

			dpo = new UserRoleDpo();
			dpo.UR_ID = 4;
			dpo.User_ID = 3;
			dpo.Role_ID = 5;
			list.Add(dpo);

			dpo = new UserRoleDpo();
			dpo.UR_ID = 6;
			dpo.User_ID = 3;
			dpo.Role_ID = 6;
			list.Add(dpo);

		}

	}
}
