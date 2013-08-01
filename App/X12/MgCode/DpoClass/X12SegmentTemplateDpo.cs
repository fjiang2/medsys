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


namespace X12.DpoClass
{
    [Revision(7)]
    [Table("X12SegmentTemplate", Level.System)]    //Primary Keys = Name;  Identity = ID;
    public class X12SegmentTemplateDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true)]                                             public int ID {get; set;}     //int(4) not null
        [Column(_Name, CType.VarChar, Primary = true, Length = 10)]                           public string Name {get; set;} //varchar(10) not null
        [Column(_Description, CType.VarChar, Nullable = true, Length = 250)]                  public string Description {get; set;} //varchar(250) null
        [Column(_Purpose, CType.VarChar, Length = 1000)]                                      public string Purpose {get; set;} //varchar(1000) not null
        [Column(_Notes, CType.VarChar, Length = 4000)]                                        public string Notes {get; set;} //varchar(4000) not null
        [Column(_Syntax, CType.VarChar, Nullable = true, Length = 4000)]                      public string Syntax {get; set;} //varchar(4000) null
        [Column(_Script, CType.NText, Nullable = true)]                                       public string Script {get; set;} //ntext(16) null

#pragma warning restore

        public X12SegmentTemplateDpo()
        {
        }

        public X12SegmentTemplateDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public X12SegmentTemplateDpo(string name)
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
                return this.ID;
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
                return new IdentityKeys(new string[]{ _ID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new X12SegmentTemplateDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Name = "Name";
        public const string _Description = "Description";
        public const string _Purpose = "Purpose";
        public const string _Notes = "Notes";
        public const string _Syntax = "Syntax";
        public const string _Script = "Script";

       
        #endregion 



    }
}

