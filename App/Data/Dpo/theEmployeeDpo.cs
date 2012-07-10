//
// Machine Generated Code
//   by devel at 4/19/2012 5:59:16 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.DataManager;


namespace App.Data.Dpo
{
    [Revision(9)]
    [Table("theEmployee", Level.System)]    //Primary Keys = Badge;  Identity = Emp_ID;
    public class theEmployeeDpo : DPObject
    {

#pragma warning disable

        [Column(_Emp_ID, SqlDbType.Int, Identity = true)]                                         public int Emp_ID;            //int(4) not null
        [Column(_Badge, SqlDbType.NVarChar, Primary = true, Length = 50)]                         public string Badge;          //nvarchar(50) not null
        [Column(_SSN, SqlDbType.NChar, Length = 9)]                                               public string SSN;            //nchar(9) not null
        [Column(_First_Name, SqlDbType.NVarChar, Length = 50)]                                    public string First_Name;     //nvarchar(50) not null
        [Column(_Last_Name, SqlDbType.NVarChar, Length = 50)]                                     public string Last_Name;      //nvarchar(50) not null
        [Column(_Middle_Name, SqlDbType.NVarChar, Nullable = true, Length = 50)]                  public string Middle_Name;    //nvarchar(50) null
        [Column(_Nick_Name, SqlDbType.NVarChar, Nullable = true, Length = 50)]                    public string Nick_Name;      //nvarchar(50) null
        [Column(_Name_Prefix, SqlDbType.NVarChar, Nullable = true, Length = 10)]                  public string Name_Prefix;    //nvarchar(10) null
        [Column(_Name_Suffix, SqlDbType.NVarChar, Nullable = true, Length = 10)]                  public string Name_Suffix;    //nvarchar(10) null
        [Column(_Email, SqlDbType.NVarChar, Nullable = true, Length = 50)]                        public string Email;          //nvarchar(50) null
        [Column(_Job_Title_ID, SqlDbType.Int)]                                                    public int Job_Title_ID;      //int(4) not null
        [Column(_Mgr_ID, SqlDbType.Int)]                                                          public int Mgr_ID;            //int(4) not null
        [Column(_Dept_ID, SqlDbType.Int)]                                                         public int Dept_ID;           //int(4) not null
        [Column(_Addr_ID, SqlDbType.Int)]                                                         public int Addr_ID;           //int(4) not null
        [Column(_Work_Phone, SqlDbType.VarChar, Nullable = true, Length = 16)]                    public string Work_Phone;     //varchar(16) null
        [Column(_Work_Fax, SqlDbType.VarChar, Nullable = true, Length = 16)]                      public string Work_Fax;       //varchar(16) null
        [Column(_Work_Pager, SqlDbType.VarChar, Nullable = true, Length = 16)]                    public string Work_Pager;     //varchar(16) null
        [Column(_Work_Mobile, SqlDbType.VarChar, Nullable = true, Length = 16)]                   public string Work_Mobile;    //varchar(16) null
        [Column(_Inactive, SqlDbType.Bit)]                                                        public bool Inactive;         //bit(1) not null
        [Column(_First_Day_Worked, SqlDbType.DateTime)]                                           public DateTime First_Day_Worked;//datetime(8) not null
        [Column(_Last_Day_Worked, SqlDbType.DateTime, Nullable = true)]                           public DateTime? Last_Day_Worked;//datetime(8) null
        [Column(_Benefit_Expired_Date, SqlDbType.DateTime, Nullable = true)]                      public DateTime? Benefit_Expired_Date;//datetime(8) null
        [Column(_Brithday, SqlDbType.DateTime)]                                                   public DateTime Brithday;     //datetime(8) not null
        [Column(_Gender, SqlDbType.TinyInt)]                                                      public byte Gender;           //tinyint(1) not null
        [Column(_Marital_Status, SqlDbType.TinyInt)]                                              public byte Marital_Status;   //tinyint(1) not null
        [Column(_Spouse, SqlDbType.NVarChar, Nullable = true, Length = 50)]                       public string Spouse;         //nvarchar(50) null
        [Column(_Spouse_SSN, SqlDbType.NChar, Nullable = true, Length = 9)]                       public string Spouse_SSN;     //nchar(9) null
        [Column(_Veteran, SqlDbType.Bit)]                                                         public bool Veteran;          //bit(1) not null
        [Column(_Vietnam_Veteran, SqlDbType.Bit)]                                                 public bool Vietnam_Veteran;  //bit(1) not null
        [Column(_Disable_Veteran, SqlDbType.Bit)]                                                 public bool Disable_Veteran;  //bit(1) not null
        [Column(_Citizen, SqlDbType.Bit)]                                                         public bool Citizen;          //bit(1) not null
        [Column(_Handicapped, SqlDbType.Bit)]                                                     public bool Handicapped;      //bit(1) not null
        [Column(_Union_Employee, SqlDbType.Bit, Nullable = true)]                                 public bool? Union_Employee;  //bit(1) null
        [Column(_Smoker, SqlDbType.Bit)]                                                          public bool Smoker;           //bit(1) not null
        [Column(_Verified, SqlDbType.Bit, Nullable = true)]                                       public bool? Verified;        //bit(1) null

#pragma warning restore

        public theEmployeeDpo()
        {
        }

        public theEmployeeDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public theEmployeeDpo(string badge)
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
              return new theEmployeeDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _Emp_ID = "Emp_ID";
        public const string _Badge = "Badge";
        public const string _SSN = "SSN";
        public const string _First_Name = "First_Name";
        public const string _Last_Name = "Last_Name";
        public const string _Middle_Name = "Middle_Name";
        public const string _Nick_Name = "Nick_Name";
        public const string _Name_Prefix = "Name_Prefix";
        public const string _Name_Suffix = "Name_Suffix";
        public const string _Email = "Email";
        public const string _Job_Title_ID = "Job_Title_ID";
        public const string _Mgr_ID = "Mgr_ID";
        public const string _Dept_ID = "Dept_ID";
        public const string _Addr_ID = "Addr_ID";
        public const string _Work_Phone = "Work_Phone";
        public const string _Work_Fax = "Work_Fax";
        public const string _Work_Pager = "Work_Pager";
        public const string _Work_Mobile = "Work_Mobile";
        public const string _Inactive = "Inactive";
        public const string _First_Day_Worked = "First_Day_Worked";
        public const string _Last_Day_Worked = "Last_Day_Worked";
        public const string _Benefit_Expired_Date = "Benefit_Expired_Date";
        public const string _Brithday = "Brithday";
        public const string _Gender = "Gender";
        public const string _Marital_Status = "Marital_Status";
        public const string _Spouse = "Spouse";
        public const string _Spouse_SSN = "Spouse_SSN";
        public const string _Veteran = "Veteran";
        public const string _Vietnam_Veteran = "Vietnam_Veteran";
        public const string _Disable_Veteran = "Disable_Veteran";
        public const string _Citizen = "Citizen";
        public const string _Handicapped = "Handicapped";
        public const string _Union_Employee = "Union_Employee";
        public const string _Smoker = "Smoker";
        public const string _Verified = "Verified";

       
        #endregion 



    }
}

