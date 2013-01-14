//
// Machine Packed Data
//   by devel at 7/19/2012 12:14:28 AM
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
	public class X12SegmentTemplateDpoPackage : BasePackage<X12SegmentTemplateDpo>
	{

		public X12SegmentTemplateDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new X12SegmentTemplateDpo();
			dpo.ID = 1;
			dpo.Name = "AMT";
			dpo.Description = "Monetary Amount Information";
			dpo.Purpose = "To indicate the total monetary amount";
			dpo.Notes = "";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 47;
			dpo.Name = "BHT";
			dpo.Description = "Beginning of Hierarchical Transaction";
			dpo.Purpose = @"To define the business hierarchical structure of the transaction set and identify the business application purpose and reference data, i.e., number, date, and time";
			dpo.Notes = "";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 2;
			dpo.Name = "CAS";
			dpo.Description = "Claims Adjustment";
			dpo.Purpose = @"To supply adjustment reason codes and amounts as needed for an entire claim or for a particular service within the claim being paid";
			dpo.Notes = @"1. Adjustment information is intended to help the provider balance the remittance information. Adjustment amounts should fully explain the difference between submitted charges and the amount paid.";
			dpo.Syntax = @"1. L050607
If CAS05 is present, then at least one of CAS06 or CAS07 are required. 
2. C0605
If CAS06 is present, then CAS05 is required. 
3. C0705
If CAS07 is present, then CAS05 is required. 
4. L080910
If CAS08 is present, then at least one of CAS09 or CAS10 are required. 
5. C0908
If CAS09 is present, then CAS08 is required. 
6. C1008
If CAS10 is present, then CAS08 is required. 
7. L111213
If CAS11 is present, then at least one of CAS12 or CAS13 are required. 
8. C1211
If CAS12 is present, then CAS11 is required. 
9. C1311
If CAS13 is present, then CAS11 is required. 
10. L141516
If CAS14 is present, then at least one of CAS15 or CAS16 are required. 
11. C1514
If CAS15 is present, then CAS14 is required. 
12. C1614
If CAS16 is present, then CAS14 is required. 
13. L171819
If CAS17 is present, then at least one of CAS18 or CAS19 are required. 
14. C1817
If CAS18 is present, then CAS17 is required. 
15. C1917
If CAS19 is present, then CAS17 is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 3;
			dpo.Name = "CLM";
			dpo.Description = "Health Claim";
			dpo.Purpose = "To specify basic data about the claim";
			dpo.Notes = "";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 4;
			dpo.Name = "CN1";
			dpo.Description = "Contract Information";
			dpo.Purpose = "To specify basic data about the contract or contract line item";
			dpo.Notes = "";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 5;
			dpo.Name = "CR1";
			dpo.Description = "Ambulance Certification";
			dpo.Purpose = "To supply information related to the ambulance service rendered to a patient";
			dpo.Notes = @"1. NOTE: The CR1 through CR5 and CRC certification segments appear on both the claim level and the service line level because certifications can be submitted for all services on a claim or for individual services. Certification information at the claim level applies to all service lines of the claim, unless overridden by certification information at the service line level.";
			dpo.Syntax = @"1. P0102
If either CR101 or CR102 is present, then the other is required. 
2. P0506
If either CR105 or CR106 is present, then the other is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 6;
			dpo.Name = "CR2";
			dpo.Description = "Chiropractic Certification";
			dpo.Purpose = "To supply information related to the chiropractic service rendered to a patient";
			dpo.Notes = "";
			dpo.Syntax = @"1. P0102
If either CR201 or CR202 is present, then the other is required. 
2. C0403
If CR204 is present, then CR203 is required. 
3. P0506
If either CR205 or CR206 is present, then the other is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 7;
			dpo.Name = "CR3";
			dpo.Description = "Durable Medical Equipment Certification";
			dpo.Purpose = "To supply information regarding a physician's certification for durable medical equipme";
			dpo.Notes = "";
			dpo.Syntax = "1. P0203\r\nIf either CR302 or CR303 is present, then the other is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 8;
			dpo.Name = "CRC";
			dpo.Description = "Conditions Indicator";
			dpo.Purpose = "To supply information on conditions";
			dpo.Notes = "";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 35;
			dpo.Name = "CTP";
			dpo.Description = "Pricing Information";
			dpo.Purpose = "To specify pricing information";
			dpo.Notes = "";
			dpo.Syntax = @"1. P0405
If either CTP04 or CTP05 is present, then the other is required. 
2. C0607
If CTP06 is present, then CTP07 is required. 
3. C0902
If CTP09 is present, then CTP02 is required. 
4. C1002
If CTP10 is present, then CTP02 is required. 
5. C1103
If CTP11 is present, then CTP03 is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 9;
			dpo.Name = "CUR";
			dpo.Description = "Currency";
			dpo.Purpose = "To specify the currency (dollars, pounds, francs, etc.) used in a transaction";
			dpo.Notes = "1. See Figures Appendix for examples detailing the use of the CUR segment.";
			dpo.Syntax = @"1. C0807
If CUR08 is present, then CUR07 is required. 
2. C0907
If CUR09 is present, then CUR07 is required. 
3. L101112
If CUR10 is present, then at least one of CUR11 or CUR12 are required. 
4. C1110
If CUR11 is present, then CUR10 is required. 
5. C1210
If CUR12 is present, then CUR10 is required. 
6. L131415
If CUR13 is present, then at least one of CUR14 or CUR15 are required. 
7. C1413
If CUR14 is present, then CUR13 is required. 
8. C1513
If CUR15 is present, then CUR13 is required. 
9. L161718
If CUR16 is present, then at least one of CUR17 or CUR18 are required. 
10. C1716
If CUR17 is present, then CUR16 is required. 
11. C1816
If CUR18 is present, then CUR16 is required. 
12. L192021
If CUR19 is present, then at least one of CUR20 or CUR21 are required. 
13. C2019
If CUR20 is present, then CUR19 is required. 
14. C2119
If CUR21 is present, then CUR19 is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 10;
			dpo.Name = "DMG";
			dpo.Description = "Demographic Information";
			dpo.Purpose = "To supply demographic information";
			dpo.Notes = "";
			dpo.Syntax = @"1. P0102
If either DMG01 or DMG02 is present, then the other is required. 
2. P1011
If either DMG10 or DMG11 is present, then the other is required. 
3. C1105
If DMG11 is present, then DMG05 is required";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 11;
			dpo.Name = "DTP";
			dpo.Description = "Date or Time or Period";
			dpo.Purpose = "To specify any or all of a date, a time, or a time period";
			dpo.Notes = "";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 38;
			dpo.Name = "FRM";
			dpo.Description = "Supporting Documentation";
			dpo.Purpose = "To specify information in response to a codified questionnaire document";
			dpo.Notes = @"1. NOTE: FRM segment provides question numbers and responses for the questions on the medical necessity information form identified in LQ position 551 


1. The FRM segment can only be used in the context of an identified questionnaire or list of questions. The source of the questions can be identified by an associated segment or by transaction set notes in a particular transaction.";
			dpo.Syntax = "1. R02030405\r\nAt least one of FRM02, FRM03, FRM04 or FRM05 is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 42;
			dpo.Name = "GE";
			dpo.Description = "Functional Group Trailer";
			dpo.Purpose = "To indicate the end of a functional group and to provide control information";
			dpo.Notes = @"1. The use of identical data interchange control numbers in the associated functional group header and trailer is designed to maximize functional group integrity. The control number is the same as that used in the corresponding header.";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 41;
			dpo.Name = "GS";
			dpo.Description = "Functional Group Header";
			dpo.Purpose = "To indicate the beginning of a functional group and to provide control information";
			dpo.Notes = @"1. A functional group of related transaction sets, within the scope of X12 standards, consists of a collection of similar transaction sets enclosed by a functional group header and a functional group trailer";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 12;
			dpo.Name = "HCP";
			dpo.Description = "Health Care Pricing";
			dpo.Purpose = "To specify pricing or repricing information about a health care claim or line item";
			dpo.Notes = "";
			dpo.Syntax = @"1. R0113
At least one of HCP01 or HCP13 is required. 
2. P0910
If either HCP09 or HCP10 is present, then the other is required. 
3. P1112
If either HCP11 or HCP12 is present, then the other is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 13;
			dpo.Name = "HI";
			dpo.Description = "Health Care Information Codes";
			dpo.Purpose = "To supply information related to the delivery of health care";
			dpo.Notes = "";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 14;
			dpo.Name = "HL";
			dpo.Description = "Hierarchical Level";
			dpo.Purpose = "To identify dependencies among and the content of hierarchically related groups of data segments";
			dpo.Notes = @"1. The HL segment is used to identify levels of detail information using a hierarchical structure, such as relating line-item data to shipment data, and packaging data to line-item data. 
2. The HL segment defines a top-down/left-right ordered structure.";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 43;
			dpo.Name = "IEA";
			dpo.Description = "Interchange Control Trailer";
			dpo.Purpose = @"To define the end of an interchange of zero or more functional groups and interchange-related control segments";
			dpo.Notes = "";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 40;
			dpo.Name = "ISA";
			dpo.Description = "Interchange Control Header";
			dpo.Purpose = @"To start and identify an interchange of zero or more functional groups and interchange-related control segments";
			dpo.Notes = "";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 15;
			dpo.Name = "K3";
			dpo.Description = "File Information";
			dpo.Purpose = "To transmit a fixed-format record or matrix contents";
			dpo.Notes = "";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 34;
			dpo.Name = "LIN";
			dpo.Description = "Item Identification";
			dpo.Purpose = "To specify basic item identification data";
			dpo.Notes = "1. NOTE: Loop 2410 contains compound drug components, quantities and prices.";
			dpo.Syntax = @"1. P0405
If either LIN04 or LIN05 is present, then the other is required. 
2. P0607
If either LIN06 or LIN07 is present, then the other is required. 
3. P0809
If either LIN08 or LIN09 is present, then the other is required. 
4. P1011
If either LIN10 or LIN11 is present, then the other is required. 
5. P1213
If either LIN12 or LIN13 is present, then the other is required. 
6. P1415
If either LIN14 or LIN15 is present, then the other is required. 
7. P1617
If either LIN16 or LIN17 is present, then the other is required. 
8. P1819
If either LIN18 or LIN19 is present, then the other is required. 
9. P2021
If either LIN20 or LIN21 is present, then the other is required. 
10. P2223
If either LIN22 or LIN23 is present, then the other is required. 
11. P2425
If either LIN24 or LIN25 is present, then the other is required. 
12. P2627
If either LIN26 or LIN27 is present, then the other is required. 
13. P2829
If either LIN28 or LIN29 is present, then the other is required. 
14. P3031
If either LIN30 or LIN31 is present, then the other is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 37;
			dpo.Name = "LQ";
			dpo.Description = "Industry Code Identification";
			dpo.Purpose = "To identify standard industry codes";
			dpo.Notes = @"1. NOTE: Loop 2440 provides certificate of medical necessity information for the procedure identified in SV101 in position 2/3700.";
			dpo.Syntax = "1. C0102\r\nIf LQ01 is present, then LQ02 is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 16;
			dpo.Name = "LX";
			dpo.Description = "Transaction Set Line Number";
			dpo.Purpose = "To reference a line number in a transaction set";
			dpo.Notes = "1. NOTE: Loop 2400 contains Service Line information.";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 32;
			dpo.Name = "MEA";
			dpo.Description = "Measurements";
			dpo.Purpose = @"To specify physical measurements or counts, including dimensions, tolerances, variances, and weights";
			dpo.Notes = "";
			dpo.Syntax = @"1. R03050608
At least one of MEA03, MEA05, MEA06 or MEA08 is required. 
2. E0412
Only one of MEA04 or MEA12 may be present. 
3. L050412
If MEA05 is present, then at least one of MEA04 or MEA12 are required. 
4. L060412
If MEA06 is present, then at least one of MEA04 or MEA12 are required. 
5. L07030506
If MEA07 is present, then at least one of MEA03, MEA05 or MEA06 are required. 
6. E0803
Only one of MEA08 or MEA03 may be present. 
7. P1112
If either MEA11 or MEA12 is present, then the other is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 17;
			dpo.Name = "MOA";
			dpo.Description = "Medicare Outpatient Adjudication";
			dpo.Purpose = @"To convey claim-level data related to the adjudication of Medicare claims not related to an inpatient setting";
			dpo.Notes = "";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 18;
			dpo.Name = "N3";
			dpo.Description = "Party Location";
			dpo.Purpose = "To specify the location of the named party";
			dpo.Notes = "";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 19;
			dpo.Name = "N4";
			dpo.Description = "Geographic Location";
			dpo.Purpose = "To specify the geographic place of the named party";
			dpo.Notes = "";
			dpo.Syntax = @"1. E0207
Only one of N402 or N407 may be present. 
2. C0605
If N406 is present, then N405 is required. 
3. C0704
If N407 is present, then N404 is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 20;
			dpo.Name = "NM1";
			dpo.Description = "Individual or Organizational Name";
			dpo.Purpose = "To supply the full name of an individual or organizational entity";
			dpo.Notes = @"1. NOTE: Loop 1000 contains submitter and receiver information. If any intermediary receivers change or add data in any way, then they add an occurrence to the loop as a form of identification. The added loop occurrence must be the last occurrence of the loop.";
			dpo.Syntax = @"1. P0809
If either NM108 or NM109 is present, then the other is required. 
2. C1110
If NM111 is present, then NM110 is required. 
3. C1203
If NM112 is present, then NM103 is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 21;
			dpo.Name = "NTE";
			dpo.Description = "Note/Special Instruction";
			dpo.Purpose = "To transmit information in a free-form format, if necessary, for comment or special instruction";
			dpo.Notes = @"1. The NTE segment permits free-form information/data which, under ANSI X12 standard implementations, is not machine processible. The use of the NTE segment should therefore be avoided, if at all possible, in an automated environment.";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 22;
			dpo.Name = "OI";
			dpo.Description = "Other Health Insurance Information";
			dpo.Purpose = "To specify information associated with other health insurance coverage";
			dpo.Notes = "";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 23;
			dpo.Name = "PAT";
			dpo.Description = "Patient Information";
			dpo.Purpose = "To supply patient information";
			dpo.Notes = "";
			dpo.Syntax = @"1. P0506
If either PAT05 or PAT06 is present, then the other is required. 
2. P0708
If either PAT07 or PAT08 is present, then the other is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 48;
			dpo.Name = "PEF";
			dpo.Description = "";
			dpo.Purpose = "";
			dpo.Notes = "";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 24;
			dpo.Name = "PER";
			dpo.Description = "Administrative Communications Contact";
			dpo.Purpose = "To identify a person or office to whom administrative communications should be directed";
			dpo.Notes = "";
			dpo.Syntax = @"1. P0304
If either PER03 or PER04 is present, then the other is required. 
2. P0506
If either PER05 or PER06 is present, then the other is required. 
3. P0708
If either PER07 or PER08 is present, then the other is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 25;
			dpo.Name = "PRV";
			dpo.Description = "Provider Information";
			dpo.Purpose = "To specify the identifying characteristics of a provider";
			dpo.Notes = "";
			dpo.Syntax = "1. P0203\r\nIf either PRV02 or PRV03 is present, then the other is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 33;
			dpo.Name = "PS1";
			dpo.Description = "Purchase Service";
			dpo.Purpose = "To specify the information about services that are purchased";
			dpo.Notes = "";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 26;
			dpo.Name = "PWK";
			dpo.Description = "Paperwork";
			dpo.Purpose = "To identify the type or transmission or both of paperwork or supporting information";
			dpo.Notes = "";
			dpo.Syntax = "1. P0506\r\nIf either PWK05 or PWK06 is present, then the other is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 31;
			dpo.Name = "QTY";
			dpo.Description = "Quantity Information";
			dpo.Purpose = "To specify quantity information";
			dpo.Notes = "";
			dpo.Syntax = @"1. R0204
At least one of QTY02 or QTY04 is required. 
2. E0204
Only one of QTY02 or QTY04 may be present.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 27;
			dpo.Name = "REF";
			dpo.Description = "Reference Information";
			dpo.Purpose = "To specify identifying information";
			dpo.Notes = "1. R0203\r\nAt least one of REF02 or REF03 is required.";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 28;
			dpo.Name = "SBR";
			dpo.Description = "Subscriber Information";
			dpo.Purpose = "To record information specific to the primary insured and the insurance carrier for that insured";
			dpo.Notes = @"1. NOTE: Loop 2320 contains insurance information about: paying and other Insurance Carriers for that Subscriber, Subscriber of the Other Insurance Carriers, School or Employer Information for that Subscriber.";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 45;
			dpo.Name = "SE";
			dpo.Description = "Transaction Set Trailer";
			dpo.Purpose = @"To indicate the end of the transaction set and provide the count of the transmitted segments (including the beginning (ST) and ending (SE) segments)";
			dpo.Notes = "1. SE is the last segment of each transaction set.";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 44;
			dpo.Name = "ST";
			dpo.Description = "Transaction Set Header";
			dpo.Purpose = "To indicate the start of a transaction set and to assign a control number";
			dpo.Notes = "";
			dpo.Syntax = "";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 29;
			dpo.Name = "SV1";
			dpo.Description = "Professional Service";
			dpo.Purpose = "To specify the service line item detail for a health care professional";
			dpo.Notes = "";
			dpo.Syntax = "1. P0304\r\nIf either SV103 or SV104 is present, then the other is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 30;
			dpo.Name = "SV5";
			dpo.Description = "Durable Medical Equipment Service";
			dpo.Purpose = "To specify the claim service detail for durable medical equipment";
			dpo.Notes = "";
			dpo.Syntax = @". R0405
At least one of SV504 or SV505 is required. 
2. C0604
If SV506 is present, then SV504 is required.";
			list.Add(dpo);

			dpo = new X12SegmentTemplateDpo();
			dpo.ID = 36;
			dpo.Name = "SVD";
			dpo.Description = "Service Line Adjudication";
			dpo.Purpose = @"To convey service line adjudication information for coordination of benefits between the initial payers of a health care claim and all subsequent payers";
			dpo.Notes = @"1. NOTE: SVD01 identifies the payer which adjudicated the corresponding service line and must match DE 67 in the NM109 position 325 for the payer.";
			dpo.Syntax = "";
			list.Add(dpo);

		}

	}
}
