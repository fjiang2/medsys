//
// Machine Generated Code
//   by devel at 5/16/2013
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
    [Revision(14)]
    [Table("sys01305", Level.System, Pack = false)]    //Primary Keys = ID;  Identity = ID;
    public class wfTaskDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true, Primary = true)]                             public int ID {get; set;}     //int(4) not null
        [Column(_Company, CType.NVarChar, Nullable = true, Length = 50)]                      public string Company {get; set;} //nvarchar(50) null
        [Column(_Summary, CType.NVarChar, Length = 128)]                                      public string Summary {get; set;} //nvarchar(128) not null
        [Column(_Category1, CType.NVarChar, Nullable = true, Length = 50)]                    public string Category1 {get; set;} //nvarchar(50) null
        [Column(_Category2, CType.NVarChar, Nullable = true, Length = 50)]                    public string Category2 {get; set;} //nvarchar(50) null
        [Column(_Category3, CType.NVarChar, Nullable = true, Length = 50)]                    public string Category3 {get; set;} //nvarchar(50) null
        [Column(_Description, CType.NVarChar, Nullable = true, Length = 2048)]                public string Description {get; set;} //nvarchar(2048) null
        [Column(_Priority, CType.Int)]                                                        public int Priority {get; set;} //int(4) not null
        [Column(_Status, CType.Int)]                                                          public int Status {get; set;} //int(4) not null
        [Column(_Submitted_Date, CType.DateTime)]                                             public DateTime Submitted_Date {get; set;} //datetime(8) not null
        [Column(_Start_Date, CType.DateTime, Nullable = true)]                                public DateTime? Start_Date {get; set;} //datetime(8) null
        [Column(_Due_Date, CType.DateTime, Nullable = true)]                                  public DateTime? Due_Date {get; set;} //datetime(8) null
        [Column(_Reminder_Date, CType.DateTime, Nullable = true)]                             public DateTime? Reminder_Date {get; set;} //datetime(8) null
        [Column(_Last_Action_Date, CType.DateTime, Nullable = true)]                          public DateTime? Last_Action_Date {get; set;} //datetime(8) null
        [Column(_Work_Date, CType.DateTime, Nullable = true)]                                 public DateTime? Work_Date {get; set;} //datetime(8) null
        [Column(_Complete_Date, CType.DateTime, Nullable = true)]                             public DateTime? Complete_Date {get; set;} //datetime(8) null
        [Column(_Complete_Percentage, CType.Float, Nullable = true)]                          public double? Complete_Percentage {get; set;} //float(8) null
        [Column(_Time_Spent, CType.Float, Nullable = true)]                                   public double? Time_Spent {get; set;} //float(8) null
        [Column(_Resolution, CType.NVarChar, Nullable = true, Length = 2048)]                 public string Resolution {get; set;} //nvarchar(2048) null
        [Column(_Owner_ID, CType.Int, Nullable = true)]                                       public int? Owner_ID {get; set;} //int(4) null
        [Column(_Sender_ID, CType.Int)]                                                       public int Sender_ID {get; set;} //int(4) not null
        [Column(_Unread, CType.Bit)]                                                          public bool Unread {get; set;} //bit(1) not null
        [Column(_Deleted, CType.Bit)]                                                         public bool Deleted {get; set;} //bit(1) not null
        [Column(_Visible, CType.Bit)]                                                         public bool Visible {get; set;} //bit(1) not null
        [Column(_Enabled, CType.Bit)]                                                         public bool Enabled {get; set;} //bit(1) not null
        [Column(_WorkflowInstance_ID, CType.Int, Nullable = true)]                            public int? WorkflowInstance_ID {get; set;} //int(4) null
        [Column(_State_Name, CType.NVarChar, Nullable = true, Length = 128)]                  public string State_Name {get; set;} //nvarchar(128) null
        [Column(_Activity_Status, CType.Int, Nullable = true)]                                public int? Activity_Status {get; set;} //int(4) null
        [Column(_Prev_States, CType.NVarChar, Nullable = true, Length = 512)]                 public string Prev_States {get; set;} //nvarchar(512) null
        [Column(_Next_States, CType.NVarChar, Nullable = true, Length = 512)]                 public string Next_States {get; set;} //nvarchar(512) null
        [Column(_Heap, CType.NVarChar, Nullable = true, Length = 4000)]                       public string Heap {get; set;} //nvarchar(4000) null

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



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _ID });
            }
        }



        public override IIdentityKeys Identity
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

