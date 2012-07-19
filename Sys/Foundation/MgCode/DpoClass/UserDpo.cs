//
// Machine Generated Code
//   by devel at 4/19/2012 5:59:03 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;


namespace Sys.Foundation.DpoClass
{
    [Revision(14)]
    [Table("sys00101", Level.System)]    //Primary Keys = User_Name;  Identity = User_ID;
    public class UserDpo : DPObject
    {

#pragma warning disable

        [Column(_User_ID, SqlDbType.Int, Identity = true)]                                        public int User_ID;           //int(4) not null
        [Column(_User_Name, SqlDbType.NVarChar, Primary = true, Length = 256)]                    public string User_Name;      //nvarchar(256) not null
        [Column(_Plain_Password, SqlDbType.NVarChar, Nullable = true, Length = 32)]               public string Plain_Password; //nvarchar(32) null
        [Column(_Password, SqlDbType.VarBinary, Nullable = true, Length = 64)]                    public byte[] Password;       //varbinary(64) null
        [Column(_Inactive, SqlDbType.Bit)]                                                        public bool Inactive;         //bit(1) not null
        [Column(_Last_Name, SqlDbType.NVarChar, Length = 50)]                                     public string Last_Name;      //nvarchar(50) not null
        [Column(_First_Name, SqlDbType.NVarChar, Length = 50)]                                    public string First_Name;     //nvarchar(50) not null
        [Column(_Middle_Name, SqlDbType.NVarChar, Nullable = true, Length = 50)]                  public string Middle_Name;    //nvarchar(50) null
        [Column(_Nickname, SqlDbType.NVarChar, Nullable = true, Length = 50)]                     public string Nickname;       //nvarchar(50) null
        [Column(_Group_Name, SqlDbType.NVarChar, Length = 64)]                                    public string Group_Name;     //nvarchar(64) not null
        [Column(_Department, SqlDbType.NVarChar, Length = 50)]                                    public string Department;     //nvarchar(50) not null
        [Column(_Job_Title, SqlDbType.NVarChar, Length = 50)]                                     public string Job_Title;      //nvarchar(50) not null
        [Column(_Supervisor, SqlDbType.NVarChar, Length = 50)]                                    public string Supervisor;     //nvarchar(50) not null
        [Column(_Email, SqlDbType.NVarChar, Length = 64)]                                         public string Email;          //nvarchar(64) not null
        [Column(_WorkPhone, SqlDbType.VarChar, Length = 16)]                                      public string WorkPhone;      //varchar(16) not null
        [Column(_WorkFax, SqlDbType.VarChar, Nullable = true, Length = 16)]                       public string WorkFax;        //varchar(16) null
        [Column(_WorkPager, SqlDbType.VarChar, Nullable = true, Length = 16)]                     public string WorkPager;      //varchar(16) null
        [Column(_WorkMobile, SqlDbType.VarChar, Nullable = true, Length = 16)]                    public string WorkMobile;     //varchar(16) null
        [Column(_Signature, SqlDbType.Image, Nullable = true)]                                    public byte[] Signature;      //image(16) null
        [Column(_Avatar, SqlDbType.Image, Nullable = true)]                                       public byte[] Avatar;         //image(16) null
        [Column(_Password_Changed_DT, SqlDbType.DateTime, Nullable = true)]                       public DateTime? Password_Changed_DT;//datetime(8) null
        [Column(_Logon_Locked_DT, SqlDbType.DateTime, Nullable = true)]                           public DateTime? Logon_Locked_DT;//datetime(8) null
        [Column(_Start_Date, SqlDbType.DateTime)]                                                 public DateTime Start_Date;   //datetime(8) not null
        [Column(_End_Date, SqlDbType.DateTime, Nullable = true)]                                  public DateTime? End_Date;    //datetime(8) null

        #region IMAGE PROPERTIES
        public Image SignatureImage
        {
            get
            {
                if (Signature != null)
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(Signature);
                    return Image.FromStream(stream);
                }
                
                return null;
            }
            set
            {
                if (value != null)
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
                    value.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    Signature = stream.ToArray();
                }
            }
        }


        public Image AvatarImage
        {
            get
            {
                if (Avatar != null)
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(Avatar);
                    return Image.FromStream(stream);
                }
                
                return null;
            }
            set
            {
                if (value != null)
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
                    value.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    Avatar = stream.ToArray();
                }
            }
        }

        #endregion
#pragma warning restore

        public UserDpo()
        {
        }

        public UserDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public UserDpo(string user_name)
        {
           this.User_Name = user_name; 

           this.Load();
           if(!this.Exists)
           {
              this.User_Name = user_name;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.User_ID;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _User_Name });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _User_ID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new UserDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _User_ID = "User_ID";
        public const string _User_Name = "User_Name";
        public const string _Plain_Password = "Plain_Password";
        public const string _Password = "Password";
        public const string _Inactive = "Inactive";
        public const string _Last_Name = "Last_Name";
        public const string _First_Name = "First_Name";
        public const string _Middle_Name = "Middle_Name";
        public const string _Nickname = "Nickname";
        public const string _Group_Name = "Group_Name";
        public const string _Department = "Department";
        public const string _Job_Title = "Job_Title";
        public const string _Supervisor = "Supervisor";
        public const string _Email = "Email";
        public const string _WorkPhone = "WorkPhone";
        public const string _WorkFax = "WorkFax";
        public const string _WorkPager = "WorkPager";
        public const string _WorkMobile = "WorkMobile";
        public const string _Signature = "Signature";
        public const string _Avatar = "Avatar";
        public const string _Password_Changed_DT = "Password_Changed_DT";
        public const string _Logon_Locked_DT = "Logon_Locked_DT";
        public const string _Start_Date = "Start_Date";
        public const string _End_Date = "End_Date";

       
        #endregion 



    }
}

