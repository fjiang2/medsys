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
    [DataTable("theDepartment", Level.Default, Id=35)]    //Primary Keys = Name;  Identity = Dept_ID;
    public class theDepartmentDpo : DPObject
    {

#pragma warning disable

        public int Dept_ID;		//int(4) not null
        public string Name;		//nvarchar(50) not null
        public string Label;		//nvarchar(50) null
        public string Description;		//nvarchar(128) null
        public int? Manager_ID;		//int(4) null

#pragma warning restore

        public theDepartmentDpo()
        {
        }

        public theDepartmentDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public theDepartmentDpo(string name)
        {
           this.Name = name;

           this.Load();
           if(!this.Exists)
           {
              this.Name = name;    
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.Dept_ID;
            }
        }



        protected override string[] PrimaryKeys
        {
            get
            {
                return new string[]{ _Name };
            }
        }



        protected override string[] IdentityKeys
        {
            get
            {
                return new string[]{ _Dept_ID };
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new theDepartmentDpo().FullTableName;
            }
        }

        public DPCollection<theDepartmentDpo> DPCollection(string where, params object[] args)
        { 
            return new DPCollection<theDepartmentDpo>(SELECT(where, args));
        }


        #region CONSTANT

        public const string _Dept_ID = "Dept_ID";
        public const string _Name = "Name";
        public const string _Label = "Label";
        public const string _Description = "Description";
        public const string _Manager_ID = "Manager_ID";

       
        protected override string CreateTableString { get { return CREATE_TABLE_STRING; }}    
        private const string CREATE_TABLE_STRING =@"
CREATE TABLE [dbo].[{0}]
(
	[Dept_ID] int NOT NULL IDENTITY(1,1),
	[Name] nvarchar(50) NOT NULL ,
	[Label] nvarchar(50) NULL ,
	[Description] nvarchar(128) NULL ,
	[Manager_ID] int NULL 
	PRIMARY KEY([Name])
) 
";


        #endregion 


    }
}

