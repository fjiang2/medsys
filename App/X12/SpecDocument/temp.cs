using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;
using X12.DpoClass;
using X12.Specification;

namespace X12
{
    class temp
    {
        public static void run()
        {
            string code = @"03 Report Justifying Treatment Beyond Utilization Guidelines 
04 Drugs Administered 
05 Treatment Diagnosis 
06 Initial Assessment 
07 Functional Goals 
08 Plan of Treatment 
09 Progress Report 
10 Continued Treatment 
11 Chemical Analysis 
13 Certified Test Report 
15 Justification for Admission 
21 Recovery Plan 
A3 Allergies/Sensitivities Document 
A4 Autopsy Report 
AM Ambulance Certification 
AS Admission Summary 
B2 Prescription 
B3 Physician Order 
B4 Referral Form 
BR Benchmark Testing Results 
BS Baseline 
BT Blanket Test Results 
CB Chiropractic Justification 
CK Consent Form(s) 
CT Certification 
D2 Drug Profile Document 
DA Dental Models 
DB Durable Medical Equipment Prescription 
DG Diagnostic Report 
DJ Discharge Monitoring Report 
DS Discharge Summary 
EB Explanation of Benefits (Coordination of Benefits or Medicare Secondary Payor) 
HC Health Certificate 
HR Health Clinic Records 
I5 Immunization Record 
IR State School Immunization Records 
LA Laboratory Results 
M1 Medical Record Attachment 
MT Models 
NN Nursing Notes 
OB Operative Note 
OC Oxygen Content Averaging Report 
OD Orders and Treatments Document 
OE Objective Physical Examination (including vital signs) Document 
OX Oxygen Therapy Certification 
OZ Support Data for Claim 
P4 Pathology Report 
P5 Patient Medical History Document 
PE Parenteral or Enteral Certification 
PN Physical Therapy Notes 
PO Prosthetics or Orthotic Certification 
PQ Paramedical Results 
PY Physician's Report 
PZ Physical Therapy Certification 
RB Radiology Films 
RR Radiology Reports 
RT Report of Tests and Analysis Report 
RX Renewable Oxygen Content Averaging Report 
SG Symptoms Document 
V5 Death Notification 
XP Photographs";

            string[] lines = code.Replace("\r\n","\n").Split(new char[] { '\n' });

            
            X12CodeDefinitionDpo dpo = new X12CodeDefinitionDpo();
            foreach (string line in lines)
            {
                dpo.ElementInstance_ID = 113;
                dpo.Code =line.Substring(0,2);
                dpo.Definition = line.Substring(2).Trim();
                dpo.Save();
            }
        }
    }
}



/***
         MustThen("NM1");
            MustThen("PER");
                        
            loopName = "1000B";
            MustThen("NM1");
                        
            loopName = "2000A";
            MustThen("HL");
            IfThen("PRV"); 
            IfThen("CUR");

            loopName = "2010AA";
            if (IsSegmentName("NM1") && CurrentLine[1].Text == "85")    //NM1 - BILLING PROVIDER NAME
            {
                SetLoopName(loopName);
                k++;

                MustThen("N3");
                MustThen("N4");
                MustThen("REF");           //REF - BILLING PROVIDER TAX IDENTIFICATION
                IfThen("REF");             //REF - BILLING PROVIDER UPIN/LICENSE INFORMATION
                IfThen("PER");             //PER - BILLING PROVIDER CONTACT INFORMATION
            }

            loopName = "2010AB";
            if (IsSegmentName("NM1") && CurrentLine[1].Text == "87")    //NM1 - PAY-TO ADDRESS NAME
            {
                SetLoopName(loopName);
                k++;

                MustThen("N3");
                MustThen("N4");
            }

            loopName = "2010AC";
            if (IsSegmentName("NM1") && CurrentLine[1].Text == "PE")    //NM1 - PAY-TO PLAN NAME
            {
                SetLoopName(loopName);
                k++;

                MustThen("N3");
                MustThen("N4");
                IfThen("REF");         //REF - PAY-TO PLAN SECONDARY IDENTIFICATION
                MustThen("REF");                //REF - PAY-TO PLAN TAX IDENTIFICATION NUMBER
            }


            loopName = "2010B";
            MustThen("HL");
            MustThen("SBR");
            IfThen("PAT");             //PAT - PATIENT INFORMATION


            loopName = "2010BA";
            if (IsSegmentName("NM1") && CurrentLine[1].Text == "IL")    //NM1 - SUBSCRIBER NAME
            {
                SetLoopName(loopName);
                k++;

                IfThen("N3");
                IfThen("N4");
                IfThen("DMG");
                IfThen("REF");
                IfThen("REF");
                IfThen("PER");
            }


            loopName = "2010BB";
            if (IsSegmentName("NM1") && CurrentLine[1].Text == "PR")    //NM1 - PAYER NAME
            {
                SetLoopName(loopName);
                k++;

                IfThen("N3");
                IfThen("N4");
                IfThen("REF");
                IfThen("REF");
            }

            loopName = "2000C";
            if (IsSegmentName("HL"))
            {
                SetLoopName(loopName);
                k++;

                MustThen("PAT");
            }

                loopName = "2010CA";
                if (IsSegmentName("NM1") && CurrentLine[1].Text == "QC")    //NM1 - PATIENT NAME
                {
                    SetLoopName(loopName);
                    k++;

                    MustThen("N3");
                    MustThen("N4");
                    MustThen("DMG");
                    IfThen("REF");
                    IfThen("REF");
                    IfThen("PER");
                }

                loopName = "2300";
                MustThen("CLM");
                for (int i = 0; i < 16; i++)
                    IfThen("DTP");

                IfThen("PWK");
                IfThen("CN1");
                IfThen("AMT");

                for (int i = 0; i < 14; i++)
                    IfThen("REF");

                IfThen("K3");
                IfThen("NTE");


                IfThen("CR1");
                IfThen("CR2");

                for (int i = 0; i < 4; i++)
                    IfThen("CRC");

                MustThen("HI");
                IfThen("HI");
                IfThen("HI");
                IfThen("HCP");
**/