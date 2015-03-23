//
// Machine Generated Code
//   by devel
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;


namespace AVL
{
    
    
    public partial class Demo : DPObject
    {
        public string TOTAL {get; set;} 
        public string OK {get; set;}  
        public string OKPERC {get; set;} 
        public string FAIL {get; set;} 
        [Column(_FAIL_PERC, CType.NVarChar, Nullable = true)]                                     public string FAIL_PERC {get; set;} 
        [Column(_PATTERN_STR, CType.NVarChar, Nullable = true)]                                   public string PATTERN_STR {get; set;} 
        public int? PATTERN_NO {get; set;} 
        public string CYCLESTR {get; set;} 
        public int? CYCLE_NO {get; set;} 
        public string OFFSETSTR {get; set;} 
        public string SEQSTR {get; set;} 
        public string PREEMPTSTR {get; set;} 
        public string TBC {get; set;} 
        public string LocalCounter {get; set;} 
        public string MODESTR {get; set;} 
        public string SPLITINDEXSTR {get; set;} 

        public Demo()
        {
        }

        public Demo(DataRow dataRow)
            :base(dataRow)
        {
        }




        //must override when logger is used
        protected override int DPObjectId
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        


        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[] {});
            }
        }
        


        public override IIdentityKeys Identity
        {
            get
            {
                return new IdentityKeys();
            }
        }
        
 

        #region CONSTANT

        public const string _TOTAL = "TOTAL";
        public const string _OK = "OK";
        public const string _OKPERC = "OKPERC";
        public const string _FAIL = "FAIL";
        public const string _FAIL_PERC = "FAIL PERC";
        public const string _PATTERN_STR = "PATTERN STR";
        public const string _PATTERN_NO = "PATTERN_NO";
        public const string _CYCLESTR = "CYCLESTR";
        public const string _CYCLE_NO = "CYCLE_NO";
        public const string _OFFSETSTR = "OFFSETSTR";
        public const string _SEQSTR = "SEQSTR";
        public const string _PREEMPTSTR = "PREEMPTSTR";
        public const string _TBC = "TBC";
        public const string _LocalCounter = "LocalCounter";
        public const string _MODESTR = "MODESTR";
        public const string _SPLITINDEXSTR = "SPLITINDEXSTR";

       
        #endregion 




		public override void Fill(DataRow row)
		{
			row.GetValue(_TOTAL);
			row.GetValue(_OK);
			row.GetValue(_OKPERC);
			row.GetValue(_FAIL);
			row.GetValue(_FAIL_PERC);
			row.GetValue(_PATTERN_STR);
			row.GetValue(_PATTERN_NO);
			row.GetValue(_CYCLESTR);
			row.GetValue(_CYCLE_NO);
			row.GetValue(_OFFSETSTR);
			row.GetValue(_SEQSTR);
			row.GetValue(_PREEMPTSTR);
			row.GetValue(_TBC);
			row.GetValue(_LocalCounter);
			row.GetValue(_MODESTR);
			row.GetValue(_SPLITINDEXSTR);
		}

		public override void Collect(DataRow row)
		{
			row.SetValue(_TOTAL, this.TOTAL);
			row.SetValue(_OK, this.OK);
			row.SetValue(_OKPERC, this.OKPERC);
			row.SetValue(_FAIL, this.FAIL);
			row.SetValue(_FAIL_PERC, this.FAIL_PERC);
			row.SetValue(_PATTERN_STR, this.PATTERN_STR);
			row.SetValue(_PATTERN_NO, this.PATTERN_NO);
			row.SetValue(_CYCLESTR, this.CYCLESTR);
			row.SetValue(_CYCLE_NO, this.CYCLE_NO);
			row.SetValue(_OFFSETSTR, this.OFFSETSTR);
			row.SetValue(_SEQSTR, this.SEQSTR);
			row.SetValue(_PREEMPTSTR, this.PREEMPTSTR);
			row.SetValue(_TBC, this.TBC);
			row.SetValue(_LocalCounter, this.LocalCounter);
			row.SetValue(_MODESTR, this.MODESTR);
			row.SetValue(_SPLITINDEXSTR, this.SPLITINDEXSTR);
		}

    }
}

