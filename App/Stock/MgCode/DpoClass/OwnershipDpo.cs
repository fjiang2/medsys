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
    [Table("Edgar..[Ownership]", Level.Fixed, Pack = false)]    //Primary Keys = CIK + OwnerCIK + TransactionDate;  Identity = ;
    public partial class OwnershipDpo : DPObject
    {
        [Column(_CIK, CType.NVarChar, Primary = true, Length = 12)]                               public string CIK {get; set;} //nvarchar(12) not null
        [Column(_Owner, CType.NVarChar, Nullable = true, Length = 50)]                            public string Owner {get; set;} //nvarchar(50) null
        [Column(_OwnerCIK, CType.NVarChar, Primary = true, Length = 12)]                          public string OwnerCIK {get; set;} //nvarchar(12) not null
        [Column(_TransactionDate, CType.DateTime, Primary = true)]                                public DateTime TransactionDate {get; set;} //datetime(8) not null
        [Column(_TypeofOwner, CType.NVarChar, Nullable = true, Length = 50)]                      public string TypeofOwner {get; set;} //nvarchar(50) null

        public OwnershipDpo()
        {
        }

        public OwnershipDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public OwnershipDpo(string cik, string ownercik, DateTime transactiondate)
        {
           this.CIK = cik; this.OwnerCIK = ownercik; this.TransactionDate = transactiondate; 

           this.Load();
           if(!this.Exists)
           {
              this.CIK = cik; this.OwnerCIK = ownercik; this.TransactionDate = transactiondate;     
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
                return new PrimaryKeys(new string[]{ _CIK, _OwnerCIK, _TransactionDate });
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
        public const string _Owner = "Owner";
        public const string _OwnerCIK = "OwnerCIK";
        public const string _TransactionDate = "TransactionDate";
        public const string _TypeofOwner = "TypeofOwner";

       
        #endregion 



    }
}

