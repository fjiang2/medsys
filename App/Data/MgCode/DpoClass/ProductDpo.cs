//
// Machine Generated Code
//   by devel at 5/16/2013
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;


namespace App.Data.DpoClass
{
    [Revision(10)]
    [Table("Northwind..[Products]", Level.Fixed)]    //Primary Keys = ProductID;  Identity = ProductID;
    public class ProductDpo : DPObject
    {

#pragma warning disable

        [Column(_ProductID, CType.Int, Identity = true, Primary = true)]                      public int ProductID {get; set;} //int(4) not null
        [Column(_mer_id, CType.Char, Nullable = true, Length = 3)]                            public string mer_id {get; set;} //char(3) null
        [Column(_product_id, CType.Char, Nullable = true, Length = 5)]                        public string product_id {get; set;} //char(5) null
        [Column(_ProductName, CType.NVarChar, Length = 40)]                                   public string ProductName {get; set;} //nvarchar(40) not null
        [ForeignKey(typeof(App.Data.DpoClass.SupplierDpo), App.Data.DpoClass.SupplierDpo._SupplierID)]
        [Column(_SupplierID, CType.Int, Nullable = true)]                                     public int? SupplierID {get; set;} //int(4) null
        [Column(_description, CType.VarChar, Nullable = true, Length = 20)]                   public string description {get; set;} //varchar(20) null
        [Column(_price, CType.Money, Nullable = true)]                                        public decimal? price {get; set;} //money(8) null
        [ForeignKey(typeof(App.Data.DpoClass.CategorieDpo), App.Data.DpoClass.CategorieDpo._CategoryID)]
        [Column(_CategoryID, CType.Int, Nullable = true)]                                     public int? CategoryID {get; set;} //int(4) null
        [Column(_QuantityPerUnit, CType.NVarChar, Nullable = true, Length = 20)]              public string QuantityPerUnit {get; set;} //nvarchar(20) null
        [Column(_qty_on_hand, CType.Int, Nullable = true)]                                    public int? qty_on_hand {get; set;} //int(4) null
        [Column(_UnitPrice, CType.Money, Nullable = true)]                                    public decimal? UnitPrice {get; set;} //money(8) null
        [Column(_UnitsInStock, CType.SmallInt, Nullable = true)]                              public short? UnitsInStock {get; set;} //smallint(2) null
        [Column(_UnitsOnOrder, CType.SmallInt, Nullable = true)]                              public short? UnitsOnOrder {get; set;} //smallint(2) null
        [Column(_ReorderLevel, CType.SmallInt, Nullable = true)]                              public short? ReorderLevel {get; set;} //smallint(2) null
        [Column(_Discontinued, CType.Bit)]                                                    public bool Discontinued {get; set;} //bit(1) not null

#pragma warning restore

        public ProductDpo()
        {
        }

        public ProductDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public ProductDpo(int productid)
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


        public static string TABLE_NAME
        { 
            get
            {
              return new ProductDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ProductID = "ProductID";
        public const string _mer_id = "mer_id";
        public const string _product_id = "product_id";
        public const string _ProductName = "ProductName";
        public const string _SupplierID = "SupplierID";
        public const string _description = "description";
        public const string _price = "price";
        public const string _CategoryID = "CategoryID";
        public const string _QuantityPerUnit = "QuantityPerUnit";
        public const string _qty_on_hand = "qty_on_hand";
        public const string _UnitPrice = "UnitPrice";
        public const string _UnitsInStock = "UnitsInStock";
        public const string _UnitsOnOrder = "UnitsOnOrder";
        public const string _ReorderLevel = "ReorderLevel";
        public const string _Discontinued = "Discontinued";

       
        #endregion 



    }
}

