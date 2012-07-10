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
    [DataTable("theJobTitle", Level.Default, Id=37)]    //Primary Keys = Job_ID;  Identity = Job_ID;
    public class theJobTitleDpo : DPObject
    {

#pragma warning disable

        public int Job_ID;		//int(4) not null
        public string Title;		//nvarchar(50) not null
        public int? Dept_ID;		//int(4) null

#pragma warning restore

        public theJobTitleDpo()
        {
        }

        public theJobTitleDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public theJobTitleDpo(int job_id)
        {
           this.Job_ID = job_id;

           this.Load();
           if(!this.Exists)
           {
              this.Job_ID = job_id;    
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.Job_ID;
            }
        }



        protected override string[] PrimaryKeys
        {
            get
            {
                return new string[]{ _Job_ID };
            }
        }



        protected override string[] IdentityKeys
        {
            get
            {
                return new string[]{ _Job_ID };
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new theJobTitleDpo().FullTableName;
            }
        }

        public DPCollection<theJobTitleDpo> DPCollection(string where, params object[] args)
        { 
            return new DPCollection<theJobTitleDpo>(SELECT(where, args));
        }


        #region CONSTANT

        public const string _Job_ID = "Job_ID";
        public const string _Title = "Title";
        public const string _Dept_ID = "Dept_ID";

       
        protected override string CreateTableString { get { return CREATE_TABLE_STRING; }}    
        private const string CREATE_TABLE_STRING =@"
CREATE TABLE [dbo].[{0}]
(
	[Job_ID] int NOT NULL IDENTITY(1,1),
	[Title] nvarchar(50) NOT NULL ,
	[Dept_ID] int NULL 
	PRIMARY KEY([Job_ID])
) 
";


        #endregion 


    }
}

