//
// Machine Generated Code
//   by devel at 4/19/2012 5:59:16 PM
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
    [Revision(9)]
    [Table("theDepartment", Level.System)]    //Primary Keys = Name;  Identity = Dept_ID;
    public class theDepartmentDpo : DPObject
    {

#pragma warning disable

        [Column(_Dept_ID, SqlDbType.Int, Identity = true)]                                        public int Dept_ID;           //int(4) not null
        [Column(_Name, SqlDbType.NVarChar, Primary = true, Length = 50)]                          public string Name;           //nvarchar(50) not null
        [Column(_Label, SqlDbType.NVarChar, Nullable = true, Length = 50)]                        public string Label;          //nvarchar(50) null
        [Column(_Description, SqlDbType.NVarChar, Nullable = true, Length = 128)]                 public string Description;    //nvarchar(128) null
        [Column(_Manager_ID, SqlDbType.Int, Nullable = true)]                                     public int? Manager_ID;       //int(4) null

#pragma warning restore

        public theDepartmentDpo()
        {
        }

        public theDepartmentDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public theDepartmentDpo(string name)
        {
           this.Name = name; 

           this.Load();
           if(!this.Exists)
           {
              this.Name = name;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.Dept_ID;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Name });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _Dept_ID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new theDepartmentDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _Dept_ID = "Dept_ID";
        public const string _Name = "Name";
        public const string _Label = "Label";
        public const string _Description = "Description";
        public const string _Manager_ID = "Manager_ID";

       
        #endregion 



    }
}

