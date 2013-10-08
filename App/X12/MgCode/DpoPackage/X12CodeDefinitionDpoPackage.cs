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
	public class X12CodeDefinitionDpoPackage : BasePackage<X12CodeDefinitionDpo>
	{

		public X12CodeDefinitionDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new X12CodeDefinitionDpo();
			dpo.ID = 1;
			dpo.ElementInstance_ID = 1;
			dpo.Code = "41";
			dpo.Definition = "Submitter";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 2;
			dpo.ElementInstance_ID = 2;
			dpo.Code = "1";
			dpo.Definition = "Person";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 3;
			dpo.ElementInstance_ID = 2;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 4;
			dpo.ElementInstance_ID = 3;
			dpo.Code = "46";
			dpo.Definition = "Electronic Transmitter Identification Number (ETIN) ,Established by trading partner agreement";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 5;
			dpo.ElementInstance_ID = 6;
			dpo.Code = "IC";
			dpo.Definition = "Information Contact";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 7;
			dpo.ElementInstance_ID = 7;
			dpo.Code = "40";
			dpo.Definition = "Receiver";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 14;
			dpo.ElementInstance_ID = 8;
			dpo.Code = "BI";
			dpo.Definition = "Billing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 8;
			dpo.ElementInstance_ID = 9;
			dpo.Code = "85";
			dpo.Definition = "Billing Provider";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 9;
			dpo.ElementInstance_ID = 10;
			dpo.Code = "85";
			dpo.Definition = "Billing Provider";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 10;
			dpo.ElementInstance_ID = 11;
			dpo.Code = "EI";
			dpo.Definition = "Employer's Identification Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 11;
			dpo.ElementInstance_ID = 11;
			dpo.Code = "SY";
			dpo.Definition = "Social Security Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 12;
			dpo.ElementInstance_ID = 12;
			dpo.Code = "0B";
			dpo.Definition = "State License Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 13;
			dpo.ElementInstance_ID = 12;
			dpo.Code = "1G";
			dpo.Definition = "Provider UPIN Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 15;
			dpo.ElementInstance_ID = 14;
			dpo.Code = "IC";
			dpo.Definition = "Information Contact";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 16;
			dpo.ElementInstance_ID = 15;
			dpo.Code = "87";
			dpo.Definition = "Pay-to Provider";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 17;
			dpo.ElementInstance_ID = 16;
			dpo.Code = "PE";
			dpo.Definition = "PE is used to indicate the subrogated payee";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 18;
			dpo.ElementInstance_ID = 17;
			dpo.Code = "2U";
			dpo.Definition = @"Payer Identification Number,This code is only allowed when the National Plan Identifier is reported in NM109 of this loop.";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 19;
			dpo.ElementInstance_ID = 17;
			dpo.Code = "FY";
			dpo.Definition = "Claim Office Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 20;
			dpo.ElementInstance_ID = 17;
			dpo.Code = "NF";
			dpo.Definition = @"National Association of Insurance Commissioners (NAIC) Code,CODE SOURCE 245: National Association of Insurance Commissioners (NAIC) Code";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 21;
			dpo.ElementInstance_ID = 18;
			dpo.Code = "EI";
			dpo.Definition = "Employer's Identification Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 22;
			dpo.ElementInstance_ID = 19;
			dpo.Code = "A";
			dpo.Definition = "Payer Responsibility Four";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 23;
			dpo.ElementInstance_ID = 19;
			dpo.Code = "B";
			dpo.Definition = "Payer Responsibility Five";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 24;
			dpo.ElementInstance_ID = 19;
			dpo.Code = "C";
			dpo.Definition = "Payer Responsibility Six";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 25;
			dpo.ElementInstance_ID = 19;
			dpo.Code = "D";
			dpo.Definition = "Payer Responsibility Seven";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 26;
			dpo.ElementInstance_ID = 19;
			dpo.Code = "E";
			dpo.Definition = "Payer Responsibility Eight";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 27;
			dpo.ElementInstance_ID = 19;
			dpo.Code = "F";
			dpo.Definition = "Payer Responsibility Nine";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 28;
			dpo.ElementInstance_ID = 19;
			dpo.Code = "G";
			dpo.Definition = "Payer Responsibility Ten";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 29;
			dpo.ElementInstance_ID = 19;
			dpo.Code = "H";
			dpo.Definition = "Payer Responsibility Eleven";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 30;
			dpo.ElementInstance_ID = 19;
			dpo.Code = "P";
			dpo.Definition = "Primary";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 31;
			dpo.ElementInstance_ID = 19;
			dpo.Code = "S";
			dpo.Definition = "Secondary";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 32;
			dpo.ElementInstance_ID = 19;
			dpo.Code = "T";
			dpo.Definition = "Tertiary";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 33;
			dpo.ElementInstance_ID = 19;
			dpo.Code = "U";
			dpo.Definition = "Unknown";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 34;
			dpo.ElementInstance_ID = 20;
			dpo.Code = "IL";
			dpo.Definition = "Insured or Subscriber";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 35;
			dpo.ElementInstance_ID = 21;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 36;
			dpo.ElementInstance_ID = 22;
			dpo.Code = "SY";
			dpo.Definition = @"Social Security Number,The Social Security Number must be a string of exactly nine numbers with no separators.";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 37;
			dpo.ElementInstance_ID = 23;
			dpo.Code = "Y4";
			dpo.Definition = "Agency Claim Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 38;
			dpo.ElementInstance_ID = 24;
			dpo.Code = "IC";
			dpo.Definition = "Information Contact";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 39;
			dpo.ElementInstance_ID = 25;
			dpo.Code = "PR";
			dpo.Definition = "Payer";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 40;
			dpo.ElementInstance_ID = 26;
			dpo.Code = "2U";
			dpo.Definition = @"Payer Identification Number,This code is only allowed when the National Plan Identifier is reported in NM109 of this loop.";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 41;
			dpo.ElementInstance_ID = 26;
			dpo.Code = "EI";
			dpo.Definition = "Employer's Identification Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 42;
			dpo.ElementInstance_ID = 26;
			dpo.Code = "FY";
			dpo.Definition = "Claim Office Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 43;
			dpo.ElementInstance_ID = 26;
			dpo.Code = "NF";
			dpo.Definition = "National Association of Insurance Commissioners (NAIC) Code";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 44;
			dpo.ElementInstance_ID = 27;
			dpo.Code = "G2";
			dpo.Definition = "Provider Commercial Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 45;
			dpo.ElementInstance_ID = 27;
			dpo.Code = "LU";
			dpo.Definition = "Location Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 46;
			dpo.ElementInstance_ID = 28;
			dpo.Code = "01";
			dpo.Definition = "Spouse";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 47;
			dpo.ElementInstance_ID = 28;
			dpo.Code = "02";
			dpo.Definition = "Child";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 48;
			dpo.ElementInstance_ID = 28;
			dpo.Code = "20";
			dpo.Definition = "Employee";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 49;
			dpo.ElementInstance_ID = 28;
			dpo.Code = "21";
			dpo.Definition = "Unknown";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 50;
			dpo.ElementInstance_ID = 28;
			dpo.Code = "39";
			dpo.Definition = "Organ Donor";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 51;
			dpo.ElementInstance_ID = 28;
			dpo.Code = "40";
			dpo.Definition = "Cadaver Donor";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 52;
			dpo.ElementInstance_ID = 28;
			dpo.Code = "53";
			dpo.Definition = "Life Partner";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 53;
			dpo.ElementInstance_ID = 28;
			dpo.Code = "G8";
			dpo.Definition = "Other Relationship";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 54;
			dpo.ElementInstance_ID = 29;
			dpo.Code = "QC";
			dpo.Definition = "Patient";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 55;
			dpo.ElementInstance_ID = 30;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 56;
			dpo.ElementInstance_ID = 31;
			dpo.Code = "Y4";
			dpo.Definition = "Agency Claim Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 57;
			dpo.ElementInstance_ID = 32;
			dpo.Code = "1Y";
			dpo.Definition = "Member Identification Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 58;
			dpo.ElementInstance_ID = 32;
			dpo.Code = "5Y";
			dpo.Definition = "Social Security Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 59;
			dpo.ElementInstance_ID = 33;
			dpo.Code = "IC";
			dpo.Definition = "Information Contact";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 60;
			dpo.ElementInstance_ID = 34;
			dpo.Code = "431";
			dpo.Definition = "Onset of Current Symptoms or Illness";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 61;
			dpo.ElementInstance_ID = 35;
			dpo.Code = "454";
			dpo.Definition = "Initial Treatment";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 62;
			dpo.ElementInstance_ID = 36;
			dpo.Code = "304";
			dpo.Definition = "Latest Visit or Consultation";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 63;
			dpo.ElementInstance_ID = 37;
			dpo.Code = "453";
			dpo.Definition = "Acute Manifestation of a Chronic Condition";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 64;
			dpo.ElementInstance_ID = 38;
			dpo.Code = "439";
			dpo.Definition = "Accident";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 65;
			dpo.ElementInstance_ID = 39;
			dpo.Code = "484";
			dpo.Definition = "Last Menstrual Period";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 66;
			dpo.ElementInstance_ID = 40;
			dpo.Code = "455";
			dpo.Definition = "Last X-Ray";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 67;
			dpo.ElementInstance_ID = 41;
			dpo.Code = "471";
			dpo.Definition = "Prescription";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 68;
			dpo.ElementInstance_ID = 42;
			dpo.Code = "314";
			dpo.Definition = "Disability";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 69;
			dpo.ElementInstance_ID = 42;
			dpo.Code = "360";
			dpo.Definition = "Initial Disability Period Start";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 70;
			dpo.ElementInstance_ID = 42;
			dpo.Code = "361";
			dpo.Definition = "Initial Disability Period End";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 71;
			dpo.ElementInstance_ID = 43;
			dpo.Code = "297";
			dpo.Definition = "Initial Disability Period Last Day Worked";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 72;
			dpo.ElementInstance_ID = 44;
			dpo.Code = "296";
			dpo.Definition = "Initial Disability Period Return To Work";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 73;
			dpo.ElementInstance_ID = 45;
			dpo.Code = "435";
			dpo.Definition = "Admission";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 74;
			dpo.ElementInstance_ID = 46;
			dpo.Code = "096";
			dpo.Definition = "Discharge";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 75;
			dpo.ElementInstance_ID = 47;
			dpo.Code = "090";
			dpo.Definition = "Report Start";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 76;
			dpo.ElementInstance_ID = 47;
			dpo.Code = "091";
			dpo.Definition = "Report End";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 77;
			dpo.ElementInstance_ID = 48;
			dpo.Code = "444";
			dpo.Definition = "First Visit or Consultation";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 78;
			dpo.ElementInstance_ID = 49;
			dpo.Code = "050";
			dpo.Definition = "Received";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 79;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "03";
			dpo.Definition = "Report Justifying Treatment Beyond Utilization Guidelines";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 80;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "04";
			dpo.Definition = "Drugs Administered";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 81;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "05";
			dpo.Definition = "Treatment Diagnosis";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 82;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "06";
			dpo.Definition = "Initial Assessment";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 83;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "07";
			dpo.Definition = "Functional Goals";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 84;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "08";
			dpo.Definition = "Plan of Treatment";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 85;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "09";
			dpo.Definition = "Progress Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 86;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "10";
			dpo.Definition = "Continued Treatment";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 87;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "11";
			dpo.Definition = "Chemical Analysis";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 88;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "13";
			dpo.Definition = "Certified Test Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 89;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "15";
			dpo.Definition = "Justification for Admission";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 90;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "21";
			dpo.Definition = "Recovery Plan";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 91;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "A3";
			dpo.Definition = "Allergies/Sensitivities Document";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 92;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "A4";
			dpo.Definition = "Autopsy Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 93;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "AM";
			dpo.Definition = "Ambulance Certification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 94;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "AS";
			dpo.Definition = "Admission Summary";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 95;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "B2";
			dpo.Definition = "Prescription";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 96;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "B3";
			dpo.Definition = "Physician Order";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 97;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "B4";
			dpo.Definition = "Referral Form";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 98;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "BR";
			dpo.Definition = "Benchmark Testing Results";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 99;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "BS";
			dpo.Definition = "Baseline";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 100;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "BT";
			dpo.Definition = "Blanket Test Results";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 101;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "CB";
			dpo.Definition = "Chiropractic Justification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 102;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "CK";
			dpo.Definition = "Consent Form(s)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 103;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "CT";
			dpo.Definition = "Certification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 104;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "D2";
			dpo.Definition = "Drug Profile Document";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 105;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "DA";
			dpo.Definition = "Dental Models";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 106;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "DB";
			dpo.Definition = "Durable Medical Equipment Prescription";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 107;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "DG";
			dpo.Definition = "Diagnostic Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 108;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "DJ";
			dpo.Definition = "Discharge Monitoring Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 109;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "DS";
			dpo.Definition = "Discharge Summary";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 110;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "EB";
			dpo.Definition = "Explanation of Benefits (Coordination of Benefits or Medicare Secondary Payor)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 111;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "HC";
			dpo.Definition = "Health Certificate";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 112;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "HR";
			dpo.Definition = "Health Clinic Records";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 113;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "I5";
			dpo.Definition = "Immunization Record";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 114;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "IR";
			dpo.Definition = "State School Immunization Records";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 115;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "LA";
			dpo.Definition = "Laboratory Results";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 116;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "M1";
			dpo.Definition = "Medical Record Attachment";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 117;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "MT";
			dpo.Definition = "Models";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 118;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "NN";
			dpo.Definition = "Nursing Notes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 119;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "OB";
			dpo.Definition = "Operative Note";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 120;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "OC";
			dpo.Definition = "Oxygen Content Averaging Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 121;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "OD";
			dpo.Definition = "Orders and Treatments Document";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 122;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "OE";
			dpo.Definition = "Objective Physical Examination (including vital signs) Document";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 123;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "OX";
			dpo.Definition = "Oxygen Therapy Certification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 124;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "OZ";
			dpo.Definition = "Support Data for Claim";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 125;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "P4";
			dpo.Definition = "Pathology Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 126;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "P5";
			dpo.Definition = "Patient Medical History Document";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 127;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "PE";
			dpo.Definition = "Parenteral or Enteral Certification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 128;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "PN";
			dpo.Definition = "Physical Therapy Notes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 129;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "PO";
			dpo.Definition = "Prosthetics or Orthotic Certification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 130;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "PQ";
			dpo.Definition = "Paramedical Results";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 131;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "PY";
			dpo.Definition = "Physician's Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 132;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "PZ";
			dpo.Definition = "Physical Therapy Certification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 133;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "RB";
			dpo.Definition = "Radiology Films";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 134;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "RR";
			dpo.Definition = "Radiology Reports";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 135;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "RT";
			dpo.Definition = "Report of Tests and Analysis Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 136;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "RX";
			dpo.Definition = "Renewable Oxygen Content Averaging Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 137;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "SG";
			dpo.Definition = "Symptoms Document";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 138;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "V5";
			dpo.Definition = "Death Notification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 139;
			dpo.ElementInstance_ID = 50;
			dpo.Code = "XP";
			dpo.Definition = "Photographs";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 140;
			dpo.ElementInstance_ID = 51;
			dpo.Code = "01";
			dpo.Definition = "Diagnosis Related Group (DRG)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 141;
			dpo.ElementInstance_ID = 51;
			dpo.Code = "02";
			dpo.Definition = "Per Diem";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 142;
			dpo.ElementInstance_ID = 51;
			dpo.Code = "03";
			dpo.Definition = "Variable Per Diem";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 143;
			dpo.ElementInstance_ID = 51;
			dpo.Code = "04";
			dpo.Definition = "Flat";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 144;
			dpo.ElementInstance_ID = 51;
			dpo.Code = "05";
			dpo.Definition = "Capitated";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 145;
			dpo.ElementInstance_ID = 51;
			dpo.Code = "06";
			dpo.Definition = "Percent";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 146;
			dpo.ElementInstance_ID = 51;
			dpo.Code = "09";
			dpo.Definition = "Other";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 147;
			dpo.ElementInstance_ID = 52;
			dpo.Code = "F5";
			dpo.Definition = "Patient Amount Paid";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 148;
			dpo.ElementInstance_ID = 53;
			dpo.Code = "4N";
			dpo.Definition = "Special Payment Reference Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 149;
			dpo.ElementInstance_ID = 54;
			dpo.Code = "F5";
			dpo.Definition = "Medicare Version Code";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 150;
			dpo.ElementInstance_ID = 55;
			dpo.Code = "EW";
			dpo.Definition = "Mammography Certification Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 151;
			dpo.ElementInstance_ID = 56;
			dpo.Code = "9F";
			dpo.Definition = "Referral Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 152;
			dpo.ElementInstance_ID = 57;
			dpo.Code = "G1";
			dpo.Definition = "Prior Authorization Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 153;
			dpo.ElementInstance_ID = 58;
			dpo.Code = "F8";
			dpo.Definition = "Original Reference Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 154;
			dpo.ElementInstance_ID = 59;
			dpo.Code = "X4";
			dpo.Definition = "Clinical Laboratory Improvement Amendment Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 155;
			dpo.ElementInstance_ID = 60;
			dpo.Code = "9A";
			dpo.Definition = "Repriced Claim Reference Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 156;
			dpo.ElementInstance_ID = 61;
			dpo.Code = "9C";
			dpo.Definition = "Adjusted Repriced Claim Reference Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 157;
			dpo.ElementInstance_ID = 62;
			dpo.Code = "LX";
			dpo.Definition = "Qualified Products List";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 158;
			dpo.ElementInstance_ID = 63;
			dpo.Code = "D9";
			dpo.Definition = "Claim Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 159;
			dpo.ElementInstance_ID = 64;
			dpo.Code = "EA";
			dpo.Definition = "Medical Record Identification Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 160;
			dpo.ElementInstance_ID = 65;
			dpo.Code = "P4";
			dpo.Definition = "Project Code";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 161;
			dpo.ElementInstance_ID = 66;
			dpo.Code = "1J";
			dpo.Definition = "Facility ID Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 162;
			dpo.ElementInstance_ID = 67;
			dpo.Code = "ADD";
			dpo.Definition = "Additional Information";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 163;
			dpo.ElementInstance_ID = 67;
			dpo.Code = "CER";
			dpo.Definition = "Certification Narrative";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 164;
			dpo.ElementInstance_ID = 67;
			dpo.Code = "DCP";
			dpo.Definition = "Goals, Rehabilitation Potential, or Discharge Plans";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 165;
			dpo.ElementInstance_ID = 67;
			dpo.Code = "DGN";
			dpo.Definition = "Diagnosis Description";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 166;
			dpo.ElementInstance_ID = 67;
			dpo.Code = "TPO";
			dpo.Definition = "Third Party Organization Notes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 167;
			dpo.ElementInstance_ID = 68;
			dpo.Code = "LB";
			dpo.Definition = "Pound";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 168;
			dpo.ElementInstance_ID = 69;
			dpo.Code = "07";
			dpo.Definition = "Ambulance Certification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 169;
			dpo.ElementInstance_ID = 70;
			dpo.Code = "E1";
			dpo.Definition = "Spectacle Lenses";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 170;
			dpo.ElementInstance_ID = 70;
			dpo.Code = "E2";
			dpo.Definition = "Contact Lenses";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 171;
			dpo.ElementInstance_ID = 70;
			dpo.Code = "E3";
			dpo.Definition = "Spectacle Frames";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 172;
			dpo.ElementInstance_ID = 71;
			dpo.Code = "75";
			dpo.Definition = "Functional Limitations";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 173;
			dpo.ElementInstance_ID = 72;
			dpo.Code = "ZZ";
			dpo.Definition = "Mutually Defined";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 174;
			dpo.ElementInstance_ID = 73;
			dpo.Code = "ABK";
			dpo.Definition = "International Classification of Diseases Clinical Modification (ICD-10-CM) Principal Diagnosis";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 175;
			dpo.ElementInstance_ID = 73;
			dpo.Code = "BK";
			dpo.Definition = "International Classification of Diseases Clinical Modification (ICD-9-CM) Principal Diagnosis";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 176;
			dpo.ElementInstance_ID = 74;
			dpo.Code = "BP";
			dpo.Definition = "Health Care Financing Administration Common Procedural Coding System Principal Procedure";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 177;
			dpo.ElementInstance_ID = 75;
			dpo.Code = "BG";
			dpo.Definition = "Condition";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 178;
			dpo.ElementInstance_ID = 76;
			dpo.Code = "00";
			dpo.Definition = "Zero Pricing (Not Covered Under Contract)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 179;
			dpo.ElementInstance_ID = 76;
			dpo.Code = "01";
			dpo.Definition = "Priced as Billed at 100%";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 180;
			dpo.ElementInstance_ID = 76;
			dpo.Code = "02";
			dpo.Definition = "Priced at the Standard Fee Schedule";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 181;
			dpo.ElementInstance_ID = 76;
			dpo.Code = "03";
			dpo.Definition = "Priced at a Contractual Percentage";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 182;
			dpo.ElementInstance_ID = 76;
			dpo.Code = "04";
			dpo.Definition = "Bundled Pricing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 183;
			dpo.ElementInstance_ID = 76;
			dpo.Code = "05";
			dpo.Definition = "Peer Review Pricing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 184;
			dpo.ElementInstance_ID = 76;
			dpo.Code = "07";
			dpo.Definition = "Flat Rate Pricing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 185;
			dpo.ElementInstance_ID = 76;
			dpo.Code = "08";
			dpo.Definition = "Combination Pricing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 186;
			dpo.ElementInstance_ID = 76;
			dpo.Code = "09";
			dpo.Definition = "Maternity Pricing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 187;
			dpo.ElementInstance_ID = 76;
			dpo.Code = "10";
			dpo.Definition = "Other Pricing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 188;
			dpo.ElementInstance_ID = 76;
			dpo.Code = "11";
			dpo.Definition = "Lower of Cost";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 189;
			dpo.ElementInstance_ID = 76;
			dpo.Code = "12";
			dpo.Definition = "Ratio of Cost";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 190;
			dpo.ElementInstance_ID = 76;
			dpo.Code = "13";
			dpo.Definition = "Cost Reimbursed";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 191;
			dpo.ElementInstance_ID = 76;
			dpo.Code = "14";
			dpo.Definition = "Adjustment Pricing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 192;
			dpo.ElementInstance_ID = 77;
			dpo.Code = "DN";
			dpo.Definition = "Referring Provider";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 193;
			dpo.ElementInstance_ID = 77;
			dpo.Code = "P3";
			dpo.Definition = "Primary Care Provider";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 194;
			dpo.ElementInstance_ID = 78;
			dpo.Code = "0B";
			dpo.Definition = "State License Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 195;
			dpo.ElementInstance_ID = 78;
			dpo.Code = "1G";
			dpo.Definition = "Provider UPIN Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 196;
			dpo.ElementInstance_ID = 78;
			dpo.Code = "G2";
			dpo.Definition = "Provider Commercial Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 197;
			dpo.ElementInstance_ID = 79;
			dpo.Code = "82";
			dpo.Definition = "Rendering Provider";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 198;
			dpo.ElementInstance_ID = 80;
			dpo.Code = "PE";
			dpo.Definition = "Performing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 199;
			dpo.ElementInstance_ID = 81;
			dpo.Code = "0B";
			dpo.Definition = "State License Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 200;
			dpo.ElementInstance_ID = 81;
			dpo.Code = "1G";
			dpo.Definition = "Provider UPIN Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 201;
			dpo.ElementInstance_ID = 81;
			dpo.Code = "G2";
			dpo.Definition = "Provider Commercial Number ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 202;
			dpo.ElementInstance_ID = 82;
			dpo.Code = "77";
			dpo.Definition = "Service Location";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 203;
			dpo.ElementInstance_ID = 83;
			dpo.Code = "0B";
			dpo.Definition = "State License Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 204;
			dpo.ElementInstance_ID = 83;
			dpo.Code = "G2";
			dpo.Definition = "Provider Commercial Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 205;
			dpo.ElementInstance_ID = 83;
			dpo.Code = "LU";
			dpo.Definition = "Location Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 206;
			dpo.ElementInstance_ID = 84;
			dpo.Code = "IC";
			dpo.Definition = "Information Contact";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 207;
			dpo.ElementInstance_ID = 85;
			dpo.Code = "DQ";
			dpo.Definition = "Supervising Physician";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 208;
			dpo.ElementInstance_ID = 86;
			dpo.Code = "0B";
			dpo.Definition = "State License Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 209;
			dpo.ElementInstance_ID = 86;
			dpo.Code = "1G";
			dpo.Definition = "Provider UPIN Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 210;
			dpo.ElementInstance_ID = 86;
			dpo.Code = "G2";
			dpo.Definition = "Provider Commercial Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 211;
			dpo.ElementInstance_ID = 86;
			dpo.Code = "LU";
			dpo.Definition = "Location Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 212;
			dpo.ElementInstance_ID = 87;
			dpo.Code = "PW";
			dpo.Definition = "Pickup Address";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 213;
			dpo.ElementInstance_ID = 88;
			dpo.Code = "45";
			dpo.Definition = "Drop-off Location";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 214;
			dpo.ElementInstance_ID = 89;
			dpo.Code = "A";
			dpo.Definition = "Payer Responsibility Four";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 215;
			dpo.ElementInstance_ID = 89;
			dpo.Code = "B";
			dpo.Definition = "Payer Responsibility Five";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 216;
			dpo.ElementInstance_ID = 89;
			dpo.Code = "C";
			dpo.Definition = "Payer Responsibility Six ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 217;
			dpo.ElementInstance_ID = 89;
			dpo.Code = "D";
			dpo.Definition = "Payer Responsibility Seven ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 218;
			dpo.ElementInstance_ID = 89;
			dpo.Code = "E";
			dpo.Definition = "Payer Responsibility Eight";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 219;
			dpo.ElementInstance_ID = 89;
			dpo.Code = "F";
			dpo.Definition = "Payer Responsibility Nine";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 220;
			dpo.ElementInstance_ID = 89;
			dpo.Code = "G";
			dpo.Definition = "Payer Responsibility Ten";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 221;
			dpo.ElementInstance_ID = 89;
			dpo.Code = "H";
			dpo.Definition = "Payer Responsibility Eleven";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 222;
			dpo.ElementInstance_ID = 89;
			dpo.Code = "P";
			dpo.Definition = "Primary";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 223;
			dpo.ElementInstance_ID = 89;
			dpo.Code = "S";
			dpo.Definition = "Secondary";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 224;
			dpo.ElementInstance_ID = 89;
			dpo.Code = "T";
			dpo.Definition = "Tertiary";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 225;
			dpo.ElementInstance_ID = 89;
			dpo.Code = "U";
			dpo.Definition = "Unknown";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 226;
			dpo.ElementInstance_ID = 90;
			dpo.Code = "CO";
			dpo.Definition = "Contractual Obligations";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 227;
			dpo.ElementInstance_ID = 90;
			dpo.Code = "CR";
			dpo.Definition = "Correction and Reversals";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 228;
			dpo.ElementInstance_ID = 90;
			dpo.Code = "OA";
			dpo.Definition = "Other adjustments";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 229;
			dpo.ElementInstance_ID = 90;
			dpo.Code = "PI";
			dpo.Definition = "Payor Initiated Reductions";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 230;
			dpo.ElementInstance_ID = 90;
			dpo.Code = "PR";
			dpo.Definition = "Patient Responsibility";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 231;
			dpo.ElementInstance_ID = 91;
			dpo.Code = "D";
			dpo.Definition = "Payor Amount Paid";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 232;
			dpo.ElementInstance_ID = 92;
			dpo.Code = "A8";
			dpo.Definition = "Noncovered Charges - Actual";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 234;
			dpo.ElementInstance_ID = 92;
			dpo.Code = "EAF";
			dpo.Definition = "Amount Owed";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 233;
			dpo.ElementInstance_ID = 93;
			dpo.Code = "A8";
			dpo.Definition = "Noncovered Charges - Actual";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 235;
			dpo.ElementInstance_ID = 94;
			dpo.Code = "IL";
			dpo.Definition = "Insured or Subscriber";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 236;
			dpo.ElementInstance_ID = 95;
			dpo.Code = "SY";
			dpo.Definition = "Social Security Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 237;
			dpo.ElementInstance_ID = 96;
			dpo.Code = "PR";
			dpo.Definition = "Payer";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 238;
			dpo.ElementInstance_ID = 97;
			dpo.Code = "573";
			dpo.Definition = "Date Claim Paid";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 239;
			dpo.ElementInstance_ID = 98;
			dpo.Code = "2U";
			dpo.Definition = "Payer Identification Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 240;
			dpo.ElementInstance_ID = 98;
			dpo.Code = "EI";
			dpo.Definition = "Employer's Identification Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 241;
			dpo.ElementInstance_ID = 98;
			dpo.Code = "FY";
			dpo.Definition = "Claim Office Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 242;
			dpo.ElementInstance_ID = 98;
			dpo.Code = "NF";
			dpo.Definition = "National Association of Insurance Commissioners (NAIC) Code";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 243;
			dpo.ElementInstance_ID = 99;
			dpo.Code = "G1";
			dpo.Definition = "Prior Authorization Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 244;
			dpo.ElementInstance_ID = 100;
			dpo.Code = "9F";
			dpo.Definition = "Referral Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 245;
			dpo.ElementInstance_ID = 101;
			dpo.Code = "T4";
			dpo.Definition = "Signal Code";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 246;
			dpo.ElementInstance_ID = 102;
			dpo.Code = "F8";
			dpo.Definition = "Original Reference Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 247;
			dpo.ElementInstance_ID = 103;
			dpo.Code = "DN";
			dpo.Definition = "Referring Provider";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 248;
			dpo.ElementInstance_ID = 103;
			dpo.Code = "P3";
			dpo.Definition = "Primary Care Provider";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 249;
			dpo.ElementInstance_ID = 104;
			dpo.Code = "0B";
			dpo.Definition = "State License Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 250;
			dpo.ElementInstance_ID = 104;
			dpo.Code = "1G";
			dpo.Definition = "Provider UPIN Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 251;
			dpo.ElementInstance_ID = 104;
			dpo.Code = "G2";
			dpo.Definition = "Provider Commercial Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 252;
			dpo.ElementInstance_ID = 105;
			dpo.Code = "82";
			dpo.Definition = "Rendering Provider";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 253;
			dpo.ElementInstance_ID = 106;
			dpo.Code = "0B";
			dpo.Definition = "State License Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 254;
			dpo.ElementInstance_ID = 106;
			dpo.Code = "1G";
			dpo.Definition = "Provider UPIN Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 255;
			dpo.ElementInstance_ID = 106;
			dpo.Code = "G2";
			dpo.Definition = "Provider Commercial Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 256;
			dpo.ElementInstance_ID = 106;
			dpo.Code = "LU";
			dpo.Definition = "Location Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 257;
			dpo.ElementInstance_ID = 107;
			dpo.Code = "77";
			dpo.Definition = "Service Location";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 258;
			dpo.ElementInstance_ID = 108;
			dpo.Code = "0B";
			dpo.Definition = "State License Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 259;
			dpo.ElementInstance_ID = 108;
			dpo.Code = "G2";
			dpo.Definition = "Provider Commercial Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 260;
			dpo.ElementInstance_ID = 108;
			dpo.Code = "LU";
			dpo.Definition = "Location Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 261;
			dpo.ElementInstance_ID = 109;
			dpo.Code = "DQ";
			dpo.Definition = "Supervising Physician";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 262;
			dpo.ElementInstance_ID = 110;
			dpo.Code = "0B";
			dpo.Definition = "State License Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 263;
			dpo.ElementInstance_ID = 110;
			dpo.Code = "1G";
			dpo.Definition = "Provider UPIN Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 264;
			dpo.ElementInstance_ID = 110;
			dpo.Code = "G2";
			dpo.Definition = "Provider Commercial Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 265;
			dpo.ElementInstance_ID = 110;
			dpo.Code = "LU";
			dpo.Definition = "Location Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 266;
			dpo.ElementInstance_ID = 111;
			dpo.Code = "85";
			dpo.Definition = "Billing Provider";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 267;
			dpo.ElementInstance_ID = 112;
			dpo.Code = "G2";
			dpo.Definition = "Provider Commercial Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 268;
			dpo.ElementInstance_ID = 112;
			dpo.Code = "LU";
			dpo.Definition = "Location Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 269;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "03";
			dpo.Definition = "Report Justifying Treatment Beyond Utilization Guidelines";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 270;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "04";
			dpo.Definition = "Drugs Administered";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 271;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "05";
			dpo.Definition = "Treatment Diagnosis";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 272;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "06";
			dpo.Definition = "Initial Assessment";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 273;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "07";
			dpo.Definition = "Functional Goals";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 274;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "08";
			dpo.Definition = "Plan of Treatment";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 275;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "09";
			dpo.Definition = "Progress Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 276;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "10";
			dpo.Definition = "Continued Treatment";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 277;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "11";
			dpo.Definition = "Chemical Analysis";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 278;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "13";
			dpo.Definition = "Certified Test Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 279;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "15";
			dpo.Definition = "Justification for Admission";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 280;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "21";
			dpo.Definition = "Recovery Plan";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 281;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "A3";
			dpo.Definition = "Allergies/Sensitivities Document";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 282;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "A4";
			dpo.Definition = "Autopsy Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 283;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "AM";
			dpo.Definition = "Ambulance Certification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 284;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "AS";
			dpo.Definition = "Admission Summary";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 285;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "B2";
			dpo.Definition = "Prescription";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 286;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "B3";
			dpo.Definition = "Physician Order";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 287;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "B4";
			dpo.Definition = "Referral Form";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 288;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "BR";
			dpo.Definition = "Benchmark Testing Results";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 289;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "BS";
			dpo.Definition = "Baseline";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 290;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "BT";
			dpo.Definition = "Blanket Test Results";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 291;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "CB";
			dpo.Definition = "Chiropractic Justification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 292;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "CK";
			dpo.Definition = "Consent Form(s)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 293;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "CT";
			dpo.Definition = "Certification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 294;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "D2";
			dpo.Definition = "Drug Profile Document";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 295;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "DA";
			dpo.Definition = "Dental Models";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 296;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "DB";
			dpo.Definition = "Durable Medical Equipment Prescription";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 297;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "DG";
			dpo.Definition = "Diagnostic Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 298;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "DJ";
			dpo.Definition = "Discharge Monitoring Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 299;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "DS";
			dpo.Definition = "Discharge Summary";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 300;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "EB";
			dpo.Definition = "Explanation of Benefits (Coordination of Benefits or Medicare Secondary Payor)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 301;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "HC";
			dpo.Definition = "Health Certificate";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 302;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "HR";
			dpo.Definition = "Health Clinic Records";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 303;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "I5";
			dpo.Definition = "Immunization Record";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 304;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "IR";
			dpo.Definition = "State School Immunization Records";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 305;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "LA";
			dpo.Definition = "Laboratory Results";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 306;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "M1";
			dpo.Definition = "Medical Record Attachment";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 307;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "MT";
			dpo.Definition = "Models";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 308;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "NN";
			dpo.Definition = "Nursing Notes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 309;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "OB";
			dpo.Definition = "Operative Note";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 310;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "OC";
			dpo.Definition = "Oxygen Content Averaging Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 311;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "OD";
			dpo.Definition = "Orders and Treatments Document";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 312;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "OE";
			dpo.Definition = "Objective Physical Examination (including vital signs) Document";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 313;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "OX";
			dpo.Definition = "Oxygen Therapy Certification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 314;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "OZ";
			dpo.Definition = "Support Data for Claim";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 315;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "P4";
			dpo.Definition = "Pathology Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 316;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "P5";
			dpo.Definition = "Patient Medical History Document";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 317;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "PE";
			dpo.Definition = "Parenteral or Enteral Certification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 318;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "PN";
			dpo.Definition = "Physical Therapy Notes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 319;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "PO";
			dpo.Definition = "Prosthetics or Orthotic Certification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 320;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "PQ";
			dpo.Definition = "Paramedical Results";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 321;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "PY";
			dpo.Definition = "Physician's Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 322;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "PZ";
			dpo.Definition = "Physical Therapy Certification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 323;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "RB";
			dpo.Definition = "Radiology Films";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 324;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "RR";
			dpo.Definition = "Radiology Reports";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 325;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "RT";
			dpo.Definition = "Report of Tests and Analysis Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 326;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "RX";
			dpo.Definition = "Renewable Oxygen Content Averaging Report";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 327;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "SG";
			dpo.Definition = "Symptoms Document";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 328;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "V5";
			dpo.Definition = "Death Notification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 329;
			dpo.ElementInstance_ID = 113;
			dpo.Code = "XP";
			dpo.Definition = "Photographs";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 330;
			dpo.ElementInstance_ID = 114;
			dpo.Code = "CT";
			dpo.Definition = "Certification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 331;
			dpo.ElementInstance_ID = 115;
			dpo.Code = "LB";
			dpo.Definition = "Pound";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 332;
			dpo.ElementInstance_ID = 116;
			dpo.Code = "1";
			dpo.Definition = "Initial";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 333;
			dpo.ElementInstance_ID = 116;
			dpo.Code = "R";
			dpo.Definition = "Renewal";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 334;
			dpo.ElementInstance_ID = 116;
			dpo.Code = "S";
			dpo.Definition = "Revised";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 335;
			dpo.ElementInstance_ID = 117;
			dpo.Code = "07";
			dpo.Definition = "Ambulance Certification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 336;
			dpo.ElementInstance_ID = 118;
			dpo.Code = "70";
			dpo.Definition = "Hospice";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 337;
			dpo.ElementInstance_ID = 119;
			dpo.Code = "09";
			dpo.Definition = "Durable Medical Equipment Certification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 338;
			dpo.ElementInstance_ID = 120;
			dpo.Code = "472";
			dpo.Definition = "Service";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 339;
			dpo.ElementInstance_ID = 121;
			dpo.Code = "471";
			dpo.Definition = "Prescription";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 340;
			dpo.ElementInstance_ID = 122;
			dpo.Code = "607";
			dpo.Definition = "Certification Revision";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 341;
			dpo.ElementInstance_ID = 123;
			dpo.Code = "463";
			dpo.Definition = "Begin Therapy";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 342;
			dpo.ElementInstance_ID = 124;
			dpo.Code = "461";
			dpo.Definition = "Last Certification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 343;
			dpo.ElementInstance_ID = 125;
			dpo.Code = "304";
			dpo.Definition = "Latest Visit or Consultation";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 344;
			dpo.ElementInstance_ID = 126;
			dpo.Code = "738";
			dpo.Definition = "Most Recent Hemoglobin or Hematocrit or Both";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 345;
			dpo.ElementInstance_ID = 126;
			dpo.Code = "739";
			dpo.Definition = "Most Recent Serum Creatine";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 346;
			dpo.ElementInstance_ID = 127;
			dpo.Code = "011";
			dpo.Definition = "Shipped";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 347;
			dpo.ElementInstance_ID = 128;
			dpo.Code = "455";
			dpo.Definition = "Last X-Ray";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 348;
			dpo.ElementInstance_ID = 129;
			dpo.Code = "454";
			dpo.Definition = "Initial Treatment";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 349;
			dpo.ElementInstance_ID = 130;
			dpo.Code = "PT";
			dpo.Definition = "Patients";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 350;
			dpo.ElementInstance_ID = 131;
			dpo.Code = "FL";
			dpo.Definition = "Units";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 351;
			dpo.ElementInstance_ID = 132;
			dpo.Code = "OG";
			dpo.Definition = "Original";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 352;
			dpo.ElementInstance_ID = 132;
			dpo.Code = "TR";
			dpo.Definition = "Test Results";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 353;
			dpo.ElementInstance_ID = 133;
			dpo.Code = "01";
			dpo.Definition = "Diagnosis Related Group (DRG)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 354;
			dpo.ElementInstance_ID = 133;
			dpo.Code = "02";
			dpo.Definition = "Per Diem";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 355;
			dpo.ElementInstance_ID = 133;
			dpo.Code = "03";
			dpo.Definition = "Variable Per Diem";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 356;
			dpo.ElementInstance_ID = 133;
			dpo.Code = "04";
			dpo.Definition = "Flat";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 357;
			dpo.ElementInstance_ID = 133;
			dpo.Code = "05";
			dpo.Definition = "Capitated";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 358;
			dpo.ElementInstance_ID = 133;
			dpo.Code = "06";
			dpo.Definition = "Percent";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 359;
			dpo.ElementInstance_ID = 133;
			dpo.Code = "09";
			dpo.Definition = "Other";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 360;
			dpo.ElementInstance_ID = 134;
			dpo.Code = "9B";
			dpo.Definition = "Repriced Line Item Reference Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 361;
			dpo.ElementInstance_ID = 135;
			dpo.Code = "9D";
			dpo.Definition = "Adjusted Repriced Line Item Reference Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 362;
			dpo.ElementInstance_ID = 136;
			dpo.Code = "G1";
			dpo.Definition = "Prior Authorization Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 363;
			dpo.ElementInstance_ID = 137;
			dpo.Code = "6R";
			dpo.Definition = "Provider Control Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 364;
			dpo.ElementInstance_ID = 138;
			dpo.Code = "EW";
			dpo.Definition = "Mammography Certification Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 365;
			dpo.ElementInstance_ID = 139;
			dpo.Code = "X4";
			dpo.Definition = "Clinical Laboratory Improvement Amendment Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 366;
			dpo.ElementInstance_ID = 140;
			dpo.Code = "F4";
			dpo.Definition = "Facility Certification Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 367;
			dpo.ElementInstance_ID = 141;
			dpo.Code = "BT";
			dpo.Definition = "Batch Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 368;
			dpo.ElementInstance_ID = 142;
			dpo.Code = "9F";
			dpo.Definition = "Referral Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 369;
			dpo.ElementInstance_ID = 143;
			dpo.Code = "T";
			dpo.Definition = "Tax";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 370;
			dpo.ElementInstance_ID = 144;
			dpo.Code = "F4";
			dpo.Definition = "Postage Claimed";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 371;
			dpo.ElementInstance_ID = 145;
			dpo.Code = "ADD";
			dpo.Definition = "Additional Information";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 372;
			dpo.ElementInstance_ID = 145;
			dpo.Code = "DCP";
			dpo.Definition = "Goals, Rehabilitation Potential, or Discharge Plans";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 373;
			dpo.ElementInstance_ID = 146;
			dpo.Code = "TPO";
			dpo.Definition = "Third Party Organization Notes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 374;
			dpo.ElementInstance_ID = 147;
			dpo.Code = "00";
			dpo.Definition = "Zero Pricing (Not Covered Under Contract";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 375;
			dpo.ElementInstance_ID = 147;
			dpo.Code = "01";
			dpo.Definition = "Priced as Billed at 100%";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 376;
			dpo.ElementInstance_ID = 147;
			dpo.Code = "02";
			dpo.Definition = "Priced at the Standard Fee Schedule";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 377;
			dpo.ElementInstance_ID = 147;
			dpo.Code = "03";
			dpo.Definition = "Priced at a Contractual Percentage";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 378;
			dpo.ElementInstance_ID = 147;
			dpo.Code = "04";
			dpo.Definition = "Bundled Pricing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 379;
			dpo.ElementInstance_ID = 147;
			dpo.Code = "05";
			dpo.Definition = "Peer Review Pricing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 380;
			dpo.ElementInstance_ID = 147;
			dpo.Code = "06";
			dpo.Definition = "Per Diem Pricing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 381;
			dpo.ElementInstance_ID = 147;
			dpo.Code = "07";
			dpo.Definition = "Flat Rate Pricing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 382;
			dpo.ElementInstance_ID = 147;
			dpo.Code = "08";
			dpo.Definition = "Combination Pricing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 383;
			dpo.ElementInstance_ID = 147;
			dpo.Code = "09";
			dpo.Definition = "Maternity Pricing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 384;
			dpo.ElementInstance_ID = 147;
			dpo.Code = "10";
			dpo.Definition = "Other Pricing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 385;
			dpo.ElementInstance_ID = 147;
			dpo.Code = "11";
			dpo.Definition = "Lower of Cost";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 386;
			dpo.ElementInstance_ID = 147;
			dpo.Code = "12";
			dpo.Definition = "Ratio of Cost";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 387;
			dpo.ElementInstance_ID = 147;
			dpo.Code = "13";
			dpo.Definition = "Cost Reimbursed";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 388;
			dpo.ElementInstance_ID = 147;
			dpo.Code = "14";
			dpo.Definition = "Adjustment Pricing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 389;
			dpo.ElementInstance_ID = 148;
			dpo.Code = "VY";
			dpo.Definition = "Link Sequence Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 390;
			dpo.ElementInstance_ID = 148;
			dpo.Code = "XZ";
			dpo.Definition = "Pharmacy Prescription Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 391;
			dpo.ElementInstance_ID = 149;
			dpo.Code = "82";
			dpo.Definition = "Rendering Provider";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 392;
			dpo.ElementInstance_ID = 150;
			dpo.Code = "PE";
			dpo.Definition = "Performing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 393;
			dpo.ElementInstance_ID = 151;
			dpo.Code = "0B";
			dpo.Definition = "State License Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 394;
			dpo.ElementInstance_ID = 151;
			dpo.Code = "1G";
			dpo.Definition = "Provider UPIN Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 395;
			dpo.ElementInstance_ID = 151;
			dpo.Code = "G2";
			dpo.Definition = "Provider Commercial Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 396;
			dpo.ElementInstance_ID = 151;
			dpo.Code = "LU";
			dpo.Definition = "Location Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 397;
			dpo.ElementInstance_ID = 152;
			dpo.Code = "QB";
			dpo.Definition = "Purchase Service Provider";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 398;
			dpo.ElementInstance_ID = 153;
			dpo.Code = "0B";
			dpo.Definition = "State License Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 399;
			dpo.ElementInstance_ID = 153;
			dpo.Code = "1G";
			dpo.Definition = "Provider UPIN Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 400;
			dpo.ElementInstance_ID = 153;
			dpo.Code = "G2";
			dpo.Definition = "Provider Commercial Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 401;
			dpo.ElementInstance_ID = 154;
			dpo.Code = "77";
			dpo.Definition = "Service Location";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 402;
			dpo.ElementInstance_ID = 155;
			dpo.Code = "G2";
			dpo.Definition = "Provider Commercial Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 403;
			dpo.ElementInstance_ID = 155;
			dpo.Code = "LU";
			dpo.Definition = "Location Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 404;
			dpo.ElementInstance_ID = 156;
			dpo.Code = "DQ";
			dpo.Definition = "Supervising Physician";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 405;
			dpo.ElementInstance_ID = 157;
			dpo.Code = "0B";
			dpo.Definition = "State License Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 406;
			dpo.ElementInstance_ID = 157;
			dpo.Code = "1G";
			dpo.Definition = "Provider UPIN Numb";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 407;
			dpo.ElementInstance_ID = 157;
			dpo.Code = "G2";
			dpo.Definition = "Provider Commercial Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 408;
			dpo.ElementInstance_ID = 157;
			dpo.Code = "LU";
			dpo.Definition = "Location Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 409;
			dpo.ElementInstance_ID = 158;
			dpo.Code = "DK";
			dpo.Definition = "Ordering Physician";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 410;
			dpo.ElementInstance_ID = 159;
			dpo.Code = "0B";
			dpo.Definition = "State License Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 411;
			dpo.ElementInstance_ID = 159;
			dpo.Code = "1G";
			dpo.Definition = "Provider UPIN Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 412;
			dpo.ElementInstance_ID = 159;
			dpo.Code = "G2";
			dpo.Definition = "Provider Commercial Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 413;
			dpo.ElementInstance_ID = 160;
			dpo.Code = "IC";
			dpo.Definition = "Information Contact";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 414;
			dpo.ElementInstance_ID = 161;
			dpo.Code = "DN";
			dpo.Definition = "Referring Provider";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 415;
			dpo.ElementInstance_ID = 161;
			dpo.Code = "P3";
			dpo.Definition = "Primary Care Provider";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 416;
			dpo.ElementInstance_ID = 162;
			dpo.Code = "0B";
			dpo.Definition = "State License Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 417;
			dpo.ElementInstance_ID = 162;
			dpo.Code = "1G";
			dpo.Definition = "Provider UPIN Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 418;
			dpo.ElementInstance_ID = 162;
			dpo.Code = "G2";
			dpo.Definition = "Provider Commercial Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 419;
			dpo.ElementInstance_ID = 163;
			dpo.Code = "PW";
			dpo.Definition = "Pickup Address";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 420;
			dpo.ElementInstance_ID = 164;
			dpo.Code = "45";
			dpo.Definition = "Drop-off Location";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 421;
			dpo.ElementInstance_ID = 165;
			dpo.Code = "CO";
			dpo.Definition = "Contractual Obligations";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 422;
			dpo.ElementInstance_ID = 165;
			dpo.Code = "CR";
			dpo.Definition = "Correction and Reversals";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 423;
			dpo.ElementInstance_ID = 165;
			dpo.Code = "OA";
			dpo.Definition = "Other adjustmen";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 424;
			dpo.ElementInstance_ID = 165;
			dpo.Code = "PI";
			dpo.Definition = "Payor Initiated Reductions ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 425;
			dpo.ElementInstance_ID = 165;
			dpo.Code = "PR";
			dpo.Definition = "Patient Responsibility";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 426;
			dpo.ElementInstance_ID = 166;
			dpo.Code = "573";
			dpo.Definition = "Date Claim Paid";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 427;
			dpo.ElementInstance_ID = 167;
			dpo.Code = "AS";
			dpo.Definition = "Form Type Code";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 428;
			dpo.ElementInstance_ID = 167;
			dpo.Code = "UT";
			dpo.Definition = @"Centers for Medicare and Medicaid Services (CMS) Durable Medical Equipment Regional Carrier (DMERC) Certificate of Medical Necessity (CMN) Forms";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 429;
			dpo.ElementInstance_ID = 168;
			dpo.Code = "20";
			dpo.Definition = "Information Source";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 430;
			dpo.ElementInstance_ID = 169;
			dpo.Code = "22";
			dpo.Definition = "Subscriber";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 431;
			dpo.ElementInstance_ID = 170;
			dpo.Code = "23";
			dpo.Definition = "Dependent";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 432;
			dpo.ElementInstance_ID = 171;
			dpo.Code = "EM";
			dpo.Definition = "Electronic Mail";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 433;
			dpo.ElementInstance_ID = 171;
			dpo.Code = "FX";
			dpo.Definition = "Facsimile";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 434;
			dpo.ElementInstance_ID = 171;
			dpo.Code = "TE";
			dpo.Definition = "Telephone";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 435;
			dpo.ElementInstance_ID = 172;
			dpo.Code = "EM";
			dpo.Definition = "Electronic Mail";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 436;
			dpo.ElementInstance_ID = 172;
			dpo.Code = "EX";
			dpo.Definition = "Telephone Extension";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 437;
			dpo.ElementInstance_ID = 172;
			dpo.Code = "FX";
			dpo.Definition = "Facsimile";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 438;
			dpo.ElementInstance_ID = 172;
			dpo.Code = "TE";
			dpo.Definition = "Telephone";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 439;
			dpo.ElementInstance_ID = 173;
			dpo.Code = "EM";
			dpo.Definition = "Electronic Mail";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 440;
			dpo.ElementInstance_ID = 173;
			dpo.Code = "EX";
			dpo.Definition = "Telephone Extension";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 441;
			dpo.ElementInstance_ID = 173;
			dpo.Code = "FX";
			dpo.Definition = "Facsimile";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 442;
			dpo.ElementInstance_ID = 173;
			dpo.Code = "TE";
			dpo.Definition = "Telephone";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 443;
			dpo.ElementInstance_ID = 174;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 444;
			dpo.ElementInstance_ID = 175;
			dpo.Code = "46";
			dpo.Definition = "Electronic Transmitter Identification Number (ETIN)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 445;
			dpo.ElementInstance_ID = 176;
			dpo.Code = "1";
			dpo.Definition = "Additional Subordinate HL Data Segment in This Hierarchical Structure";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 446;
			dpo.ElementInstance_ID = 177;
			dpo.Code = "PXC";
			dpo.Definition = "Health Care Provider Taxonomy Code";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 447;
			dpo.ElementInstance_ID = 178;
			dpo.Code = "1";
			dpo.Definition = "Person";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 448;
			dpo.ElementInstance_ID = 178;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 449;
			dpo.ElementInstance_ID = 179;
			dpo.Code = "XX";
			dpo.Definition = "Centers for Medicare and Medicaid Services National Provider Identifier";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 450;
			dpo.ElementInstance_ID = 180;
			dpo.Code = "EM";
			dpo.Definition = "Electronic Mail";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 451;
			dpo.ElementInstance_ID = 180;
			dpo.Code = "FX";
			dpo.Definition = "Facsimile";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 452;
			dpo.ElementInstance_ID = 180;
			dpo.Code = "TE";
			dpo.Definition = "Telephone";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 453;
			dpo.ElementInstance_ID = 181;
			dpo.Code = "EM";
			dpo.Definition = "Electronic Mail";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 454;
			dpo.ElementInstance_ID = 181;
			dpo.Code = "EX";
			dpo.Definition = "Telephone Extension";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 455;
			dpo.ElementInstance_ID = 181;
			dpo.Code = "FX";
			dpo.Definition = "Facsimile";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 456;
			dpo.ElementInstance_ID = 181;
			dpo.Code = "TE";
			dpo.Definition = "Telephone";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 457;
			dpo.ElementInstance_ID = 182;
			dpo.Code = "EM";
			dpo.Definition = "Electronic Mail";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 458;
			dpo.ElementInstance_ID = 182;
			dpo.Code = "EX";
			dpo.Definition = "Telephone Extension";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 459;
			dpo.ElementInstance_ID = 182;
			dpo.Code = "FX";
			dpo.Definition = "Facsimile";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 460;
			dpo.ElementInstance_ID = 182;
			dpo.Code = "TE";
			dpo.Definition = "Telephone";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 461;
			dpo.ElementInstance_ID = 183;
			dpo.Code = "1";
			dpo.Definition = "Person";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 462;
			dpo.ElementInstance_ID = 183;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 463;
			dpo.ElementInstance_ID = 184;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 464;
			dpo.ElementInstance_ID = 185;
			dpo.Code = "PI";
			dpo.Definition = "Payor Identification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 465;
			dpo.ElementInstance_ID = 185;
			dpo.Code = "XV";
			dpo.Definition = "Centers for Medicare and Medicaid Services PlanID";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 466;
			dpo.ElementInstance_ID = 186;
			dpo.Code = "0";
			dpo.Definition = "No Subordinate HL Segment in This Hierarchical Structure. ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 467;
			dpo.ElementInstance_ID = 186;
			dpo.Code = "1";
			dpo.Definition = "Additional Subordinate HL Data Segment in This Hierarchical Structure. ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 468;
			dpo.ElementInstance_ID = 187;
			dpo.Code = "12";
			dpo.Definition = "Medicare Secondary Working Aged Beneficiary or Spouse with Employer Group Health Plan";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 469;
			dpo.ElementInstance_ID = 187;
			dpo.Code = "13";
			dpo.Definition = @"Medicare Secondary End-Stage Renal Disease Beneficiary in the Mandated Coordination Period with an Employer's Group Health Plan";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 470;
			dpo.ElementInstance_ID = 187;
			dpo.Code = "14";
			dpo.Definition = "Medicare Secondary, No-fault Insurance including Auto is Primary";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 471;
			dpo.ElementInstance_ID = 187;
			dpo.Code = "15";
			dpo.Definition = "Medicare Secondary Worker's Compensation";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 472;
			dpo.ElementInstance_ID = 187;
			dpo.Code = "16";
			dpo.Definition = "Medicare Secondary Public Health Service (PHS)or Other Federal Agency";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 473;
			dpo.ElementInstance_ID = 187;
			dpo.Code = "41";
			dpo.Definition = "Medicare Secondary Black Lung";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 474;
			dpo.ElementInstance_ID = 187;
			dpo.Code = "42";
			dpo.Definition = "Medicare Secondary Veteran's Administration";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 475;
			dpo.ElementInstance_ID = 187;
			dpo.Code = "43";
			dpo.Definition = "Medicare Secondary Disabled Beneficiary Under Age 65 with Large Group Health Plan (LGHP)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 476;
			dpo.ElementInstance_ID = 187;
			dpo.Code = "47";
			dpo.Definition = "Medicare Secondary, Other Liability Insurance is Primary";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 477;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "11";
			dpo.Definition = "Other Non-Federal Programs";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 478;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "12";
			dpo.Definition = "Preferred Provider Organization (PPO)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 479;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "13";
			dpo.Definition = "Point of Service (POS)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 480;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "14";
			dpo.Definition = "Exclusive Provider Organization (EPO) ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 481;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "15";
			dpo.Definition = "Indemnity Insurance";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 482;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "16";
			dpo.Definition = "Health Maintenance Organization (HMO) Medicare Risk";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 483;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "17";
			dpo.Definition = "Dental Maintenance Organization";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 484;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "AM";
			dpo.Definition = "Automobile Medical";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 485;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "BL";
			dpo.Definition = "Blue Cross/Blue Shield";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 486;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "CH";
			dpo.Definition = "Champus";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 487;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "CI";
			dpo.Definition = "Commercial Insurance Co.";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 488;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "DS";
			dpo.Definition = "Disability";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 489;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "FI";
			dpo.Definition = "Federal Employees Program";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 490;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "HM";
			dpo.Definition = "Health Maintenance Organization";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 491;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "LM";
			dpo.Definition = "Liability Medical";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 492;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "MA";
			dpo.Definition = "Medicare Part A";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 493;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "MB";
			dpo.Definition = "Medicare Part B";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 494;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "MC";
			dpo.Definition = "Medicaid";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 495;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "OF";
			dpo.Definition = "Other Federal Program,Use code OF when submitting Medicare Part D claims.";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 496;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "TV";
			dpo.Definition = "Title V";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 497;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "VA";
			dpo.Definition = "Veterans Affairs Plan";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 498;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "WC";
			dpo.Definition = "Workers' Compensation Health Claim";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 499;
			dpo.ElementInstance_ID = 188;
			dpo.Code = "ZZ";
			dpo.Definition = "Mutually Defined,Use Code ZZ when Type of Insurance is not known";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 500;
			dpo.ElementInstance_ID = 189;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 501;
			dpo.ElementInstance_ID = 190;
			dpo.Code = "01";
			dpo.Definition = "Actual Pounds";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 502;
			dpo.ElementInstance_ID = 191;
			dpo.Code = "Y";
			dpo.Definition = "Yes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 503;
			dpo.ElementInstance_ID = 192;
			dpo.Code = "II";
			dpo.Definition = "Standard Unique Health Identifier for each Individual in the United States";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 504;
			dpo.ElementInstance_ID = 192;
			dpo.Code = "MI";
			dpo.Definition = "Member Identification Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 505;
			dpo.ElementInstance_ID = 193;
			dpo.Code = "F";
			dpo.Definition = "Female";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 506;
			dpo.ElementInstance_ID = 193;
			dpo.Code = "M";
			dpo.Definition = "Male";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 507;
			dpo.ElementInstance_ID = 193;
			dpo.Code = "U";
			dpo.Definition = "Unknown";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 508;
			dpo.ElementInstance_ID = 194;
			dpo.Code = "TE";
			dpo.Definition = "Telephone";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 509;
			dpo.ElementInstance_ID = 195;
			dpo.Code = "EX";
			dpo.Definition = "Telephone Extension";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 510;
			dpo.ElementInstance_ID = 196;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 511;
			dpo.ElementInstance_ID = 197;
			dpo.Code = "PI";
			dpo.Definition = "Payor Identification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 512;
			dpo.ElementInstance_ID = 197;
			dpo.Code = "XV";
			dpo.Definition = "Centers for Medicare and Medicaid Services PlanID";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 513;
			dpo.ElementInstance_ID = 198;
			dpo.Code = "18";
			dpo.Definition = "Self";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 514;
			dpo.ElementInstance_ID = 199;
			dpo.Code = "0";
			dpo.Definition = "No Subordinate HL Segment in This Hierarchical Structure";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 515;
			dpo.ElementInstance_ID = 200;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 516;
			dpo.ElementInstance_ID = 201;
			dpo.Code = "01";
			dpo.Definition = "Actual Pounds";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 517;
			dpo.ElementInstance_ID = 202;
			dpo.Code = "Y";
			dpo.Definition = "Yes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 518;
			dpo.ElementInstance_ID = 203;
			dpo.Code = "1";
			dpo.Definition = "Person";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 519;
			dpo.ElementInstance_ID = 204;
			dpo.Code = "F";
			dpo.Definition = "Female";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 520;
			dpo.ElementInstance_ID = 204;
			dpo.Code = "M";
			dpo.Definition = "Male";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 521;
			dpo.ElementInstance_ID = 204;
			dpo.Code = "U";
			dpo.Definition = "Unknown";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 522;
			dpo.ElementInstance_ID = 205;
			dpo.Code = "IC";
			dpo.Definition = "Information Contact";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 523;
			dpo.ElementInstance_ID = 206;
			dpo.Code = "TE";
			dpo.Definition = "Telephone";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 524;
			dpo.ElementInstance_ID = 207;
			dpo.Code = "EX";
			dpo.Definition = "Telephone Extension";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 525;
			dpo.ElementInstance_ID = 208;
			dpo.Code = "N";
			dpo.Definition = "No";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 526;
			dpo.ElementInstance_ID = 208;
			dpo.Code = "Y";
			dpo.Definition = "Yes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 527;
			dpo.ElementInstance_ID = 209;
			dpo.Code = "A";
			dpo.Definition = "Assigned";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 528;
			dpo.ElementInstance_ID = 209;
			dpo.Code = "B";
			dpo.Definition = "Assignment Accepted on Clinical Lab Services Only";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 529;
			dpo.ElementInstance_ID = 209;
			dpo.Code = "C";
			dpo.Definition = "Not Assigned";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 530;
			dpo.ElementInstance_ID = 210;
			dpo.Code = "N";
			dpo.Definition = "No";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 531;
			dpo.ElementInstance_ID = 210;
			dpo.Code = "W";
			dpo.Definition = "Not Applicable";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 532;
			dpo.ElementInstance_ID = 210;
			dpo.Code = "Y";
			dpo.Definition = "Yes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 533;
			dpo.ElementInstance_ID = 211;
			dpo.Code = "I";
			dpo.Definition = @"Informed Consent to Release Medical Information for Conditions or Diagnoses Regulated by Federal Statutes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 534;
			dpo.ElementInstance_ID = 211;
			dpo.Code = "Y";
			dpo.Definition = "Yes, Provider has a Signed Statement Permitting Release of Medical Billing Data Related to a Claim";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 535;
			dpo.ElementInstance_ID = 212;
			dpo.Code = "P";
			dpo.Definition = "Signature generated by provider because the patient was not physically present for services";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 536;
			dpo.ElementInstance_ID = 213;
			dpo.Code = "02";
			dpo.Definition = "Physically Handicapped Children's Program";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 537;
			dpo.ElementInstance_ID = 213;
			dpo.Code = "03";
			dpo.Definition = "Special Federal Funding";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 538;
			dpo.ElementInstance_ID = 213;
			dpo.Code = "05";
			dpo.Definition = "Disability";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 539;
			dpo.ElementInstance_ID = 213;
			dpo.Code = "09";
			dpo.Definition = "Second Opinion or Surgery";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 540;
			dpo.ElementInstance_ID = 214;
			dpo.Code = "1";
			dpo.Definition = "Proof of Eligibility Unknown or Unavailable";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 549;
			dpo.ElementInstance_ID = 214;
			dpo.Code = "10";
			dpo.Definition = "Administration Delay in the Prior Approval Process";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 550;
			dpo.ElementInstance_ID = 214;
			dpo.Code = "11";
			dpo.Definition = "Other";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 551;
			dpo.ElementInstance_ID = 214;
			dpo.Code = "12";
			dpo.Definition = "Natural Disaster";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 541;
			dpo.ElementInstance_ID = 214;
			dpo.Code = "2";
			dpo.Definition = "Litigation";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 542;
			dpo.ElementInstance_ID = 214;
			dpo.Code = "3";
			dpo.Definition = "Authorization Delays";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 543;
			dpo.ElementInstance_ID = 214;
			dpo.Code = "4";
			dpo.Definition = "Delay in Certifying Provider";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 544;
			dpo.ElementInstance_ID = 214;
			dpo.Code = "5";
			dpo.Definition = "Delay in Supplying Billing Forms";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 545;
			dpo.ElementInstance_ID = 214;
			dpo.Code = "6";
			dpo.Definition = "Delay in Supplying Billing Forms";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 546;
			dpo.ElementInstance_ID = 214;
			dpo.Code = "7";
			dpo.Definition = "Third Party Processing Delay";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 547;
			dpo.ElementInstance_ID = 214;
			dpo.Code = "8";
			dpo.Definition = "Delay in Eligibility Determination";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 548;
			dpo.ElementInstance_ID = 214;
			dpo.Code = "9";
			dpo.Definition = "Original Claim Rejected or Denied Due to a Reason Unrelated to the Billing Limitation Rules";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 552;
			dpo.ElementInstance_ID = 215;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 553;
			dpo.ElementInstance_ID = 216;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 554;
			dpo.ElementInstance_ID = 217;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMM";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 555;
			dpo.ElementInstance_ID = 217;
			dpo.Code = "RD8";
			dpo.Definition = "Range of Dates Expressed in Format CCYYMMDD-CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 556;
			dpo.ElementInstance_ID = 218;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 557;
			dpo.ElementInstance_ID = 219;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 558;
			dpo.ElementInstance_ID = 220;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 559;
			dpo.ElementInstance_ID = 221;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 560;
			dpo.ElementInstance_ID = 222;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 561;
			dpo.ElementInstance_ID = 223;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 562;
			dpo.ElementInstance_ID = 224;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 563;
			dpo.ElementInstance_ID = 226;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 564;
			dpo.ElementInstance_ID = 227;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 565;
			dpo.ElementInstance_ID = 228;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 566;
			dpo.ElementInstance_ID = 229;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 567;
			dpo.ElementInstance_ID = 230;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 568;
			dpo.ElementInstance_ID = 231;
			dpo.Code = "AA";
			dpo.Definition = "Available on Request at Provider Site";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 569;
			dpo.ElementInstance_ID = 231;
			dpo.Code = "BM";
			dpo.Definition = "By Mail";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 570;
			dpo.ElementInstance_ID = 231;
			dpo.Code = "EL";
			dpo.Definition = "Electronically Only";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 571;
			dpo.ElementInstance_ID = 231;
			dpo.Code = "EM";
			dpo.Definition = "E-Mail";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 572;
			dpo.ElementInstance_ID = 231;
			dpo.Code = "FT";
			dpo.Definition = "File Transfer";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 573;
			dpo.ElementInstance_ID = 231;
			dpo.Code = "FX";
			dpo.Definition = "By Fax";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 574;
			dpo.ElementInstance_ID = 232;
			dpo.Code = "AC";
			dpo.Definition = "Attachment Control Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 576;
			dpo.ElementInstance_ID = 233;
			dpo.Code = "N";
			dpo.Definition = " Regular crossover";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 575;
			dpo.ElementInstance_ID = 233;
			dpo.Code = "Y";
			dpo.Definition = "4081";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 577;
			dpo.ElementInstance_ID = 234;
			dpo.Code = "A";
			dpo.Definition = @"Patient was transported to nearest facility for care of symptoms, complaints, or both Can be used to indicate that the patient was transferred to a residential facility. ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 578;
			dpo.ElementInstance_ID = 234;
			dpo.Code = "B";
			dpo.Definition = "Patient was transported for the benefit of a preferred physician";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 579;
			dpo.ElementInstance_ID = 234;
			dpo.Code = "C";
			dpo.Definition = "Patient was transported for the nearness of family members";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 580;
			dpo.ElementInstance_ID = 234;
			dpo.Code = "D";
			dpo.Definition = "Patient was transported for the care of a specialist or for availability of specialized equipment";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 581;
			dpo.ElementInstance_ID = 234;
			dpo.Code = "E";
			dpo.Definition = "Patient Transferred to Rehabilitation Facility";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 582;
			dpo.ElementInstance_ID = 235;
			dpo.Code = "DH";
			dpo.Definition = "Miles";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 583;
			dpo.ElementInstance_ID = 236;
			dpo.Code = "A";
			dpo.Definition = "Acute Condition";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 584;
			dpo.ElementInstance_ID = 236;
			dpo.Code = "C";
			dpo.Definition = "Chronic Condition";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 585;
			dpo.ElementInstance_ID = 236;
			dpo.Code = "D";
			dpo.Definition = "Non-acute";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 586;
			dpo.ElementInstance_ID = 236;
			dpo.Code = "E";
			dpo.Definition = "Non-Life Threatening";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 587;
			dpo.ElementInstance_ID = 236;
			dpo.Code = "F";
			dpo.Definition = "Routine";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 588;
			dpo.ElementInstance_ID = 236;
			dpo.Code = "G";
			dpo.Definition = "Symptomatic";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 589;
			dpo.ElementInstance_ID = 236;
			dpo.Code = "M";
			dpo.Definition = "Acute Manifestation of a Chronic Condition";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 590;
			dpo.ElementInstance_ID = 237;
			dpo.Code = "N";
			dpo.Definition = "No";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 591;
			dpo.ElementInstance_ID = 237;
			dpo.Code = "Y";
			dpo.Definition = "Yes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 592;
			dpo.ElementInstance_ID = 238;
			dpo.Code = "01";
			dpo.Definition = "Patient was admitted to a hospital";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 593;
			dpo.ElementInstance_ID = 238;
			dpo.Code = "04";
			dpo.Definition = "Patient was moved by stretcher";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 594;
			dpo.ElementInstance_ID = 238;
			dpo.Code = "05";
			dpo.Definition = "Patient was unconscious or in shock";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 595;
			dpo.ElementInstance_ID = 238;
			dpo.Code = "06";
			dpo.Definition = "Patient was transported in an emergency situation";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 596;
			dpo.ElementInstance_ID = 238;
			dpo.Code = "07";
			dpo.Definition = "Patient had to be physically restrained";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 597;
			dpo.ElementInstance_ID = 238;
			dpo.Code = "08";
			dpo.Definition = "Patient had visible hemorrhaging";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 598;
			dpo.ElementInstance_ID = 238;
			dpo.Code = "09";
			dpo.Definition = "Ambulance service was medically necessary";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 599;
			dpo.ElementInstance_ID = 238;
			dpo.Code = "12";
			dpo.Definition = "Patient is confined to a bed or chair";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 600;
			dpo.ElementInstance_ID = 239;
			dpo.Code = "Y";
			dpo.Definition = "Yes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 601;
			dpo.ElementInstance_ID = 240;
			dpo.Code = "IH";
			dpo.Definition = "Independent at Home";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 602;
			dpo.ElementInstance_ID = 241;
			dpo.Code = "N";
			dpo.Definition = "No";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 603;
			dpo.ElementInstance_ID = 241;
			dpo.Code = "Y";
			dpo.Definition = "Yes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 604;
			dpo.ElementInstance_ID = 242;
			dpo.Code = "AV";
			dpo.Definition = "Available - Not Used";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 605;
			dpo.ElementInstance_ID = 242;
			dpo.Code = "NU";
			dpo.Definition = "Not Used";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 606;
			dpo.ElementInstance_ID = 242;
			dpo.Code = "S2";
			dpo.Definition = "Under Treatment";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 607;
			dpo.ElementInstance_ID = 242;
			dpo.Code = "ST";
			dpo.Definition = "New Services Requested";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 608;
			dpo.ElementInstance_ID = 243;
			dpo.Code = "T1";
			dpo.Definition = "Cannot Identify Provider as TPO (Third Party Organization) Participant";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 609;
			dpo.ElementInstance_ID = 243;
			dpo.Code = "T2";
			dpo.Definition = "Cannot Identify Payer as TPO (Third Party Organization) Participant ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 610;
			dpo.ElementInstance_ID = 243;
			dpo.Code = "T3";
			dpo.Definition = "Cannot Identify Insured as TPO (Third Party Organization) Participant";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 611;
			dpo.ElementInstance_ID = 243;
			dpo.Code = "T4";
			dpo.Definition = "Payer Name or Identifier Missing ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 612;
			dpo.ElementInstance_ID = 243;
			dpo.Code = "T5";
			dpo.Definition = "Certification Information Missing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 613;
			dpo.ElementInstance_ID = 243;
			dpo.Code = "T6";
			dpo.Definition = "Claim does not contain enough information for re-pricing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 614;
			dpo.ElementInstance_ID = 244;
			dpo.Code = "1";
			dpo.Definition = "Procedure Followed (Compliance)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 615;
			dpo.ElementInstance_ID = 244;
			dpo.Code = "2";
			dpo.Definition = "Not Followed - Call Not Made (Non-Compliance Call Not Made)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 616;
			dpo.ElementInstance_ID = 244;
			dpo.Code = "3";
			dpo.Definition = "Not Medically Necessary (Non-Compliance Non-Medically Necessary) ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 617;
			dpo.ElementInstance_ID = 244;
			dpo.Code = "4";
			dpo.Definition = "Not Followed Other (Non-Compliance Other)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 618;
			dpo.ElementInstance_ID = 244;
			dpo.Code = "5";
			dpo.Definition = "Emergency Admit to Non-Network Hospital";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 619;
			dpo.ElementInstance_ID = 245;
			dpo.Code = "1";
			dpo.Definition = "Non-Network Professional Provider in Network Hospital";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 620;
			dpo.ElementInstance_ID = 245;
			dpo.Code = "2";
			dpo.Definition = "Emergency Care";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 621;
			dpo.ElementInstance_ID = 245;
			dpo.Code = "3";
			dpo.Definition = "Services or Specialist not in Network";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 622;
			dpo.ElementInstance_ID = 245;
			dpo.Code = "4";
			dpo.Definition = "Out-of-Service Area";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 623;
			dpo.ElementInstance_ID = 245;
			dpo.Code = "5";
			dpo.Definition = "State Mandates";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 624;
			dpo.ElementInstance_ID = 245;
			dpo.Code = "6";
			dpo.Definition = "Other";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 625;
			dpo.ElementInstance_ID = 246;
			dpo.Code = "1";
			dpo.Definition = "Person";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 626;
			dpo.ElementInstance_ID = 247;
			dpo.Code = "XX";
			dpo.Definition = "Centers for Medicare and Medicaid Services National Provider Identifier";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 627;
			dpo.ElementInstance_ID = 248;
			dpo.Code = "1";
			dpo.Definition = "Person";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 628;
			dpo.ElementInstance_ID = 248;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 629;
			dpo.ElementInstance_ID = 249;
			dpo.Code = "XX";
			dpo.Definition = "Centers for Medicare and Medicaid Services National Provider Identifier";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 630;
			dpo.ElementInstance_ID = 250;
			dpo.Code = "PXC";
			dpo.Definition = "Health Care Provider Taxonomy Code";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 631;
			dpo.ElementInstance_ID = 251;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 632;
			dpo.ElementInstance_ID = 252;
			dpo.Code = "XX";
			dpo.Definition = "Code qualifying the type of entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 633;
			dpo.ElementInstance_ID = 253;
			dpo.Code = "TE";
			dpo.Definition = "Telephone";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 634;
			dpo.ElementInstance_ID = 254;
			dpo.Code = "EX";
			dpo.Definition = "Telephone Extension";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 635;
			dpo.ElementInstance_ID = 255;
			dpo.Code = "1";
			dpo.Definition = "Person";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 636;
			dpo.ElementInstance_ID = 256;
			dpo.Code = "XX";
			dpo.Definition = "Centers for Medicare and Medicaid Services National Provider Identifier";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 637;
			dpo.ElementInstance_ID = 257;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 638;
			dpo.ElementInstance_ID = 258;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 639;
			dpo.ElementInstance_ID = 259;
			dpo.Code = "01";
			dpo.Definition = "Spouse";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 640;
			dpo.ElementInstance_ID = 259;
			dpo.Code = "18";
			dpo.Definition = "Self";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 641;
			dpo.ElementInstance_ID = 259;
			dpo.Code = "19";
			dpo.Definition = "Child";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 642;
			dpo.ElementInstance_ID = 259;
			dpo.Code = "20";
			dpo.Definition = "Employee";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 643;
			dpo.ElementInstance_ID = 259;
			dpo.Code = "21";
			dpo.Definition = "Unknown";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 644;
			dpo.ElementInstance_ID = 259;
			dpo.Code = "39";
			dpo.Definition = "Organ Donor";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 645;
			dpo.ElementInstance_ID = 259;
			dpo.Code = "40";
			dpo.Definition = "Cadaver Donor";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 646;
			dpo.ElementInstance_ID = 259;
			dpo.Code = "53";
			dpo.Definition = "Life Partner";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 647;
			dpo.ElementInstance_ID = 259;
			dpo.Code = "G8";
			dpo.Definition = "Other Relationship";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 648;
			dpo.ElementInstance_ID = 260;
			dpo.Code = "12";
			dpo.Definition = "Medicare Secondary Working Aged Beneficiary or Spouse with Employer Group Health Plan ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 649;
			dpo.ElementInstance_ID = 260;
			dpo.Code = "13";
			dpo.Definition = @"Medicare Secondary End-Stage Renal Disease Beneficiary in the Mandated Coordination Period with an Employer's Group Health Plan";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 650;
			dpo.ElementInstance_ID = 260;
			dpo.Code = "14";
			dpo.Definition = "Medicare Secondary, No-fault Insurance including Auto is Primary";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 651;
			dpo.ElementInstance_ID = 260;
			dpo.Code = "15";
			dpo.Definition = "Medicare Secondary Worker's Compensation ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 652;
			dpo.ElementInstance_ID = 260;
			dpo.Code = "16";
			dpo.Definition = "Medicare Secondary Public Health Service (PHS)or Other Federal Agency";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 653;
			dpo.ElementInstance_ID = 260;
			dpo.Code = "41";
			dpo.Definition = "Medicare Secondary Black Lung";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 654;
			dpo.ElementInstance_ID = 260;
			dpo.Code = "42";
			dpo.Definition = "Medicare Secondary Veteran's Administration";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 655;
			dpo.ElementInstance_ID = 260;
			dpo.Code = "43";
			dpo.Definition = "Medicare Secondary Disabled Beneficiary Under Age 65 with Large Group Health Plan (LGHP)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 656;
			dpo.ElementInstance_ID = 260;
			dpo.Code = "47";
			dpo.Definition = "Medicare Secondary, Other Liability Insurance is Primary";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 657;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "11";
			dpo.Definition = "Other Non-Federal Programs";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 658;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "12";
			dpo.Definition = "Preferred Provider Organization (PPO)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 659;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "13";
			dpo.Definition = " Point of Service (POS) ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 660;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "14";
			dpo.Definition = "Exclusive Provider Organization (EPO) ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 661;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "15";
			dpo.Definition = "Indemnity Insurance";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 662;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "16";
			dpo.Definition = "Health Maintenance Organization (HMO) Medicare Risk";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 663;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "17";
			dpo.Definition = "Dental Maintenance Organization";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 664;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "AM";
			dpo.Definition = "Automobile Medical";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 665;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "BL";
			dpo.Definition = " Blue Cross/Blue Shield ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 666;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "CH";
			dpo.Definition = "Champus";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 667;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "CI";
			dpo.Definition = "Commercial Insurance Co.";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 668;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "DI";
			dpo.Definition = "Disability";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 669;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "FI";
			dpo.Definition = "Federal Employees Program";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 670;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "HM";
			dpo.Definition = "Health Maintenance Organization";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 671;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "LM";
			dpo.Definition = "Liability Medical";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 672;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "MA";
			dpo.Definition = "Medicare Part A ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 673;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "MB";
			dpo.Definition = "Medicare Part B";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 674;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "MC";
			dpo.Definition = "Medicaid";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 675;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "OF";
			dpo.Definition = "Other Federal Program";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 676;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "TV";
			dpo.Definition = "Title V";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 677;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "VA";
			dpo.Definition = "Veterans Affairs Plan";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 678;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "WC";
			dpo.Definition = "Workers' Compensation Health Claim";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 679;
			dpo.ElementInstance_ID = 261;
			dpo.Code = "ZZ";
			dpo.Definition = "Mutually Defined,Use Code ZZ when Type of Insurance is not known.";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 680;
			dpo.ElementInstance_ID = 262;
			dpo.Code = "N";
			dpo.Definition = "No";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 681;
			dpo.ElementInstance_ID = 262;
			dpo.Code = "W";
			dpo.Definition = "Not Applicable";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 682;
			dpo.ElementInstance_ID = 262;
			dpo.Code = "Y";
			dpo.Definition = "Yes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 683;
			dpo.ElementInstance_ID = 263;
			dpo.Code = "P";
			dpo.Definition = "Signature generated by provider because the patient was not physically present for services";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 684;
			dpo.ElementInstance_ID = 264;
			dpo.Code = "I";
			dpo.Definition = @"Informed Consent to Release Medical Information for Conditions or Diagnoses Regulated by Federal Statutes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 685;
			dpo.ElementInstance_ID = 264;
			dpo.Code = "Y";
			dpo.Definition = @"Yes, Provider has a Signed Statement Permitting Release of Medical Billing Data Related to a Claim  Required when the provider has collected a signature. OR Required when state or federal laws require a signature be collected. ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 686;
			dpo.ElementInstance_ID = 265;
			dpo.Code = "1";
			dpo.Definition = "Person";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 687;
			dpo.ElementInstance_ID = 265;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 688;
			dpo.ElementInstance_ID = 266;
			dpo.Code = "II";
			dpo.Definition = "Standard Unique Health Identifier for each Individual in the United States";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 689;
			dpo.ElementInstance_ID = 266;
			dpo.Code = "MI";
			dpo.Definition = "Member Identification Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 690;
			dpo.ElementInstance_ID = 267;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 691;
			dpo.ElementInstance_ID = 268;
			dpo.Code = "PI";
			dpo.Definition = "Payor Identification ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 692;
			dpo.ElementInstance_ID = 268;
			dpo.Code = "XV";
			dpo.Definition = "Centers for Medicare and Medicaid Services PlanID";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 693;
			dpo.ElementInstance_ID = 269;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 694;
			dpo.ElementInstance_ID = 270;
			dpo.Code = "1";
			dpo.Definition = "Person";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 695;
			dpo.ElementInstance_ID = 271;
			dpo.Code = "1";
			dpo.Definition = "Person";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 696;
			dpo.ElementInstance_ID = 271;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 697;
			dpo.ElementInstance_ID = 272;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 698;
			dpo.ElementInstance_ID = 273;
			dpo.Code = "1";
			dpo.Definition = "Person";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 699;
			dpo.ElementInstance_ID = 274;
			dpo.Code = "1";
			dpo.Definition = "Person";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 700;
			dpo.ElementInstance_ID = 274;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 701;
			dpo.ElementInstance_ID = 275;
			dpo.Code = "ER";
			dpo.Definition = "Jurisdiction Specific Procedure and Supply Codes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 702;
			dpo.ElementInstance_ID = 275;
			dpo.Code = "HC";
			dpo.Definition = "Health Care Financing Administration Common Procedural Coding System (HCPCS) Codes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 703;
			dpo.ElementInstance_ID = 275;
			dpo.Code = "IV";
			dpo.Definition = "Home Infusion EDI Coalition (HIEC) Product/Service Code";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 704;
			dpo.ElementInstance_ID = 275;
			dpo.Code = "WK";
			dpo.Definition = "Advanced Billing Concepts (ABC) Codes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 705;
			dpo.ElementInstance_ID = 276;
			dpo.Code = "MJ";
			dpo.Definition = "Minutes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 706;
			dpo.ElementInstance_ID = 276;
			dpo.Code = "UN";
			dpo.Definition = "Unit";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 707;
			dpo.ElementInstance_ID = 277;
			dpo.Code = "Y";
			dpo.Definition = "Yes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 708;
			dpo.ElementInstance_ID = 278;
			dpo.Code = "Y";
			dpo.Definition = "Yes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 709;
			dpo.ElementInstance_ID = 279;
			dpo.Code = "Y";
			dpo.Definition = "Yes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 710;
			dpo.ElementInstance_ID = 280;
			dpo.Code = "0";
			dpo.Definition = "Copay exempt";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 711;
			dpo.ElementInstance_ID = 281;
			dpo.Code = "HC";
			dpo.Definition = "Health Care Financing Administration Common Procedural Coding System (HCPCS) Codes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 712;
			dpo.ElementInstance_ID = 282;
			dpo.Code = "1";
			dpo.Definition = "Weekly";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 713;
			dpo.ElementInstance_ID = 282;
			dpo.Code = "4";
			dpo.Definition = "Monthly";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 714;
			dpo.ElementInstance_ID = 282;
			dpo.Code = "6";
			dpo.Definition = "Daily";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 715;
			dpo.ElementInstance_ID = 283;
			dpo.Code = "AA";
			dpo.Definition = "Available on Request at Provider Site";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 716;
			dpo.ElementInstance_ID = 283;
			dpo.Code = "BM";
			dpo.Definition = "By Mail";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 717;
			dpo.ElementInstance_ID = 283;
			dpo.Code = "EL";
			dpo.Definition = "Electronically Only";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 718;
			dpo.ElementInstance_ID = 283;
			dpo.Code = "EM";
			dpo.Definition = "E-Mail";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 719;
			dpo.ElementInstance_ID = 283;
			dpo.Code = "FT";
			dpo.Definition = "File Transfer";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 720;
			dpo.ElementInstance_ID = 283;
			dpo.Code = "FX";
			dpo.Definition = "By Fax";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 721;
			dpo.ElementInstance_ID = 284;
			dpo.Code = "AB";
			dpo.Definition = "Previously Submitted to Payer";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 722;
			dpo.ElementInstance_ID = 284;
			dpo.Code = "AD";
			dpo.Definition = "Certification Included in this Claim";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 723;
			dpo.ElementInstance_ID = 284;
			dpo.Code = "AF";
			dpo.Definition = "Narrative Segment Included in this Claim";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 724;
			dpo.ElementInstance_ID = 284;
			dpo.Code = "AG";
			dpo.Definition = "No Documentation is Required";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 725;
			dpo.ElementInstance_ID = 284;
			dpo.Code = "NS";
			dpo.Definition = "Not Specified";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 726;
			dpo.ElementInstance_ID = 285;
			dpo.Code = "A";
			dpo.Definition = "Patient was transported to nearest facility for care of symptoms, complaints, or both";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 727;
			dpo.ElementInstance_ID = 285;
			dpo.Code = "B";
			dpo.Definition = "Patient was transported for the benefit of a preferred physician ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 728;
			dpo.ElementInstance_ID = 285;
			dpo.Code = "C";
			dpo.Definition = "Patient was transported for the nearness of family members";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 729;
			dpo.ElementInstance_ID = 285;
			dpo.Code = "D";
			dpo.Definition = "Patient was transported for the care of a specialist or for availability of specialized equipment";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 730;
			dpo.ElementInstance_ID = 285;
			dpo.Code = "E";
			dpo.Definition = "Patient Transferred to Rehabilitation Facility";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 731;
			dpo.ElementInstance_ID = 286;
			dpo.Code = "DH";
			dpo.Definition = "Miles";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 732;
			dpo.ElementInstance_ID = 287;
			dpo.Code = "MO";
			dpo.Definition = "Months";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 733;
			dpo.ElementInstance_ID = 288;
			dpo.Code = "N";
			dpo.Definition = "No";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 734;
			dpo.ElementInstance_ID = 288;
			dpo.Code = "Y";
			dpo.Definition = "Yes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 735;
			dpo.ElementInstance_ID = 289;
			dpo.Code = "01";
			dpo.Definition = "Patient was admitted to a hospital";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 736;
			dpo.ElementInstance_ID = 289;
			dpo.Code = "04";
			dpo.Definition = "Patient was moved by stretcher";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 737;
			dpo.ElementInstance_ID = 289;
			dpo.Code = "05";
			dpo.Definition = "Patient was unconscious or in shock";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 738;
			dpo.ElementInstance_ID = 289;
			dpo.Code = "06";
			dpo.Definition = "Patient was transported in an emergency situation";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 739;
			dpo.ElementInstance_ID = 289;
			dpo.Code = "07";
			dpo.Definition = "Patient had to be physically restrained";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 740;
			dpo.ElementInstance_ID = 289;
			dpo.Code = "08";
			dpo.Definition = "Patient had visible hemorrhaging";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 741;
			dpo.ElementInstance_ID = 289;
			dpo.Code = "09";
			dpo.Definition = "Ambulance service was medically necessary";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 742;
			dpo.ElementInstance_ID = 289;
			dpo.Code = "12";
			dpo.Definition = "Patient is confined to a bed or chair";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 743;
			dpo.ElementInstance_ID = 290;
			dpo.Code = "N";
			dpo.Definition = "No";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 744;
			dpo.ElementInstance_ID = 290;
			dpo.Code = "Y";
			dpo.Definition = "Yes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 745;
			dpo.ElementInstance_ID = 291;
			dpo.Code = "65";
			dpo.Definition = "Open";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 746;
			dpo.ElementInstance_ID = 292;
			dpo.Code = "N";
			dpo.Definition = "No";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 747;
			dpo.ElementInstance_ID = 292;
			dpo.Code = "Y";
			dpo.Definition = "Yes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 748;
			dpo.ElementInstance_ID = 293;
			dpo.Code = "38";
			dpo.Definition = "Certification signed by the physician is on file at the supplier's office";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 749;
			dpo.ElementInstance_ID = 293;
			dpo.Code = "ZV";
			dpo.Definition = "Replacement Item";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 750;
			dpo.ElementInstance_ID = 294;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 751;
			dpo.ElementInstance_ID = 294;
			dpo.Code = "RD8";
			dpo.Definition = "Range of Dates Expressed in Format CCYYMMDD-CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 752;
			dpo.ElementInstance_ID = 295;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 753;
			dpo.ElementInstance_ID = 296;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 754;
			dpo.ElementInstance_ID = 297;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 755;
			dpo.ElementInstance_ID = 298;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 756;
			dpo.ElementInstance_ID = 299;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 757;
			dpo.ElementInstance_ID = 300;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 758;
			dpo.ElementInstance_ID = 301;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 759;
			dpo.ElementInstance_ID = 302;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 760;
			dpo.ElementInstance_ID = 303;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 765;
			dpo.ElementInstance_ID = 304;
			dpo.Code = "D4";
			dpo.Definition = "Creatinine";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 761;
			dpo.ElementInstance_ID = 304;
			dpo.Code = "HT";
			dpo.Definition = "Height";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 762;
			dpo.ElementInstance_ID = 304;
			dpo.Code = "R1";
			dpo.Definition = "Hemoglobin";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 763;
			dpo.ElementInstance_ID = 304;
			dpo.Code = "R2";
			dpo.Definition = "Hematocrit";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 764;
			dpo.ElementInstance_ID = 304;
			dpo.Code = "R3";
			dpo.Definition = "Epoetin Starting Dosage";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 766;
			dpo.ElementInstance_ID = 305;
			dpo.Code = "ER";
			dpo.Definition = "Jurisdiction Specific Procedure and Supply Codes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 767;
			dpo.ElementInstance_ID = 305;
			dpo.Code = "HC";
			dpo.Definition = "Health Care Financing Administration Common Procedural Coding System (HCPCS) Codes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 768;
			dpo.ElementInstance_ID = 305;
			dpo.Code = "IV";
			dpo.Definition = "Home Infusion EDI Coalition (HIEC) Product/Service Code";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 769;
			dpo.ElementInstance_ID = 305;
			dpo.Code = "WK";
			dpo.Definition = " Advanced Billing Concepts (ABC) Codes ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 770;
			dpo.ElementInstance_ID = 306;
			dpo.Code = "MJ";
			dpo.Definition = "Minutes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 771;
			dpo.ElementInstance_ID = 306;
			dpo.Code = "UN";
			dpo.Definition = "Unit";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 772;
			dpo.ElementInstance_ID = 307;
			dpo.Code = "T1";
			dpo.Definition = "Cannot Identify Provider as TPO (Third Party Organization) Participant ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 773;
			dpo.ElementInstance_ID = 307;
			dpo.Code = "T2";
			dpo.Definition = "Cannot Identify Payer as TPO (Third Party Organization) Participant";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 774;
			dpo.ElementInstance_ID = 307;
			dpo.Code = "T3";
			dpo.Definition = "Cannot Identify Insured as TPO (Third Party Organization) Participant ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 775;
			dpo.ElementInstance_ID = 307;
			dpo.Code = "T4";
			dpo.Definition = "Payer Name or Identifier Missing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 776;
			dpo.ElementInstance_ID = 307;
			dpo.Code = "T5";
			dpo.Definition = "Certification Information Missing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 777;
			dpo.ElementInstance_ID = 307;
			dpo.Code = "T6";
			dpo.Definition = "Claim does not contain enough information for re-pricing";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 778;
			dpo.ElementInstance_ID = 308;
			dpo.Code = "1";
			dpo.Definition = "Procedure Followed (Compliance)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 779;
			dpo.ElementInstance_ID = 308;
			dpo.Code = "2";
			dpo.Definition = "Not Followed - Call Not Made (Non-Compliance Call Not Made)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 780;
			dpo.ElementInstance_ID = 308;
			dpo.Code = "3";
			dpo.Definition = "Not Medically Necessary (Non-Compliance Non-Medically Necessary)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 781;
			dpo.ElementInstance_ID = 308;
			dpo.Code = "4";
			dpo.Definition = "Not Followed Other (Non-Compliance Other)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 782;
			dpo.ElementInstance_ID = 308;
			dpo.Code = "5";
			dpo.Definition = "Emergency Admit to Non-Network Hospital";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 783;
			dpo.ElementInstance_ID = 309;
			dpo.Code = "1";
			dpo.Definition = "Non-Network Professional Provider in Network Hospital";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 784;
			dpo.ElementInstance_ID = 309;
			dpo.Code = "2";
			dpo.Definition = "Emergency Care";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 785;
			dpo.ElementInstance_ID = 309;
			dpo.Code = "3";
			dpo.Definition = "Services or Specialist not in Network";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 786;
			dpo.ElementInstance_ID = 309;
			dpo.Code = "4";
			dpo.Definition = "Out-of-Service Area";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 787;
			dpo.ElementInstance_ID = 309;
			dpo.Code = "5";
			dpo.Definition = "State Mandates";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 788;
			dpo.ElementInstance_ID = 309;
			dpo.Code = "6";
			dpo.Definition = "Other";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 789;
			dpo.ElementInstance_ID = 310;
			dpo.Code = "EN";
			dpo.Definition = "EAN/UCC - 13";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 790;
			dpo.ElementInstance_ID = 310;
			dpo.Code = "EO";
			dpo.Definition = "EAN/UCC - 8";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 791;
			dpo.ElementInstance_ID = 310;
			dpo.Code = "HI";
			dpo.Definition = "HIBC (Health Care Industry Bar Code) Supplier Labeling Standard Primary Data Message ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 792;
			dpo.ElementInstance_ID = 310;
			dpo.Code = "N4";
			dpo.Definition = "National Drug Code in 5-4-2 Format";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 793;
			dpo.ElementInstance_ID = 310;
			dpo.Code = "ON";
			dpo.Definition = "Customer Order Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 794;
			dpo.ElementInstance_ID = 310;
			dpo.Code = "UK";
			dpo.Definition = "GTIN 14-digit Data Structure";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 795;
			dpo.ElementInstance_ID = 310;
			dpo.Code = "UP";
			dpo.Definition = "UCC - 12";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 796;
			dpo.ElementInstance_ID = 311;
			dpo.Code = "1";
			dpo.Definition = "Person";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 797;
			dpo.ElementInstance_ID = 311;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 798;
			dpo.ElementInstance_ID = 312;
			dpo.Code = "PXC";
			dpo.Definition = "Health Care Provider Taxonomy Code";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 799;
			dpo.ElementInstance_ID = 313;
			dpo.Code = "1";
			dpo.Definition = "Person";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 800;
			dpo.ElementInstance_ID = 313;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 801;
			dpo.ElementInstance_ID = 314;
			dpo.Code = "XX";
			dpo.Definition = "Centers for Medicare and Medicaid Services National Provider Identifier";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 802;
			dpo.ElementInstance_ID = 315;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 803;
			dpo.ElementInstance_ID = 316;
			dpo.Code = "XX";
			dpo.Definition = "Centers for Medicare and Medicaid Services National Provider Identifier";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 804;
			dpo.ElementInstance_ID = 317;
			dpo.Code = "1";
			dpo.Definition = "Person";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 805;
			dpo.ElementInstance_ID = 318;
			dpo.Code = "XX";
			dpo.Definition = "Centers for Medicare and Medicaid Services National Provider Identifier";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 806;
			dpo.ElementInstance_ID = 319;
			dpo.Code = "1";
			dpo.Definition = "Person";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 807;
			dpo.ElementInstance_ID = 320;
			dpo.Code = "XX";
			dpo.Definition = "Centers for Medicare and Medicaid Services National Provider Identifier";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 808;
			dpo.ElementInstance_ID = 321;
			dpo.Code = "EM";
			dpo.Definition = "Electronic Mail";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 809;
			dpo.ElementInstance_ID = 321;
			dpo.Code = "FX";
			dpo.Definition = "Facsimile";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 810;
			dpo.ElementInstance_ID = 321;
			dpo.Code = "TE";
			dpo.Definition = "Telephone";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 811;
			dpo.ElementInstance_ID = 322;
			dpo.Code = "EM";
			dpo.Definition = "Electronic Mail ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 812;
			dpo.ElementInstance_ID = 322;
			dpo.Code = "EX";
			dpo.Definition = "Telephone Extension";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 813;
			dpo.ElementInstance_ID = 322;
			dpo.Code = "FX";
			dpo.Definition = "Facsimile";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 814;
			dpo.ElementInstance_ID = 322;
			dpo.Code = "TE";
			dpo.Definition = "Telephone";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 815;
			dpo.ElementInstance_ID = 323;
			dpo.Code = "EM";
			dpo.Definition = "Electronic Mail";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 816;
			dpo.ElementInstance_ID = 323;
			dpo.Code = "EX";
			dpo.Definition = "Telephone Extension";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 817;
			dpo.ElementInstance_ID = 323;
			dpo.Code = "FX";
			dpo.Definition = "Facsimile";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 818;
			dpo.ElementInstance_ID = 323;
			dpo.Code = "TE";
			dpo.Definition = "Telephone";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 819;
			dpo.ElementInstance_ID = 324;
			dpo.Code = "1";
			dpo.Definition = "Person";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 820;
			dpo.ElementInstance_ID = 325;
			dpo.Code = "XX";
			dpo.Definition = "Centers for Medicare and Medicaid Services National Provider Identifier";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 821;
			dpo.ElementInstance_ID = 326;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 822;
			dpo.ElementInstance_ID = 327;
			dpo.Code = "2";
			dpo.Definition = "Non-Person Entity";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 823;
			dpo.ElementInstance_ID = 328;
			dpo.Code = "ER";
			dpo.Definition = "Jurisdiction Specific Procedure and Supply Codes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 824;
			dpo.ElementInstance_ID = 328;
			dpo.Code = "HC";
			dpo.Definition = "Health Care Financing Administration Common Procedural Coding System (HCPCS) Codes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 825;
			dpo.ElementInstance_ID = 328;
			dpo.Code = "IV";
			dpo.Definition = "Home Infusion EDI Coalition (HIEC) Product/Service Code";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 826;
			dpo.ElementInstance_ID = 328;
			dpo.Code = "WK";
			dpo.Definition = "Advanced Billing Concepts (ABC) Codes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 827;
			dpo.ElementInstance_ID = 329;
			dpo.Code = "D8";
			dpo.Definition = "Date Expressed in Format CCYYMMDD";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 828;
			dpo.ElementInstance_ID = 330;
			dpo.Code = "N";
			dpo.Definition = "No";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 829;
			dpo.ElementInstance_ID = 330;
			dpo.Code = "W";
			dpo.Definition = "Not Applicable";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 830;
			dpo.ElementInstance_ID = 330;
			dpo.Code = "Y";
			dpo.Definition = "Yes";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 831;
			dpo.ElementInstance_ID = 331;
			dpo.Code = "00";
			dpo.Definition = "No Authorization Information Present (No Meaningful Information in I02)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 832;
			dpo.ElementInstance_ID = 331;
			dpo.Code = "03";
			dpo.Definition = "Additional Data Identification";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 833;
			dpo.ElementInstance_ID = 332;
			dpo.Code = "00";
			dpo.Definition = "No Security Information Present (No Meaningful Information in I04)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 834;
			dpo.ElementInstance_ID = 332;
			dpo.Code = "01";
			dpo.Definition = "Password";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 835;
			dpo.ElementInstance_ID = 333;
			dpo.Code = "01";
			dpo.Definition = "Duns (Dun & Bradstreet)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 836;
			dpo.ElementInstance_ID = 333;
			dpo.Code = "14";
			dpo.Definition = "Duns Plus Suffix";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 837;
			dpo.ElementInstance_ID = 333;
			dpo.Code = "20";
			dpo.Definition = "Health Industry Number (HIN)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 838;
			dpo.ElementInstance_ID = 333;
			dpo.Code = "27";
			dpo.Definition = "Carrier Identification Number as assigned by Health Care Financing Administration (HCFA)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 839;
			dpo.ElementInstance_ID = 333;
			dpo.Code = "28";
			dpo.Definition = @"Fiscal Intermediary Identification Number as assigned by Health Care Financing Administration (HCFA)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 840;
			dpo.ElementInstance_ID = 333;
			dpo.Code = "29";
			dpo.Definition = @"Medicare Provider and Supplier Identification Number as assigned by Health Care Financing Administration (HCFA)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 841;
			dpo.ElementInstance_ID = 333;
			dpo.Code = "30";
			dpo.Definition = "U.S. Federal Tax Identification Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 842;
			dpo.ElementInstance_ID = 333;
			dpo.Code = "33";
			dpo.Definition = "National Association of Insurance Commissioners Company Code (NAIC)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 843;
			dpo.ElementInstance_ID = 333;
			dpo.Code = "ZZ";
			dpo.Definition = "Mutually Defined";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 844;
			dpo.ElementInstance_ID = 334;
			dpo.Code = "01";
			dpo.Definition = "Duns (Dun & Bradstreet)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 845;
			dpo.ElementInstance_ID = 334;
			dpo.Code = "14";
			dpo.Definition = "Duns Plus Suffix";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 846;
			dpo.ElementInstance_ID = 334;
			dpo.Code = "20";
			dpo.Definition = "Health Industry Number (HIN)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 847;
			dpo.ElementInstance_ID = 334;
			dpo.Code = "27";
			dpo.Definition = "Carrier Identification Number as assigned by Health Care Financing Administration (HCFA)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 848;
			dpo.ElementInstance_ID = 334;
			dpo.Code = "28";
			dpo.Definition = @"Fiscal Intermediary Identification Number as assigned by Health Care Financing Administration (HCFA) ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 849;
			dpo.ElementInstance_ID = 334;
			dpo.Code = "29";
			dpo.Definition = @"Medicare Provider and Supplier Identification Number as assigned by Health Care Financing Administration (HCFA)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 850;
			dpo.ElementInstance_ID = 334;
			dpo.Code = "30";
			dpo.Definition = "U.S. Federal Tax Identification Number";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 851;
			dpo.ElementInstance_ID = 334;
			dpo.Code = "33";
			dpo.Definition = " National Association of Insurance Commissioners Company Code (NAIC) ";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 852;
			dpo.ElementInstance_ID = 334;
			dpo.Code = "ZZ";
			dpo.Definition = "Mutually Defined";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 853;
			dpo.ElementInstance_ID = 335;
			dpo.Code = "00501";
			dpo.Definition = "Standards Approved for Publication by ASC X12 Procedures Review Board through October 2003";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 854;
			dpo.ElementInstance_ID = 336;
			dpo.Code = "0";
			dpo.Definition = "No Interchange Acknowledgment Requested";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 855;
			dpo.ElementInstance_ID = 336;
			dpo.Code = "1";
			dpo.Definition = "Interchange Acknowledgment Requested (TA1)";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 856;
			dpo.ElementInstance_ID = 337;
			dpo.Code = "P";
			dpo.Definition = "Production Data";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 857;
			dpo.ElementInstance_ID = 337;
			dpo.Code = "T";
			dpo.Definition = "Test Data";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 858;
			dpo.ElementInstance_ID = 338;
			dpo.Code = "^";
			dpo.Definition = "Repetition Separator";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 859;
			dpo.ElementInstance_ID = 339;
			dpo.Code = "X";
			dpo.Definition = "Accredited Standards Committee X12";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 860;
			dpo.ElementInstance_ID = 340;
			dpo.Code = "005010X222A1";
			dpo.Definition = "Standards Approved for Publication by ASC X12 Procedures Review Board through October 2003";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 861;
			dpo.ElementInstance_ID = 341;
			dpo.Code = "837";
			dpo.Definition = "Health Care Claim";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 862;
			dpo.ElementInstance_ID = 342;
			dpo.Code = "0019";
			dpo.Definition = "Information Source, Subscriber, Dependent";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 863;
			dpo.ElementInstance_ID = 343;
			dpo.Code = "00";
			dpo.Definition = "Original transmissions are transmissions which have never been sent to the receiver.";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 864;
			dpo.ElementInstance_ID = 343;
			dpo.Code = "18";
			dpo.Definition = @"Reissue,If a transmission was disrupted and the receiver requests a retransmission, the sender uses ""Reissue"" to indicate the transmission has been previously sent.";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 865;
			dpo.ElementInstance_ID = 344;
			dpo.Code = "31";
			dpo.Definition = "Subrogation Demand";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 866;
			dpo.ElementInstance_ID = 344;
			dpo.Code = "CH";
			dpo.Definition = "Chargeable";
			list.Add(dpo);

			dpo = new X12CodeDefinitionDpo();
			dpo.ID = 867;
			dpo.ElementInstance_ID = 344;
			dpo.Code = "RP";
			dpo.Definition = "Reporting";
			list.Add(dpo);

		}

	}
}
