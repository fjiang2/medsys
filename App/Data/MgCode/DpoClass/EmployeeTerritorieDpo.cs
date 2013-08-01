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
    [Table("Northwind..[EmployeeTerritories]", Level.Fixed)]    //Primary Keys = EmployeeID + TerritoryID;  Identity = ;
    public class EmployeeTerritorieDpo : DPObject
    {

#pragma warning disable

        [ForeignKey(typeof(App.Data.DpoClass.EmployeeDpo), App.Data.DpoClass.EmployeeDpo._EmployeeID)]
        [Column(_EmployeeID, CType.Int, Primary = true)]                                      public int EmployeeID {get; set;} //int(4) not null
        [ForeignKey(typeof(App.Data.DpoClass.TerritorieDpo), App.Data.DpoClass.TerritorieDpo._TerritoryID)]
        [Column(_TerritoryID, CType.NVarChar, Primary = true, Length = 20)]                   public string TerritoryID {get; set;} //nvarchar(20) not null

#pragma warning restore

        public EmployeeTerritorieDpo()
        {
        }

        public EmployeeTerritorieDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public EmployeeTerritorieDpo(int employeeid, string territoryid)
        {
           this.EmployeeID = employeeid; this.TerritoryID = territoryid; 

           this.Load();
           if(!this.Exists)
           {
              this.EmployeeID = employeeid; this.TerritoryID = territoryid;     
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
                return new PrimaryKeys(new string[]{ _EmployeeID, _TerritoryID });
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
              return new EmployeeTerritorieDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _EmployeeID = "EmployeeID";
        public const string _TerritoryID = "TerritoryID";

       
        #endregion 



    }
}

