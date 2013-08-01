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


namespace Sys.PersistentObjects.DpoClass
{
    [Revision(3)]
    [Table("sys00204", Level.System, Pack = false)]    //Primary Keys = Category + Feature;  Identity = ID;
    public class dictEnumTypeDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true)]                                             public int ID {get; set;}     //int(4) not null
        [Column(_Category, CType.VarChar, Primary = true, Length = 50)]                       public string Category {get; set;} //varchar(50) not null
        [Column(_Feature, CType.VarChar, Primary = true, Length = 50)]                        public string Feature {get; set;} //varchar(50) not null
        [Column(_Value, CType.Int)]                                                           public int Value {get; set;}  //int(4) not null
        [Column(_Label, CType.NVarChar, Nullable = true, Length = 100)]                       public string Label {get; set;} //nvarchar(100) null

#pragma warning restore

        public dictEnumTypeDpo()
        {
        }

        public dictEnumTypeDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public dictEnumTypeDpo(string category, string feature)
        {
           this.Category = category; this.Feature = feature; 

           this.Load();
           if(!this.Exists)
           {
              this.Category = category; this.Feature = feature;     
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
                return new PrimaryKeys(new string[]{ _Category, _Feature });
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
              return new dictEnumTypeDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Category = "Category";
        public const string _Feature = "Feature";
        public const string _Value = "Value";
        public const string _Label = "Label";

       
        #endregion 



    }
}

