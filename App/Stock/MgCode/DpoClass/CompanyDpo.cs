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
    [Revision(3)]
    [Table("Edgar..[Companies]", Level.Fixed, Pack = false)]    //Primary Keys = Symbol;  Identity = ;
    public partial class CompanyDpo : DPObject
    {
        [Column(_Symbol, CType.NVarChar, Primary = true, Length = 20)]                            public string Symbol {get; set;} //nvarchar(20) not null
        [Column(_CIK, CType.NVarChar, Nullable = true, Length = 12)]                              public string CIK {get; set;} //nvarchar(12) null
        [Column(_Name, CType.NVarChar, Length = 100)]                                             public string Name {get; set;} //nvarchar(100) not null
        [Column(_LastSale, CType.Float, Nullable = true)]                                         public double? LastSale {get; set;} //float(8) null
        [Column(_MarketCap, CType.Float, Nullable = true)]                                        public double? MarketCap {get; set;} //float(8) null
        [Column(_ADR_TSO, CType.NVarChar, Nullable = true, Length = 10)]                          public string ADR_TSO {get; set;} //nvarchar(10) null
        [Column(_IPOyear, CType.Int, Nullable = true)]                                            public int? IPOyear {get; set;} //int(4) null
        [Column(_Sector, CType.NVarChar, Nullable = true, Length = 50)]                           public string Sector {get; set;} //nvarchar(50) null
        [Column(_Industry, CType.NVarChar, Nullable = true, Length = 80)]                         public string Industry {get; set;} //nvarchar(80) null
        [Column(_Summary_Quote, CType.NVarChar, Length = 40)]                                     public string Summary_Quote {get; set;} //nvarchar(40) not null
        [Column(_Exchange, CType.NVarChar, Length = 10)]                                          public string Exchange {get; set;} //nvarchar(10) not null
        [Column(_Has_Insider_Transaction, CType.Bit)]                                             public bool Has_Insider_Transaction {get; set;} //bit(1) not null
        [Column(_Last_Downloaded_Time, CType.DateTime)]                                           public DateTime Last_Downloaded_Time {get; set;} //datetime(8) not null
        [Column(_Last_Processed_Time, CType.DateTime)]                                            public DateTime Last_Processed_Time {get; set;} //datetime(8) not null
        [Column(_Inactive, CType.Bit)]                                                            public bool Inactive {get; set;} //bit(1) not null

        public CompanyDpo()
        {
        }

        public CompanyDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public CompanyDpo(string symbol)
        {
           this.Symbol = symbol; 

           this.Load();
           if(!this.Exists)
           {
              this.Symbol = symbol;     
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
                return new PrimaryKeys(new string[]{ _Symbol });
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

        public const string _Symbol = "Symbol";
        public const string _CIK = "CIK";
        public const string _Name = "Name";
        public const string _LastSale = "LastSale";
        public const string _MarketCap = "MarketCap";
        public const string _ADR_TSO = "ADR_TSO";
        public const string _IPOyear = "IPOyear";
        public const string _Sector = "Sector";
        public const string _Industry = "Industry";
        public const string _Summary_Quote = "Summary_Quote";
        public const string _Exchange = "Exchange";
        public const string _Has_Insider_Transaction = "Has_Insider_Transaction";
        public const string _Last_Downloaded_Time = "Last_Downloaded_Time";
        public const string _Last_Processed_Time = "Last_Processed_Time";
        public const string _Inactive = "Inactive";

       
        #endregion 



    }
}

