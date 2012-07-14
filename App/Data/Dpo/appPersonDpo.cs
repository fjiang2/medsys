//
// Machine Generated Code
//   by devel at 7/12/2012 2:17:10 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;


namespace App.Data.Dpo
{
    [Revision(1)]
    [Table("app00101", Level.System, Pack = false)]    //Primary Keys = Person_ID;  Identity = Person_ID;
    public class appPersonDpo : DPObject
    {

#pragma warning disable

        [Column(_Person_ID, SqlDbType.Int, Identity = true, Primary = true)]                      public int Person_ID;         //int(4) not null
        [Column(_Member_Enum, SqlDbType.Int)]                                                     public int Member_Enum;       //int(4) not null
        [Column(_SSN, SqlDbType.NVarChar, Nullable = true, Length = 10)]                          public string SSN;            //nvarchar(10) null
        [Column(_First_Name, SqlDbType.NVarChar, Length = 50)]                                    public string First_Name;     //nvarchar(50) not null
        [Column(_Last_Name, SqlDbType.NVarChar, Length = 50)]                                     public string Last_Name;      //nvarchar(50) not null
        [Column(_Middle_Name, SqlDbType.NVarChar, Nullable = true, Length = 50)]                  public string Middle_Name;    //nvarchar(50) null
        [Column(_Nick_Name, SqlDbType.NVarChar, Nullable = true, Length = 50)]                    public string Nick_Name;      //nvarchar(50) null
        [Column(_Prefix_Name, SqlDbType.NVarChar, Nullable = true, Length = 50)]                  public string Prefix_Name;    //nvarchar(50) null
        [Column(_Suffix_Name, SqlDbType.NVarChar, Nullable = true, Length = 50)]                  public string Suffix_Name;    //nvarchar(50) null
        [Column(_Gender_Enum, SqlDbType.Int)]                                                     public int Gender_Enum;       //int(4) not null
        [Column(_Birthday, SqlDbType.DateTime, Nullable = true)]                                  public DateTime? Birthday;    //datetime(8) null
        [Column(_MaritalStatus_Enum, SqlDbType.Int, Nullable = true)]                             public int? MaritalStatus_Enum;//int(4) null
        [Column(_Citizen, SqlDbType.Bit, Nullable = true)]                                        public bool? Citizen;         //bit(1) null
        [Column(_Inactive, SqlDbType.Bit)]                                                        public bool Inactive;         //bit(1) not null

#pragma warning restore

        public appPersonDpo()
        {
        }

        public appPersonDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public appPersonDpo(int person_id)
        {
           this.Person_ID = person_id; 

           this.Load();
           if(!this.Exists)
           {
              this.Person_ID = person_id;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.Person_ID;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Person_ID });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _Person_ID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new appPersonDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _Person_ID = "Person_ID";
        public const string _Member_Enum = "Member_Enum";
        public const string _SSN = "SSN";
        public const string _First_Name = "First_Name";
        public const string _Last_Name = "Last_Name";
        public const string _Middle_Name = "Middle_Name";
        public const string _Nick_Name = "Nick_Name";
        public const string _Prefix_Name = "Prefix_Name";
        public const string _Suffix_Name = "Suffix_Name";
        public const string _Gender_Enum = "Gender_Enum";
        public const string _Birthday = "Birthday";
        public const string _MaritalStatus_Enum = "MaritalStatus_Enum";
        public const string _Citizen = "Citizen";
        public const string _Inactive = "Inactive";

       
        #endregion 



    }
}

