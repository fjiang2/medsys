//
// Machine Generated Code
//   by devel at 4/18/2012 3:50:04 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;


namespace App.Data.Dpo
{
    [Revision(8)]
    [Table("Northwind..Products", Level.Fixed)]    //Primary Keys = ProductID;  Identity = ProductID;
    public class ProductDpo : DPObject
    {

#pragma warning disable

        [Column(_ProductID, SqlDbType.Int, Identity = true, Primary = true)]                      public int ProductID;         //int(4) not null
        [Column(_ProductName, SqlDbType.NVarChar, Length = 40)]                                   public string ProductName;    //nvarchar(40) not null
        [Column(_SupplierID, SqlDbType.Int, Nullable = true)]                                     public int? SupplierID;       //int(4) null
        [Column(_CategoryID, SqlDbType.Int, Nullable = true)]                                     public int? CategoryID;       //int(4) null
        [Column(_QuantityPerUnit, SqlDbType.NVarChar, Nullable = true, Length = 20)]              public string QuantityPerUnit;//nvarchar(20) null
        [Column(_UnitPrice, SqlDbType.Money, Nullable = true)]                                    public decimal? UnitPrice;    //money(8) null
        [Column(_UnitsInStock, SqlDbType.SmallInt, Nullable = true)]                              public short? UnitsInStock;   //smallint(2) null
        [Column(_UnitsOnOrder, SqlDbType.SmallInt, Nullable = true)]                              public short? UnitsOnOrder;   //smallint(2) null
        [Column(_ReorderLevel, SqlDbType.SmallInt, Nullable = true)]                              public short? ReorderLevel;   //smallint(2) null
        [Column(_Discontinued, SqlDbType.Bit)]                                                    public bool Discontinued;     //bit(1) not null

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



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _ProductID });
            }
        }



        public override IdentityKeys Identity
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
        public const string _ProductName = "ProductName";
        public const string _SupplierID = "SupplierID";
        public const string _CategoryID = "CategoryID";
        public const string _QuantityPerUnit = "QuantityPerUnit";
        public const string _UnitPrice = "UnitPrice";
        public const string _UnitsInStock = "UnitsInStock";
        public const string _UnitsOnOrder = "UnitsOnOrder";
        public const string _ReorderLevel = "ReorderLevel";
        public const string _Discontinued = "Discontinued";

       
        #endregion 



    }
}

