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
    [Revision(9)]
    [Table("Northwind..[Order Details]", Level.Fixed)]    //Primary Keys = OrderID + ProductID;  Identity = ;
    public class Order_DetailDpo : DPObject
    {

#pragma warning disable

        [ForeignKey(typeof(App.Data.DpoClass.OrderDpo), App.Data.DpoClass.OrderDpo._OrderID)]
        [Column(_OrderID, SqlDbType.Int, Primary = true)]                                         public int OrderID {get; set;} //int(4) not null
        [ForeignKey(typeof(App.Data.DpoClass.ProductDpo), App.Data.DpoClass.ProductDpo._ProductID)]
        [Column(_ProductID, SqlDbType.Int, Primary = true)]                                       public int ProductID {get; set;} //int(4) not null
        [Column(_UnitPrice, SqlDbType.Money)]                                                     public decimal UnitPrice {get; set;} //money(8) not null
        [Column(_Quantity, SqlDbType.SmallInt)]                                                   public short Quantity {get; set;} //smallint(2) not null
        [Column(_Discount, SqlDbType.Real)]                                                       public Single Discount {get; set;} //real(4) not null

#pragma warning restore

        public Order_DetailDpo()
        {
        }

        public Order_DetailDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public Order_DetailDpo(int orderid, int productid)
        {
           this.OrderID = orderid; this.ProductID = productid; 

           this.Load();
           if(!this.Exists)
           {
              this.OrderID = orderid; this.ProductID = productid;     
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
                return new PrimaryKeys(new string[]{ _OrderID, _ProductID });
            }
        }



        public override IIdentityKeys Identity
        {
            get
            {
                return new IdentityKeys();
            }
        }
        

        public static string TABLE_NAME
        { 
            get
            {
              return new Order_DetailDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _OrderID = "OrderID";
        public const string _ProductID = "ProductID";
        public const string _UnitPrice = "UnitPrice";
        public const string _Quantity = "Quantity";
        public const string _Discount = "Discount";

       
        #endregion 



    }
}

