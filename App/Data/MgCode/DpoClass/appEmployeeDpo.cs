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
    [Revision(13)]
    [Table("app00201", Level.Application)]    //Primary Keys = Badge;  Identity = Emp_ID;
    public class appEmployeeDpo : DPObject
    {

#pragma warning disable

        [Column(_Emp_ID, CType.Int, Identity = true)]                                         public int Emp_ID {get; set;} //int(4) not null
        [Column(_Badge, CType.NVarChar, Primary = true, Length = 50)]                         public string Badge {get; set;} //nvarchar(50) not null
        [Column(_Person_ID, CType.Int)]                                                       public int Person_ID {get; set;} //int(4) not null
        [Column(_Email, CType.NVarChar, Nullable = true, Length = 50)]                        public string Email {get; set;} //nvarchar(50) null
        [Column(_Job_Title_ID, CType.Int)]                                                    public int Job_Title_ID {get; set;} //int(4) not null
        [Column(_Manager_ID, CType.Int)]                                                      public int Manager_ID {get; set;} //int(4) not null
        [Column(_Department_ID, CType.Int)]                                                   public int Department_ID {get; set;} //int(4) not null
        [Column(_Address_ID, CType.Int)]                                                      public int Address_ID {get; set;} //int(4) not null
        [Column(_Work_Phone_ID, CType.Int)]                                                   public int Work_Phone_ID {get; set;} //int(4) not null
        [Column(_Home_Phone_ID, CType.Int, Nullable = true)]                                  public int? Home_Phone_ID {get; set;} //int(4) null
        [Column(_First_Day_Worked, CType.DateTime)]                                           public DateTime First_Day_Worked {get; set;} //datetime(8) not null
        [Column(_Last_Day_Worked, CType.DateTime, Nullable = true)]                           public DateTime? Last_Day_Worked {get; set;} //datetime(8) null
        [Column(_Benefit_Expired_Date, CType.DateTime, Nullable = true)]                      public DateTime? Benefit_Expired_Date {get; set;} //datetime(8) null
        [Column(_Veteran, CType.Bit)]                                                         public bool Veteran {get; set;} //bit(1) not null
        [Column(_Vietnam_Veteran, CType.Bit)]                                                 public bool Vietnam_Veteran {get; set;} //bit(1) not null
        [Column(_Disable_Veteran, CType.Bit)]                                                 public bool Disable_Veteran {get; set;} //bit(1) not null
        [Column(_Handicapped, CType.Bit)]                                                     public bool Handicapped {get; set;} //bit(1) not null
        [Column(_Union_Employee, CType.Bit, Nullable = true)]                                 public bool? Union_Employee {get; set;} //bit(1) null
        [Column(_Smoker, CType.Bit)]                                                          public bool Smoker {get; set;} //bit(1) not null
        [Column(_Verified, CType.Bit, Nullable = true)]                                       public bool? Verified {get; set;} //bit(1) null
        [Column(_Inactive, CType.Bit)]                                                        public bool Inactive {get; set;} //bit(1) not null

#pragma warning restore

        public appEmployeeDpo()
        {
        }

        public appEmployeeDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public appEmployeeDpo(string badge)
        {
           this.Badge = badge; 

           this.Load();
           if(!this.Exists)
           {
              this.Badge = badge;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.Emp_ID;
            }
        }



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Badge });
            }
        }



        public override IIdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _Emp_ID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new appEmployeeDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _Emp_ID = "Emp_ID";
        public const string _Badge = "Badge";
        public const string _Person_ID = "Person_ID";
        public const string _Email = "Email";
        public const string _Job_Title_ID = "Job_Title_ID";
        public const string _Manager_ID = "Manager_ID";
        public const string _Department_ID = "Department_ID";
        public const string _Address_ID = "Address_ID";
        public const string _Work_Phone_ID = "Work_Phone_ID";
        public const string _Home_Phone_ID = "Home_Phone_ID";
        public const string _First_Day_Worked = "First_Day_Worked";
        public const string _Last_Day_Worked = "Last_Day_Worked";
        public const string _Benefit_Expired_Date = "Benefit_Expired_Date";
        public const string _Veteran = "Veteran";
        public const string _Vietnam_Veteran = "Vietnam_Veteran";
        public const string _Disable_Veteran = "Disable_Veteran";
        public const string _Handicapped = "Handicapped";
        public const string _Union_Employee = "Union_Employee";
        public const string _Smoker = "Smoker";
        public const string _Verified = "Verified";
        public const string _Inactive = "Inactive";

       
        #endregion 



    }
}

