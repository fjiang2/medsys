//
// Machine Generated Code
//   by devel at 4/18/2012 3:50:03 PM
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
    [Revision(7)]
    [Table("Northwind..[Order Details]", Level.Fixed)]    //Primary Keys = OrderID + ProductID;  Identity = ;
    public class Order_DetailDpo : DPObject
    {

#pragma warning disable

        [Column(_OrderID, SqlDbType.Int, Primary = true)]                                         public int OrderID;           //int(4) not null
        [Column(_ProductID, SqlDbType.Int, Primary = true)]                                       public int ProductID;         //int(4) not null
        [Column(_UnitPrice, SqlDbType.Money)]                                                     public decimal UnitPrice;     //money(8) not null
        [Column(_Quantity, SqlDbType.SmallInt)]                                                   public short Quantity;        //smallint(2) not null
        [Column(_Discount, SqlDbType.Real)]                                                       public Single Discount;       //real(4) not null

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
        


        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _OrderID, _ProductID });
            }
        }



        public override IdentityKeys Identity
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

