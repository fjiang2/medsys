//
// Machine Generated Code
//   by devel at 4/19/2012 5:59:09 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.DataManager;


namespace Sys.ViewManager.Dpo
{
    [Revision(10)]
    [Table("sys00802", Level.System)]    //Primary Keys = ID;  Identity = ID;
    public class AppLinkDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true, Primary = true)]                             public int ID;                //int(4) not null
        [Column(_Label, SqlDbType.NVarChar, Length = 50)]                                         public string Label;          //nvarchar(50) not null
        [Column(_Description, SqlDbType.NVarChar, Nullable = true, Length = 128)]                 public string Description;    //nvarchar(128) null
        [Column(_Command, SqlDbType.NVarChar, Length = 128)]                                      public string Command;        //nvarchar(128) not null
        [Column(_Icon, SqlDbType.Image, Nullable = true)]                                         public byte[] Icon;           //image(16) null
        [Column(_OrderBy, SqlDbType.Int, Nullable = true)]                                        public int? OrderBy;          //int(4) null

        #region IMAGE PROPERTIES
        public Image IconImage
        {
            get
            {
                if (Icon != null)
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(Icon);
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
                    Icon = stream.ToArray();
                }
            }
        }

        #endregion
#pragma warning restore

        public AppLinkDpo()
        {
        }

        public AppLinkDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public AppLinkDpo(int id)
        {
           this.ID = id; 

           this.Load();
           if(!this.Exists)
           {
              this.ID = id;     
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
                return new PrimaryKeys(new string[]{ _ID });
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
              return new AppLinkDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Label = "Label";
        public const string _Description = "Description";
        public const string _Command = "Command";
        public const string _Icon = "Icon";
        public const string _OrderBy = "OrderBy";

       
        #endregion 



    }
}

