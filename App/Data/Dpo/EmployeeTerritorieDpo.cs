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
    [Table("Northwind..EmployeeTerritories", Level.Fixed)]    //Primary Keys = EmployeeID + TerritoryID;  Identity = ;
    public class EmployeeTerritorieDpo : DPObject
    {

#pragma warning disable

        [Column(_EmployeeID, SqlDbType.Int, Primary = true)]                                      public int EmployeeID;        //int(4) not null
        [Column(_TerritoryID, SqlDbType.NVarChar, Primary = true, Length = 20)]                   public string TerritoryID;    //nvarchar(20) not null

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
        


        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _EmployeeID, _TerritoryID });
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
              return new EmployeeTerritorieDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _EmployeeID = "EmployeeID";
        public const string _TerritoryID = "TerritoryID";

       
        #endregion 



    }
}

