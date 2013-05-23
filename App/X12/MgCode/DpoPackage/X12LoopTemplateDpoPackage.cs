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
using X12.DpoClass;

namespace X12.DpoPackage
{
	public class X12LoopTemplateDpoPackage : BasePackage<X12LoopTemplateDpo>
	{

		public X12LoopTemplateDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new X12LoopTemplateDpo();
			dpo.ID = 1;
			dpo.ParentID = 49;
			dpo.Name = "1000A";
			dpo.Sequence = 1;
			dpo.Description = "SUBMITTER NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 2;
			dpo.ParentID = 49;
			dpo.Name = "1000B";
			dpo.Sequence = 2;
			dpo.Description = "RECEIVER NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 4;
			dpo.ParentID = 49;
			dpo.Name = "2000A";
			dpo.Sequence = 4;
			dpo.Description = "BILLING PROVIDER HIERARCHICAL LEVEL";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = -1;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 10;
			dpo.ParentID = 4;
			dpo.Name = "2000B";
			dpo.Sequence = 10;
			dpo.Description = "SUBSCRIBER HIERARCHICAL LEVEL";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = -1;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 13;
			dpo.ParentID = 10;
			dpo.Name = "2000C";
			dpo.Sequence = 13;
			dpo.Description = "PATIENT HIERARCHICAL LEVEL";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = -1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 5;
			dpo.ParentID = 4;
			dpo.Name = "2010AA";
			dpo.Sequence = 5;
			dpo.Description = "BILLING PROVIDER NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 6;
			dpo.ParentID = 4;
			dpo.Name = "2010AB";
			dpo.Sequence = 6;
			dpo.Description = "PAY-TO ADDRESS NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 9;
			dpo.ParentID = 4;
			dpo.Name = "2010AC";
			dpo.Sequence = 9;
			dpo.Description = "PAY-TO PLAN NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 11;
			dpo.ParentID = 10;
			dpo.Name = "2010BA";
			dpo.Sequence = 11;
			dpo.Description = "SUBSCRIBER NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 12;
			dpo.ParentID = 10;
			dpo.Name = "2010BB";
			dpo.Sequence = 12;
			dpo.Description = "PAYER NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 14;
			dpo.ParentID = 13;
			dpo.Name = "2010CA";
			dpo.Sequence = 14;
			dpo.Description = "PATIENT NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 15;
			dpo.ParentID = 13;
			dpo.Name = "2300";
			dpo.Sequence = 15;
			dpo.Description = "CLAIM INFORMATION";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 100;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 17;
			dpo.ParentID = 15;
			dpo.Name = "2310A";
			dpo.Sequence = 17;
			dpo.Description = "REFERRING PROVIDER NAME";
			dpo.MinRepeat = 2;
			dpo.MaxRepeat = 2;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 18;
			dpo.ParentID = 15;
			dpo.Name = "2310B";
			dpo.Sequence = 18;
			dpo.Description = "RENDERING PROVIDER NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 19;
			dpo.ParentID = 15;
			dpo.Name = "2310C";
			dpo.Sequence = 19;
			dpo.Description = "SERVICE FACILITY LOCATION NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 20;
			dpo.ParentID = 15;
			dpo.Name = "2310D";
			dpo.Sequence = 20;
			dpo.Description = "SUPERVISING PROVIDER NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 21;
			dpo.ParentID = 15;
			dpo.Name = "2310E";
			dpo.Sequence = 21;
			dpo.Description = "AMBULANCE PICK-UP LOCATION";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 22;
			dpo.ParentID = 15;
			dpo.Name = "2310F";
			dpo.Sequence = 22;
			dpo.Description = "AMBULANCE DROP-OFF LOCATION";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 23;
			dpo.ParentID = 15;
			dpo.Name = "2320";
			dpo.Sequence = 23;
			dpo.Description = "OTHER SUBSCRIBER INFORMATION";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 10;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 24;
			dpo.ParentID = 23;
			dpo.Name = "2330A";
			dpo.Sequence = 24;
			dpo.Description = "OTHER SUBSCRIBER NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 25;
			dpo.ParentID = 23;
			dpo.Name = "2330B";
			dpo.Sequence = 25;
			dpo.Description = "OTHER PAYER NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 26;
			dpo.ParentID = 23;
			dpo.Name = "2330C";
			dpo.Sequence = 26;
			dpo.Description = "OTHER PAYER REFERRING PROVIDER";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 2;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 28;
			dpo.ParentID = 23;
			dpo.Name = "2330D";
			dpo.Sequence = 28;
			dpo.Description = "OTHER PAYER RENDERING PROVIDER";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 29;
			dpo.ParentID = 23;
			dpo.Name = "2330E";
			dpo.Sequence = 29;
			dpo.Description = "OTHER PAYER SERVICE FACILITY LOCATION";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 30;
			dpo.ParentID = 23;
			dpo.Name = "2330F";
			dpo.Sequence = 30;
			dpo.Description = "OTHER PAYER SUPERVISING PROVIDER";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 31;
			dpo.ParentID = 23;
			dpo.Name = "2330G";
			dpo.Sequence = 31;
			dpo.Description = "OTHER PAYER BILLING PROVIDER";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 32;
			dpo.ParentID = 15;
			dpo.Name = "2400";
			dpo.Sequence = 32;
			dpo.Description = "SERVICE LINE NUMBER";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 50;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 33;
			dpo.ParentID = 32;
			dpo.Name = "2410";
			dpo.Sequence = 33;
			dpo.Description = "DRUG IDENTIFICATION";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 34;
			dpo.ParentID = 32;
			dpo.Name = "2420A";
			dpo.Sequence = 34;
			dpo.Description = "RENDERING PROVIDER NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 35;
			dpo.ParentID = 32;
			dpo.Name = "2420B";
			dpo.Sequence = 35;
			dpo.Description = "PURCHASED SERVICE PROVIDER NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 36;
			dpo.ParentID = 32;
			dpo.Name = "2420C";
			dpo.Sequence = 36;
			dpo.Description = "SERVICE FACILITY LOCATION NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 37;
			dpo.ParentID = 32;
			dpo.Name = "2420D";
			dpo.Sequence = 37;
			dpo.Description = "SUPERVISING PROVIDER NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 38;
			dpo.ParentID = 32;
			dpo.Name = "2420E";
			dpo.Sequence = 38;
			dpo.Description = "ORDERING PROVIDER NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 39;
			dpo.ParentID = 32;
			dpo.Name = "2420F";
			dpo.Sequence = 39;
			dpo.Description = "REFERRING PROVIDER NAME";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 2;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 40;
			dpo.ParentID = 32;
			dpo.Name = "2420G";
			dpo.Sequence = 40;
			dpo.Description = "AMBULANCE PICK-UP LOCATION";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 41;
			dpo.ParentID = 32;
			dpo.Name = "2420H";
			dpo.Sequence = 41;
			dpo.Description = "AMBULANCE DROP-OFF LOCATION";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 42;
			dpo.ParentID = 32;
			dpo.Name = "2430";
			dpo.Sequence = 42;
			dpo.Description = "LINE ADJUDICATION INFORMATION";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 15;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 43;
			dpo.ParentID = 32;
			dpo.Name = "2440";
			dpo.Sequence = 43;
			dpo.Description = "FORM IDENTIFICATION CODE";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = -1;
			dpo.Required = false;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 52;
			dpo.ParentID = 49;
			dpo.Name = "BHT";
			dpo.Sequence = 0;
			dpo.Description = "Beginning of Hierarchical Transaction";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 55;
			dpo.ParentID = 45;
			dpo.Name = "GE";
			dpo.Sequence = 1;
			dpo.Description = "Functional Group Trailer";
			dpo.MinRepeat = 0;
			dpo.MaxRepeat = 1;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 47;
			dpo.ParentID = 45;
			dpo.Name = "GS";
			dpo.Sequence = 0;
			dpo.Description = "Functional Group Header";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = -1;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 56;
			dpo.ParentID = 0;
			dpo.Name = "IEA";
			dpo.Sequence = 1;
			dpo.Description = "Interchange Control Trailer";
			dpo.MinRepeat = 0;
			dpo.MaxRepeat = 1;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 45;
			dpo.ParentID = 0;
			dpo.Name = "ISA";
			dpo.Sequence = 0;
			dpo.Description = "Interchange Control Header";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = 1;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 54;
			dpo.ParentID = 47;
			dpo.Name = "SE";
			dpo.Sequence = 1;
			dpo.Description = "Transaction Set Trailer";
			dpo.MinRepeat = 0;
			dpo.MaxRepeat = 1;
			dpo.Required = true;
			list.Add(dpo);

			dpo = new X12LoopTemplateDpo();
			dpo.ID = 49;
			dpo.ParentID = 47;
			dpo.Name = "ST";
			dpo.Sequence = 0;
			dpo.Description = "Transaction Set header";
			dpo.MinRepeat = 1;
			dpo.MaxRepeat = -1;
			dpo.Required = true;
			list.Add(dpo);

		}

	}
}
