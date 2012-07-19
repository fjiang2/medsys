//
// Machine Generated Code
//   by devel at 7/19/2012 12:12:42 AM
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
    [Revision(11)]
    [Table("sys00701", Level.System)]    //Primary Keys = AssemblyName;  Identity = ID;
    public class AssemblyDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true)]                                             public int ID;                //int(4) not null
        [Column(_AssemblyName, SqlDbType.VarChar, Primary = true, Length = 50)]                   public string AssemblyName;   //varchar(50) not null
        [Column(_FullName, SqlDbType.VarChar, Nullable = true, Length = 2560)]                    public string FullName;       //varchar(2560) null
        [Column(_Version, SqlDbType.VarChar, Nullable = true, Length = 50)]                       public string Version;        //varchar(50) null
        [Column(_Label, SqlDbType.NVarChar, Nullable = true, Length = 128)]                       public string Label;          //nvarchar(128) null
        [Column(_DateInstalled, SqlDbType.DateTime, Nullable = true)]                             public DateTime? DateInstalled;//datetime(8) null
        [Column(_Inactive, SqlDbType.Bit)]                                                        public bool Inactive;         //bit(1) not null
        [Column(_Location, SqlDbType.VarChar, Nullable = true, Length = 50)]                      public string Location;       //varchar(50) null

#pragma warning restore

        public AssemblyDpo()
        {
        }

        public AssemblyDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public AssemblyDpo(string assemblyname)
        {
           this.AssemblyName = assemblyname; 

           this.Load();
           if(!this.Exists)
           {
              this.AssemblyName = assemblyname;     
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
                return new PrimaryKeys(new string[]{ _AssemblyName });
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
              return new AssemblyDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _AssemblyName = "AssemblyName";
        public const string _FullName = "FullName";
        public const string _Version = "Version";
        public const string _Label = "Label";
        public const string _DateInstalled = "DateInstalled";
        public const string _Inactive = "Inactive";
        public const string _Location = "Location";

       
        #endregion 



    }
}

