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


namespace Sys.ViewManager.DpoClass
{
    [Revision(17)]
    [Table("sys00803", Level.System)]    //Primary Keys = Shortcut;  Identity = ID;
    public class ShortcutDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true)]                                             public int ID {get; set;}     //int(4) not null
        [Column(_Ty, CType.Int)]                                                              public int Ty {get; set;}     //int(4) not null
        [Column(_Shortcut, CType.NVarChar, Primary = true, Length = 150)]                     public string Shortcut {get; set;} //nvarchar(150) not null
        [Column(_Label, CType.NVarChar, Length = 50)]                                         public string Label {get; set;} //nvarchar(50) not null
        [Column(_Description, CType.NVarChar, Nullable = true, Length = 128)]                 public string Description {get; set;} //nvarchar(128) null
        [Column(_Code, CType.NVarChar, Length = 256)]                                         public string Code {get; set;} //nvarchar(256) not null
        [Column(_Icon, CType.Image, Nullable = true)]                                         public byte[] Icon {get; set;} //image(16) null
        [Column(_Help, CType.NText, Nullable = true)]                                         public string Help {get; set;} //ntext(16) null

        #region IMAGE PROPERTIES
        public Image IconImage
        {
            get
            {
                if (Icon != null)
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(Icon);
                    return System.Drawing.Image.FromStream(stream);
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

        public ShortcutDpo()
        {
        }

        public ShortcutDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public ShortcutDpo(string shortcut)
        {
           this.Shortcut = shortcut; 

           this.Load();
           if(!this.Exists)
           {
              this.Shortcut = shortcut;     
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
                return new PrimaryKeys(new string[]{ _Shortcut });
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
              return new ShortcutDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Ty = "Ty";
        public const string _Shortcut = "Shortcut";
        public const string _Label = "Label";
        public const string _Description = "Description";
        public const string _Code = "Code";
        public const string _Icon = "Icon";
        public const string _Help = "Help";

       
        #endregion 



    }
}

