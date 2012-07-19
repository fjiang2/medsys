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
using Sys.Data.Manager;


namespace App.Data.DpoClass
{
    [Revision(9)]
    [Table("app00203", Level.Application)]    //Primary Keys = Job_ID;  Identity = Job_ID;
    public class appJobTitleDpo : DPObject
    {

#pragma warning disable

        [Column(_Job_ID, SqlDbType.Int, Identity = true, Primary = true)]                         public int Job_ID;            //int(4) not null
        [Column(_Title, SqlDbType.NVarChar, Length = 50)]                                         public string Title;          //nvarchar(50) not null
        [Column(_Dept_ID, SqlDbType.Int, Nullable = true)]                                        public int? Dept_ID;          //int(4) null

#pragma warning restore

        public appJobTitleDpo()
        {
        }

        public appJobTitleDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public appJobTitleDpo(int job_id)
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



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Job_ID });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _Job_ID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new appJobTitleDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _Job_ID = "Job_ID";
        public const string _Title = "Title";
        public const string _Dept_ID = "Dept_ID";

       
        #endregion 



    }
}

