//
// Machine Generated Code
//   by devel at 4/19/2012 5:59:14 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;


namespace Sys.Workflow.DpoClass
{
    [Revision(11)]
    [Table("sys01308", Level.System, Pack = false)]    //Primary Keys = ID;  Identity = ID;
    public class wfNoteDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true, Primary = true)]                             public int ID;                //int(4) not null
        [Column(_WorkflowInstance_ID, SqlDbType.Int, Nullable = true)]                            public int? WorkflowInstance_ID;//int(4) null
        [Column(_S1_Name, SqlDbType.NVarChar, Nullable = true, Length = 50)]                      public string S1_Name;        //nvarchar(50) null
        [Column(_S2_Name, SqlDbType.NVarChar, Nullable = true, Length = 50)]                      public string S2_Name;        //nvarchar(50) null
        [Column(_User_ID, SqlDbType.Int, Nullable = true)]                                        public int? User_ID;          //int(4) null
        [Column(_Date_Created, SqlDbType.DateTime, Nullable = true)]                              public DateTime? Date_Created;//datetime(8) null
        [Column(_Comment, SqlDbType.NVarChar, Nullable = true, Length = -1)]                      public string Comment;        //nvarchar(-1) null

#pragma warning restore

        public wfNoteDpo()
        {
        }

        public wfNoteDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public wfNoteDpo(int id)
        {
           this.ID = id; 

           this.Load();
           if(!this.Exists)
           {
              this.ID = id;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.ID;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _ID });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _ID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new wfNoteDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _WorkflowInstance_ID = "WorkflowInstance_ID";
        public const string _S1_Name = "S1_Name";
        public const string _S2_Name = "S2_Name";
        public const string _User_ID = "User_ID";
        public const string _Date_Created = "Date_Created";
        public const string _Comment = "Comment";

       
        #endregion 



    }
}

