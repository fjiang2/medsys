//
// Machine Generated Code
//   by devel at 5/4/2012 4:32:11 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.DataManager;


namespace Sys.Platform.Dpo
{
    [Revision(4)]
    [Table("Appointments", Level.System, Pack = false)]    //Primary Keys = UniqueID;  Identity = UniqueID;
    public class AppointmentDpo : DPObject
    {

#pragma warning disable

        [Column(_UniqueID, SqlDbType.Int, Identity = true, Primary = true)]                       public int UniqueID;          //int(4) not null
        [Column(_User_ID, SqlDbType.Int)]                                                         public int User_ID;           //int(4) not null
        [Column(_Type, SqlDbType.Int)]                                                            public int Type;              //int(4) not null
        [Column(_StartDate, SqlDbType.SmallDateTime)]                                             public DateTime StartDate;    //smalldatetime(4) not null
        [Column(_EndDate, SqlDbType.SmallDateTime)]                                               public DateTime EndDate;      //smalldatetime(4) not null
        [Column(_AllDay, SqlDbType.Bit)]                                                          public bool AllDay;           //bit(1) not null
        [Column(_Subject, SqlDbType.NVarChar, Nullable = true, Length = 50)]                      public string Subject;        //nvarchar(50) null
        [Column(_Location, SqlDbType.NVarChar, Nullable = true, Length = 50)]                     public string Location;       //nvarchar(50) null
        [Column(_Description, SqlDbType.NVarChar, Nullable = true, Length = -1)]                  public string Description;    //nvarchar(-1) null
        [Column(_Status, SqlDbType.Int)]                                                          public int Status;            //int(4) not null
        [Column(_Label, SqlDbType.Int, Nullable = true)]                                          public int? Label;            //int(4) null
        [Column(_ResourceID, SqlDbType.Int)]                                                      public int ResourceID;        //int(4) not null
        [Column(_ReminderInfo, SqlDbType.NVarChar, Nullable = true, Length = -1)]                 public string ReminderInfo;   //nvarchar(-1) null
        [Column(_RecurrenceInfo, SqlDbType.NVarChar, Nullable = true, Length = -1)]               public string RecurrenceInfo; //nvarchar(-1) null
        [Column(_CustomField1, SqlDbType.NVarChar, Nullable = true, Length = -1)]                 public string CustomField1;   //nvarchar(-1) null

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



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _UniqueID });
            }
        }



        public override IdentityKeys Identity
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

