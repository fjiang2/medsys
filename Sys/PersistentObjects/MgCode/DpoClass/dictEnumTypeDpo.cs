//
// Machine Generated Code
//   by devel at 7/11/2012 9:59:49 AM
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
    [Revision(0)]
    [Table("sys00204", Level.System, Pack = false)]    //Primary Keys = Category + Feature;  Identity = ID;
    public class dictEnumTypeDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true)]                                             public int ID;                //int(4) not null
        [Column(_Category, SqlDbType.VarChar, Primary = true, Length = 50)]                       public string Category;       //varchar(50) not null
        [Column(_Feature, SqlDbType.VarChar, Primary = true, Length = 50)]                        public string Feature;        //varchar(50) not null
        [Column(_Value, SqlDbType.Int)]                                                           public int Value;             //int(4) not null
        [Column(_Label, SqlDbType.NVarChar, Nullable = true, Length = 100)]                       public string Label;          //nvarchar(100) null

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



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Category, _Feature });
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

