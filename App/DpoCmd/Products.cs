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


namespace Northwind
{
    [Revision(3)]
    [Table("Products", Level.Application, Pack = false)]    //Primary Keys = ProductID;  Identity = ProductID;
    public partial class Products : DPObject
    {
        [Column(_ProductID, CType.Int, Identity = true, Primary = true)]                          public int ProductID {get; set;} //int(4) not null
        [Column(_ProductName, CType.NVarChar, Length = 40)]                                       public string ProductName {get; set;} //nvarchar(40) not null
        [Column(_SupplierID, CType.Int, Nullable = true)]                                         public int? SupplierID {get; set;} //int(4) null
        [Column(_CategoryID, CType.Int, Nullable = true)]                                         public int? CategoryID {get; set;} //int(4) null
        [Column(_QuantityPerUnit, CType.NVarChar, Nullable = true, Length = 20)]                  public string QuantityPerUnit {get; set;} //nvarchar(20) null
        [Column(_UnitPrice, CType.Money, Nullable = true)]                                        public decimal? UnitPrice {get; set;} //money(8) null
        [Column(_UnitsInStock, CType.SmallInt, Nullable = true)]                                  public short? UnitsInStock {get; set;} //smallint(2) null
        [Column(_UnitsOnOrder, CType.SmallInt, Nullable = true)]                                  public short? UnitsOnOrder {get; set;} //smallint(2) null
        [Column(_ReorderLevel, CType.SmallInt, Nullable = true)]                                  public short? ReorderLevel {get; set;} //smallint(2) null
        [Column(_Discontinued, CType.Bit)]                                                        public bool Discontinued {get; set;} //bit(1) not null
        [Column(_Options, CType.VarChar, Nullable = true, Length = 50)]                           public string Options {get; set;} //varchar(50) null

        public Products()
        {
        }

        public Products(DataRow dataRow)
            :base(dataRow)
        {
        }


        public Products(int productid)
        {
           this.ProductID = productid; 

           this.Load();
           if(!this.Exists)
           {
              this.ProductID = productid;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.ProductID;
            }
        }



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _ProductID });
            }
        }



        public override IIdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _ProductID });
            }
        }

 

        #region CONSTANT

        public const string _ProductID = "ProductID";
        public const string _ProductName = "ProductName";
        public const string _SupplierID = "SupplierID";
        public const string _CategoryID = "CategoryID";
        public const string _QuantityPerUnit = "QuantityPerUnit";
        public const string _UnitPrice = "UnitPrice";
        public const string _UnitsInStock = "UnitsInStock";
        public const string _UnitsOnOrder = "UnitsOnOrder";
        public const string _ReorderLevel = "ReorderLevel";
        public const string _Discontinued = "Discontinued";
        public const string _Options = "Options";

       
        #endregion 




		public override void Fill(DataRow row)
		{
			ProductID = (int)row.GetValue(_ProductID);
			ProductName = (string)row.GetValue(_ProductName);
			SupplierID = (int?)row.GetValue(_SupplierID);
			CategoryID = (int?)row.GetValue(_CategoryID);
			QuantityPerUnit = (string)row.GetValue(_QuantityPerUnit);
			UnitPrice = (decimal?)row.GetValue(_UnitPrice);
			UnitsInStock = (short?)row.GetValue(_UnitsInStock);
			UnitsOnOrder = (short?)row.GetValue(_UnitsOnOrder);
			ReorderLevel = (short?)row.GetValue(_ReorderLevel);
			Discontinued = (bool)row.GetValue(_Discontinued);
			Options = (string)row.GetValue(_Options);
		}

		public override void Collect(DataRow row)
		{
			row.SetValue(_ProductID, this.ProductID);
			row.SetValue(_ProductName, this.ProductName);
			row.SetValue(_SupplierID, this.SupplierID);
			row.SetValue(_CategoryID, this.CategoryID);
			row.SetValue(_QuantityPerUnit, this.QuantityPerUnit);
			row.SetValue(_UnitPrice, this.UnitPrice);
			row.SetValue(_UnitsInStock, this.UnitsInStock);
			row.SetValue(_UnitsOnOrder, this.UnitsOnOrder);
			row.SetValue(_ReorderLevel, this.ReorderLevel);
			row.SetValue(_Discontinued, this.Discontinued);
			row.SetValue(_Options, this.Options);
		}

    }
}

