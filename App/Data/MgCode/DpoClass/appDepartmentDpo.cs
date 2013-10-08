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


namespace App.Data.DpoClass
{
    [Revision(13)]
    [Table("app00202", Level.Application)]    //Primary Keys = Name;  Identity = Dept_ID;
    public class appDepartmentDpo : DPObject
    {

#pragma warning disable

        [Column(_Dept_ID, CType.Int, Identity = true)]                                        public int Dept_ID {get; set;} //int(4) not null
        [Column(_Name, CType.NVarChar, Primary = true, Length = 50)]                          public string Name {get; set;} //nvarchar(50) not null
        [Column(_Label, CType.NVarChar, Nullable = true, Length = 50)]                        public string Label {get; set;} //nvarchar(50) null
        [Column(_Description, CType.NVarChar, Nullable = true, Length = 128)]                 public string Description {get; set;} //nvarchar(128) null
        [Column(_Manager_ID, CType.Int, Nullable = true)]                                     public int? Manager_ID {get; set;} //int(4) null

#pragma warning restore

        public appDepartmentDpo()
        {
        }

        public appDepartmentDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public appDepartmentDpo(string name)
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



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Name });
            }
        }



        public override IIdentityKeys Identity
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
              return new appDepartmentDpo().TableName.FullName;
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

