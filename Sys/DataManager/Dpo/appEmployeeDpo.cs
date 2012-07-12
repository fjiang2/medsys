//
// Machine Generated Code
//   by devel at 7/12/2012 2:16:55 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.DataManager;


namespace Sys.DataManager.Dpo
{
    [Revision(10)]
    [Table("app00201", Level.System)]    //Primary Keys = Badge;  Identity = Emp_ID;
    public class appEmployeeDpo : DPObject
    {

#pragma warning disable

        [Column(_Emp_ID, SqlDbType.Int, Identity = true)]                                         public int Emp_ID;            //int(4) not null
        [Column(_Badge, SqlDbType.NVarChar, Primary = true, Length = 50)]                         public string Badge;          //nvarchar(50) not null
        [Column(_Person_ID, SqlDbType.Int)]                                                       public int Person_ID;         //int(4) not null
        [Column(_Email, SqlDbType.NVarChar, Nullable = true, Length = 50)]                        public string Email;          //nvarchar(50) null
        [Column(_Job_Title_ID, SqlDbType.Int)]                                                    public int Job_Title_ID;      //int(4) not null
        [Column(_Manager_ID, SqlDbType.Int)]                                                      public int Manager_ID;        //int(4) not null
        [Column(_Department_ID, SqlDbType.Int)]                                                   public int Department_ID;     //int(4) not null
        [Column(_Address_ID, SqlDbType.Int)]                                                      public int Address_ID;        //int(4) not null
        [Column(_Work_Phone_ID, SqlDbType.Int)]                                                   public int Work_Phone_ID;     //int(4) not null
        [Column(_Home_Phone_ID, SqlDbType.Int, Nullable = true)]                                  public int? Home_Phone_ID;    //int(4) null
        [Column(_First_Day_Worked, SqlDbType.DateTime)]                                           public DateTime First_Day_Worked;//datetime(8) not null
        [Column(_Last_Day_Worked, SqlDbType.DateTime, Nullable = true)]                           public DateTime? Last_Day_Worked;//datetime(8) null
        [Column(_Benefit_Expired_Date, SqlDbType.DateTime, Nullable = true)]                      public DateTime? Benefit_Expired_Date;//datetime(8) null
        [Column(_Veteran, SqlDbType.Bit)]                                                         public bool Veteran;          //bit(1) not null
        [Column(_Vietnam_Veteran, SqlDbType.Bit)]                                                 public bool Vietnam_Veteran;  //bit(1) not null
        [Column(_Disable_Veteran, SqlDbType.Bit)]                                                 public bool Disable_Veteran;  //bit(1) not null
        [Column(_Handicapped, SqlDbType.Bit)]                                                     public bool Handicapped;      //bit(1) not null
        [Column(_Union_Employee, SqlDbType.Bit, Nullable = true)]                                 public bool? Union_Employee;  //bit(1) null
        [Column(_Smoker, SqlDbType.Bit)]                                                          public bool Smoker;           //bit(1) not null
        [Column(_Verified, SqlDbType.Bit, Nullable = true)]                                       public bool? Verified;        //bit(1) null
        [Column(_Inactive, SqlDbType.Bit)]                                                        public bool Inactive;         //bit(1) not null

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



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Badge });
            }
        }



        public override IdentityKeys Identity
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

