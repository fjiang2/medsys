//
// Machine Generated Code
//   by devel at 4/18/2012 3:50:03 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.DataManager;


namespace App.Data.Dpo
{
    [Revision(7)]
    [Table("Employees", Level.Default)]    //Primary Keys = EmployeeID;  Identity = EmployeeID;
    public class EmployeeDpo : DPObject
    {

#pragma warning disable

        [Column(_EmployeeID, SqlDbType.Int, Identity = true, Primary = true)]                     public int EmployeeID;        //int(4) not null
        [Column(_LastName, SqlDbType.NVarChar, Length = 20)]                                      public string LastName;       //nvarchar(20) not null
        [Column(_FirstName, SqlDbType.NVarChar, Length = 10)]                                     public string FirstName;      //nvarchar(10) not null
        [Column(_Title, SqlDbType.NVarChar, Nullable = true, Length = 30)]                        public string Title;          //nvarchar(30) null
        [Column(_TitleOfCourtesy, SqlDbType.NVarChar, Nullable = true, Length = 25)]              public string TitleOfCourtesy;//nvarchar(25) null
        [Column(_BirthDate, SqlDbType.DateTime, Nullable = true)]                                 public DateTime? BirthDate;   //datetime(8) null
        [Column(_HireDate, SqlDbType.DateTime, Nullable = true)]                                  public DateTime? HireDate;    //datetime(8) null
        [Column(_Address, SqlDbType.NVarChar, Nullable = true, Length = 60)]                      public string Address;        //nvarchar(60) null
        [Column(_City, SqlDbType.NVarChar, Nullable = true, Length = 15)]                         public string City;           //nvarchar(15) null
        [Column(_Region, SqlDbType.NVarChar, Nullable = true, Length = 15)]                       public string Region;         //nvarchar(15) null
        [Column(_PostalCode, SqlDbType.NVarChar, Nullable = true, Length = 10)]                   public string PostalCode;     //nvarchar(10) null
        [Column(_Country, SqlDbType.NVarChar, Nullable = true, Length = 15)]                      public string Country;        //nvarchar(15) null
        [Column(_HomePhone, SqlDbType.NVarChar, Nullable = true, Length = 24)]                    public string HomePhone;      //nvarchar(24) null
        [Column(_Extension, SqlDbType.NVarChar, Nullable = true, Length = 4)]                     public string Extension;      //nvarchar(4) null
        [Column(_Photo, SqlDbType.Image, Nullable = true)]                                        public byte[] Photo;          //image(16) null
        [Column(_Notes, SqlDbType.NText, Nullable = true)]                                        public string Notes;          //ntext(16) null
        [Column(_ReportsTo, SqlDbType.Int, Nullable = true)]                                      public int? ReportsTo;        //int(4) null
        [Column(_PhotoPath, SqlDbType.NVarChar, Nullable = true, Length = 255)]                   public string PhotoPath;      //nvarchar(255) null

        #region IMAGE PROPERTIES
        public Image PhotoImage
        {
            get
            {
                if (Photo != null)
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(Photo);
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
                    Photo = stream.ToArray();
                }
            }
        }

        #endregion
#pragma warning restore

        public EmployeeDpo()
        {
        }

        public EmployeeDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public EmployeeDpo(int employeeid)
        {
           this.EmployeeID = employeeid; 

           this.Load();
           if(!this.Exists)
           {
              this.EmployeeID = employeeid;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.EmployeeID;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _EmployeeID });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _EmployeeID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new EmployeeDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _EmployeeID = "EmployeeID";
        public const string _LastName = "LastName";
        public const string _FirstName = "FirstName";
        public const string _Title = "Title";
        public const string _TitleOfCourtesy = "TitleOfCourtesy";
        public const string _BirthDate = "BirthDate";
        public const string _HireDate = "HireDate";
        public const string _Address = "Address";
        public const string _City = "City";
        public const string _Region = "Region";
        public const string _PostalCode = "PostalCode";
        public const string _Country = "Country";
        public const string _HomePhone = "HomePhone";
        public const string _Extension = "Extension";
        public const string _Photo = "Photo";
        public const string _Notes = "Notes";
        public const string _ReportsTo = "ReportsTo";
        public const string _PhotoPath = "PhotoPath";

       
        #endregion 



    }
}

