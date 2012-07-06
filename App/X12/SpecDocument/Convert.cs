using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X12
{
    /// <summary>
    /// Read Health Care Claim: Professional
    /// </summary>
    class Convert
    {

        string specification =
@"HI 
  
 
  HI01 C022 
Health Care
Code Info. 
M 1 ID 0/0   
 
 HI02 C022 
Health Care
Code Info. 
O 1 ID 0/0   
 
 HI03 C022 
Health Care
Code Info. 
O 1 ID 0/0   
 
 HI04 C022 
Health Care
Code Info. 
O 1 ID 0/0   
 
 HI05 C022 
Health Care
Code Info. 
O 1 ID 0/0   
 
 HI06 C022 
Health Care
Code Info. 
O 1 ID 0/0   
 
 HI07 C022 
Health Care
Code Info. 
O 1 ID 0/0   
 
 HI08 C022 
Health Care
Code Info. 
O 1 ID 0/0   
 
 HI09 C022 
Health Care
Code Info. 
O 1 ID 0/0   
 
 HI10 C022 
Health Care
Code Info. 
O 1 ID 0/0   
 
 HI11 C022 
Health Care
Code Info. 
O 1 ID 0/0   
 
 HI12 C022 
Health Care
Code Info. 
O 1 ID 0/0   
 
    
 
  
 
 
 
    
 
  
 
 
  
 
 
 
";
        public Convert()
        {
            string a = @" 
  
 
  ";
            int pos = specification.IndexOf(a);
            string segment = specification.Substring(0,pos);
            string spec = specification.Substring(pos + a.Length);
            ConvertSegment(spec.Trim(), segment);
        }

        public void ConvertSegment(string spec, string segment)
        {
            string x = spec.Replace("\r\n \r\n", "#");
            string[] elements = x.Split(new char[] { '#'});
            foreach (string e in elements)
                ConvertElement(e, segment);
        }

        public void ConvertElement(string specification, string segment)
        {

            Dpo.X12ElementTemplateDpo dpo = new Dpo.X12ElementTemplateDpo();

            dpo.SegmentName = segment;

            string x = specification.Replace("\r\n", "#");
            //line 1
            string[] lines = x.Split(new char[] { '#' });
            string[] L0 = lines[0].Trim().Split(new char[] { ' ' });
            dpo.RefDes = L0[0].Trim();
            dpo.DeNum = L0[1].Trim();

            //line 2
            dpo.Description = lines[1].Trim()+" " + lines[2].Trim();

            //line 3
            string[] L2 = lines[3].Trim().Split(new char[] { ' ' });
            dpo.Condition = L2[0].Trim();
            dpo.RepeatValue = int.Parse(L2[1]);

            string len;
            if (L2.Length == 3)
            {
                dpo.DataType = "";
                len = L2[2];
            }
            else
            {
                dpo.DataType = L2[2].Trim();
                len = L2[3];
            }

            string[] L3 = len.Split(new char[] { '/' });
            dpo.MinLength = int.Parse(L3[0]);
            dpo.MaxLength = int.Parse(L3[1]);

            dpo.Save();
  
        }

    }
}
