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


namespace PTA.DpoClass
{
    [Revision(18)]
    [Table("ptaAdults", Level.Application, Pack = false)]    //Primary Keys = Adult_ID;  Identity = ;
    public class ptaAdultDpo : DPObject
    {

#pragma warning disable

        [Column(_Adult_ID, SqlDbType.Int, Primary = true)]                                        public int Adult_ID {get; set;} //int(4) not null
        [Column(_Address_ID, SqlDbType.Int)]                                                      public int Address_ID {get; set;} //int(4) not null
        [Column(_Home_Phone_ID, SqlDbType.Int)]                                                   public int Home_Phone_ID {get; set;} //int(4) not null
        [Column(_Work_Phone_ID, SqlDbType.Int, Nullable = true)]                                  public int? Work_Phone_ID {get; set;} //int(4) null
        [Column(_Email, SqlDbType.VarChar, Nullable = true, Length = 60)]                         public string Email {get; set;} //varchar(60) null
        [Column(_Profession, SqlDbType.NVarChar, Nullable = true, Length = 150)]                  public string Profession {get; set;} //nvarchar(150) null
        [Column(_Day, SqlDbType.Bit)]                                                             public bool Day {get; set;}   //bit(1) not null
        [Column(_Night, SqlDbType.Bit)]                                                           public bool Night {get; set;} //bit(1) not null
        [Column(_Weekend, SqlDbType.Bit)]                                                         public bool Weekend {get; set;} //bit(1) not null
        [Column(_Arts, SqlDbType.Bit)]                                                            public bool Arts {get; set;}  //bit(1) not null
        [Column(_Chess, SqlDbType.Bit)]                                                           public bool Chess {get; set;} //bit(1) not null
        [Column(_Classroom, SqlDbType.Bit)]                                                       public bool Classroom {get; set;} //bit(1) not null
        [Column(_Construction, SqlDbType.Bit)]                                                    public bool Construction {get; set;} //bit(1) not null
        [Column(_Crawfish, SqlDbType.Bit)]                                                        public bool Crawfish {get; set;} //bit(1) not null
        [Column(_Writing, SqlDbType.Bit)]                                                         public bool Writing {get; set;} //bit(1) not null
        [Column(_Fundraising, SqlDbType.Bit)]                                                     public bool Fundraising {get; set;} //bit(1) not null
        [Column(_Events, SqlDbType.Bit)]                                                          public bool Events {get; set;} //bit(1) not null
        [Column(_Landscaping, SqlDbType.Bit)]                                                     public bool Landscaping {get; set;} //bit(1) not null
        [Column(_Gardening, SqlDbType.Bit)]                                                       public bool Gardening {get; set;} //bit(1) not null
        [Column(_Library, SqlDbType.Bit)]                                                         public bool Library {get; set;} //bit(1) not null
        [Column(_Lice, SqlDbType.Bit)]                                                            public bool Lice {get; set;}  //bit(1) not null
        [Column(_Lunch, SqlDbType.Bit)]                                                           public bool Lunch {get; set;} //bit(1) not null
        [Column(_Letter, SqlDbType.Bit)]                                                          public bool Letter {get; set;} //bit(1) not null
        [Column(_Office, SqlDbType.Bit)]                                                          public bool Office {get; set;} //bit(1) not null
        [Column(_Traffic, SqlDbType.Bit)]                                                         public bool Traffic {get; set;} //bit(1) not null
        [Column(_Registration, SqlDbType.Bit)]                                                    public bool Registration {get; set;} //bit(1) not null
        [Column(_Nurse, SqlDbType.Bit)]                                                           public bool Nurse {get; set;} //bit(1) not null
        [Column(_Soiree, SqlDbType.Bit)]                                                          public bool Soiree {get; set;} //bit(1) not null
        [Column(_Auction, SqlDbType.Bit)]                                                         public bool Auction {get; set;} //bit(1) not null
        [Column(_Technology, SqlDbType.Bit)]                                                      public bool Technology {get; set;} //bit(1) not null
        [Column(_Tutoring, SqlDbType.Bit)]                                                        public bool Tutoring {get; set;} //bit(1) not null
        [Column(_Committee, SqlDbType.Bit)]                                                       public bool Committee {get; set;} //bit(1) not null
        [Column(_Other, SqlDbType.NVarChar, Nullable = true, Length = 120)]                       public string Other {get; set;} //nvarchar(120) null

#pragma warning restore

        public ptaAdultDpo()
        {
        }

        public ptaAdultDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public ptaAdultDpo(int adult_id)
        {
           this.Adult_ID = adult_id; 

           this.Load();
           if(!this.Exists)
           {
              this.Adult_ID = adult_id;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.Adult_ID;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Adult_ID });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys();
            }
        }
        

        public static string TABLE_NAME
        { 
            get
            {
              return new ptaAdultDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _Adult_ID = "Adult_ID";
        public const string _Address_ID = "Address_ID";
        public const string _Home_Phone_ID = "Home_Phone_ID";
        public const string _Work_Phone_ID = "Work_Phone_ID";
        public const string _Email = "Email";
        public const string _Profession = "Profession";
        public const string _Day = "Day";
        public const string _Night = "Night";
        public const string _Weekend = "Weekend";
        public const string _Arts = "Arts";
        public const string _Chess = "Chess";
        public const string _Classroom = "Classroom";
        public const string _Construction = "Construction";
        public const string _Crawfish = "Crawfish";
        public const string _Writing = "Writing";
        public const string _Fundraising = "Fundraising";
        public const string _Events = "Events";
        public const string _Landscaping = "Landscaping";
        public const string _Gardening = "Gardening";
        public const string _Library = "Library";
        public const string _Lice = "Lice";
        public const string _Lunch = "Lunch";
        public const string _Letter = "Letter";
        public const string _Office = "Office";
        public const string _Traffic = "Traffic";
        public const string _Registration = "Registration";
        public const string _Nurse = "Nurse";
        public const string _Soiree = "Soiree";
        public const string _Auction = "Auction";
        public const string _Technology = "Technology";
        public const string _Tutoring = "Tutoring";
        public const string _Committee = "Committee";
        public const string _Other = "Other";

       
        #endregion 



    }
}

