//Machine Generated Code by devel at 3/23/2012 8:44:14 PM
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.DataManager;


namespace Sys.DataManager.Dpo
{
    [DataTable("theEmployee", Level.Default, Id=36)]    //Primary Keys = Badge;  Identity = Emp_ID;
    public class theEmployeeDpo : DPObject
    {

#pragma warning disable

        public int Emp_ID;		//int(4) not null
        public string Badge;		//nvarchar(50) not null
        public string SSN;		//nchar(9) not null
        public string First_Name;		//nvarchar(50) not null
        public string Last_Name;		//nvarchar(50) not null
        public string Middle_Name;		//nvarchar(50) null
        public string Nick_Name;		//nvarchar(50) null
        public string Name_Prefix;		//nvarchar(10) null
        public string Name_Suffix;		//nvarchar(10) null
        public string Email;		//nvarchar(50) null
        public int Job_Title_ID;		//int(4) not null
        public int Mgr_ID;		//int(4) not null
        public int Dept_ID;		//int(4) not null
        public int Addr_ID;		//int(4) not null
        public string Work_Phone;		//varchar(16) null
        public string Work_Fax;		//varchar(16) null
        public string Work_Pager;		//varchar(16) null
        public string Work_Mobile;		//varchar(16) null
        public bool Inactive;		//bit(1) not null
        public DateTime First_Day_Worked;		//datetime(8) not null
        public DateTime? Last_Day_Worked;		//datetime(8) null
        public DateTime? Benefit_Expired_Date;		//datetime(8) null
        public DateTime Brithday;		//datetime(8) not null
        public byte Gender;		//tinyint(1) not null
        public byte Marital_Status;		//tinyint(1) not null
        public string Spouse;		//nvarchar(50) null
        public string Spouse_SSN;		//nchar(9) null
        public bool Veteran;		//bit(1) not null
        public bool Vietnam_Veteran;		//bit(1) not null
        public bool Disable_Veteran;		//bit(1) not null
        public bool Citizen;		//bit(1) not null
        public bool Handicapped;		//bit(1) not null
        public bool? Union_Employee;		//bit(1) null
        public bool Smoker;		//bit(1) not null
        public bool? Verified;		//bit(1) null

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



        protected override string[] PrimaryKeys
        {
            get
            {
                return new string[]{ _Badge };
            }
        }



        protected override string[] IdentityKeys
        {
            get
            {
                return new string[]{ _Emp_ID };
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new theEmployeeDpo().FullTableName;
            }
        }

        public DPCollection<theEmployeeDpo> DPCollection(string where, params object[] args)
        { 
            return new DPCollection<theEmployeeDpo>(SELECT(where, args));
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

       
        protected override string CreateTableString { get { return CREATE_TABLE_STRING; }}    
        private const string CREATE_TABLE_STRING =@"
CREATE TABLE [dbo].[{0}]
(
	[Emp_ID] int NOT NULL IDENTITY(1,1),
	[Badge] nvarchar(50) NOT NULL ,
	[SSN] nchar(9) NOT NULL ,
	[First_Name] nvarchar(50) NOT NULL ,
	[Last_Name] nvarchar(50) NOT NULL ,
	[Middle_Name] nvarchar(50) NULL ,
	[Nick_Name] nvarchar(50) NULL ,
	[Name_Prefix] nvarchar(10) NULL ,
	[Name_Suffix] nvarchar(10) NULL ,
	[Email] nvarchar(50) NULL ,
	[Job_Title_ID] int NOT NULL ,
	[Mgr_ID] int NOT NULL ,
	[Dept_ID] int NOT NULL ,
	[Addr_ID] int NOT NULL ,
	[Work_Phone] varchar(16) NULL ,
	[Work_Fax] varchar(16) NULL ,
	[Work_Pager] varchar(16) NULL ,
	[Work_Mobile] varchar(16) NULL ,
	[Inactive] bit NOT NULL ,
	[First_Day_Worked] datetime NOT NULL ,
	[Last_Day_Worked] datetime NULL ,
	[Benefit_Expired_Date] datetime NULL ,
	[Brithday] datetime NOT NULL ,
	[Gender] tinyint NOT NULL ,
	[Marital_Status] tinyint NOT NULL ,
	[Spouse] nvarchar(50) NULL ,
	[Spouse_SSN] nchar(9) NULL ,
	[Veteran] bit NOT NULL ,
	[Vietnam_Veteran] bit NOT NULL ,
	[Disable_Veteran] bit NOT NULL ,
	[Citizen] bit NOT NULL ,
	[Handicapped] bit NOT NULL ,
	[Union_Employee] bit NULL ,
	[Smoker] bit NOT NULL ,
	[Verified] bit NULL 
	PRIMARY KEY([Badge])
) 
";


        #endregion 


    }
}

