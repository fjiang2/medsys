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


namespace Stock.DpoClass
{
    [Revision(0)]
    [Table("Edgar..[Transactions]", Level.Fixed, Pack = false)]    //Primary Keys = CIK + Date + OwnerCIK;  Identity = ;
    public partial class TransactionDpo : DPObject
    {
        [Column(_CIK, CType.NVarChar, Primary = true, Length = 12)]                               public string CIK {get; set;} //nvarchar(12) not null
        [Column(_Type, CType.NVarChar, Nullable = true, Length = 10)]                             public string Type {get; set;} //nvarchar(10) null
        [Column(_Date, CType.DateTime, Primary = true)]                                           public DateTime Date {get; set;} //datetime(8) not null
        [Column(_ReportingOwner, CType.NVarChar, Nullable = true, Length = 50)]                   public string ReportingOwner {get; set;} //nvarchar(50) null
        [Column(_Form, CType.NVarChar, Nullable = true, Length = 50)]                             public string Form {get; set;} //nvarchar(50) null
        [Column(_Trans, CType.NVarChar, Nullable = true, Length = 50)]                            public string Trans {get; set;} //nvarchar(50) null
        [Column(_Modes, CType.NVarChar, Nullable = true, Length = 50)]                            public string Modes {get; set;} //nvarchar(50) null
        [Column(_Shares, CType.Float, Nullable = true)]                                           public double? Shares {get; set;} //float(8) null
        [Column(_Owned, CType.Float, Nullable = true)]                                            public double? Owned {get; set;} //float(8) null
        [Column(_No, CType.NVarChar, Nullable = true, Length = 50)]                               public string No {get; set;}  //nvarchar(50) null
        [Column(_OwnerCIK, CType.NVarChar, Primary = true, Length = 12)]                          public string OwnerCIK {get; set;} //nvarchar(12) not null
        [Column(_SecurityName, CType.NVarChar, Nullable = true, Length = 50)]                     public string SecurityName {get; set;} //nvarchar(50) null
        [Column(_Deemed, CType.NVarChar, Nullable = true, Length = 50)]                           public string Deemed {get; set;} //nvarchar(50) null
        [Column(_Exercise, CType.NVarChar, Nullable = true, Length = 50)]                         public string Exercise {get; set;} //nvarchar(50) null
        [Column(_Nature, CType.NVarChar, Nullable = true, Length = 50)]                           public string Nature {get; set;} //nvarchar(50) null
        [Column(_Derivative, CType.NVarChar, Nullable = true, Length = 50)]                       public string Derivative {get; set;} //nvarchar(50) null
        [Column(_SharesUnderlying, CType.Float, Nullable = true)]                                 public double? SharesUnderlying {get; set;} //float(8) null
        [Column(_Price, CType.Float, Nullable = true)]                                            public double? Price {get; set;} //float(8) null
        [Column(_Expires, CType.DateTime, Nullable = true)]                                       public DateTime? Expires {get; set;} //datetime(8) null
        [Column(_SecurityUnderlying, CType.NVarChar, Nullable = true, Length = 50)]               public string SecurityUnderlying {get; set;} //nvarchar(50) null

        public TransactionDpo()
        {
        }

        public TransactionDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public TransactionDpo(string cik, DateTime date, string ownercik)
        {
           this.CIK = cik; this.Date = date; this.OwnerCIK = ownercik; 

           this.Load();
           if(!this.Exists)
           {
              this.CIK = cik; this.Date = date; this.OwnerCIK = ownercik;     
           }
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
                return new PrimaryKeys(new string[]{ _CIK, _Date, _OwnerCIK });
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

        public const string _CIK = "CIK";
        public const string _Type = "Type";
        public const string _Date = "Date";
        public const string _ReportingOwner = "ReportingOwner";
        public const string _Form = "Form";
        public const string _Trans = "Trans";
        public const string _Modes = "Modes";
        public const string _Shares = "Shares";
        public const string _Owned = "Owned";
        public const string _No = "No";
        public const string _OwnerCIK = "OwnerCIK";
        public const string _SecurityName = "SecurityName";
        public const string _Deemed = "Deemed";
        public const string _Exercise = "Exercise";
        public const string _Nature = "Nature";
        public const string _Derivative = "Derivative";
        public const string _SharesUnderlying = "SharesUnderlying";
        public const string _Price = "Price";
        public const string _Expires = "Expires";
        public const string _SecurityUnderlying = "SecurityUnderlying";

       
        #endregion 



    }
}

