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
using Sys.DataManager;
using Tie;

namespace Sys.Workflow.Dpo
{
    [Revision(11)]
    [Table("sys01305", Level.System, Pack = false)]    //Primary Keys = ID;  Identity = ID;
    public class wfTaskDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true, Primary = true)]                             public int ID;                //int(4) not null
        [Column(_Company, SqlDbType.NVarChar, Nullable = true, Length = 50)]                      public string Company;        //nvarchar(50) null
        [Column(_Summary, SqlDbType.NVarChar, Length = 128)]                                      public string Summary;        //nvarchar(128) not null
        [Column(_Category1, SqlDbType.NVarChar, Nullable = true, Length = 50)]                    public string Category1;      //nvarchar(50) null
        [Column(_Category2, SqlDbType.NVarChar, Nullable = true, Length = 50)]                    public string Category2;      //nvarchar(50) null
        [Column(_Category3, SqlDbType.NVarChar, Nullable = true, Length = 50)]                    public string Category3;      //nvarchar(50) null
        [Column(_Description, SqlDbType.NVarChar, Nullable = true, Length = 2048)]                public string Description;    //nvarchar(2048) null
        [Column(_Priority, SqlDbType.Int)]                                                        [NonValized] public int Priority;          //int(4) not null
        [Column(_Status, SqlDbType.Int)]                                                          [NonValized] public int Status;            //int(4) not null
        [Column(_Submitted_Date, SqlDbType.DateTime)]                                             public DateTime Submitted_Date;//datetime(8) not null
        [Column(_Start_Date, SqlDbType.DateTime, Nullable = true)]                                public DateTime? Start_Date;  //datetime(8) null
        [Column(_Due_Date, SqlDbType.DateTime, Nullable = true)]                                  public DateTime? Due_Date;    //datetime(8) null
        [Column(_Reminder_Date, SqlDbType.DateTime, Nullable = true)]                             public DateTime? Reminder_Date;//datetime(8) null
        [Column(_Last_Action_Date, SqlDbType.DateTime, Nullable = true)]                          public DateTime? Last_Action_Date;//datetime(8) null
        [Column(_Work_Date, SqlDbType.DateTime, Nullable = true)]                                 public DateTime? Work_Date;   //datetime(8) null
        [Column(_Complete_Date, SqlDbType.DateTime, Nullable = true)]                             public DateTime? Complete_Date;//datetime(8) null
        [Column(_Complete_Percentage, SqlDbType.Float, Nullable = true)]                          public double? Complete_Percentage;//float(8) null
        [Column(_Time_Spent, SqlDbType.Float, Nullable = true)]                                   public double? Time_Spent;    //float(8) null
        [Column(_Resolution, SqlDbType.NVarChar, Nullable = true, Length = 2048)]                 public string Resolution;     //nvarchar(2048) null
        [Column(_Owner_ID, SqlDbType.Int, Nullable = true)]                                       public int? Owner_ID;         //int(4) null
        [Column(_Sender_ID, SqlDbType.Int)]                                                       public int Sender_ID;         //int(4) not null
        [Column(_Unread, SqlDbType.Bit)]                                                          public bool Unread;           //bit(1) not null
        [Column(_Deleted, SqlDbType.Bit)]                                                         public bool Deleted;          //bit(1) not null
        [Column(_Visible, SqlDbType.Bit)]                                                         public bool Visible;          //bit(1) not null
        [Column(_Enabled, SqlDbType.Bit)]                                                         public bool Enabled;          //bit(1) not null
        [Column(_WorkflowInstance_ID, SqlDbType.Int, Nullable = true)]                            public int? WorkflowInstance_ID;//int(4) null
        [Column(_State_Name, SqlDbType.NVarChar, Nullable = true, Length = 128)]                  [NonValized] public string State_Name;     //nvarchar(128) null
        [Column(_Activity_Status, SqlDbType.Int, Nullable = true)]                                [NonValized] public int? Activity_Status;  //int(4) null
        [Column(_Prev_States, SqlDbType.NVarChar, Nullable = true, Length = 512)]                 [NonValized] public string Prev_States;    //nvarchar(512) null
        [Column(_Next_States, SqlDbType.NVarChar, Nullable = true, Length = 512)]                 [NonValized] public string Next_States;    //nvarchar(512) null
        [Column(_Heap, SqlDbType.NVarChar, Nullable = true, Length = 4000)]                       [NonValized] public string Heap;           //nvarchar(4000) null

#pragma warning restore

        public wfTaskDpo()
        {
        }

        public wfTaskDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public wfTaskDpo(int id)
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
              return new wfTaskDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Company = "Company";
        public const string _Summary = "Summary";
        public const string _Category1 = "Category1";
        public const string _Category2 = "Category2";
        public const string _Category3 = "Category3";
        public const string _Description = "Description";
        public const string _Priority = "Priority";
        public const string _Status = "Status";
        public const string _Submitted_Date = "Submitted_Date";
        public const string _Start_Date = "Start_Date";
        public const string _Due_Date = "Due_Date";
        public const string _Reminder_Date = "Reminder_Date";
        public const string _Last_Action_Date = "Last_Action_Date";
        public const string _Work_Date = "Work_Date";
        public const string _Complete_Date = "Complete_Date";
        public const string _Complete_Percentage = "Complete_Percentage";
        public const string _Time_Spent = "Time_Spent";
        public const string _Resolution = "Resolution";
        public const string _Owner_ID = "Owner_ID";
        public const string _Sender_ID = "Sender_ID";
        public const string _Unread = "Unread";
        public const string _Deleted = "Deleted";
        public const string _Visible = "Visible";
        public const string _Enabled = "Enabled";
        public const string _WorkflowInstance_ID = "WorkflowInstance_ID";
        public const string _State_Name = "State_Name";
        public const string _Activity_Status = "Activity_Status";
        public const string _Prev_States = "Prev_States";
        public const string _Next_States = "Next_States";
        public const string _Heap = "Heap";

       
        #endregion 



    }
}

