//
// Machine Generated Code
//   by devel at 4/19/2012 5:59:13 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;
using Tie;

namespace Sys.Workflow.Dpo
{
    [Revision(11)]
    [Table("sys01304", Level.System, Pack = false)]    //Primary Keys = ID;  Identity = ID;
    public class wfWorkflowInstanceDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true, Primary = true)]                             public int ID;                //int(4) not null
        [Column(_Workflow_Name, SqlDbType.NVarChar, Length = 50)]                                 public string Workflow_Name;  //nvarchar(50) not null
        [Column(_Label, SqlDbType.NVarChar, Length = 128)]                                        public string Label;          //nvarchar(128) not null
        [Column(_Description, SqlDbType.NVarChar, Nullable = true, Length = 1024)]                public string Description;    //nvarchar(1024) null
        [Column(_Work_Date, SqlDbType.DateTime, Nullable = true)]                                 public DateTime? Work_Date;   //datetime(8) null
        [Column(_Complete_Date, SqlDbType.DateTime, Nullable = true)]                             public DateTime? Complete_Date;//datetime(8) null
        [Column(_Heap, SqlDbType.NText, Nullable = true)]                                         [NonValized] public string Heap;           //ntext(16) null
        [Column(_Deleted, SqlDbType.Bit)]                                                         public bool Deleted;          //bit(1) not null

#pragma warning restore

        public wfWorkflowInstanceDpo()
        {
        }

        public wfWorkflowInstanceDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public wfWorkflowInstanceDpo(int id)
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
              return new wfWorkflowInstanceDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Workflow_Name = "Workflow_Name";
        public const string _Label = "Label";
        public const string _Description = "Description";
        public const string _Work_Date = "Work_Date";
        public const string _Complete_Date = "Complete_Date";
        public const string _Heap = "Heap";
        public const string _Deleted = "Deleted";

       
        #endregion 



    }
}

