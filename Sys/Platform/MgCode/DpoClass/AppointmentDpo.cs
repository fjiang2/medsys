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


namespace Sys.Platform.DpoClass
{
    [Revision(8)]
    [Table("Appointments", Level.System, Pack = false)]    //Primary Keys = UniqueID;  Identity = UniqueID;
    public class AppointmentDpo : DPObject
    {

#pragma warning disable

        [Column(_UniqueID, SqlDbType.Int, Identity = true, Primary = true)]                       public int UniqueID {get; set;} //int(4) not null
        [Column(_User_ID, SqlDbType.Int)]                                                         public int User_ID {get; set;} //int(4) not null
        [Column(_Type, SqlDbType.Int)]                                                            public int Type {get; set;}   //int(4) not null
        [Column(_StartDate, SqlDbType.SmallDateTime)]                                             public DateTime StartDate {get; set;} //smalldatetime(4) not null
        [Column(_EndDate, SqlDbType.SmallDateTime)]                                               public DateTime EndDate {get; set;} //smalldatetime(4) not null
        [Column(_AllDay, SqlDbType.Bit)]                                                          public bool AllDay {get; set;} //bit(1) not null
        [Column(_Subject, SqlDbType.NVarChar, Nullable = true, Length = 50)]                      public string Subject {get; set;} //nvarchar(50) null
        [Column(_Location, SqlDbType.NVarChar, Nullable = true, Length = 50)]                     public string Location {get; set;} //nvarchar(50) null
        [Column(_Description, SqlDbType.NVarChar, Nullable = true, Length = -1)]                  public string Description {get; set;} //nvarchar(-1) null
        [Column(_Status, SqlDbType.Int)]                                                          public int Status {get; set;} //int(4) not null
        [Column(_Label, SqlDbType.Int, Nullable = true)]                                          public int? Label {get; set;} //int(4) null
        [Column(_ResourceID, SqlDbType.Int)]                                                      public int ResourceID {get; set;} //int(4) not null
        [Column(_ReminderInfo, SqlDbType.NVarChar, Nullable = true, Length = -1)]                 public string ReminderInfo {get; set;} //nvarchar(-1) null
        [Column(_RecurrenceInfo, SqlDbType.NVarChar, Nullable = true, Length = -1)]               public string RecurrenceInfo {get; set;} //nvarchar(-1) null
        [Column(_CustomField1, SqlDbType.NVarChar, Nullable = true, Length = -1)]                 public string CustomField1 {get; set;} //nvarchar(-1) null

#pragma warning restore

        public AppointmentDpo()
        {
        }

        public AppointmentDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public AppointmentDpo(int uniqueid)
        {
           this.UniqueID = uniqueid; 

           this.Load();
           if(!this.Exists)
           {
              this.UniqueID = uniqueid;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.UniqueID;
            }
        }



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _UniqueID });
            }
        }



        public override IIdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _UniqueID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new AppointmentDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _UniqueID = "UniqueID";
        public const string _User_ID = "User_ID";
        public const string _Type = "Type";
        public const string _StartDate = "StartDate";
        public const string _EndDate = "EndDate";
        public const string _AllDay = "AllDay";
        public const string _Subject = "Subject";
        public const string _Location = "Location";
        public const string _Description = "Description";
        public const string _Status = "Status";
        public const string _Label = "Label";
        public const string _ResourceID = "ResourceID";
        public const string _ReminderInfo = "ReminderInfo";
        public const string _RecurrenceInfo = "RecurrenceInfo";
        public const string _CustomField1 = "CustomField1";

       
        #endregion 



    }
}

