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
    [Table("Northwind..[Orders]", Level.Fixed)]    //Primary Keys = OrderID;  Identity = OrderID;
    public class OrderDpo : DPObject
    {

#pragma warning disable

        [Column(_OrderID, SqlDbType.Int, Identity = true, Primary = true)]                        public int OrderID {get; set;} //int(4) not null
        [ForeignKey(typeof(App.Data.DpoClass.CustomerDpo), App.Data.DpoClass.CustomerDpo._CustomerID)]
        [Column(_CustomerID, SqlDbType.NChar, Nullable = true, Length = 5)]                       public string CustomerID {get; set;} //nchar(5) null
        [ForeignKey(typeof(App.Data.DpoClass.EmployeeDpo), App.Data.DpoClass.EmployeeDpo._EmployeeID)]
        [Column(_EmployeeID, SqlDbType.Int, Nullable = true)]                                     public int? EmployeeID {get; set;} //int(4) null
        [Column(_OrderDate, SqlDbType.DateTime, Nullable = true)]                                 public DateTime? OrderDate {get; set;} //datetime(8) null
        [Column(_RequiredDate, SqlDbType.DateTime, Nullable = true)]                              public DateTime? RequiredDate {get; set;} //datetime(8) null
        [Column(_ShippedDate, SqlDbType.DateTime, Nullable = true)]                               public DateTime? ShippedDate {get; set;} //datetime(8) null
        [ForeignKey(typeof(App.Data.DpoClass.ShipperDpo), App.Data.DpoClass.ShipperDpo._ShipperID)]
        [Column(_ShipVia, SqlDbType.Int, Nullable = true)]                                        public int? ShipVia {get; set;} //int(4) null
        [Column(_Freight, SqlDbType.Money, Nullable = true)]                                      public decimal? Freight {get; set;} //money(8) null
        [Column(_ShipName, SqlDbType.NVarChar, Nullable = true, Length = 40)]                     public string ShipName {get; set;} //nvarchar(40) null
        [Column(_ShipAddress, SqlDbType.NVarChar, Nullable = true, Length = 60)]                  public string ShipAddress {get; set;} //nvarchar(60) null
        [Column(_ShipCity, SqlDbType.NVarChar, Nullable = true, Length = 15)]                     public string ShipCity {get; set;} //nvarchar(15) null
        [Column(_ShipRegion, SqlDbType.NVarChar, Nullable = true, Length = 15)]                   public string ShipRegion {get; set;} //nvarchar(15) null
        [Column(_ShipPostalCode, SqlDbType.NVarChar, Nullable = true, Length = 10)]               public string ShipPostalCode {get; set;} //nvarchar(10) null
        [Column(_ShipCountry, SqlDbType.NVarChar, Nullable = true, Length = 15)]                  public string ShipCountry {get; set;} //nvarchar(15) null

#pragma warning restore

        public OrderDpo()
        {
        }

        public OrderDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public OrderDpo(int orderid)
        {
           this.OrderID = orderid; 

           this.Load();
           if(!this.Exists)
           {
              this.OrderID = orderid;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.OrderID;
            }
        }



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _OrderID });
            }
        }



        public override IIdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _OrderID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new OrderDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _OrderID = "OrderID";
        public const string _CustomerID = "CustomerID";
        public const string _EmployeeID = "EmployeeID";
        public const string _OrderDate = "OrderDate";
        public const string _RequiredDate = "RequiredDate";
        public const string _ShippedDate = "ShippedDate";
        public const string _ShipVia = "ShipVia";
        public const string _Freight = "Freight";
        public const string _ShipName = "ShipName";
        public const string _ShipAddress = "ShipAddress";
        public const string _ShipCity = "ShipCity";
        public const string _ShipRegion = "ShipRegion";
        public const string _ShipPostalCode = "ShipPostalCode";
        public const string _ShipCountry = "ShipCountry";

       
        #endregion 



    }
}

