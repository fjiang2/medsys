//
// Machine Generated Code
//   by devel at 6/22/2012 2:14:34 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.DataManager;


namespace X12.Dpo
{
    [Revision(4)]
    [Table("X12SegmentTemplate", Level.System)]    //Primary Keys = Name;  Identity = ID;
    public class X12SegmentTemplateDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true)]                                             public int ID;                //int(4) not null
        [Column(_Name, SqlDbType.VarChar, Primary = true, Length = 10)]                           public string Name;           //varchar(10) not null
        [Column(_Description, SqlDbType.VarChar, Nullable = true, Length = 250)]                  public string Description;    //varchar(250) null
        [Column(_Purpose, SqlDbType.VarChar, Length = 1000)]                                      public string Purpose;        //varchar(1000) not null
        [Column(_Notes, SqlDbType.VarChar, Length = 4000)]                                        public string Notes;          //varchar(4000) not null
        [Column(_Syntax, SqlDbType.VarChar, Nullable = true, Length = 4000)]                      public string Syntax;         //varchar(4000) null
        [Column(_Script, SqlDbType.NText, Nullable = true)]                                       public string Script;         //ntext(16) null

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

