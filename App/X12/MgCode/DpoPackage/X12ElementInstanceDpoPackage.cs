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
	public class X12ElementInstanceDpoPackage : BasePackage<X12ElementInstanceDpo>
	{

		public X12ElementInstanceDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new X12ElementInstanceDpo();
			dpo.ID = 331;
			dpo.ElementTemplate_ID = 1;
			dpo.SegmentInstance_ID = 214;
			dpo.Usage = 1;
			dpo.Description = "Authorization Information Qualifier";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 332;
			dpo.ElementTemplate_ID = 3;
			dpo.SegmentInstance_ID = 214;
			dpo.Usage = 1;
			dpo.Description = "Security Information Qualifier";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 333;
			dpo.ElementTemplate_ID = 5;
			dpo.SegmentInstance_ID = 214;
			dpo.Usage = 1;
			dpo.Description = @"Interchange ID Qualifier
Code indicating the system/method of code structure used to designate the sender or receiver ID element being qualified";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 334;
			dpo.ElementTemplate_ID = 7;
			dpo.SegmentInstance_ID = 214;
			dpo.Usage = 1;
			dpo.Description = "Interchange ID Qualifier";
			dpo.Situational_Rule = @"Code indicating the system/method of code structure used to designate the sender or receiver ID element being qualified";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 338;
			dpo.ElementTemplate_ID = 11;
			dpo.SegmentInstance_ID = 214;
			dpo.Usage = 1;
			dpo.Description = "Repetition Separator";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 335;
			dpo.ElementTemplate_ID = 12;
			dpo.SegmentInstance_ID = 214;
			dpo.Usage = 1;
			dpo.Description = "Interchange Control Version Number";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 336;
			dpo.ElementTemplate_ID = 14;
			dpo.SegmentInstance_ID = 214;
			dpo.Usage = 1;
			dpo.Description = "Code indicating sender's request for an interchange acknowledgment";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 337;
			dpo.ElementTemplate_ID = 15;
			dpo.SegmentInstance_ID = 214;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 339;
			dpo.ElementTemplate_ID = 23;
			dpo.SegmentInstance_ID = 215;
			dpo.Usage = 1;
			dpo.Description = @"Code identifying the issuer of the standard; this code is used in conjunction with Data Element 480";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 340;
			dpo.ElementTemplate_ID = 24;
			dpo.SegmentInstance_ID = 215;
			dpo.Usage = 1;
			dpo.Description = "Version / Release / Industry Identifier Code";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 341;
			dpo.ElementTemplate_ID = 29;
			dpo.SegmentInstance_ID = 216;
			dpo.Usage = 1;
			dpo.Description = "Transaction Set Identifier Code";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 342;
			dpo.ElementTemplate_ID = 32;
			dpo.SegmentInstance_ID = 217;
			dpo.Usage = 1;
			dpo.Description = @"Code indicating the hierarchical application structure of a transaction set that utilizes the HL segment to define the structure of the transaction set";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 343;
			dpo.ElementTemplate_ID = 33;
			dpo.SegmentInstance_ID = 217;
			dpo.Usage = 1;
			dpo.Description = "Code identifying purpose of transaction set";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 344;
			dpo.ElementTemplate_ID = 37;
			dpo.SegmentInstance_ID = 217;
			dpo.Usage = 2;
			dpo.Description = "Code specifying the type of transaction";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 1;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 1;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 7;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 3;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 10;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 7;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 15;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 13;
			dpo.Usage = 0;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 16;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 16;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 20;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 24;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individ";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 25;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 30;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 29;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 37;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 77;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 90;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 79;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 92;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 82;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 95;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 85;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 100;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 87;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 102;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 88;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 105;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 94;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 115;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 96;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 119;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 103;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 128;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 105;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 130;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 107;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 132;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 109;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 134;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 111;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 136;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 149;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 181;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 152;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 184;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 154;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 186;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 156;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 190;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 158;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 192;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 161;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 197;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 163;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 199;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 164;
			dpo.ElementTemplate_ID = 38;
			dpo.SegmentInstance_ID = 202;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 2;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 1;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity \r\nSEMANTIC: NM102 qualifies NM103.";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 174;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 3;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 178;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 7;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 183;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 13;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 184;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 16;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 196;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 30;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 203;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 37;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 246;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 90;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 248;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 92;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 251;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 95;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 255;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 100;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 257;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 102;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 258;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 105;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 265;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 115;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 267;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 119;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 270;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 128;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 271;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 130;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 272;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 132;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 273;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 134;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 274;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 136;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 311;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 181;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 313;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 184;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 315;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 186;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 317;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 190;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 319;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 192;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 324;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 197;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 326;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 199;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 327;
			dpo.ElementTemplate_ID = 39;
			dpo.SegmentInstance_ID = 202;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the type of entity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 4;
			dpo.ElementTemplate_ID = 40;
			dpo.SegmentInstance_ID = 1;
			dpo.Usage = 1;
			dpo.Description = "SEGMENT SYNTAX: C1203 \r\n INDUSTRY NAME: Submitter Last or Organization Name";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 5;
			dpo.ElementTemplate_ID = 41;
			dpo.SegmentInstance_ID = 1;
			dpo.Usage = 2;
			dpo.Description = "";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when NM102 = 1 (person) and the person has a first name. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 3;
			dpo.ElementTemplate_ID = 45;
			dpo.SegmentInstance_ID = 1;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 175;
			dpo.ElementTemplate_ID = 45;
			dpo.SegmentInstance_ID = 3;
			dpo.Usage = 0;
			dpo.Description = "Code designating the system/method of code structure used for Identification Code (67)";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 179;
			dpo.ElementTemplate_ID = 45;
			dpo.SegmentInstance_ID = 7;
			dpo.Usage = 0;
			dpo.Description = "Code designating the system/method of code structure used for Identification Code (67)";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 185;
			dpo.ElementTemplate_ID = 45;
			dpo.SegmentInstance_ID = 16;
			dpo.Usage = 0;
			dpo.Description = "Code designating the system/method of code structure used for Identification Code (67)";
			dpo.Situational_Rule = @"On or after the mandated implementation date for the HIPAA National Plan Identifier (National Plan ID), XV must be sent.

Prior to the mandated implementation date and prior to any phase-in period identified by Federal regulation, PI must be sent.

If a phase-in period is designated, PI must be sent unless:
1. Both the sender and receiver agree to use the National Plan ID, 
2. The receiver has a National Plan ID, and
3. The sender has the capability to send the National Plan ID.

If all of the above conditions are true, XV must be sent. In this case the Payer Identification Number that would have been sent using qualifier PI can be sent in the corresponding REF segment using qualifier 2U.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 192;
			dpo.ElementTemplate_ID = 45;
			dpo.SegmentInstance_ID = 24;
			dpo.Usage = 0;
			dpo.Description = "Code designating the system/method of code structure used for Identification Code (67)";
			dpo.Situational_Rule = "Required when NM102 = 1 (person). If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 197;
			dpo.ElementTemplate_ID = 45;
			dpo.SegmentInstance_ID = 30;
			dpo.Usage = 0;
			dpo.Description = "Code designating the system/method of code structure used for Identification Code (67)";
			dpo.Situational_Rule = @"On or after the mandated implementation date for the HIPAA National Plan Identifier (National Plan ID), XV must be sent.

Prior to the mandated implementation date and prior to any phase-in period identified by Federal regulation, PI must be sent.

If a phase-in period is designated, PI must be sent unless:
1. Both the sender and receiver agree to use the National Plan ID, 
2. The receiver has a National Plan ID, and
3. The sender has the capability to send the National Plan ID.

If all of the above conditions are true, XV must be sent. In this case the Payer Identification Number that would have been sent using qualifier PI can be sent in the corresponding REF segment using qualifier 2U.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 247;
			dpo.ElementTemplate_ID = 45;
			dpo.SegmentInstance_ID = 90;
			dpo.Usage = 0;
			dpo.Description = "Code designating the system/method of code structure used for Identification Code (67)";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required for providers on or after the mandated HIPAA National Provider Identifier (NPI) implementation date when the provider has received an NPI and the NPI is available to the submitter.
OR
Required for providers prior to the mandated HIPAA NPI implementation date when the provider has received an NPI and the submitter has the capability to send it.
If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 249;
			dpo.ElementTemplate_ID = 45;
			dpo.SegmentInstance_ID = 92;
			dpo.Usage = 0;
			dpo.Description = "Code designating the system/method of code structure used for Identification Code (67)";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 252;
			dpo.ElementTemplate_ID = 45;
			dpo.SegmentInstance_ID = 95;
			dpo.Usage = 0;
			dpo.Description = "Code designating the system/method of code structure used for Identification Code (67)";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 256;
			dpo.ElementTemplate_ID = 45;
			dpo.SegmentInstance_ID = 100;
			dpo.Usage = 0;
			dpo.Description = "Code designating the system/method of code structure used for Identification Code (67)";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required for providers in the United States or its territories on or after the mandated HIPAA National Provider Identifier (NPI) implementation date when the provider is eligible to receive an NPI.
OR
Required for providers not in the United States or its territories on or after the mandated HIPAA National Provider Identifier (NPI) implementation date when the provider has received an NPI.
OR
Required for providers prior to the mandated NPI implementation date when the provider has received an NPI and the submitter has the capability to send it.
If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 266;
			dpo.ElementTemplate_ID = 45;
			dpo.SegmentInstance_ID = 115;
			dpo.Usage = 0;
			dpo.Description = "Code designating the system/method of code structure used for Identification Code (67)";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 268;
			dpo.ElementTemplate_ID = 45;
			dpo.SegmentInstance_ID = 119;
			dpo.Usage = 0;
			dpo.Description = "Code designating the system/method of code structure used for Identification Code (67)";
			dpo.Situational_Rule = @"On or after the mandated implementation date for the HIPAA National Plan Identifier (National Plan ID), XV must be sent.

Prior to the mandated implementation date and prior to any phase-in period identified by Federal regulation, PI must be sent.

If a phase-in period is designated, PI must be sent unless:
1. Both the sender and receiver agree to use the National Plan ID, 
2. The receiver has a National Plan ID, and
3. The sender has the capability to send the National Plan ID.

If all of the above conditions are true, XV must be sent. In this case the Payer Identification Number that would have been sent using qualifier PI can be sent in the corresponding REF segment using qualifier 2U.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 314;
			dpo.ElementTemplate_ID = 45;
			dpo.SegmentInstance_ID = 184;
			dpo.Usage = 0;
			dpo.Description = "Code designating the system/method of code structure used for Identification Code (67)";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required for providers on or after the mandated HIPAA National Provider Identifier (NPI) implementation date when the provider has received an NPI and the NPI is available to the submitter.
OR
Required for providers prior to the mandated HIPAA NPI implementation date when the provider has received an NPI and the submitter has the capability to send it.
If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 316;
			dpo.ElementTemplate_ID = 45;
			dpo.SegmentInstance_ID = 186;
			dpo.Usage = 0;
			dpo.Description = "Code designating the system/method of code structure used for Identification Code (67)";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when the service location to be identified has an NPI and is not a component or subpart of the Billing Provider entity.
If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 318;
			dpo.ElementTemplate_ID = 45;
			dpo.SegmentInstance_ID = 190;
			dpo.Usage = 0;
			dpo.Description = "Code designating the system/method of code structure used for Identification Code (67)";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required for providers in the United States or its territories on or after the mandated HIPAA National Provider Identifier (NPI) implementation date when the provider is eligible to receive an NPI.
OR
Required for providers not in the United States or its territories on or after the mandated HIPAA National Provider Identifier (NPI) implementation date when the provider has received an NPI.
OR
Required for providers prior to the mandated NPI implementation date when the provider has received an NPI and the submitter has the capability to send it.
If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 320;
			dpo.ElementTemplate_ID = 45;
			dpo.SegmentInstance_ID = 192;
			dpo.Usage = 0;
			dpo.Description = "Code designating the system/method of code structure used for Identification Code (67)";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 325;
			dpo.ElementTemplate_ID = 45;
			dpo.SegmentInstance_ID = 197;
			dpo.Usage = 0;
			dpo.Description = "Code designating the system/method of code structure used for Identification Code (67)";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required for providers on or after the mandated HIPAA National Provider Identifier (NPI) implementation date when the provider has received an NPI and the NPI is available to the submitter.
OR
Required for providers prior to the mandated HIPAA NPI implementation date when the provider has received an NPI and the submitter has the capability to send it.
If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 6;
			dpo.ElementTemplate_ID = 50;
			dpo.SegmentInstance_ID = 2;
			dpo.Usage = 1;
			dpo.Description = "Code identifying the major duty or responsibility of the person or group named";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 14;
			dpo.ElementTemplate_ID = 50;
			dpo.SegmentInstance_ID = 12;
			dpo.Usage = 1;
			dpo.Description = "Code identifying the major duty or responsibility of the person or group named";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 205;
			dpo.ElementTemplate_ID = 50;
			dpo.SegmentInstance_ID = 43;
			dpo.Usage = 1;
			dpo.Description = "Code identifying the major duty or responsibility of the person or group named";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 84;
			dpo.ElementTemplate_ID = 50;
			dpo.SegmentInstance_ID = 99;
			dpo.Usage = 1;
			dpo.Description = "Code identifying the major duty or responsibility of the person or group named";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 160;
			dpo.ElementTemplate_ID = 50;
			dpo.SegmentInstance_ID = 196;
			dpo.Usage = 1;
			dpo.Description = "Code identifying the major duty or responsibility of the person or group named";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 24;
			dpo.ElementTemplate_ID = 50;
			dpo.SegmentInstance_ID = 211;
			dpo.Usage = 1;
			dpo.Description = "Code identifying the major duty or responsibility of the person or group named";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 171;
			dpo.ElementTemplate_ID = 52;
			dpo.SegmentInstance_ID = 2;
			dpo.Usage = 0;
			dpo.Description = "Code identifying the type of communication number";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 180;
			dpo.ElementTemplate_ID = 52;
			dpo.SegmentInstance_ID = 12;
			dpo.Usage = 0;
			dpo.Description = "Code identifying the type of communication number";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 206;
			dpo.ElementTemplate_ID = 52;
			dpo.SegmentInstance_ID = 43;
			dpo.Usage = 0;
			dpo.Description = "Code identifying the type of communication number";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 253;
			dpo.ElementTemplate_ID = 52;
			dpo.SegmentInstance_ID = 99;
			dpo.Usage = 0;
			dpo.Description = "Code identifying the type of communication number";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 321;
			dpo.ElementTemplate_ID = 52;
			dpo.SegmentInstance_ID = 196;
			dpo.Usage = 0;
			dpo.Description = "Code identifying the type of communication number";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 194;
			dpo.ElementTemplate_ID = 52;
			dpo.SegmentInstance_ID = 211;
			dpo.Usage = 0;
			dpo.Description = "Code identifying the type of communication number";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 172;
			dpo.ElementTemplate_ID = 54;
			dpo.SegmentInstance_ID = 2;
			dpo.Usage = 0;
			dpo.Description = "Code identifying the type of communication number";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 181;
			dpo.ElementTemplate_ID = 54;
			dpo.SegmentInstance_ID = 12;
			dpo.Usage = 0;
			dpo.Description = "Code identifying the type of communication number";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 207;
			dpo.ElementTemplate_ID = 54;
			dpo.SegmentInstance_ID = 43;
			dpo.Usage = 0;
			dpo.Description = "Code identifying the type of communication number";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 254;
			dpo.ElementTemplate_ID = 54;
			dpo.SegmentInstance_ID = 99;
			dpo.Usage = 0;
			dpo.Description = "Code identifying the type of communication number";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when this information is deemed necessary by the submitter. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 322;
			dpo.ElementTemplate_ID = 54;
			dpo.SegmentInstance_ID = 196;
			dpo.Usage = 0;
			dpo.Description = "Code identifying the type of communication number";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when this information is deemed necessary by the submitter. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 195;
			dpo.ElementTemplate_ID = 54;
			dpo.SegmentInstance_ID = 211;
			dpo.Usage = 0;
			dpo.Description = "Code identifying the type of communication number";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when this information is deemed necessary by the submitter. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 173;
			dpo.ElementTemplate_ID = 56;
			dpo.SegmentInstance_ID = 2;
			dpo.Usage = 0;
			dpo.Description = "Code identifying the type of communication number";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 182;
			dpo.ElementTemplate_ID = 56;
			dpo.SegmentInstance_ID = 12;
			dpo.Usage = 0;
			dpo.Description = "Code identifying the type of communication number";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 323;
			dpo.ElementTemplate_ID = 56;
			dpo.SegmentInstance_ID = 196;
			dpo.Usage = 0;
			dpo.Description = "Code identifying the type of communication number";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when this information is deemed necessary by the submitter. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 13;
			dpo.ElementTemplate_ID = 59;
			dpo.SegmentInstance_ID = 4;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 168;
			dpo.ElementTemplate_ID = 61;
			dpo.SegmentInstance_ID = 4;
			dpo.Usage = 1;
			dpo.Description = "Hierarchical Level Code";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 169;
			dpo.ElementTemplate_ID = 61;
			dpo.SegmentInstance_ID = 21;
			dpo.Usage = 1;
			dpo.Description = "Hierarchical Level Code";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 170;
			dpo.ElementTemplate_ID = 61;
			dpo.SegmentInstance_ID = 35;
			dpo.Usage = 1;
			dpo.Description = "Hierarchical Level Code";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 176;
			dpo.ElementTemplate_ID = 62;
			dpo.SegmentInstance_ID = 4;
			dpo.Usage = 2;
			dpo.Description = @"Code indicating if there are hierarchical child data segments subordinate to the level being described";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 186;
			dpo.ElementTemplate_ID = 62;
			dpo.SegmentInstance_ID = 21;
			dpo.Usage = 2;
			dpo.Description = @"Code indicating if there are hierarchical child data segments subordinate to the level being described";
			dpo.Situational_Rule = @"The claim (Loop ID-2300) can be used when HL04 has no subordinate levels (HL04 = 0) or when HL04 has subordinate levels indicated (HL04 = 1). 
 
 In the first case (HL04 = 0), the subscriber is the patient and there are no dependent claims. 
 
 The second case (HL04 = 1) happens when claims for one or more dependents of the subscriber are being sent under the same billing provider HL (for example, a spouse and son are both treated by the same provider). In that case, the subscriber HL04 = 1 because there is at least one dependent to this subscriber. The dependent HL (spouse) would then be sent followed by the Loop ID-2300 for the spouse. The next HL would be the dependent HL for the son followed by the Loop ID-2300 for the son. 
 
 
 In order to send claims for the subscriber and one or more dependents, the Subscriber HL, with Relationship Code SBR02=18 (Self), would be followed by the Subscriber's Loop ID-2300 for the Subscriber's claims. Then the Subscriber HL would be repeated, followed by one or more Patient HL loops for the dependents, with the proper Relationship Code in PAT01, each followed by their respective Loop ID-2300 for each dependent's claims.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 199;
			dpo.ElementTemplate_ID = 62;
			dpo.SegmentInstance_ID = 35;
			dpo.Usage = 2;
			dpo.Description = @"Code indicating if there are hierarchical child data segments subordinate to the level being described";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 8;
			dpo.ElementTemplate_ID = 63;
			dpo.SegmentInstance_ID = 5;
			dpo.Usage = 1;
			dpo.Description = "Code identifying the type of provider";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 80;
			dpo.ElementTemplate_ID = 63;
			dpo.SegmentInstance_ID = 93;
			dpo.Usage = 1;
			dpo.Description = "Code identifying the type of provider";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 150;
			dpo.ElementTemplate_ID = 63;
			dpo.SegmentInstance_ID = 182;
			dpo.Usage = 1;
			dpo.Description = "Code identifying the type of provider";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 177;
			dpo.ElementTemplate_ID = 64;
			dpo.SegmentInstance_ID = 5;
			dpo.Usage = 0;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 250;
			dpo.ElementTemplate_ID = 64;
			dpo.SegmentInstance_ID = 93;
			dpo.Usage = 0;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 312;
			dpo.ElementTemplate_ID = 64;
			dpo.SegmentInstance_ID = 182;
			dpo.Usage = 0;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 9;
			dpo.ElementTemplate_ID = 69;
			dpo.SegmentInstance_ID = 6;
			dpo.Usage = 1;
			dpo.Description = "Code identifying an organizational entity, a physical location, property or an individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 11;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 10;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 12;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 11;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 17;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 19;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 18;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 20;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 22;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 28;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 23;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 29;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 26;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 33;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 27;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 34;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 31;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 41;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 32;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 42;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 33;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 43;
			dpo.Usage = 1;
			dpo.Description = "Code identifying the major duty or responsibility of the person or group named";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 53;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 64;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 54;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 65;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 55;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 66;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 56;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 67;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 57;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 68;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 58;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 69;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 59;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 70;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 60;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 71;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 61;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 72;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 62;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 73;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 63;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 74;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 64;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 75;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 65;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 76;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 66;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 77;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 78;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 91;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 81;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 94;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 83;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 98;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 86;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 101;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 95;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 118;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 98;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 123;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 99;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 124;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 100;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 125;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 101;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 126;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 102;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 127;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 104;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 129;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 106;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 131;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 108;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 133;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 110;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 135;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 112;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 137;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 134;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 162;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 135;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 163;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 136;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 164;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 137;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 165;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 138;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 166;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 139;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 167;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 140;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 168;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 141;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 169;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 142;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 170;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 148;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 180;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 151;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 183;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 153;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 185;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 155;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 189;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 157;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 191;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 159;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 195;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 162;
			dpo.ElementTemplate_ID = 99;
			dpo.SegmentInstance_ID = 198;
			dpo.Usage = 1;
			dpo.Description = "Code qualifying the Reference Identification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 233;
			dpo.ElementTemplate_ID = 100;
			dpo.SegmentInstance_ID = 65;
			dpo.Usage = 0;
			dpo.Description = @"Reference information as defined for a particular Transaction Set or as specified by the Reference Identification Qualifier";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 19;
			dpo.ElementTemplate_ID = 103;
			dpo.SegmentInstance_ID = 22;
			dpo.Usage = 1;
			dpo.Description = "Code identifying the insurance carrier's level of responsibility for a payment of a claim";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 89;
			dpo.ElementTemplate_ID = 103;
			dpo.SegmentInstance_ID = 108;
			dpo.Usage = 1;
			dpo.Description = "Code identifying the insurance carrier's level of responsibility for a payment of a claim";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 198;
			dpo.ElementTemplate_ID = 104;
			dpo.SegmentInstance_ID = 22;
			dpo.Usage = 2;
			dpo.Description = "Code indicating the relationship between two individuals or entities";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when the patient is the subscriber or is considered to be the subscriber. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 259;
			dpo.ElementTemplate_ID = 104;
			dpo.SegmentInstance_ID = 108;
			dpo.Usage = 2;
			dpo.Description = "Code indicating the relationship between two individuals or entities";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 187;
			dpo.ElementTemplate_ID = 107;
			dpo.SegmentInstance_ID = 22;
			dpo.Usage = 2;
			dpo.Description = "Code identifying the type of insurance policy within a specific insurance progr";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when the destination payer (Loop ID-2010BB) is Medicare and Medicare is not the primary payer (SBR01 does not equal ""P""). If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 260;
			dpo.ElementTemplate_ID = 107;
			dpo.SegmentInstance_ID = 108;
			dpo.Usage = 2;
			dpo.Description = "Code identifying the type of insurance policy within a specific insurance program";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when the payer identified in Loop ID-2330B for this iteration of Loop ID-2320 is Medicare and Medicare is not the primary payer (Loop ID-2320 SBR01 is not P). If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 188;
			dpo.ElementTemplate_ID = 111;
			dpo.SegmentInstance_ID = 22;
			dpo.Usage = 2;
			dpo.Description = "Code identifying type of claim";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required prior to mandated use of the HIPAA National Plan ID. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 261;
			dpo.ElementTemplate_ID = 111;
			dpo.SegmentInstance_ID = 108;
			dpo.Usage = 2;
			dpo.Description = "Code identifying type of claim";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required prior to mandated use of the HIPAA National Plan ID. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 28;
			dpo.ElementTemplate_ID = 112;
			dpo.SegmentInstance_ID = 36;
			dpo.Usage = 1;
			dpo.Description = "Code indicating the relationship between two individuals or entities";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 189;
			dpo.ElementTemplate_ID = 116;
			dpo.SegmentInstance_ID = 23;
			dpo.Usage = 0;
			dpo.Description = "Code indicating the date format, time format, or date and time format";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when patient is known to be deceased and the date of death is available to the provider billing system. If not required by this implementation guide, do not send";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 200;
			dpo.ElementTemplate_ID = 116;
			dpo.SegmentInstance_ID = 36;
			dpo.Usage = 0;
			dpo.Description = "Code indicating the date format, time format, or date and time format";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when patient is known to be deceased and the date of death is available to the provider billing system. If not required by this implementation guide, do not send";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 190;
			dpo.ElementTemplate_ID = 118;
			dpo.SegmentInstance_ID = 23;
			dpo.Usage = 0;
			dpo.Description = @"Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when claims involve Medicare Durable Medical Equipment Regional Carriers Certificate of Medical Necessity (DMERC CMN) 02.03, 10.02, or DME MAC 10.03.
If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 201;
			dpo.ElementTemplate_ID = 118;
			dpo.SegmentInstance_ID = 36;
			dpo.Usage = 0;
			dpo.Description = @"Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when claims involve Medicare Durable Medical Equipment Regional Carriers Certificate of Medical Necessity (DMERC CMN) 02.03, 10.02, or DME MAC 10.03.
If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 191;
			dpo.ElementTemplate_ID = 120;
			dpo.SegmentInstance_ID = 23;
			dpo.Usage = 2;
			dpo.Description = "Code indicating a Yes or No condition or response";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when mandated by law. The determination of pregnancy shall be completed in compliance with applicable law. The ""Y"" code indicates that the patient is pregnant. If PAT09 is not used, it means that the patient is not pregnant or that the pregnancy indicator is not mandated by law.
If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 202;
			dpo.ElementTemplate_ID = 120;
			dpo.SegmentInstance_ID = 36;
			dpo.Usage = 2;
			dpo.Description = "Code indicating a Yes or No condition or response";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when mandated by law. The determination of pregnancy shall be completed in compliance with applicable law. The ""Y"" code indicates that the patient is pregnant. If PAT09 is not used, it means that the patient is not pregnant or that the pregnancy indicator is not mandated by law.
If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 21;
			dpo.ElementTemplate_ID = 121;
			dpo.SegmentInstance_ID = 27;
			dpo.Usage = 1;
			dpo.Description = "Code indicating the date format, time format, or date and time format";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 30;
			dpo.ElementTemplate_ID = 121;
			dpo.SegmentInstance_ID = 40;
			dpo.Usage = 1;
			dpo.Description = "Code indicating the date format, time format, or date and time format";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 193;
			dpo.ElementTemplate_ID = 123;
			dpo.SegmentInstance_ID = 27;
			dpo.Usage = 2;
			dpo.Description = "Code indicating the sex of the individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 204;
			dpo.ElementTemplate_ID = 123;
			dpo.SegmentInstance_ID = 40;
			dpo.Usage = 2;
			dpo.Description = "Code indicating the sex of the individual";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 208;
			dpo.ElementTemplate_ID = 137;
			dpo.SegmentInstance_ID = 44;
			dpo.Usage = 2;
			dpo.Description = "Code indicating a Yes or No condition or response";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 209;
			dpo.ElementTemplate_ID = 138;
			dpo.SegmentInstance_ID = 44;
			dpo.Usage = 2;
			dpo.Description = "Code indicating whether the provider accepts assignment";
			dpo.Situational_Rule = @"Within this element the context of the word assignment is related to the relationship between the provider and the payer. This is NOT the field for reporting whether the patient has or has not assigned benefits to the provider. The benefit assignment indicator is in CLM08.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 210;
			dpo.ElementTemplate_ID = 139;
			dpo.SegmentInstance_ID = 44;
			dpo.Usage = 2;
			dpo.Description = "Code indicating a Yes or No condition or response";
			dpo.Situational_Rule = @"INDUSTRY NAME: Benefits Assignment Certification Indicator 
 
 
 This element answers the question whether or not the insured has authorized the plan to remit payment directly to the provider.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 211;
			dpo.ElementTemplate_ID = 140;
			dpo.SegmentInstance_ID = 44;
			dpo.Usage = 2;
			dpo.Description = @"Code indicating whether the provider has on file a signed statement by the patient authorizing the release of medical data to other organizations";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 212;
			dpo.ElementTemplate_ID = 141;
			dpo.SegmentInstance_ID = 44;
			dpo.Usage = 2;
			dpo.Description = @"Code indicating how the patient or subscriber authorization signatures were obtained and how they are being retained by the provider";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 213;
			dpo.ElementTemplate_ID = 143;
			dpo.SegmentInstance_ID = 44;
			dpo.Usage = 2;
			dpo.Description = @"Code indicating the Special Program under which the services rendered to the patient were performed";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when the services were rendered under one of the following circumstances, programs, or projects. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 214;
			dpo.ElementTemplate_ID = 151;
			dpo.SegmentInstance_ID = 44;
			dpo.Usage = 2;
			dpo.Description = "Code indicating the reason why a request was delayed";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when the claim is submitted late (past contracted date of filing limitations). If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 34;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 45;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 35;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 46;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 36;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 47;
			dpo.Usage = 0;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 37;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 48;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 38;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 49;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 39;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 50;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 40;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 51;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 41;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 52;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 42;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 53;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 43;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 54;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 44;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 55;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 45;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 56;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 46;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 57;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 47;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 58;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 48;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 59;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 49;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 60;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 97;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 122;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 120;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 148;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 121;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 149;
			dpo.Usage = 2;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 122;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 150;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 123;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 151;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 124;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 152;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 125;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 153;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 126;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 154;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 127;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 155;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 128;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 156;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 129;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 157;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 166;
			dpo.ElementTemplate_ID = 152;
			dpo.SegmentInstance_ID = 207;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 215;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 45;
			dpo.Usage = 1;
			dpo.Description = "Code specifying type of date or time, or both date and time";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 216;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 46;
			dpo.Usage = 1;
			dpo.Description = "Code indicating the date format, time format, or date and time format";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 218;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 47;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 219;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 48;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 220;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 49;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 221;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 50;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 222;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 51;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 223;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 52;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 217;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 53;
			dpo.Usage = 1;
			dpo.Description = "Code indicating the date format, time format, or date and time format";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 224;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 54;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 225;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 55;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 226;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 56;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 227;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 57;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 228;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 58;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 229;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 59;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 230;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 60;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 269;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 122;
			dpo.Usage = 1;
			dpo.Description = "Code indicating the date format, time format, or date and time format";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 294;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 148;
			dpo.Usage = 1;
			dpo.Description = "Code indicating the date format, time format, or date and time format";
			dpo.Situational_Rule = @"RD8 is required only when the ""To and From"" dates are different. However, at the discretion of the submitter, RD8 can also be used when the ""To and From"" dates are the same.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 295;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 149;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 296;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 150;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 297;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 151;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 298;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 152;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 299;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 153;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 300;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 154;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 301;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 155;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 302;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 156;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 303;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 157;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 329;
			dpo.ElementTemplate_ID = 153;
			dpo.SegmentInstance_ID = 207;
			dpo.Usage = 1;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 50;
			dpo.ElementTemplate_ID = 155;
			dpo.SegmentInstance_ID = 61;
			dpo.Usage = 1;
			dpo.Description = "Code indicating the title or contents of a document, report or supporting item";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 113;
			dpo.ElementTemplate_ID = 155;
			dpo.SegmentInstance_ID = 141;
			dpo.Usage = 1;
			dpo.Description = "Code indicating the title or contents of a document, report or supporting item";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 114;
			dpo.ElementTemplate_ID = 155;
			dpo.SegmentInstance_ID = 142;
			dpo.Usage = 1;
			dpo.Description = "Code indicating the title or contents of a document, report or supporting item";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 231;
			dpo.ElementTemplate_ID = 156;
			dpo.SegmentInstance_ID = 61;
			dpo.Usage = 2;
			dpo.Description = "Code defining timing, transmission method or format by which reports are to be sent";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 283;
			dpo.ElementTemplate_ID = 156;
			dpo.SegmentInstance_ID = 141;
			dpo.Usage = 2;
			dpo.Description = "Code defining timing, transmission method or format by which reports are to be sent";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 284;
			dpo.ElementTemplate_ID = 156;
			dpo.SegmentInstance_ID = 142;
			dpo.Usage = 2;
			dpo.Description = "Code defining timing, transmission method or format by which reports are to be sent";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 232;
			dpo.ElementTemplate_ID = 159;
			dpo.SegmentInstance_ID = 61;
			dpo.Usage = 0;
			dpo.Description = "Code designating the system/method of code structure used for Identification Code (67)";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when PWK02 = ""BM"", ""EL"", ""EM"", ""FX"" or ""FT"". If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 51;
			dpo.ElementTemplate_ID = 164;
			dpo.SegmentInstance_ID = 62;
			dpo.Usage = 1;
			dpo.Description = "Code identifying a contract type";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 133;
			dpo.ElementTemplate_ID = 164;
			dpo.SegmentInstance_ID = 161;
			dpo.Usage = 1;
			dpo.Description = "Code identifying a contract type";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 52;
			dpo.ElementTemplate_ID = 170;
			dpo.SegmentInstance_ID = 63;
			dpo.Usage = 1;
			dpo.Description = "Code to qualify amount";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 91;
			dpo.ElementTemplate_ID = 170;
			dpo.SegmentInstance_ID = 110;
			dpo.Usage = 1;
			dpo.Description = "Code to qualify amount";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 93;
			dpo.ElementTemplate_ID = 170;
			dpo.SegmentInstance_ID = 111;
			dpo.Usage = 2;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 92;
			dpo.ElementTemplate_ID = 170;
			dpo.SegmentInstance_ID = 112;
			dpo.Usage = 1;
			dpo.Description = "Code to qualify amount";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 143;
			dpo.ElementTemplate_ID = 170;
			dpo.SegmentInstance_ID = 171;
			dpo.Usage = 1;
			dpo.Description = "Code to qualify amount";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 144;
			dpo.ElementTemplate_ID = 170;
			dpo.SegmentInstance_ID = 172;
			dpo.Usage = 1;
			dpo.Description = "Code to qualify amount";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 67;
			dpo.ElementTemplate_ID = 176;
			dpo.SegmentInstance_ID = 79;
			dpo.Usage = 2;
			dpo.Description = "Code identifying the functional area or purpose for which the note applies";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 145;
			dpo.ElementTemplate_ID = 176;
			dpo.SegmentInstance_ID = 174;
			dpo.Usage = 2;
			dpo.Description = "Code identifying the functional area or purpose for which the note applies";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 146;
			dpo.ElementTemplate_ID = 176;
			dpo.SegmentInstance_ID = 175;
			dpo.Usage = 2;
			dpo.Description = "Code identifying the functional area or purpose for which the note applies";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 68;
			dpo.ElementTemplate_ID = 178;
			dpo.SegmentInstance_ID = 80;
			dpo.Usage = 0;
			dpo.Description = @"Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 115;
			dpo.ElementTemplate_ID = 178;
			dpo.SegmentInstance_ID = 143;
			dpo.Usage = 0;
			dpo.Description = @"Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 234;
			dpo.ElementTemplate_ID = 181;
			dpo.SegmentInstance_ID = 80;
			dpo.Usage = 2;
			dpo.Description = "Code indicating the reason for ambulance transport";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 285;
			dpo.ElementTemplate_ID = 181;
			dpo.SegmentInstance_ID = 143;
			dpo.Usage = 2;
			dpo.Description = "Code indicating the reason for ambulance transport";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 235;
			dpo.ElementTemplate_ID = 182;
			dpo.SegmentInstance_ID = 80;
			dpo.Usage = 0;
			dpo.Description = @"Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 286;
			dpo.ElementTemplate_ID = 182;
			dpo.SegmentInstance_ID = 143;
			dpo.Usage = 0;
			dpo.Description = @"Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 236;
			dpo.ElementTemplate_ID = 195;
			dpo.SegmentInstance_ID = 81;
			dpo.Usage = 2;
			dpo.Description = "Code indicating the nature of a patient's condition";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 69;
			dpo.ElementTemplate_ID = 200;
			dpo.SegmentInstance_ID = 82;
			dpo.Usage = 1;
			dpo.Description = "Specifies the situation or category to which the code applies";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 70;
			dpo.ElementTemplate_ID = 200;
			dpo.SegmentInstance_ID = 83;
			dpo.Usage = 1;
			dpo.Description = "Specifies the situation or category to which the code applies";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 71;
			dpo.ElementTemplate_ID = 200;
			dpo.SegmentInstance_ID = 84;
			dpo.Usage = 1;
			dpo.Description = "Specifies the situation or category to which the code applies";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 72;
			dpo.ElementTemplate_ID = 200;
			dpo.SegmentInstance_ID = 85;
			dpo.Usage = 1;
			dpo.Description = "Specifies the situation or category to which the code applies";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 117;
			dpo.ElementTemplate_ID = 200;
			dpo.SegmentInstance_ID = 145;
			dpo.Usage = 2;
			dpo.Description = "Specifies the situation or category to which the code applies";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 118;
			dpo.ElementTemplate_ID = 200;
			dpo.SegmentInstance_ID = 146;
			dpo.Usage = 1;
			dpo.Description = "Specifies the situation or category to which the code applies";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 119;
			dpo.ElementTemplate_ID = 200;
			dpo.SegmentInstance_ID = 147;
			dpo.Usage = 1;
			dpo.Description = "Specifies the situation or category to which the code applies";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 237;
			dpo.ElementTemplate_ID = 201;
			dpo.SegmentInstance_ID = 82;
			dpo.Usage = 1;
			dpo.Description = "Code indicating a Yes or No condition or response";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 239;
			dpo.ElementTemplate_ID = 201;
			dpo.SegmentInstance_ID = 84;
			dpo.Usage = 1;
			dpo.Description = "Code indicating a Yes or No condition or response";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 241;
			dpo.ElementTemplate_ID = 201;
			dpo.SegmentInstance_ID = 85;
			dpo.Usage = 1;
			dpo.Description = "Code indicating a Yes or No condition or response";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 288;
			dpo.ElementTemplate_ID = 201;
			dpo.SegmentInstance_ID = 145;
			dpo.Usage = 1;
			dpo.Description = "Code indicating a Yes or No condition or response";
			dpo.Situational_Rule = @"SEMANTIC: CRC02 is a Certification Condition Code applies indicator. A ""Y"" value indicates the condition codes in CRC03 through CRC07 apply; an ""N"" value indicates the condition codes in CRC03 through CRC07 do not apply.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 290;
			dpo.ElementTemplate_ID = 201;
			dpo.SegmentInstance_ID = 146;
			dpo.Usage = 1;
			dpo.Description = "Code indicating a Yes or No condition or response";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 292;
			dpo.ElementTemplate_ID = 201;
			dpo.SegmentInstance_ID = 147;
			dpo.Usage = 1;
			dpo.Description = "Code indicating a Yes or No condition or response";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 238;
			dpo.ElementTemplate_ID = 202;
			dpo.SegmentInstance_ID = 82;
			dpo.Usage = 1;
			dpo.Description = "Code indicating a condition";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 240;
			dpo.ElementTemplate_ID = 202;
			dpo.SegmentInstance_ID = 84;
			dpo.Usage = 1;
			dpo.Description = "Code indicating a condition";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 242;
			dpo.ElementTemplate_ID = 202;
			dpo.SegmentInstance_ID = 85;
			dpo.Usage = 1;
			dpo.Description = "Code indicating a condition";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 289;
			dpo.ElementTemplate_ID = 202;
			dpo.SegmentInstance_ID = 145;
			dpo.Usage = 1;
			dpo.Description = "Code indicating a condition";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 291;
			dpo.ElementTemplate_ID = 202;
			dpo.SegmentInstance_ID = 146;
			dpo.Usage = 1;
			dpo.Description = "Code indicating a condition";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 293;
			dpo.ElementTemplate_ID = 202;
			dpo.SegmentInstance_ID = 147;
			dpo.Usage = 1;
			dpo.Description = "Code indicating a Yes or No condition or response";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 76;
			dpo.ElementTemplate_ID = 207;
			dpo.SegmentInstance_ID = 89;
			dpo.Usage = 0;
			dpo.Description = "Code specifying pricing methodology at which the claim or line item has been priced or repriced";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 147;
			dpo.ElementTemplate_ID = 207;
			dpo.SegmentInstance_ID = 177;
			dpo.Usage = 0;
			dpo.Description = "";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 305;
			dpo.ElementTemplate_ID = 215;
			dpo.SegmentInstance_ID = 177;
			dpo.Usage = 0;
			dpo.Description = "Code identifying the type/source of the descriptive number used in Product/Service ID (234)";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when this information is deemed necessary by the repricer. The segment is not completed by providers. The information is completed by repricers only. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 306;
			dpo.ElementTemplate_ID = 217;
			dpo.SegmentInstance_ID = 177;
			dpo.Usage = 0;
			dpo.Description = @"Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when this information is deemed necessary by the repricer. The segment is not completed by providers. The information is completed by repricers only. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 243;
			dpo.ElementTemplate_ID = 219;
			dpo.SegmentInstance_ID = 89;
			dpo.Usage = 0;
			dpo.Description = "Code assigned by issuer to identify reason for rejection";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when this information is deemed necessary by the repricer. The segment is not completed by providers. The information is completed by repricers only. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 307;
			dpo.ElementTemplate_ID = 219;
			dpo.SegmentInstance_ID = 177;
			dpo.Usage = 0;
			dpo.Description = "Code assigned by issuer to identify reason for rejection";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when this information is deemed necessary by the repricer. The segment is not completed by providers. The information is completed by repricers only. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 244;
			dpo.ElementTemplate_ID = 220;
			dpo.SegmentInstance_ID = 89;
			dpo.Usage = 2;
			dpo.Description = "Code specifying policy compliance";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when this information is deemed necessary by the repricer. The segment is not completed by providers. The information is completed by repricers only. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 308;
			dpo.ElementTemplate_ID = 220;
			dpo.SegmentInstance_ID = 177;
			dpo.Usage = 2;
			dpo.Description = "Code specifying policy compliance";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when this information is deemed necessary by the repricer. The segment is not completed by providers. The information is completed by repricers only. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 245;
			dpo.ElementTemplate_ID = 221;
			dpo.SegmentInstance_ID = 89;
			dpo.Usage = 2;
			dpo.Description = "Code specifying the exception reason for consideration of out-of-network health care services";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when this information is deemed necessary by the repricer. The segment is not completed by providers. The information is completed by repricers only. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 309;
			dpo.ElementTemplate_ID = 221;
			dpo.SegmentInstance_ID = 177;
			dpo.Usage = 2;
			dpo.Description = "Code specifying the exception reason for consideration of out-of-network health care services";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when this information is deemed necessary by the repricer. The segment is not completed by providers. The information is completed by repricers only. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 90;
			dpo.ElementTemplate_ID = 222;
			dpo.SegmentInstance_ID = 109;
			dpo.Usage = 1;
			dpo.Description = "Code identifying the general category of payment adjustment";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 165;
			dpo.ElementTemplate_ID = 222;
			dpo.SegmentInstance_ID = 206;
			dpo.Usage = 1;
			dpo.Description = "Code identifying the general category of payment adjustment";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 262;
			dpo.ElementTemplate_ID = 243;
			dpo.SegmentInstance_ID = 113;
			dpo.Usage = 2;
			dpo.Description = "Code indicating a Yes or No condition or response";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 263;
			dpo.ElementTemplate_ID = 244;
			dpo.SegmentInstance_ID = 113;
			dpo.Usage = 2;
			dpo.Description = @"Code indicating how the patient or subscriber authorization signatures were obtained and how they are being retained by the provider";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when a signature was executed on the patient's behalf under state or federal law. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 264;
			dpo.ElementTemplate_ID = 246;
			dpo.SegmentInstance_ID = 113;
			dpo.Usage = 2;
			dpo.Description = @"Code indicating whether the provider has on file a signed statement by the patient authorizing the release of medical data to other organizations";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 275;
			dpo.ElementTemplate_ID = 257;
			dpo.SegmentInstance_ID = 139;
			dpo.Usage = 1;
			dpo.Description = "Code identifying the type/source of the descriptive number used in Product/Service ID (234)";
			dpo.Situational_Rule = @"The NDC number is used for reporting prescribed drugs and biologics when required by government regulation, or as deemed by the provider to enhance claim reporting or adjudication processes. The NDC number is reported in the LIN segment of Loop ID-2410 only.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 276;
			dpo.ElementTemplate_ID = 259;
			dpo.SegmentInstance_ID = 139;
			dpo.Usage = 0;
			dpo.Description = @"Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 277;
			dpo.ElementTemplate_ID = 265;
			dpo.SegmentInstance_ID = 139;
			dpo.Usage = 2;
			dpo.Description = "Code indicating a Yes or No condition or response";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when the service is known to be an emergency by the provider. If not required by this implementation guide, do not send. 
 
 
 INDUSTRY NAME: Emergency Indicator 
 
 
 For this implementation, the listed value takes precedence over the semantic note.

Emergency definition: The patient requires immediate medical intervention as a result of severe, life threatening, or potentially disabling conditions.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 278;
			dpo.ElementTemplate_ID = 267;
			dpo.SegmentInstance_ID = 139;
			dpo.Usage = 2;
			dpo.Description = "Code indicating a Yes or No condition or response";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when Medicaid services are the result of a screening referral.
If not required by this implementation guide, do not send. 
 
 
 INDUSTRY NAME: EPSDT Indicator 
 
 
 For this implementation, the listed value takes precedence over the semantic note. 
 
 
 When this element is used, this service is not the screening service.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 279;
			dpo.ElementTemplate_ID = 268;
			dpo.SegmentInstance_ID = 139;
			dpo.Usage = 2;
			dpo.Description = "Code indicating a Yes or No condition or response";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when applicable for Medicaid claims. If not required by this implementation guide, do not send. 
 
 
 INDUSTRY NAME: Family Planning Indicator 
 
 
 For this implementation, the listed value takes precedence over the semantic note.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 280;
			dpo.ElementTemplate_ID = 271;
			dpo.SegmentInstance_ID = 139;
			dpo.Usage = 2;
			dpo.Description = "Code indicating whether or not co-payment requirements were met on a line by line basis";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when patient is exempt from co-pay. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 281;
			dpo.ElementTemplate_ID = 278;
			dpo.SegmentInstance_ID = 140;
			dpo.Usage = 1;
			dpo.Description = "Code identifying the type/source of the descriptive number used in Product/Service ID (234)";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 282;
			dpo.ElementTemplate_ID = 283;
			dpo.SegmentInstance_ID = 140;
			dpo.Usage = 2;
			dpo.Description = "Code indicating frequency or type of activities or actions being reported";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 130;
			dpo.ElementTemplate_ID = 285;
			dpo.SegmentInstance_ID = 158;
			dpo.Usage = 1;
			dpo.Description = "Code specifying the type of quantity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 131;
			dpo.ElementTemplate_ID = 285;
			dpo.SegmentInstance_ID = 159;
			dpo.Usage = 1;
			dpo.Description = "Code specifying the type of quantity";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 132;
			dpo.ElementTemplate_ID = 289;
			dpo.SegmentInstance_ID = 160;
			dpo.Usage = 2;
			dpo.Description = "Code identifying the broad category to which a measurement applies";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 304;
			dpo.ElementTemplate_ID = 290;
			dpo.SegmentInstance_ID = 160;
			dpo.Usage = 2;
			dpo.Description = "Code identifying a specific product or process characteristic to which a measurement applies";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 310;
			dpo.ElementTemplate_ID = 305;
			dpo.SegmentInstance_ID = 178;
			dpo.Usage = 1;
			dpo.Description = "Code identifying the type/source of the descriptive number used in Product/Service ID (234";
			dpo.Situational_Rule = @"At the time of this writing, UPN code sets designated by values EN, EO, HI, ON, UK, and UP have been approved by the Secretary of HHS as a pilot project allowed under HIPAA law. During the pilot, these code values may only be used by parties registered in the pilot project and their trading partners. Beyond the pilot, these codes may only be used if mandated by government regulation.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 328;
			dpo.ElementTemplate_ID = 348;
			dpo.SegmentInstance_ID = 205;
			dpo.Usage = 2;
			dpo.Description = "Code identifying the type/source of the descriptive number used in Product/Service ID (234)";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 167;
			dpo.ElementTemplate_ID = 352;
			dpo.SegmentInstance_ID = 209;
			dpo.Usage = 2;
			dpo.Description = "Code identifying a specific industry code list";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 330;
			dpo.ElementTemplate_ID = 355;
			dpo.SegmentInstance_ID = 210;
			dpo.Usage = 0;
			dpo.Description = "Code indicating a Yes or No condition or response";
			dpo.Situational_Rule = @"SITUATIONAL RULE: Required when the question identified in FRM01 uses a Yes or No response format. If not required by this implementation guide, do not send.";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 116;
			dpo.ElementTemplate_ID = 361;
			dpo.SegmentInstance_ID = 144;
			dpo.Usage = 2;
			dpo.Description = "Code indicating the type of certification";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 287;
			dpo.ElementTemplate_ID = 362;
			dpo.SegmentInstance_ID = 144;
			dpo.Usage = 0;
			dpo.Description = @"Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 73;
			dpo.ElementTemplate_ID = 366;
			dpo.SegmentInstance_ID = 86;
			dpo.Usage = 1;
			dpo.Description = "To send health care codes and their associated dates, amounts and quantities";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 74;
			dpo.ElementTemplate_ID = 366;
			dpo.SegmentInstance_ID = 87;
			dpo.Usage = 1;
			dpo.Description = "To send health care codes and their associated dates, amounts and quantities";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

			dpo = new X12ElementInstanceDpo();
			dpo.ID = 75;
			dpo.ElementTemplate_ID = 366;
			dpo.SegmentInstance_ID = 88;
			dpo.Usage = 1;
			dpo.Description = "To send health care codes and their associated dates, amounts and quantities";
			dpo.Situational_Rule = "";
			dpo.Code_Definition = 0;
			list.Add(dpo);

		}

	}
}
