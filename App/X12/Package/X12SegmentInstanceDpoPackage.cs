//
// Machine Packed Data
//   by devel at 6/22/2012 2:20:50 PM
//
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Sys;
using Sys.Data;
using Sys.DataManager;
using X12.Dpo;

namespace X12.Package
{
	public class X12SegmentInstanceDpoPackage : BasePackage<X12SegmentInstanceDpo>
	{

		public X12SegmentInstanceDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new X12SegmentInstanceDpo();
			dpo.ID = 1;
			dpo.LoopName = "1000A";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "SUBMITTER NAME";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "1. The submitter is the entity responsible for the creation and formatting of this transaction.";
			dpo.TR3_Example = "NM1412ABC SUBMITTER46999999999~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 2;
			dpo.LoopName = "1000A";
			dpo.Name = "PER";
			dpo.Sequence = 1;
			dpo.Description = "SUBMITTER EDI CONTACT INFORMATION";
			dpo.RepeatValue = 2;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @"1. When the communication number represents a telephone number in the United States and other countries using the North American Dialing Plan (for voice, data, fax, etc.), the communication number must always include the area code and phone number using the format AAABBBCCCC where AAA is the area code, BBB is the telephone number prefix, and CCCC is the telephone number. Therefore, the following telephone number (555) 555-1234 would be represented as 5555551234. Do not submit long distance access numbers, such as ""1"", in the telephone number. Telephone extensions, when applicable, must be submitted in the next element immediately following the telephone number. When submitting telephone extensions, only submit the numeric extension. Do not include data that indicates an extension, such as ""ext"" or ""x-"". 
 
2. The contact information in this segment identifies the person in the submitter organization who deals with data transmission issues. If data transmission problems arise, this is the person to contact in the submitter organization. 
 
3. There are 2 repetitions of the PER segment to allow for six possible combinations of communication numbers including extensions.";
			dpo.TR3_Example = "PERICJOHN SMITHTE5555551234EX123~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 3;
			dpo.LoopName = "1000B";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "RECEIVER NAME";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "NM1402XYZ RECEIVER46111222333~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 6;
			dpo.LoopName = "2000A";
			dpo.Name = "CUR";
			dpo.Sequence = 2;
			dpo.Description = "FOREIGN CURRENCY INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the amounts represented in this transaction are currencies other than the United States dollar. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. It is REQUIRED that all amounts reported within the transaction are of the currency named in this segment. If this segment is not used, then it is required that all amounts in this transaction be expressed in US dollars.";
			dpo.TR3_Example = "CUR85CAD~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 4;
			dpo.LoopName = "2000A";
			dpo.Name = "HL";
			dpo.Sequence = 0;
			dpo.Description = "BILLING PROVIDER HIERARCHICAL LEVEL";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "HL*1**20*1~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 5;
			dpo.LoopName = "2000A";
			dpo.Name = "PRV";
			dpo.Sequence = 1;
			dpo.Description = "BILLING PROVIDER SPECIALTY INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the payer's adjudication is known to be impacted by the provider taxonomy code.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "PRVBIPXC207Q00000X~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 21;
			dpo.LoopName = "2000B";
			dpo.Name = "HL";
			dpo.Sequence = 0;
			dpo.Description = "SUBSCRIBER HIERARCHICAL LEVEL";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @"1. If a patient can be uniquely identified to the destination payer in Loop ID-2010BB by a unique Member Identification Number, then the patient is the subscriber or is considered to be the subscriber and is identified at this level, and the patient HL in Loop ID-2000C is not used. 
 
2. If the patient is not the subscriber and cannot be identified to the destination payer by a unique Member Identification Number or it is not known to the sender if the Member Identification number is unique, both this HL and the patient HL in Loop ID- 2000C are required.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 23;
			dpo.LoopName = "2000B";
			dpo.Name = "PAT";
			dpo.Sequence = 2;
			dpo.Description = "PATIENT INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the patient is the subscriber or considered to be the subscriber and at least one of the element requirements are met. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 22;
			dpo.LoopName = "2000B";
			dpo.Name = "SBR";
			dpo.Sequence = 1;
			dpo.Description = "SUBSCRIBER INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 35;
			dpo.LoopName = "2000C";
			dpo.Name = "HL";
			dpo.Sequence = 0;
			dpo.Description = "PATIENT HIERARCHICAL LEVEL";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the patient is a dependent of the subscriber identified in Loop ID-2000B and cannot be uniquely identified to the payer using the subscriber's identifier in the Subscriber Level. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. There are no HLs subordinate to the Patient HL. 
 
2. If a patient is a dependent of a subscriber and can be uniquely identified to the payer by a unique Identification Number, then the patient is considered the subscriber and is to be identified in the Subscriber Level.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 36;
			dpo.LoopName = "2000C";
			dpo.Name = "PAT";
			dpo.Sequence = 1;
			dpo.Description = "PATIENT INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 8;
			dpo.LoopName = "2010AA";
			dpo.Name = "N3";
			dpo.Sequence = 1;
			dpo.Description = "BILLING PROVIDER ADDRESS";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @". The Billing Provider Address must be a street address. Post Office Box or Lock Box addresses are to be sent in the Pay-To Address Loop (Loop ID-2010AB), if necessary.";
			dpo.TR3_Example = "N3123 MAIN STREET~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 9;
			dpo.LoopName = "2010AA";
			dpo.Name = "N4";
			dpo.Sequence = 2;
			dpo.Description = "BILLING PROVIDER CITY, STATE, ZIP CODE";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "N4KANSAS CITYMO64108~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 7;
			dpo.LoopName = "2010AA";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "BILLING PROVIDER NAME";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @"1. Beginning on the NPI compliance date: When the Billing Provider is an organization health care provider, the organization health care provider's NPI or its subpart's NPI is reported in NM109. When a health care provider organization has determined that it needs to enumerate its subparts, it will report the NPI of a subpart as the Billing Provider. The subpart reported as the Billing Provider MUST always represent the most detailed level of enumeration as determined by the organization health care provider and MUST be the same identifier sent to any trading partner. For additional explanation, see section 1.10.3 Organization Health Care Provider Subpart Presentation. 
 
2. Prior to the NPI compliance date, proprietary identifiers necessary for the receiver to identify the Billing Provider entity are to be reported in the REF segment of Loop ID-2010BB. 
 
3. The Taxpayer Identifying Number (TIN) of the Billing Provider to be used for 1099 purposes must be reported in the REF segment of this loop. 
 
4. The Billing Provider may be an individual only when the health care provider performing services is an independent, unincorporated entity. In these cases, the Billing Provider is the individual whose social security number is used for 1099 purposes. That individual's NPI is reported in NM109, and the individual's Tax Identification Number must be reported in the REF segment of this loop. The individual's NPI must be reported when the individual provider is eligible for an NPI. See section 1.10.1 (Providers who are Not Eligible for Enumeration). 
 
5. When the individual or the organization is not a health care provider and, thus, not eligible to receive an NPI (For example, personal care services, carpenters, etc), the Billing Provider should be the legal entity. However, willing trading partners may agree upon varying definitions. Proprietary identifiers necessary for the receiver to identify the entity are to be reported in the Loop ID-2010BB REF, Billing Provider Secondary Identification segment. The TIN to be used for 1099 purposes must be reported in the REF (Tax Identification Number) segment of this loop.";
			dpo.TR3_Example = "NM1852ABC Group PracticeXX1234567890~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 12;
			dpo.LoopName = "2010AA";
			dpo.Name = "PER";
			dpo.Sequence = 5;
			dpo.Description = "BILLING PROVIDER CONTACT INFORMATION";
			dpo.RepeatValue = 2;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when this information is different than that contained in the Loop ID-1000A - Submitter PER segment. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @". When the communication number represents a telephone number in the United States and other countries using the North American Dialing Plan (for voice, data, fax, etc.), the communication number must always include the area code and phone number using the format AAABBBCCCC where AAA is the area code, BBB is the telephone number prefix, and CCCC is the telephone number. Therefore, the following telephone number (555) 555-1234 would be represented as 5555551234. Do not submit long distance access numbers, such as ""1"", in the telephone number. Telephone extensions, when applicable, must be submitted in the next element immediately following the telephone number. When submitting telephone extensions, only submit the numeric extension. Do not include data that indicates an extension, such as ""ext"" or ""x-"". 
 
2. There are 2 repetitions of the PER segment to allow for six possible combinations of communication numbers including extensions.";
			dpo.TR3_Example = "PERICJOHN SMITHTE5555551234EX123~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 10;
			dpo.LoopName = "2010AA";
			dpo.Name = "REF";
			dpo.Sequence = 3;
			dpo.Description = "BILLING PROVIDER TAX IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @"1. This is the tax identification number (TIN) of the entity to be paid for the submitted services.";
			dpo.TR3_Example = "REFEI123456789~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 11;
			dpo.LoopName = "2010AA";
			dpo.Name = "REF";
			dpo.Sequence = 4;
			dpo.Description = "BILLING PROVIDER UPIN/LICENSE INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated HIPAA National Provider Identifier (NPI) implementation date when a UPIN and/or license number is necessary for the receiver to identify the provider.
OR
Required on or after the mandated NPI implementation date when NM109 of this loop is not used and a UPIN or license number is necessary for the receiver to identify the provider.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Payer specific secondary identifiers are reported in the Loop ID-2010BB REF, Billing Provider Secondary Identification.";
			dpo.TR3_Example = "REF0B654321~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 14;
			dpo.LoopName = "2010AB";
			dpo.Name = "N3";
			dpo.Sequence = 1;
			dpo.Description = "PAY-TO ADDRESS - ADDRESS";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "N3*123 MAIN STREET~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 15;
			dpo.LoopName = "2010AB";
			dpo.Name = "N4";
			dpo.Sequence = 2;
			dpo.Description = "PAY-TO ADDRESS CITY, STATE, ZIP CODE";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "N4*KANSAS CITY*MO*64108~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 13;
			dpo.LoopName = "2010AB";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "PAY-TO ADDRESS NAME";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the address for payment is different than that of the Billing Provider. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. The purpose of Loop ID-2010AB has changed from previous versions. Loop ID-2010AB only contains address information when different from the Billing Provider Address. There are no applicable identifiers for Pay-To Address information.";
			dpo.TR3_Example = "NM1*87*2~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 17;
			dpo.LoopName = "2010AC";
			dpo.Name = "N3";
			dpo.Sequence = 1;
			dpo.Description = "PAY-TO PLAN ADDRESS";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "N3*123 MAIN STREET~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 18;
			dpo.LoopName = "2010AC";
			dpo.Name = "N4";
			dpo.Sequence = 2;
			dpo.Description = "PAY-TO PLAN CITY, STATE, ZIP CODE";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 16;
			dpo.LoopName = "2010AC";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "PAY-TO PLAN NAME";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when willing trading partners agree to use this implementation for their subrogation payment requests.";
			dpo.TR3_Notes = "1. This loop may only be used when BHT06 = 31.";
			dpo.TR3_Example = "NM1*PE*2*ANY STATE*MEDICAID*****PI*12345~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 19;
			dpo.LoopName = "2010AC";
			dpo.Name = "REF";
			dpo.Sequence = 3;
			dpo.Description = "PAY-TO PLAN SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated implementation date for the HIPAA National Plan Identifier when an additional identification number to that provided in the NM109 of this loop is necessary for the claim processor to identify the entity. If not required by this implementation guide, do not send";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 20;
			dpo.LoopName = "2010AC";
			dpo.Name = "REF";
			dpo.Sequence = 4;
			dpo.Description = "PAY-TO PLAN TAX IDENTIFICATION NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 27;
			dpo.LoopName = "2010BA";
			dpo.Name = "DMG";
			dpo.Sequence = 3;
			dpo.Description = "SUBSCRIBER DEMOGRAPHIC INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the patient is the subscriber or considered to be the subscriber. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 25;
			dpo.LoopName = "2010BA";
			dpo.Name = "N3";
			dpo.Sequence = 1;
			dpo.Description = "SUBSCRIBER ADDRESS";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the patient is the subscriber or considered to be the subscriber. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 26;
			dpo.LoopName = "2010BA";
			dpo.Name = "N4";
			dpo.Sequence = 2;
			dpo.Description = "SUBSCRIBER CITY, STATE, ZIP CODE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the patient is the subscriber or considered to be the subscriber. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 24;
			dpo.LoopName = "2010BA";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "SUBSCRIBER NAME";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @"1. In worker's compensation or other property and casualty claims, the ""subscriber"" may be a non-person entity (for example, the employer). However, this varies by state.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 211;
			dpo.LoopName = "2010BA";
			dpo.Name = "PER";
			dpo.Sequence = 6;
			dpo.Description = "PROPERTY AND CASUALTY SUBSCRIBER CONTACT INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required for Property and Casualty claims when this information is deemed necessary by the submitter. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @". When the communication number represents a telephone number in the United States and other countries using the North American Dialing Plan (for voice, data, fax, etc.), the communication number must always include the area code and phone number using the format AAABBBCCCC where AAA is the area code, BBB is the telephone number prefix, and CCCC is the telephone number. Therefore, the following telephone number (555) 555-1234 would be represented as 5555551234. Do not submit long distance access numbers, such as ""1"", in the telephone number. Telephone extensions, when applicable, must be submitted in the next element immediately following the telephone number. When submitting telephone extensions, only submit the numeric extension. Do not include data that indicates an extension, such as ""ext"" or ""x-"".";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 28;
			dpo.LoopName = "2010BA";
			dpo.Name = "REF";
			dpo.Sequence = 4;
			dpo.Description = "SUBSCRIBER SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when an additional identification number to that provided in NM109 of this loop is necessary for the claim processor to identify the entity. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 29;
			dpo.LoopName = "2010BA";
			dpo.Name = "REF";
			dpo.Sequence = 5;
			dpo.Description = "PROPERTY AND CASUALTY CLAIM NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the services included in this claim are to be considered as part of a property and casualty claim. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @". This is a property and casualty payer-assigned claim number. Providers receive this number from the property and casualty payer during eligibility determinations or some other communication with that payer. See Section 1.4.2, Property and Casualty, for additional information about property and casualty claims.  
 
2. This segment is not a HIPAA requirement as of this writing.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 31;
			dpo.LoopName = "2010BB";
			dpo.Name = "N3";
			dpo.Sequence = 1;
			dpo.Description = "PAYER ADDRESS";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the payer address is available and the submitter intends for the claim to be printed on paper at the next EDI location (for example, a clearinghouse). If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 32;
			dpo.LoopName = "2010BB";
			dpo.Name = "N4";
			dpo.Sequence = 2;
			dpo.Description = "PAYER CITY, STATE, ZIP CODE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the payer address is available and the submitter intends for the claim to be printed on paper at the next EDI location (for example, a clearinghouse). If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 30;
			dpo.LoopName = "2010BB";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "PAYER NAME";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @"1. This is the destination payer. 
 
2. For the purposes of this implementation the term payer is synonymous with several other terms, such as, repricer and third party administrator";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 33;
			dpo.LoopName = "2010BB";
			dpo.Name = "REF";
			dpo.Sequence = 3;
			dpo.Description = "PAYER SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated implementation date for the HIPAA National Plan Identifier when an additional identification number to that provided in the NM109 of this loop is necessary for the claim processor to identify the entity. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 34;
			dpo.LoopName = "2010BB";
			dpo.Name = "REF";
			dpo.Sequence = 4;
			dpo.Description = "BILLING PROVIDER SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated NPI Implementation Date when an additional identification number is necessary for the receiver to identify the provider.
OR
Required on or after the mandated NPI Implementation Date when NM109 in Loop 2010AA is not used and an identification number other than the NPI is necessary for the receiver to identify the provider.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 40;
			dpo.LoopName = "2010CA";
			dpo.Name = "DMG";
			dpo.Sequence = 3;
			dpo.Description = "PATIENT DEMOGRAPHIC INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 38;
			dpo.LoopName = "2010CA";
			dpo.Name = "N3";
			dpo.Sequence = 1;
			dpo.Description = "PATIENT ADDRESS";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 39;
			dpo.LoopName = "2010CA";
			dpo.Name = "N4";
			dpo.Sequence = 2;
			dpo.Description = "PATIENT CITY, STATE, ZIP CODE";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 37;
			dpo.LoopName = "2010CA";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "PATIENT NAME";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 43;
			dpo.LoopName = "2010CA";
			dpo.Name = "PER";
			dpo.Sequence = 6;
			dpo.Description = "PROPERTY AND CASUALTY PATIENT CONTACT INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required for Property and Casualty claims when this information is different than the information provided in the Subscriber Contact Information PER segment in Loop ID-2010BA and this information is deemed necessary by the submitter. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. When the communication number represents a telephone number in the United States and other countries using the North American Dialing Plan (for voice, data, fax, etc.), the communication number must always include the area code and phone number using the format AAABBBCCCC where AAA is the area code, BBB is the telephone number prefix, and CCCC is the telephone number. Therefore, the following telephone number (555) 555-1234 would be represented as 5555551234. Do not submit long distance access numbers, such as ""1"", in the telephone number. Telephone extensions, when applicable, must be submitted in the next element immediately following the telephone number. When submitting telephone extensions, only submit the numeric extension. Do not include data that indicates an extension, such as ""ext"" or ""x-"".";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 41;
			dpo.LoopName = "2010CA";
			dpo.Name = "REF";
			dpo.Sequence = 4;
			dpo.Description = "PROPERTY AND CASUALTY CLAIM NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the services included in this claim are to be considered as part of a property and casualty claim. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. This is a property and casualty payer-assigned claim number. Providers receive this number from the property and casualty payer during eligibility determinations or some other communication with that payer. See Section 1.4.2, Property and Casualty, for additional information about property and casualty claims.  
 
2. This segment is not a HIPAA requirement as of this writing.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 42;
			dpo.LoopName = "2010CA";
			dpo.Name = "REF";
			dpo.Sequence = 5;
			dpo.Description = "PROPERTY AND CASUALTY PATIENT IDENTIFIER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when an identification number is needed by the receiver to identify the patient for Property and Casualty claims. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 63;
			dpo.LoopName = "2300";
			dpo.Name = "AMT";
			dpo.Sequence = 19;
			dpo.Description = "PATIENT AMOUNT PAID";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when patient has made payment specifically toward this claim. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Patient Amount Paid refers to the sum of all amounts paid on the claim by the patient or his or her representative(s).";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 44;
			dpo.LoopName = "2300";
			dpo.Name = "CLM";
			dpo.Sequence = 0;
			dpo.Description = "CLAIM INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @"1. The developers of this implementation guide recommend that trading partners limit the size of the transaction (ST-SE envelope) to a maximum of 5000 CLM segments. There is no recommended limit to the number of ST-SE transactions within a GS-GE or ISA-IEA. Willing trading partners can agree to set limits higher. 
 
2. For purposes of this documentation, the claim detail information is presented only in the dependent level. Specific claim detail information can be given in either the subscriber or the dependent hierarchical level. Because of this, the claim information is said to ""float."" Claim information is positioned in the same hierarchical level that describes its owner-participant, either the subscriber or the dependent. In other words, the claim information, Loop ID-2300, is placed following Loop ID-2010BB in the Subscriber Hierarchical Level (HL) when patient information is sent in Loop ID-2010BA of the Subscriber HL. Claim information is placed in the Patient HL when the patient information is sent in Loop ID-2010CA of the Patient HL. When the patient is the subscriber or is considered to be the subscriber, Loop ID-2000C and Loop ID-2010CA are not sent. See Subscriber/Patient HL Segment explanation in section 1.4.3.2.2.1 for details.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 62;
			dpo.LoopName = "2300";
			dpo.Name = "CN1";
			dpo.Sequence = 18;
			dpo.Description = "CONTRACT INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the submitter is contractually obligated to supply this information on post-adjudicated claims. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. The developers of this implementation guide note that the CN1 segment is for use only for post-adjudicated claims, which do not meet the definition of a health care claim under HIPAA. Consequently, at the time of this writing, the CN1 segment is for non-HIPAA use only.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 80;
			dpo.LoopName = "2300";
			dpo.Name = "CR1";
			dpo.Sequence = 36;
			dpo.Description = "AMBULANCE TRANSPORT INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required on all claims involving ambulance transport services. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. The CR1 segment in Loop ID-2300 applies to the entire claim unless overridden by a CR1 segment at the service line level in Loop ID-2400 with the same value in CR101.";
			dpo.TR3_Example = "CR1LB140ADH12UNCONSCIOUS~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 81;
			dpo.LoopName = "2300";
			dpo.Name = "CR2";
			dpo.Sequence = 37;
			dpo.Description = "SPINAL MANIPULATION SERVICE INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required on chiropractic claims involving spinal manipulation when the information is known to impact the payer's adjudication process. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 82;
			dpo.LoopName = "2300";
			dpo.Name = "CRC";
			dpo.Sequence = 38;
			dpo.Description = "AMBULANCE CERTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the claim involves ambulance transport services
AND
when reporting condition codes in any of CRC03 through CRC07. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @". The CRC segment in Loop ID-2300 applies to the entire claim unless overridden by a CRC segment at the service line level in Loop ID-2400 with the same value in CRC01. 
 
2. Repeat this segment only when it is necessary to report additional unique values to those reported in CRC03 thru CRC07.";
			dpo.TR3_Example = "CRC07Y01~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 83;
			dpo.LoopName = "2300";
			dpo.Name = "CRC";
			dpo.Sequence = 39;
			dpo.Description = "PATIENT CONDITION INFORMATION: VISION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required on vision claims involving replacement lenses or frames when this information is known to impact reimbursement. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 84;
			dpo.LoopName = "2300";
			dpo.Name = "CRC";
			dpo.Sequence = 40;
			dpo.Description = "HOMEBOUND INDICATOR";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required for Medicare claims when an independent laboratory renders an EKG tracing or obtains a specimen from a homebound or institutionalized patient. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 85;
			dpo.LoopName = "2300";
			dpo.Name = "CRC";
			dpo.Sequence = 41;
			dpo.Description = "EPSDT REFERRAL";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required on Early & Periodic Screening, Diagnosis, and Treatment (EPSDT) claims when the screening service is being billed in this claim. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 45;
			dpo.LoopName = "2300";
			dpo.Name = "DTP";
			dpo.Sequence = 1;
			dpo.Description = "DATE - ONSET OF CURRENT ILLNESS OR SYMPTOM";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required for the initial medical service or visit performed in response to a medical emergency when the date is available and is different than the date of service. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "1. This date is the onset of acute symptoms for the current illness or condition.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 46;
			dpo.LoopName = "2300";
			dpo.Name = "DTP";
			dpo.Sequence = 2;
			dpo.Description = "DATE - INITIAL TREATMENT DATE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the Initial Treatment Date is known to impact adjudication for claims involving spinal manipulation, physical therapy, occupational therapy, speech language pathology, dialysis, optical refractions, or pregnancy. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Dates in Loop ID-2300 apply to all service lines within Loop ID-2400 unless a DTP segment occurs in Loop ID-2400 with the same value in DTP01. In that case, the DTP in Loop ID-2400 overrides the DTP in Loop ID-2300 for that service line only.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 47;
			dpo.LoopName = "2300";
			dpo.Name = "DTP";
			dpo.Sequence = 3;
			dpo.Description = "DATE - LAST SEEN DATE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when claims involve services for routine foot care and it is known to impact the payer's adjudication process. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @". This is the date that the patient was seen by the attending or supervising physician for the qualifying medical condition related to the services performed. 
 
2. Dates in Loop ID-2300 apply to all service lines within Loop ID-2400 unless a DTP segment occurs in Loop ID-2400 with the same value in DTP01. In that case, the DTP in Loop ID-2400 overrides the DTP in Loop ID-2300 for that service line only.";
			dpo.TR3_Example = "DTP*304*D8*20050108~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 48;
			dpo.LoopName = "2300";
			dpo.Name = "DTP";
			dpo.Sequence = 4;
			dpo.Description = "DATE - ACUTE MANIFESTATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when Loop ID-2300 CR208 = ""A"" or ""M"", the claim involves spinal manipulation, and the payer is Medicare. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 49;
			dpo.LoopName = "2300";
			dpo.Name = "DTP";
			dpo.Sequence = 5;
			dpo.Description = "DATE - ACCIDENT";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when CLM11-1 or CLM11-2 has a value of `AA' or `OA'.
OR
Required when CLM11-1 or CLM11-2 has a value of `EM' and this claim is the result of an accident.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 50;
			dpo.LoopName = "2300";
			dpo.Name = "DTP";
			dpo.Sequence = 6;
			dpo.Description = "DATE - LAST MENSTRUAL PERIOD";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when, in the judgment of the provider, the services on this claim are related to the patient's pregnancy. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 51;
			dpo.LoopName = "2300";
			dpo.Name = "DTP";
			dpo.Sequence = 7;
			dpo.Description = "DATE - LAST X-RAY DATE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when claim involves spinal manipulation and an x-ray was taken. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @". Dates in Loop ID-2300 apply to all service lines within Loop ID-2400 unless a DTP segment occurs in Loop ID-2400 with the same value in DTP01. In that case, the DTP in Loop ID-2400 overrides the DTP in Loop ID-2300 for that service line only.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 52;
			dpo.LoopName = "2300";
			dpo.Name = "DTP";
			dpo.Sequence = 8;
			dpo.Description = "DATE - HEARING AND VISION PRESCRIPTION DATE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required on claims where a prescription has been written for hearing devices or vision frames and lenses and it is being billed on this claim. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 53;
			dpo.LoopName = "2300";
			dpo.Name = "DTP";
			dpo.Sequence = 9;
			dpo.Description = "DATE - DISABILITY DATES";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required on claims involving disability where, in the judgment of the provider, the patient was or will be unable to perform the duties normally associated with his/her work.
OR
Required on non-HIPAA claims (for example workers compensation or property and casualty) when required by the claims processor.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 54;
			dpo.LoopName = "2300";
			dpo.Name = "DTP";
			dpo.Sequence = 10;
			dpo.Description = "DATE - LAST WORKED";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required on claims where this information is necessary for adjudication of the claim (for example, workers compensation claims involving absence from work). If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 55;
			dpo.LoopName = "2300";
			dpo.Name = "DTP";
			dpo.Sequence = 11;
			dpo.Description = "DATE - AUTHORIZED RETURN TO WORK";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required on claims where this information is necessary for adjudication of the claim (for example, workers compensation claims involving absence from work). If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 56;
			dpo.LoopName = "2300";
			dpo.Name = "DTP";
			dpo.Sequence = 12;
			dpo.Description = "DATE - ADMISSION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required on all ambulance claims when the patient was known to be admitted to the hospital.
OR
Required on all claims involving inpatient medical visits.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 57;
			dpo.LoopName = "2300";
			dpo.Name = "DTP";
			dpo.Sequence = 13;
			dpo.Description = "DATE - DISCHARGE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required for inpatient claims when the patient was discharged from the facility and the discharge date is known. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 58;
			dpo.LoopName = "2300";
			dpo.Name = "DTP";
			dpo.Sequence = 14;
			dpo.Description = "ASSUMED AND RELINQUISHED CARE DATES";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required to indicate ""assumed care date"" or ""relinquished care date"" when providers share post-operative care (global surgery claims). If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Assumed Care Date is the date care was assumed by another provider during post-operative care. Relinquished Care Date is the date the provider filing this claim ceased post-operative care. See Medicare guidelines for further explanation of these dates.

Example: Surgeon ""A"" relinquished post-operative care to Physician ""B"" five days after surgery. When Surgeon ""A"" submits a claim, ""A"" will use code ""091 - Report End"" to indicate the day the surgeon relinquished care of this patient to Physician ""B"". When Physician ""B"" submits a claim, ""B"" will use code ""090 - Report Start"" to indicate the date they assumed care of this patient from Surgeon ""A"".";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 59;
			dpo.LoopName = "2300";
			dpo.Name = "DTP";
			dpo.Sequence = 15;
			dpo.Description = "DATE - PROPERTY AND CASUALTY DATE OF FIRST CONTACT";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required for Property and Casualty claims when state mandated. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. This is the date the patient first consulted the service provider for this condition. The date of first contact is the date the patient first consulted the provider by any means. It is not necessarily the Initial Treatment Date.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 60;
			dpo.LoopName = "2300";
			dpo.Name = "DTP";
			dpo.Sequence = 16;
			dpo.Description = "DATE - REPRICER RECEIVED DATE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when a repricer is passing the claim onto the payer. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 89;
			dpo.LoopName = "2300";
			dpo.Name = "HCP";
			dpo.Sequence = 45;
			dpo.Description = "CLAIM PRICING/REPRICING INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when this information is deemed necessary by the repricer. The segment is not completed by providers. The information is completed by repricers only. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. This information is specific to the destination payer reported in Loop ID-2010BB. 
 
2. For capitated encounters, pricing or repricing information usually is not applicable and is provided to qualify other information within the claim.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 86;
			dpo.LoopName = "2300";
			dpo.Name = "HI";
			dpo.Sequence = 42;
			dpo.Description = "HEALTH CARE DIAGNOSIS CODE";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "1. Do not transmit the decimal point for ICD codes. The decimal point is implied.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 87;
			dpo.LoopName = "2300";
			dpo.Name = "HI";
			dpo.Sequence = 43;
			dpo.Description = "ANESTHESIA RELATED PROCEDURE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required on claims where anesthesiology services are being billed or reported when the provider knows the surgical code and knows the adjudication of the claim will depend on provision of the surgical code. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 88;
			dpo.LoopName = "2300";
			dpo.Name = "HI";
			dpo.Sequence = 44;
			dpo.Description = "CONDITION INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when condition information applies to the claim.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 78;
			dpo.LoopName = "2300";
			dpo.Name = "K3";
			dpo.Sequence = 34;
			dpo.Description = "FILE INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when ALL of the following conditions are met:
• A regulatory agency concludes it must use the K3 to meet an emergency
  legislative requirement;
• The administering regulatory agency or other state organization has
  completed each one of the following steps:
    contacted the X12N workgroup, 
    requested a review of the K3 data requirement to ensure there is not
      an existing method within the implementation guide to meet this
      requirement
• X12N determines that there is no method to meet the requirement.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. At the time of publication of this implementation, K3 segments have no specific use. The K3 segment is expected to be used only when necessary to meet the unexpected data requirement of a legislative authority. Before this segment can be used : 
- The X12N Health Care Claim workgroup must conclude there is no other available option in the implementation guide to meet the emergency legislative requirement.
- The requestor must submit a proposal for approval accompanied by the relevant business documentation to the X12N Health Care Claim workgroup chairs and receive approval for the request.
Upon review of the request, X12N will issue an approval or denial decision to the requesting entity. Approved usage(s) of the K3 segment will be reviewed by the X12N Health Care Claim workgroup to develop a permanent change to include the business case in future transaction implementations. 
 
2. Only when all of the requirements above have been met, may the regulatory agency require the temporary use of the K3 segment. 
 
3. X12N will submit the necessary data maintenance and refer the request to the appropriate data content committee(s).";
			dpo.TR3_Example = "K3*STATE DATA REQUIREMENT~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 79;
			dpo.LoopName = "2300";
			dpo.Name = "NTE";
			dpo.Sequence = 35;
			dpo.Description = "CLAIM NOTE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when in the judgment of the provider, the information is needed to substantiate the medical treatment and is not supported elsewhere within the claim data set.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Information in the NTE segment in Loop ID-2300 applies to the entire claim unless overridden by information in the NTE segment in Loop ID-2400. Information is considered to be overridden when the value in NTE01 in Loop ID-2400 is the same as the value in NTE01 in Loop ID-2300. 
 
2. The developers of this implementation guide discourage using narrative information within the 837. Trading partners who use narrative information with claims are strongly encouraged to codify that information within the X12 environment.";
			dpo.TR3_Example = "NTEADDSURGERY WAS UNUSUALLY LONG BECAUSE [FILL IN REASON]~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 61;
			dpo.LoopName = "2300";
			dpo.Name = "PWK";
			dpo.Sequence = 17;
			dpo.Description = "CLAIM SUPPLEMENTAL INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when there is a paper attachment following this claim.
OR
Required when attachments are sent electronically (PWK02 = EL) but are transmitted in another functional group (for example, 275) rather than by paper. PWK06 is then used to identify the attached electronic documentation. The number in PWK06 is carried in the TRN of the electronic attachment.
OR
Required when the provider deems it necessary to identify additional information that is being held at the provider's office and is available upon request by the payer (or appropriate entity), but the information is not being submitted with the claim. Use the value of ""AA"" in PWK02 to convey this specific use of the PWK segment.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 64;
			dpo.LoopName = "2300";
			dpo.Name = "REF";
			dpo.Sequence = 20;
			dpo.Description = "SERVICE AUTHORIZATION EXCEPTION CODE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when mandated by government law or regulation to obtain authorization for specific service(s) but, for the reasons listed in REF02, the service was performed without obtaining the authorization. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 65;
			dpo.LoopName = "2300";
			dpo.Name = "REF";
			dpo.Sequence = 21;
			dpo.Description = "MANDATORY MEDICARE (SECTION 4081) CROSSOVER INDICATOR";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the submitter is Medicare and the claim is a Medigap or COB crossover claim. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 66;
			dpo.LoopName = "2300";
			dpo.Name = "REF";
			dpo.Sequence = 22;
			dpo.Description = "MAMMOGRAPHY CERTIFICATION NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when mammography services are rendered by a certified mammography provider. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 67;
			dpo.LoopName = "2300";
			dpo.Name = "REF";
			dpo.Sequence = 23;
			dpo.Description = "REFERRAL NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when a referral number is assigned by the payer or Utilization Management Organization (UMO)
AND
a referral is involved.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Numbers at this position apply to the entire claim unless they are overridden in the REF segment in Loop ID-2400. A reference identification is considered to be overridden if the value in REF01 is the same in both the Loop ID-2300 REF segment and the Loop ID-2400 REF segment. In that case, the Loop ID-2400 REF applies only to that specific line.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 68;
			dpo.LoopName = "2300";
			dpo.Name = "REF";
			dpo.Sequence = 24;
			dpo.Description = "PRIOR AUTHORIZATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when an authorization number is assigned by the payer or UMO
AND
the services on this claim were preauthorized.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Generally, preauthorization numbers are assigned by the payer or UMO to authorize a service prior to its being performed. The UMO (Utilization Management Organization) is generally the entity empowered to make a decision regarding the outcome of a health services review or the owner of information. The prior authorization number carried in this REF is specific to the destination payer reported in the Loop ID-2010BB. If other payers have similar numbers for this claim, report that information in the Loop ID-2330 loop REF which holds that payer's information. 
 
2. Numbers at this position apply to the entire claim unless they are overridden in the REF segment in Loop ID-2400. A reference identification is considered to be overridden if the value in REF01 is the same in both the Loop ID-2300 REF segment and the Loop ID-2400 REF segment. In that case, the Loop ID-2400 REF applies only to that specific line.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 69;
			dpo.LoopName = "2300";
			dpo.Name = "REF";
			dpo.Sequence = 25;
			dpo.Description = "PAYER CLAIM CONTROL NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when CLM05-3 (Claim Frequency Code) indicates this claim is a replacement or void to a previously adjudicated claim. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "1. This information is specific to the destination payer reported in Loop ID-2010BB.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 70;
			dpo.LoopName = "2300";
			dpo.Name = "REF";
			dpo.Sequence = 26;
			dpo.Description = "CLINICAL LABORATORY IMPROVEMENT AMENDMENT (CLIA) NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required for all CLIA certified facilities performing CLIA covered laboratory services. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. If a CLIA number is indicated at the line level (Loop ID-2400) in addition to the claim level (Loop ID-2300), that would indicate an exception to the CLIA number at the claim level for that individual line. 
 
2. In cases where this claim contains both in-house and outsourced laboratory services, the CLIA Number for laboratory services performed by the Billing or Rendering Provider is reported in this loop. The CLIA number for laboratory services which were outsourced is reported in Loop ID-2400.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 71;
			dpo.LoopName = "2300";
			dpo.Name = "REF";
			dpo.Sequence = 27;
			dpo.Description = "REPRICED CLAIM NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when this information is deemed necessary by the repricer. The segment is not completed by providers. The information is completed by repricers only. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "1. This information is specific to the destination payer reported in Loop ID-2010BB";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 72;
			dpo.LoopName = "2300";
			dpo.Name = "REF";
			dpo.Sequence = 28;
			dpo.Description = "ADJUSTED REPRICED CLAIM NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when this information is deemed necessary by the repricer. The segment is not completed by providers. The information is completed by repricers only. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "1. This information is specific to the destination payer reported in Loop ID-2010BB.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 73;
			dpo.LoopName = "2300";
			dpo.Name = "REF";
			dpo.Sequence = 29;
			dpo.Description = "INVESTIGATIONAL DEVICE EXEMPTION NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when claim involves a Food and Drug Administration (FDA) assigned investigational device exemption (IDE) number. When more than one IDE applies, they must be split into separate claims. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 74;
			dpo.LoopName = "2300";
			dpo.Name = "REF";
			dpo.Sequence = 30;
			dpo.Description = "CLAIM IDENTIFIER FOR TRANSMISSION INTERMEDIARIES";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when this information is deemed necessary by transmission intermediaries (Automated Clearinghouses, and others) who need to attach their own unique claim number. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Although this REF is supplied for transmission intermediaries to attach their own unique claim number to a claim, 837-recipients are not required under HIPAA to return this number in any HIPAA transaction. Trading partners may voluntarily agree to this interaction if they wish.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 75;
			dpo.LoopName = "2300";
			dpo.Name = "REF";
			dpo.Sequence = 31;
			dpo.Description = "MEDICAL RECORD NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the provider needs to identify for future inquiries, the actual medical record of the patient identified in either Loop ID-2010BA or Loop ID-2010CA for this episode of care. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Although this REF is supplied for transmission intermediaries to attach their own unique claim number to a claim, 837-recipients are not required under HIPAA to return this number in any HIPAA transaction. Trading partners may voluntarily agree to this interaction if they wish.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 76;
			dpo.LoopName = "2300";
			dpo.Name = "REF";
			dpo.Sequence = 32;
			dpo.Description = "DEMONSTRATION PROJECT IDENTIFIER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when it is necessary to identify claims which are atypical in ways such as content, purpose, and/or payment, as could be the case for a demonstration or other special project, or a clinical trial. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 77;
			dpo.LoopName = "2300";
			dpo.Name = "REF";
			dpo.Sequence = 33;
			dpo.Description = "CARE PLAN OVERSIGHT";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the physician is billing Medicare for Care Plan Oversight (CPO). If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. This is the number of the home health agency or hospice providing Medicare covered services to the patient for the period during which CPO services were furnished.
Prior to the mandated HIPAA National Provider Identifier (NPI) implementation date this number is the Medicare Number.
On or after the mandated HIPAA National Provider Identifier (NPI) implementation date this is the NPI.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 90;
			dpo.LoopName = "2310A";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "REFERRING PROVIDER NAME";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when this claim involves a referral. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. When reporting the provider who ordered services such as diagnostic and lab, use Loop ID-2310A at the claim level. For ordered services such as Durable Medical Equipment, use Loop ID-2420E at the line level. 
 
2. When there is only one referral on the claim, use code ""DN - Referring Provider"". When more than one referral exists and there is a requirement to report the additional referral, use code DN in the first iteration of this loop to indicate the referral received by the rendering provider on this claim. Use code ""P3 - Primary Care Provider"" in the second iteration of the loop to indicate the initial referral from the primary care provider or whatever provider wrote the initial referral for this patient's episode of care being billed/reported in this transaction. 
 
3. Information in Loop ID-2310 applies to the entire claim unless overridden on a service line by the presence of Loop ID-2420 with the same value in NM101.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 91;
			dpo.LoopName = "2310A";
			dpo.Name = "REF";
			dpo.Sequence = 1;
			dpo.Description = "REFERRING PROVIDER SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated HIPAA National Provider Identifier (NPI) implementation date when an identification number other than the NPI is necessary for the receiver to identify the provider.
OR
Required on or after the mandated NPI Implementation Date when NM109 in this loop is not used and an identification number other than the NPI is necessary for the receiver to identify the provider.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. The REF segment in Loop ID-2310 applies to the entire claim unless overridden on the service line level by the presence of a REF segment with the same value in REF01.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 92;
			dpo.LoopName = "2310B";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "RENDERING PROVIDER NAME";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the Rendering Provider information is different than that carried in Loop ID-2010AA - Billing Provider.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Used for all types of rendering providers including laboratories. The Rendering Provider is the person or company (laboratory or other facility) who rendered the care. In the case where a substitute provider (locum tenens) was used, enter that provider's information here. 
 
2. Information in Loop ID-2310 applies to the entire claim unless overridden on a service line by the presence of Loop ID-2420 with the same value in NM101.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 93;
			dpo.LoopName = "2310B";
			dpo.Name = "PRV";
			dpo.Sequence = 1;
			dpo.Description = "RENDERING PROVIDER SPECIALTY INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when adjudication is known to be impacted by the provider taxonomy code. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. The PRV segment in Loop ID-2310 applies to the entire claim unless overridden on the service line level by the presence of a PRV segment with the same value in PRV01.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 94;
			dpo.LoopName = "2310B";
			dpo.Name = "REF";
			dpo.Sequence = 2;
			dpo.Description = "RENDERING PROVIDER SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 4;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated HIPAA National Provider Identifier (NPI) implementation date when an identification number other than the NPI is necessary for the receiver to identify the provider.
OR
Required on or after the mandated NPI Implementation Date when NM109 in this loop is not used and an identification number other than the NPI is necessary for the receiver to identify the provider.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. The REF segment in Loop ID-2310 applies to the entire claim unless overridden on the service line level by the presence of a REF segment with the same value in REF01.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 96;
			dpo.LoopName = "2310C";
			dpo.Name = "N3";
			dpo.Sequence = 1;
			dpo.Description = "SERVICE FACILITY LOCATION ADDRESS";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @"1. If service facility location is in an area where there are no street addresses, enter a description of where the service was rendered (for example, ""crossroad of State Road 34 and 45"" or ""Exit near Mile marker 265 on Interstate 80"".)";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 97;
			dpo.LoopName = "2310C";
			dpo.Name = "N4";
			dpo.Sequence = 2;
			dpo.Description = "SERVICE FACILITY LOCATION CITY, STATE, ZIP CODE";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 95;
			dpo.LoopName = "2310C";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "SERVICE FACILITY LOCATION NAME";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the location of health care service is different than that carried in Loop ID-2010AA (Billing Provider).
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. When an organization health care provider's NPI is provided to identify the Service Location, the organization health care provider must be external to the entity identified as the Billing Provider (for example, reference lab). It is not permissible to report an organization health care provider NPI as the Service Location if the entity being identified is a component (for example, subpart) of the Billing Provider. In that case, the subpart must be the Billing Provider. 
 
2. The purpose of this loop is to identify specifically where the service was rendered. When reporting ambulance services, do not use this loop. Use Loop ID-2310E - Ambulance Pick-up Location and Loop ID-2310F - Ambulance Drop-off Location. 
 
3. Information in Loop ID-2310 applies to the entire claim unless overridden on a service line by the presence of Loop ID-2420 with the same value in NM101.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 99;
			dpo.LoopName = "2310C";
			dpo.Name = "PER";
			dpo.Sequence = 4;
			dpo.Description = "SERVICE FACILITY CONTACT INFO";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required for Property and Casualty claims when this information is different than the information provided in Loop ID-1000A Submitter EDI Contact Information PER Segment, and Loop ID-2010AA Billing Provider Contact Information PER segment and when deemed necessary by the submitter.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. When the communication number represents a telephone number in the United States and other countries using the North American Dialing Plan (for voice, data, fax, etc.), the communication number must always include the area code and phone number using the format AAABBBCCCC where AAA is the area code, BBB is the telephone number prefix, and CCCC is the telephone number. Therefore, the following telephone number (555) 555-1234 would be represented as 5555551234. Do not submit long distance access numbers, such as ""1"", in the telephone number. Telephone extensions, when applicable, must be submitted in the next element immediately following the telephone number. When submitting telephone extensions, only submit the numeric extension. Do not include data that indicates an extension, such as ""ext"" or ""x-"".";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 98;
			dpo.LoopName = "2310C";
			dpo.Name = "REF";
			dpo.Sequence = 3;
			dpo.Description = "SERVICE FACILITY LOCATION SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated HIPAA National Provider Identifier (NPI) implementation date when an identification number other than the NPI is necessary for the receiver to identify the provider.
OR
Required on or after the mandated NPI Implementation Date when NM109 in this loop is not used and an identification number other than the NPI is necessary for the receiver to identify the provider.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 100;
			dpo.LoopName = "2310D";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "SUPERVISING PROVIDER NAME";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the rendering provider is supervised by a physician. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Information in Loop ID-2310 applies to the entire claim unless overridden on a service line by the presence of Loop ID-2420 with the same value in NM101.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 101;
			dpo.LoopName = "2310D";
			dpo.Name = "REF";
			dpo.Sequence = 1;
			dpo.Description = "SUPERVISING PROVIDER SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated HIPAA National Provider Identifier (NPI) implementation date when an identification number other than the NPI is necessary for the receiver to identify the provider.
OR
Required on or after the mandated NPI implementation date when the entity is not a Health Care provider (a.k.a. an atypical provider), and an identifier is necessary for the claims processor to identify the entity.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 103;
			dpo.LoopName = "2310E";
			dpo.Name = "N3";
			dpo.Sequence = 1;
			dpo.Description = "AMBULANCE PICK-UP LOCATION ADDRESS";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @"1. If the ambulance pickup location is in an area where there are no street addresses, enter a description of where the service was rendered (for example, ""crossroad of State Road 34 and 45"" or ""Exit near Mile marker 265 on Interstate 80"".)";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 104;
			dpo.LoopName = "2310E";
			dpo.Name = "N4";
			dpo.Sequence = 2;
			dpo.Description = "AMBULANCE PICK-UP LOCATION CITY, STATE, ZIP CODE";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 102;
			dpo.LoopName = "2310E";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "AMBULANCE PICK-UP LOCATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when billing for ambulance or non-emergency transportation services. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Information in Loop ID-2310 applies to the entire claim unless overridden on a service line by the presence of Loop ID-2420 with the same value in NM101.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 106;
			dpo.LoopName = "2310F";
			dpo.Name = "N3";
			dpo.Sequence = 1;
			dpo.Description = "AMBULANCE DROP-OFF LOCATION ADDRESS";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 107;
			dpo.LoopName = "2310F";
			dpo.Name = "N4";
			dpo.Sequence = 2;
			dpo.Description = "AMBULANCE DROP-OFF LOCATION CITY, STATE, ZIP CODE";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 105;
			dpo.LoopName = "2310F";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "AMBULANCE DROP-OFF LOCATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when billing for ambulance or non-emergency transportation services. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Information in Loop ID-2310 applies to the entire claim unless overridden on a service line by the presence of Loop ID-2420 with the same value in NM101.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 110;
			dpo.LoopName = "2320";
			dpo.Name = "AMT";
			dpo.Sequence = 2;
			dpo.Description = "COORDINATION OF BENEFITS (COB) PAYER PAID AMOUNT";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the claim has been adjudicated by the payer identified in Loop ID-2330B of this loop.
OR
Required when Loop ID-2010AC is present. In this case, the claim is a post payment recovery claim submitted by a subrogated Medicaid agency.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 111;
			dpo.LoopName = "2320";
			dpo.Name = "AMT";
			dpo.Sequence = 3;
			dpo.Description = "COORDINATION OF BENEFITS (COB) TOTAL NON-COVERED AMOUNT";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the destination payer's cost avoidance policy allows providers to bypass claim submission to the otherwise prior payer identified in Loop ID-2330B. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. When this segment is used, the amount reported in AMT02 must equal the total claim charge amount reported in CLM02. Neither the prior payer paid AMT, nor any CAS segments are used as this claim has not been adjudicated by this payer.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 112;
			dpo.LoopName = "2320";
			dpo.Name = "AMT";
			dpo.Sequence = 4;
			dpo.Description = "REMAINING PATIENT LIABILITY";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the Other Payer identified in Loop ID-2330B (of this iteration of Loop ID-2320) has adjudicated this claim and provided claim level information only.
OR
Required when the Other Payer identified in Loop ID-2330B (of this iteration of Loop ID-2320) has adjudicated this claim and the provider received a paper remittance advice and the provider does not have the ability to report line item information.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. In the judgment of the provider, this is the remaining amount to be paid after adjudication by the Other Payer identified in Loop ID-2330B of this iteration of Loop ID-2320. 
 
2. This segment is only used in provider submitted claims. It is not used in Payer-to-Payer Coordination of Benefits (COB). 
 
3. This segment is not used if the line level (Loop ID-2430) Remaining Patient Liability AMT segment is used for this Other Payer.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 109;
			dpo.LoopName = "2320";
			dpo.Name = "CAS";
			dpo.Sequence = 1;
			dpo.Description = "CLAIM LEVEL ADJUSTMENTS";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the claim has been adjudicated by the payer identified in this loop, and the claim has claim level adjustment information. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Submitters must use this CAS segment to report prior payers' claim level adjustments that cause the amount paid to differ from the amount originally charged. 
 
2. Only one Group Code is allowed per CAS. If it is necessary to send more than one Group Code at the claim level, repeat the CAS segment. 
 
3. Codes and associated amounts must come from either paper remittance advice or 835s (Electronic Remittance Advice) received on the claim. When the information originates from a paper remittance advice that does not use the standard Claim Adjustment Reason Codes, the paper values must be converted to standard Claim Adjustment Reason Codes.  
 
4. A single CAS segment contains six repetitions of the ""adjustment trio"" composed of adjustment reason code, adjustment amount, and adjustment quantity. These six adjustment trios are used to report up to six adjustments related to a particular Claim Adjustment Group Code (CAS01). The first non-zero adjustment is reported in the first adjustment trio (CAS02-CAS04). If there is a second non-zero adjustment, it is reported in the second adjustment trio (CAS05-CAS07), and so on through the sixth adjustment trio (CAS17-CAS19).";
			dpo.TR3_Example = "CAS*PR*1*7.93~";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 114;
			dpo.LoopName = "2320";
			dpo.Name = "MOA";
			dpo.Sequence = 6;
			dpo.Description = "OUTPATIENT ADJUDICATION INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when outpatient adjudication information is reported in the remittance advice
OR
Required when it is necessary to report remark codes.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 113;
			dpo.LoopName = "2320";
			dpo.Name = "OI";
			dpo.Sequence = 5;
			dpo.Description = "OTHER INSURANCE COVERAGE INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @"1. All information contained in the OI segment applies only to the payer identified in Loop ID-2330B in this iteration of Loop ID-2320.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 108;
			dpo.LoopName = "2320";
			dpo.Name = "SBR";
			dpo.Sequence = 0;
			dpo.Description = "OTHER SUBSCRIBER INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when other payers are known to potentially be involved in paying on this claim. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. All information contained in Loop ID-2320 applies only to the payer identified in Loop ID-2330B of this iteration of Loop ID-2320. It is specific only to that payer. If information for an additional payer is necessary, repeat Loop ID-2320 with its respective 2330 Loops.  
 
2. See Crosswalking COB Data Elements section for more information on handling COB in the 837.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 116;
			dpo.LoopName = "2330A";
			dpo.Name = "N3";
			dpo.Sequence = 1;
			dpo.Description = "OTHER SUBSCRIBER ADDRESS";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the information is available. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 117;
			dpo.LoopName = "2330A";
			dpo.Name = "N4";
			dpo.Sequence = 2;
			dpo.Description = "OTHER SUBSCRIBER CITY, STATE, ZIP CODE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the information is available. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 115;
			dpo.LoopName = "2330A";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "OTHER SUBSCRIBER NAME";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @"1. If the patient can be uniquely identified to the Other Payer indicated in this iteration of Loop ID-2320 by a unique Member Identification Number, then the patient is the subscriber or is considered to be the subscriber and is identified in this Other Subscriber's Name Loop ID-2330A.  
 
2. If the patient is a dependent of the subscriber for this other coverage and cannot be uniquely identified to the Other Payer indicated in this iteration of Loop ID-2320 by a unique Member Identification Number, then the subscriber for this other coverage is identified in this Other Subscriber's Name Loop ID-2330A. 
 
3. See Crosswalking COB Data Elements section for more information on handling COB in the 837.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 118;
			dpo.LoopName = "2330A";
			dpo.Name = "REF";
			dpo.Sequence = 3;
			dpo.Description = "OTHER SUBSCRIBER SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when an additional identification number to that provided in NM109 of this loop is necessary for the claim processor to identify the entity. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 122;
			dpo.LoopName = "2330B";
			dpo.Name = "DTP";
			dpo.Sequence = 3;
			dpo.Description = "CLAIM CHECK OR REMITTANCE DATE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the payer identified in this loop has previously adjudicated the claim and Loop ID-2430, Line Check or Remittance Date, is not used. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 120;
			dpo.LoopName = "2330B";
			dpo.Name = "N3";
			dpo.Sequence = 1;
			dpo.Description = "OTHER PAYER ADDRESS";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the payer address is available and the submitter intends for the claim to be printed on paper at the next EDI location (for example, a clearinghouse). If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 121;
			dpo.LoopName = "2330B";
			dpo.Name = "N4";
			dpo.Sequence = 2;
			dpo.Description = "OTHER PAYER CITY, STATE, ZIP CODE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the payer address is available and the submitter intends for the claim to be printed on paper at the next EDI location (for example, a clearinghouse). If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 119;
			dpo.LoopName = "2330B";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "OTHER PAYER NAME";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "1. See Crosswalking COB Data Elements section for more information on handling COB in the 837.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 123;
			dpo.LoopName = "2330B";
			dpo.Name = "REF";
			dpo.Sequence = 4;
			dpo.Description = "OTHER PAYER SECONDARY IDENTIFIER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated implementation date for the HIPAA National Plan Identifier when an additional identification number to that provided in the NM109 of this loop is necessary for the claim processor to identify the entity. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 124;
			dpo.LoopName = "2330B";
			dpo.Name = "REF";
			dpo.Sequence = 5;
			dpo.Description = "OTHER PAYER PRIOR AUTHORIZATION NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the payer identified in this loop has assigned a prior authorization number to this claim.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 125;
			dpo.LoopName = "2330B";
			dpo.Name = "REF";
			dpo.Sequence = 6;
			dpo.Description = "OTHER PAYER REFERRAL NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the payer identified in this loop has assigned a referral number to this claim.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 126;
			dpo.LoopName = "2330B";
			dpo.Name = "REF";
			dpo.Sequence = 7;
			dpo.Description = "OTHER PAYER CLAIM ADJUSTMENT INDICATOR";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the claim is being sent in the payer-to-payer COB model, 
AND
the destination payer is secondary to the payer identified in this Loop ID-2330B, 
AND
the payer identified in this Loop ID-2330B has re-adjudicated the claim.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 127;
			dpo.LoopName = "2330B";
			dpo.Name = "REF";
			dpo.Sequence = 8;
			dpo.Description = "OTHER PAYER CLAIM CONTROL NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when it is necessary to identify the Other Payer's Claim Control Number in a payer-to-payer COB situation.
OR
Required when the Other Payer's Claim Control Number is available.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 128;
			dpo.LoopName = "2330C";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "OTHER PAYER REFERRING PROVIDER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated implementation of the HIPAA National Provider Identifier (NPI) rule when the provider in the corresponding Loop ID-2310 is sent and one or more additional payer-specific provider identification numbers are required by this non-destination payer (Loop ID-2330B) to identify the provider.
OR
Required after the mandated implementation of the NPI rule for providers who are not Health Care Providers when the provider is sent in the corresponding Loop ID-2310 and one or more additional payer-specific provider identification numbers are required by this non-destination payer (Loop ID-2330B) to identify the provider.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "1. See Crosswalking COB Data Elements section for more information on handling COB in the 837.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 129;
			dpo.LoopName = "2330C";
			dpo.Name = "REF";
			dpo.Sequence = 1;
			dpo.Description = "OTHER PAYER REFERRING PROVIDER SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @"1. Non-destination (COB) payer's provider identification number(s). 
 
2. See Crosswalking COB Data Elements section for more information on handling COB in the 837.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 130;
			dpo.LoopName = "2330D";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "OTHER PAYER RENDERING PROVIDER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated implementation of the HIPAA National Provider Identifier (NPI) rule when the provider in the corresponding Loop ID-2310 is sent and one or more additional payer-specific provider identification numbers are required by this non-destination payer (Loop ID-2330B) to identify the provider.
OR
Required after the mandated implementation of the NPI rule for providers who are not Health Care Providers when the provider is sent in the corresponding Loop ID-2310 and one or more additional payer-specific provider identification numbers are required by this non-destination payer (Loop ID-2330B) to identify the provider.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "1. See Crosswalking COB Data Elements section for more information on handling COB in the 837.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 131;
			dpo.LoopName = "2330D";
			dpo.Name = "REF";
			dpo.Sequence = 1;
			dpo.Description = "OTHER PAYER RENDERING PROVIDER SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "1. See Crosswalking COB Data Elements section for more information on handling COB in the 837.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 132;
			dpo.LoopName = "2330E";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "OTHER PAYER SERVICE FACILITY LOCATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated implementation of the HIPAA National Provider Identifier (NPI) rule when the provider in the corresponding Loop ID-2310 is sent and one or more additional payer-specific provider identification numbers are required by this non-destination payer (Loop ID-2330B) to identify the provider.
OR
Required after the mandated implementation of the NPI rule for providers who are not Health Care Providers when the provider is sent in the corresponding Loop ID-2310 and one or more additional payer-specific provider identification numbers are required by this non-destination payer (Loop ID-2330B) to identify the provider.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "1. See Crosswalking COB Data Elements section for more information on handling COB in the 837.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 133;
			dpo.LoopName = "2330E";
			dpo.Name = "REF";
			dpo.Sequence = 1;
			dpo.Description = "OTHER PAYER SERVICE FACILITY LOCATION SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 3;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 134;
			dpo.LoopName = "2330F";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "OTHER PAYER SUPERVISING PROVIDER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated implementation of the HIPAA National Provider Identifier (NPI) rule when the provider in the corresponding Loop ID-2310 is sent and one or more additional payer-specific provider identification numbers are required by this non-destination payer (Loop ID-2330B) to identify the provider.
OR
Required after the mandated implementation of the NPI rule for providers who are not Health Care Providers when the provider is sent in the corresponding Loop ID-2310 and one or more additional payer-specific provider identification numbers are required by this non-destination payer (Loop ID-2330B) to identify the provider.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "1. See Crosswalking COB Data Elements section for more information on handling COB in the 837.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 135;
			dpo.LoopName = "2330F";
			dpo.Name = "REF";
			dpo.Sequence = 1;
			dpo.Description = "OTHER PAYER SUPERVISING PROVIDER SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 3;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 136;
			dpo.LoopName = "2330G";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "OTHER PAYER BILLING PROVIDER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated implementation of the HIPAA National Provider Identifier (NPI) rule when the provider in the corresponding Loop ID-2310 is sent and one or more additional payer-specific provider identification numbers are required by this non-destination payer (Loop ID-2330B) to identify the provider.
OR
Required after the mandated implementation of the NPI rule for providers who are not Health Care Providers when the provider is sent in the corresponding Loop ID-2310 and one or more additional payer-specific provider identification numbers are required by this non-destination payer (Loop ID-2330B) to identify the provider.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "1. See Crosswalking COB Data Elements section for more information on handling COB in the 837.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 137;
			dpo.LoopName = "2330G";
			dpo.Name = "REF";
			dpo.Sequence = 1;
			dpo.Description = "OTHER PAYER BILLING PROVIDER SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "1. See Crosswalking COB Data Elements section for more information on handling COB in the 837.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 171;
			dpo.LoopName = "2400";
			dpo.Name = "AMT";
			dpo.Sequence = 33;
			dpo.Description = "SALES TAX AMOUNT";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when sales tax applies to the service line and the submitter is required to report that information to the receiver. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @". When reporting the Sales Tax Amount (AMT02), the amount reported in the Line Item Charge Amount (SV102) for this service line must include the amount reported in the Sales Tax Amount.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 172;
			dpo.LoopName = "2400";
			dpo.Name = "AMT";
			dpo.Sequence = 34;
			dpo.Description = "POSTAGE CLAIMED AMOUNT";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when service line charge (SV102) includes postage amount claimed in this service line. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. When reporting the Postage Claimed Amount (AMT02), the amount reported in the Line Item Charge Amount (SV102) for this service line must include the amount reported in the Postage Claimed Amount.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 161;
			dpo.LoopName = "2400";
			dpo.Name = "CN1";
			dpo.Sequence = 23;
			dpo.Description = "CONTRACT INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the submitter is contractually obligated to supply this information on post-adjudicated claims. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. The developers of this implementation guide note that the CN1 segment is for use only for post-adjudicated claims, which do not meet the definition of a health care claim under HIPAA. Consequently, at the time of this writing, the CN1 segment is for non-HIPAA use only.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 143;
			dpo.LoopName = "2400";
			dpo.Name = "CR1";
			dpo.Sequence = 5;
			dpo.Description = "AMBULANCE TRANSPORT INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required on ambulance transport services when the information applicable to any one of the segment's elements is different than the information reported in the CR1 at the claim level (Loop ID-2300). If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 144;
			dpo.LoopName = "2400";
			dpo.Name = "CR3";
			dpo.Sequence = 6;
			dpo.Description = "DURABLE MEDICAL EQUIPMENT CERTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when a Durable Medical Equipment Regional Carrier Certificate of Medical Necessity (DMERC CMN) or a DMERC Information Form (DIF) or Oxygen Therapy Certification is included on this service line.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 145;
			dpo.LoopName = "2400";
			dpo.Name = "CRC";
			dpo.Sequence = 7;
			dpo.Description = "AMBULANCE CERTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required on ambulance transport services when the information applicable to any one of the segment's elements is different than the information reported in the Ambulance Certification CRC at the claim level (Loop ID-2300). If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. The maximum number of CRC segments which can occur per Loop ID-2400 is 3. Submitters are free to mix and match the three types of service line level CRC segments shown in this implementation guide to meet their billing or reporting needs but no more than a total of 3 CRC segments per Loop ID-2400 are allowed.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 146;
			dpo.LoopName = "2400";
			dpo.Name = "CRC";
			dpo.Sequence = 8;
			dpo.Description = "HOSPICE EMPLOYEE INDICATOR";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required on all Medicare claims involving physician services to hospice patients. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. The maximum number of CRC segments which can occur per Loop ID-2400 is 3. Submitters are free to mix and match the three types of service line level CRC segments shown in this implementation guide to meet their billing or reporting needs but no more than a total of 3 CRC segments per Loop ID-2400 are allowed. 
 
2. The example shows the method used to indicate whether the rendering provider is an employee of the hospice.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 147;
			dpo.LoopName = "2400";
			dpo.Name = "CRC";
			dpo.Sequence = 9;
			dpo.Description = "CONDITION INDICATOR/DURABLE MEDICAL EQUIPMENT";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when a Durable Medical Equipment Regional Carrier Certificate of Medical Necessity (DMERC CMN) or a DMERC Information Form (DIF), or Oxygen Therapy Certification is included on this service line and the information is necessary for adjudication.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. The maximum number of CRC segments which can occur per Loop ID-2400 is 3. Submitters are free to mix and match the three types of service line level CRC segments shown in this implementation guide to meet their billing or reporting needs but no more than a total of 3 CRC segments per Loop ID-2400 are allowed. 
 
2. The first example shows a case where an item billed was not a replacement item.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 148;
			dpo.LoopName = "2400";
			dpo.Name = "DTP";
			dpo.Sequence = 10;
			dpo.Description = "DATE - SERVICE DATE";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @"1. In cases where a drug is being billed on a service line, date range may be used to indicate drug duration for which the drug supply will be used by the patient. The difference in dates, including both the begin and end dates, are the days supply of the drug. Example: 20000101 - 20000107 (1/1/00 to 1/7/00) is used for a 7 day supply where the first day of the drug used by the patient is 1/1/00. In the event a drug is administered on less than a daily basis (for example, every other day) the date range would include the entire period during which the drug was supplied, including the last day the drug was used. Example: 20000101 - 20000108 (1/1/00 to 1/8/00) is used for an 8 days supply where the prescription is written for Q48 (every 48 hours), four doses of the drug are dispensed and the first dose is used on 1/1/00.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 149;
			dpo.LoopName = "2400";
			dpo.Name = "DTP";
			dpo.Sequence = 11;
			dpo.Description = "DATE - PRESCRIPTION DATE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when a drug is billed for this line and a prescription was written (or otherwise communicated by the prescriber if not written). If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 150;
			dpo.LoopName = "2400";
			dpo.Name = "DTP";
			dpo.Sequence = 12;
			dpo.Description = "DATE - CERTIFICATION REVISION/RECERTIFICATION DATE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when CR301 (DMERC Certification) = ""R"" or ""S"". If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 151;
			dpo.LoopName = "2400";
			dpo.Name = "DTP";
			dpo.Sequence = 13;
			dpo.Description = "DATE - BEGIN THERAPY DATE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when a Durable Medical Equipment Regional Carrier Certificate of Medical Necessity (DMERC CMN) or DMERC Information Form (DIF), or Oxygen Therapy Certification is included on this service line. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 152;
			dpo.LoopName = "2400";
			dpo.Name = "DTP";
			dpo.Sequence = 14;
			dpo.Description = "DATE - LAST CERTIFICATION DATE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when a Durable Medical Equipment Regional Carrier Certificate of Medical Necessity (DMERC CMN), DMERC Information Form (DIF), or Oxygen Therapy Certification is included on this service line. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. This is the date the ordering physician signed the CMN or Oxygen Therapy Certification, or the date the supplier signed the DMERC Information Form (DIF).";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 153;
			dpo.LoopName = "2400";
			dpo.Name = "DTP";
			dpo.Sequence = 15;
			dpo.Description = "DATE - LAST SEEN DATE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when a claim involves physician services for routine foot care; and is different than the date listed at the claim level and is known to impact the payer's adjudication process. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 154;
			dpo.LoopName = "2400";
			dpo.Name = "DTP";
			dpo.Sequence = 16;
			dpo.Description = "DATE - TEST DATE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required on initial EPO claims service lines for dialysis patients when test results are being billed or reported. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 155;
			dpo.LoopName = "2400";
			dpo.Name = "DTP";
			dpo.Sequence = 17;
			dpo.Description = "DATE - SHIPPED DATE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when billing or reporting shipped products. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 156;
			dpo.LoopName = "2400";
			dpo.Name = "DTP";
			dpo.Sequence = 18;
			dpo.Description = "DATE - LAST X-RAY DATE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when claim involves spinal manipulation and an x-ray was taken and is different than information at the claim level (Loop ID-2300). If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 157;
			dpo.LoopName = "2400";
			dpo.Name = "DTP";
			dpo.Sequence = 19;
			dpo.Description = "DATE - INITIAL TREATMENT DATE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the Initial Treatment Date is known to impact adjudication for claims involving spinal manipulation, physcial therapy, occupational therapy, or speech language pathology and when different from what is reported at the claim level. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 177;
			dpo.LoopName = "2400";
			dpo.Name = "HCP";
			dpo.Sequence = 39;
			dpo.Description = "LINE PRICING/REPRICING INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when this information is deemed necessary by the repricer. The segment is not completed by providers. The information is completed by repricers only. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. This information is specific to the destination payer reported in Loop ID-2010BB. 
 
2. For capitated encounters, pricing or repricing information usually is not applicable and is provided to qualify other information within the claim.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 173;
			dpo.LoopName = "2400";
			dpo.Name = "K3";
			dpo.Sequence = 35;
			dpo.Description = "FILE INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when ALL of the following conditions are met:
• A regulatory agency concludes it must use the K3 to meet an emergency
  legislative requirement;
• The administering regulatory agency or other state organization has
  completed each one of the following steps:
    contacted the X12N workgroup, 
    requested a review of the K3 data requirement to ensure there is not
      an existing method within the implementation guide to meet this
      requirement
• X12N determines that there is no method to meet the requirement.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. At the time of publication of this implementation, K3 segments have no specific use. The K3 segment is expected to be used only when necessary to meet the unexpected data requirement of a legislative authority. Before this segment can be used : 
- The X12N Health Care Claim workgroup must conclude there is no other available option in the implementation guide to meet the emergency legislative requirement.
- The requestor must submit a proposal for approval accompanied by the relevant business documentation to the X12N Health Care Claim workgroup chairs and receive approval for the request.
Upon review of the request, X12N will issue an approval or denial decision to the requesting entity. Approved usage(s) of the K3 segment will be reviewed by the X12N Health Care Claim workgroup to develop a permanent change to include the business case in future transaction implementations. 
 
2. Only when all of the requirements above have been met, may the regulatory agency require the temporary use of the K3 segment. 
 
3. X12N will submit the necessary data maintenance and refer the request to the appropriate data content committee(s).";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 138;
			dpo.LoopName = "2400";
			dpo.Name = "LX";
			dpo.Sequence = 0;
			dpo.Description = "SERVICE LINE NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @"1. The LX functions as a line counter. 
 
2. The Service Line LX segment must begin with one and is incremented by one for each additional service line of a claim. 
 
3. LX01 is used to indicate bundling in SVD06 in the Line Item Adjudication loop. See Section 1.4.1.2 for more information on bundling and unbundling.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 160;
			dpo.LoopName = "2400";
			dpo.Name = "MEA";
			dpo.Sequence = 22;
			dpo.Description = "TEST RESULT";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required on Dialysis related service lines for ESRD. Use R1, R2, R3, or R4 to qualify the Hemoglobin, Hematocrit, Epoetin Starting Dosage, and Creatinine test results. 
OR
Required on DMERC service lines to report the Patient's Height from the Certificate of Medical Necessity (CMN). Use HT qualifier.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 174;
			dpo.LoopName = "2400";
			dpo.Name = "NTE";
			dpo.Sequence = 36;
			dpo.Description = "LINE NOTE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when in the judgment of the provider, the information is needed to substantiate the medical treatment and is not supported elsewhere within the claim data set.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Use SV101-7 to describe non-specific procedure codes. Do not use this NTE Segment to describe a non-specific procedure code. If an NDC code is reported in Loop 2410, do not use this segment for a description of the procedure code. The NDC in loop 2410 will provide the description.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 175;
			dpo.LoopName = "2400";
			dpo.Name = "NTE";
			dpo.Sequence = 37;
			dpo.Description = "THIRD PARTY ORGANIZATION NOTES";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the TPO/repricer needs to forward additional information to the payer. This segment is not completed by providers. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 176;
			dpo.LoopName = "2400";
			dpo.Name = "PS1";
			dpo.Sequence = 38;
			dpo.Description = "PURCHASED SERVICE INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required on non-vision service lines when adjudication is known to be impacted by the charge amount for services purchased from another source.
OR
Required on vision service lines when adjudication is known to be impacted by the acquisition cost of lenses.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 141;
			dpo.LoopName = "2400";
			dpo.Name = "PWK";
			dpo.Sequence = 3;
			dpo.Description = "LINE SUPPLEMENTAL INFORMATION";
			dpo.RepeatValue = 10;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when there is a paper attachment following this claim.
OR
Required when attachments are sent electronically (PWK02 = EL) but are transmitted in another functional group (for example, 275) rather than by paper. PWK06 is then used to identify the attached electronic documentation. The number in PWK06 is carried in the TRN of the electronic attachment.
OR
Required when the provider deems it necessary to identify additional information that is being held at the provider's office and is available upon request by the payer (or appropriate entity), but the information is not being submitted with the claim. Use the value of ""AA"" in PWK02 to convey this specific use of the PWK segment.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 142;
			dpo.LoopName = "2400";
			dpo.Name = "PWK";
			dpo.Sequence = 4;
			dpo.Description = "DURABLE MEDICAL EQUIPMENT CERTIFICATE OF MEDICAL NECESSITY INDICATOR";
			dpo.RepeatValue = 10;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required on claims that include a Durable Medical Equipment Regional Carrier (DMERC) Certificate of Medical Necessity (CMN). If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 158;
			dpo.LoopName = "2400";
			dpo.Name = "QTY";
			dpo.Sequence = 20;
			dpo.Description = "AMBULANCE PATIENT COUNT";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when more than one patient is transported in the same vehicle for Ambulance or non-emergency transportation services. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. The QTY02 is the only place to report the number of patients when there are multiple patients transported.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 159;
			dpo.LoopName = "2400";
			dpo.Name = "QTY";
			dpo.Sequence = 21;
			dpo.Description = "OBSTETRIC ANESTHESIA ADDITIONAL UNITS";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required in conjunction with anesthesia for obstetric services when the anesthesia provider chooses to report additional complexity beyond the normal services reflected by the procedure base units and anesthesia time.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 162;
			dpo.LoopName = "2400";
			dpo.Name = "REF";
			dpo.Sequence = 24;
			dpo.Description = "REPRICED LINE ITEM REFERENCE NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when a repricing (pricing) organization needs to have an identifying number on the service line in their submission to their payer organization. This segment is not completed by providers. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 163;
			dpo.LoopName = "2400";
			dpo.Name = "REF";
			dpo.Sequence = 25;
			dpo.Description = "ADJUSTED REPRICED LINE ITEM REFERENCE NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when a repricing (pricing) organization needs to have an identifying number on an adjusted service line in their submission to their payer organization. This segment is not completed by providers. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 164;
			dpo.LoopName = "2400";
			dpo.Name = "REF";
			dpo.Sequence = 26;
			dpo.Description = "PRIOR AUTHORIZATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when service line involved a prior authorization number that is different than the number reported at the claim level (Loop ID-2300).
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. When it is necessary to report one or more non-destination payer Prior Authorization Numbers, the composite data element in REF04 is used to identify the payer which assigned this number.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 165;
			dpo.LoopName = "2400";
			dpo.Name = "REF";
			dpo.Sequence = 27;
			dpo.Description = "LINE ITEM CONTROL NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the submitter needs a line item control number for subsequent communications to or from the payer. If not required by this implementation guide, do not send";
			dpo.TR3_Notes = @"1. The line item control number must be unique within a patient control number (CLM01). Payers are required to return this number in the remittance advice transaction (835) if the provider sends it to them in the 837 and adjudication is based upon line item detail regardless of whether bundling or unbundling has occurred. 
 
2. Submitters are STRONGLY encouraged to routinely send a unique line item control number on all service lines, particularly if the submitter automatically posts their remittance advice. Submitting a unique line item control number allows the capability to automatically post by service line.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 166;
			dpo.LoopName = "2400";
			dpo.Name = "REF";
			dpo.Sequence = 28;
			dpo.Description = "MAMMOGRAPHY CERTIFICATION NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when mammography services are rendered by a certified mammography provider and the mammography certification number is different than that sent in Loop ID-2300. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 167;
			dpo.LoopName = "2400";
			dpo.Name = "REF";
			dpo.Sequence = 29;
			dpo.Description = "CLINICAL LABORATORY IMPROVEMENT AMENDMENT (CLIA) NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required for all CLIA certified facilities performing CLIA covered laboratory services and the number is different than the CLIA number reported at the claim level (Loop ID-2300). If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 168;
			dpo.LoopName = "2400";
			dpo.Name = "REF";
			dpo.Sequence = 30;
			dpo.Description = "REFERRING CLINICAL LABORATORY IMPROVEMENT AMENDMENT (CLIA) FACILITY IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required for claims for any laboratory that referred tests to another laboratory covered by the CLIA Act that is billed on this line. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 169;
			dpo.LoopName = "2400";
			dpo.Name = "REF";
			dpo.Sequence = 31;
			dpo.Description = "IMMUNIZATION BATCH NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when mandated by state or federal law or regulations to report an Immunization Batch Number. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 170;
			dpo.LoopName = "2400";
			dpo.Name = "REF";
			dpo.Sequence = 32;
			dpo.Description = "REFERRAL NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when this service line involved a referral number that is different than the number reported at the claim level (Loop-ID 2300).
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. When it is necessary to report one or more non-destination payer Referral Numbers, the composite data element in REF04 is used to identify the payer which assigned this referral number.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 139;
			dpo.LoopName = "2400";
			dpo.Name = "SV1";
			dpo.Sequence = 1;
			dpo.Description = "PROFESSIONAL SERVICE";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 140;
			dpo.LoopName = "2400";
			dpo.Name = "SV5";
			dpo.Sequence = 2;
			dpo.Description = "DURABLE MEDICAL EQUIPMENT SERVICE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when necessary to report both the rental and purchase price information for durable medical equipment. This is not used for claims where the provider is reporting only the rental price or only the purchase price. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 179;
			dpo.LoopName = "2410";
			dpo.Name = "CTP";
			dpo.Sequence = 1;
			dpo.Description = "DRUG QUANTITY";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 178;
			dpo.LoopName = "2410";
			dpo.Name = "LIN";
			dpo.Sequence = 0;
			dpo.Description = "DRUG IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when government regulation mandates that prescribed drugs and biologics are reported with NDC numbers.
OR
Required when the provider or submitter chooses to report NDC numbers to enhance the claim reporting or adjudication processes.
OR
Required when an HHS approved pilot project specifies reporting of Universal Product Number (UPN) by parties registered in the pilot and their trading partners.
OR
Required when government regulation mandates that medical and surgical supplies are reported with UPN's.

If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Drugs and biologics reported in this segment are a further specification of service(s) described in the SV1 segment of this Service Line Loop ID-2400.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 180;
			dpo.LoopName = "2410";
			dpo.Name = "REF";
			dpo.Sequence = 2;
			dpo.Description = "PRESCRIPTION OR COMPOUND DRUG ASSOCIATION NUMBER";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when dispensing of the drug has been done with an assigned prescription number.
OR
Required when the provided medication involves the compounding of two or more drugs being reported and there is no prescription number.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. In cases where a compound drug is being billed, the components of the compound will all have the same prescription number. Payers receiving the claim can relate all the components by matching the prescription number. 
 
2. For cases where the drug is provided without a prescription (for example, from a physician's office), the value provided in this segment is a ""link sequence number"". The link sequence number is a provider assigned number that is unique to this claim. Its purpose is to enable the receiver to piece together the components of the compound.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 181;
			dpo.LoopName = "2420A";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "RENDERING PROVIDER NAME";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the Rendering Provider NM1 information is different than that carried in the Loop ID-2310B Rendering Provider.
OR
Required when Loop ID-2310B Rendering Provider is not used AND this particular line item has different Rendering Provider information than that which is carried in Loop ID-2010AA Billing Provider.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Used for all types of rendering providers including laboratories. The Rendering Provider is the person or company (laboratory or other facility) who rendered the care. In the case where a substitute provider (locum tenens) was used, enter that provider's information here.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 182;
			dpo.LoopName = "2420A";
			dpo.Name = "PRV";
			dpo.Sequence = 1;
			dpo.Description = "RENDERING PROVIDER SPECIALTY INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when adjudication is known to be impacted by the provider taxonomy code. If not required by this implementation guide, do not send";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 183;
			dpo.LoopName = "2420A";
			dpo.Name = "REF";
			dpo.Sequence = 2;
			dpo.Description = "RENDERING PROVIDER SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated HIPAA National Provider Identifier (NPI) implementation date when an identification number other than the NPI is necessary for the receiver to identify the provider.
OR
Required on or after the mandated NPI Implementation Date when NM109 in this loop is not used and an identification number other than the NPI is necessary for the receiver to identify the provider.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. When it is necessary to report one or more non-destination payer Secondary Identifiers, the composite data element in REF04 is used to identify the payer who assigned this identifier.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 184;
			dpo.LoopName = "2420B";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "PURCHASED SERVICE PROVIDER NAME";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the service reported in this line item is a purchased service. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Purchased services are situations where, for example, a physician purchases a diagnostic exam from an outside entity. Purchased services do not include substitute (locum tenens) provider situations.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 185;
			dpo.LoopName = "2420B";
			dpo.Name = "REF";
			dpo.Sequence = 1;
			dpo.Description = "PURCHASED SERVICE PROVIDER SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated HIPAA National Provider Identifier (NPI) implementation date when an identification number other than the NPI is necessary for the receiver to identify the provider.
OR
Required on or after the mandated NPI Implementation Date when NM109 in this loop is not used and an identification number other than the NPI is necessary for the receiver to identify the provider.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. When it is necessary to report one or more non-destination payer Secondary Identifiers, the composite data element in REF04 is used to identify the payer who assigned this identifier.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 187;
			dpo.LoopName = "2420C";
			dpo.Name = "N3";
			dpo.Sequence = 1;
			dpo.Description = "SERVICE FACILITY LOCATION ADDRESS";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @"1. If service facility location is in an area where there are no street addresses, enter a description of where the service was rendered (for example, ""crossroad of State Road 34 and 45"" or ""Exit near Mile marker 265 on Interstate 80"".)";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 188;
			dpo.LoopName = "2420C";
			dpo.Name = "N4";
			dpo.Sequence = 2;
			dpo.Description = "SERVICE FACILITY LOCATION CITY, STATE, ZIP CODE";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 186;
			dpo.LoopName = "2420C";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "SERVICE FACILITY LOCATION NAME";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the location of health care service for this service line is different than that carried in Loop ID-2010AA Billing Provider or Loop ID-2310C Service Facility Location. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. When an organization health care provider's NPI is provided to identify the Service Location, the organization health care provider must be external to the entity identified as the Billing Provider (for example, reference lab). It is not permissible to report an organization health care provider NPI as the Service Location if the entity being identified is a component (for example, subpart) of the Billing Provider. In that case, the subpart must be the Billing Provider. 
 
2. The purpose of this loop is to identify specifically where the service was rendered. When reporting ambulance services, do not use this loop. Use the pick-up (2420G) and drop-off location (2420H) loops elsewhere in this transaction.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 189;
			dpo.LoopName = "2420C";
			dpo.Name = "REF";
			dpo.Sequence = 3;
			dpo.Description = "SERVICE FACILITY LOCATION SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated HIPAA National Provider Identifier (NPI) implementation date when an identification number other than the NPI is necessary for the receiver to identify the provider.
OR
Required on or after the mandated NPI implementation date when the entity is not a Health Care provider (a.k.a. an atypical provider), and an identifier is necessary for the claims processor to identify the entity.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. When it is necessary to report one or more non-destination payer Secondary Identifiers, the composite data element in REF04 is used to identify the payer who assigned this identifier.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 190;
			dpo.LoopName = "2420D";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "SUPERVISING PROVIDER NAME";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the rendering provider is supervised by a physician and the supervising physician is different than that listed at the claim level for this service line. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 191;
			dpo.LoopName = "2420D";
			dpo.Name = "REF";
			dpo.Sequence = 1;
			dpo.Description = "SUPERVISING PROVIDER SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated HIPAA National Provider Identifier (NPI) implementation date when an identification number other than the NPI is necessary for the receiver to identify the provider.
OR
Required on or after the mandated NPI Implementation Date when NM109 in this loop is not used and an identification number other than the NPI is necessary for the receiver to identify the provider.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. When it is necessary to report one or more non-destination payer Secondary Identifiers, the composite data element in REF04 is used to identify the payer who assigned this identifier.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 193;
			dpo.LoopName = "2420E";
			dpo.Name = "N3";
			dpo.Sequence = 1;
			dpo.Description = "ORDERING PROVIDER ADDRESS";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when a Durable Medical Equipment Regional Carrier Certificate of Medical Necessity (DMERC CMN) or DMERC Information Form (DIF), or Oxygen Therapy Certification is included on this service line. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 194;
			dpo.LoopName = "2420E";
			dpo.Name = "N4";
			dpo.Sequence = 2;
			dpo.Description = "ORDERING PROVIDER CITY, STATE, ZIP CODE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when a Durable Medical Equipment Regional Carrier Certificate of Medical Necessity (DMERC CMN) or DMERC Information Form (DIF), or Oxygen Therapy Certification is included on this service line. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 192;
			dpo.LoopName = "2420E";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "ORDERING PROVIDER NAME";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the service or supply was ordered by a provider who is different than the rendering provider for this service line.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 196;
			dpo.LoopName = "2420E";
			dpo.Name = "PER";
			dpo.Sequence = 4;
			dpo.Description = "ORDERING PROVIDER CONTACT INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when a Durable Medical Equipment Regional Carrier Certificate of Medical Necessity (DMERC CMN) or DMERC Information Form (DIF), or Oxygen Therapy Certification is included on this service line. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. When the communication number represents a telephone number in the United States and other countries using the North American Dialing Plan (for voice, data, fax, etc.), the communication number must always include the area code and phone number using the format AAABBBCCCC where AAA is the area code, BBB is the telephone number prefix, and CCCC is the telephone number. Therefore, the following telephone number (555) 555-1234 would be represented as 5555551234. Do not submit long distance access numbers, such as ""1"", in the telephone number. Telephone extensions, when applicable, must be submitted in the next element immediately following the telephone number. When submitting telephone extensions, only submit the numeric extension. Do not include data that indicates an extension, such as ""ext"" or ""x-"".";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 195;
			dpo.LoopName = "2420E";
			dpo.Name = "REF";
			dpo.Sequence = 3;
			dpo.Description = "ORDERING PROVIDER SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated HIPAA National Provider Identifier (NPI) implementation date when an identification number other than the NPI is necessary for the receiver to identify the provider.
OR
Required on or after the mandated NPI Implementation Date when NM109 in this loop is not used and an identification number other than the NPI is necessary for the receiver to identify the provider.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. When it is necessary to report one or more non-destination payer Secondary Identifiers, the composite data element in REF04 is used to identify the payer who assigned this identifier.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 197;
			dpo.LoopName = "2420F";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "REFERRING PROVIDER NAME";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when this service line involves a referral and the referring provider differs from that reported at the claim level (loop 2310A). If not required by this implementation guide, may be provided at the sender's discretion, but cannot be required by the receiver.";
			dpo.TR3_Notes = @"1. When reporting the provider who ordered services such as diagnostic and lab, use Loop ID-2310A at the claim level. For ordered services such as Durable Medical Equipment, use Loop ID-2420E at the line level. 
 
2. When there is only one referral on the claim, use code ""DN - Referring Provider"". When more than one referral exists and there is a requirement to report the additional referral, use code DN in the first iteration of this loop to indicate the referral received by the rendering provider on this claim. Use code ""P3 - Primary Care Provider"" in the second iteration of the loop to indicate the initial referral from the primary care provider or whatever provider wrote the initial referral for this patient's episode of care being billed/reported in this transaction.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 198;
			dpo.LoopName = "2420F";
			dpo.Name = "REF";
			dpo.Sequence = 1;
			dpo.Description = "REFERRING PROVIDER SECONDARY IDENTIFICATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required prior to the mandated HIPAA National Provider Identifier (NPI) implementation date when an identification number other than the NPI is necessary for the receiver to identify the provider.
OR
Required on or after the mandated NPI Implementation Date when NM109 in this loop is not used and an identification number other than the NPI is necessary for the receiver to identify the provider.
If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. When it is necessary to report one or more non-destination payer Secondary Identifiers, the composite data element in REF04 is used to identify the payer who assigned this identifier.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 200;
			dpo.LoopName = "2420G";
			dpo.Name = "N3";
			dpo.Sequence = 1;
			dpo.Description = "AMBULANCE PICK-UP LOCATION ADDRESS";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @"1. If the ambulance pickup location is in an area where there are no street addresses, enter a description of where the service was rendered (for example, ""crossroad of State Road 34 and 45"" or ""Exit near Mile marker 265 on Interstate 80"".)";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 201;
			dpo.LoopName = "2420G";
			dpo.Name = "N4";
			dpo.Sequence = 2;
			dpo.Description = "AMBULANCE PICK-UP LOCATION CITY, STATE, ZIP CODE";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 199;
			dpo.LoopName = "2420G";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "AMBULANCE PICK-UP LOCATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the ambulance pick-up location for this service line is different than the ambulance pick-up location provided in Loop ID-2310E. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 203;
			dpo.LoopName = "2420H";
			dpo.Name = "N3";
			dpo.Sequence = 1;
			dpo.Description = "AMBULANCE DROP-OFF LOCATION ADDRESS";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @". If the ambulance drop-off location is in an area where there are no street addresses, enter a description of where the service was rendered (for example, ""crossroad of State Road 34 and 45"" or ""Exit near Mile marker 265 on Interstate 80"".)";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 204;
			dpo.LoopName = "2420H";
			dpo.Name = "N4";
			dpo.Sequence = 2;
			dpo.Description = "AMBULANCE DROP-OFF LOCATION CITY, STATE, ZIP CODE";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 202;
			dpo.LoopName = "2420H";
			dpo.Name = "NM1";
			dpo.Sequence = 0;
			dpo.Description = "AMBULANCE DROP-OFF LOCATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"uired when the ambulance drop-off location for this service line is different than the ambulance drop-off location provided in Loop ID-2310F. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 208;
			dpo.LoopName = "2430";
			dpo.Name = "AMT";
			dpo.Sequence = 3;
			dpo.Description = "REMAINING PATIENT LIABILITY";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the Other Payer referenced in SVD01 of this iteration of Loop ID-2430 has adjudicated this claim, provided line level information, and the provider has the ability to report line item information. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. In the judgment of the provider, this is the remaining amount to be paid after adjudication by the Other Payer referenced in SVD01 of this iteration of Loop ID-2430. 
 
2. This segment is only used in provider submitted claims. It is not used in Payer-to-Payer Coordination of Benefits (COB). 
 
3. This segment is not used if the claim level (Loop ID-2320) Remaining Patient Liability AMT segment is used for this Other Payer.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 206;
			dpo.LoopName = "2430";
			dpo.Name = "CAS";
			dpo.Sequence = 1;
			dpo.Description = "LINE ADJUSTMENT";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the payer identified in Loop 2330B made line level adjustments which caused the amount paid to differ from the amount originally charged. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. A single CAS segment contains six repetitions of the ""adjustment trio"" composed of adjustment reason code, adjustment amount, and adjustment quantity. These six adjustment trios are used to report up to six adjustments related to a particular Claim Adjustment Group Code (CAS01). The first non-zero adjustment is reported in the first adjustment trio (CAS02-CAS04). If there is a second non-zero adjustment, it is reported in the second adjustment trio (CAS05-CAS07), and so on through the sixth adjustment trio (CAS17-CAS19).";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 207;
			dpo.LoopName = "2430";
			dpo.Name = "DTP";
			dpo.Sequence = 2;
			dpo.Description = "LINE CHECK OR REMITTANCE DATE";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 205;
			dpo.LoopName = "2430";
			dpo.Name = "SVD";
			dpo.Sequence = 0;
			dpo.Description = "LINE ADJUDICATION INFORMATION";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when the claim has been previously adjudicated by payer identified in Loop ID-2330B and this service line has payments and/or adjustments applied to it. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. To show unbundled lines: If, in the original claim, line 3 is unbundled into (for example) 2 additional lines, then the SVD for line 3 is used 3 times: once for the original adjustment to line 3 and then two more times for the additional unbundled lines.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 210;
			dpo.LoopName = "2440";
			dpo.Name = "FRM";
			dpo.Sequence = 1;
			dpo.Description = "SUPPORTING DOCUMENTATION";
			dpo.RepeatValue = 99;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = @"1. The LQ segment is used to identify the general (LQ01) and specific type (LQ02) for the form being reported in Loop ID-2440. The FRM segment is used to answer specific questions on the form identified in the LQ segment. FRM01 is used to indicate the question being answered. Answers can take one of 4 forms: FRM02 for Yes/No questions, FRM03 for text/uncodified answers, FRM04 for answers which use dates, and FRM05 for answers which are percents. For each FRM01 (question) use a remaining FRM element, choosing the element which has the most appropriate format. One FRM segment is used for each question/answer pair.

The example below shows how the FRM can be used to answer all the pertinent questions on DMERC form 0802 (LQ*UT*08.02~).";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 209;
			dpo.LoopName = "2440";
			dpo.Name = "LQ";
			dpo.Sequence = 0;
			dpo.Description = "FORM IDENTIFICATION CODE";
			dpo.RepeatValue = 1;
			dpo.Required = false;
			dpo.Situational_Rule = @"Required when adjudication is known to be impacted by one of the types of supporting documentation (standardized paper forms) listed in LQ01. If not required by this implementation guide, do not send.";
			dpo.TR3_Notes = @"1. Loop ID-2440 is designed to allow providers to attach standardized supplemental information to the claim when required to do so by the payer. The LQ segment contains information to identify the form (LQ01) and the specific form number (LQ02). In the example given below, LQ01=UT which identifies the form as a Medicare DMERC CMN form. LQ02=01.02 identifies which DMERC CMN form is being used. 
 
2. An example application of this Form Identification Code Loop is for Medicare DMERC claims for which the DME provider is required to obtain a Certificate of Medical Necessity (DMERC CMN) or DMERC Information Form (DIF), or Oxygen Therapy Certification from the referring physician. Another example is payer documentation requirements for Home Health services.";
			dpo.TR3_Example = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 217;
			dpo.LoopName = "BHT";
			dpo.Name = "BHT";
			dpo.Sequence = 0;
			dpo.Description = "Beginning of Hierarchical Transaction";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			dpo.Script = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 219;
			dpo.LoopName = "GE";
			dpo.Name = "GE";
			dpo.Sequence = 0;
			dpo.Description = "Functional Group Trailer";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			dpo.Script = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 215;
			dpo.LoopName = "GS";
			dpo.Name = "GS";
			dpo.Sequence = 0;
			dpo.Description = "Functional Group Header";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			dpo.Script = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 220;
			dpo.LoopName = "IEA";
			dpo.Name = "IEA";
			dpo.Sequence = 0;
			dpo.Description = "Interchange Control Trailer";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			dpo.Script = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 214;
			dpo.LoopName = "ISA";
			dpo.Name = "ISA";
			dpo.Sequence = 0;
			dpo.Description = "Interchange Control Header";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			dpo.Script = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 218;
			dpo.LoopName = "SE";
			dpo.Name = "SE";
			dpo.Sequence = 0;
			dpo.Description = "Transaction Set Trailer";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			dpo.Script = "";
			list.Add(dpo);

			dpo = new X12SegmentInstanceDpo();
			dpo.ID = 216;
			dpo.LoopName = "ST";
			dpo.Name = "ST";
			dpo.Sequence = 0;
			dpo.Description = "Functional Group Header";
			dpo.RepeatValue = 1;
			dpo.Required = true;
			dpo.Situational_Rule = "";
			dpo.TR3_Notes = "";
			dpo.TR3_Example = "";
			dpo.Script = "";
			list.Add(dpo);

		}

	}
}
