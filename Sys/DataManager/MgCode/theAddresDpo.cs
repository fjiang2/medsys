//Machine Generated Code by devel at 3/23/2012 8:44:13 PM
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.DataManager;


namespace Sys.DataManager.Dpo
{
    [DataTable("theAddress", Level.Default, Id=34)]    //Primary Keys = Addr_ID;  Identity = Addr_ID;
    public class theAddresDpo : DPObject
    {

#pragma warning disable

        public int Addr_ID;		//int(4) not null
        public string Street1;		//nvarchar(100) not null
        public string Street2;		//nvarchar(100) null
        public string City;		//nvarchar(50) not null
        public string State;		//nvarchar(50) not null
        public string Zip;		//nvarchar(10) not null
        public string Country_Code;		//nvarchar(50) null
        public string Country_Sub_Code;		//nchar(10) null

#pragma warning restore

        public theAddresDpo()
        {
        }

        public theAddresDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public theAddresDpo(int addr_id)
        {
           this.Addr_ID = addr_id;

           this.Load();
           if(!this.Exists)
           {
              this.Addr_ID = addr_id;    
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.Addr_ID;
            }
        }



        protected override string[] PrimaryKeys
        {
            get
            {
                return new string[]{ _Addr_ID };
            }
        }



        protected override string[] IdentityKeys
        {
            get
            {
                return new string[]{ _Addr_ID };
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new theAddresDpo().FullTableName;
            }
        }

        public DPCollection<theAddresDpo> DPCollection(string where, params object[] args)
        { 
            return new DPCollection<theAddresDpo>(SELECT(where, args));
        }


        #region CONSTANT

        public const string _Addr_ID = "Addr_ID";
        public const string _Street1 = "Street1";
        public const string _Street2 = "Street2";
        public const string _City = "City";
        public const string _State = "State";
        public const string _Zip = "Zip";
        public const string _Country_Code = "Country_Code";
        public const string _Country_Sub_Code = "Country_Sub_Code";

       
        protected override string CreateTableString { get { return CREATE_TABLE_STRING; }}    
        private const string CREATE_TABLE_STRING =@"
CREATE TABLE [dbo].[{0}]
(
	[Addr_ID] int NOT NULL IDENTITY(1,1),
	[Street1] nvarchar(100) NOT NULL ,
	[Street2] nvarchar(100) NULL ,
	[City] nvarchar(50) NOT NULL ,
	[State] nvarchar(50) NOT NULL ,
	[Zip] nvarchar(10) NOT NULL ,
	[Country_Code] nvarchar(50) NULL ,
	[Country_Sub_Code] nchar(10) NULL 
	PRIMARY KEY([Addr_ID])
) 
";


        #endregion 


    }
}

