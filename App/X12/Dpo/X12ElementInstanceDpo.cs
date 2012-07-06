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
    [Table("medsys..X12ElementInstance")]    //Primary Keys = ElementTemplate_ID + SegmentInstance_ID;  Identity = ID;
    public class X12ElementInstanceDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true)]                                             public int ID;                //int(4) not null
        [Column(_ElementTemplate_ID, SqlDbType.Int, Primary = true)]                              public int ElementTemplate_ID;//int(4) not null
        [Column(_SegmentInstance_ID, SqlDbType.Int, Primary = true)]                              public int SegmentInstance_ID;//int(4) not null
        [Column(_Usage, SqlDbType.Int)]                                                           public int Usage;             //int(4) not null
        [Column(_Description, SqlDbType.VarChar, Nullable = true, Length = 4000)]                 public string Description;    //varchar(4000) null
        [Column(_Situational_Rule, SqlDbType.VarChar, Nullable = true, Length = 4000)]            public string Situational_Rule;//varchar(4000) null
        [Column(_Code_Definition, SqlDbType.Int)]                                                 public int Code_Definition;   //int(4) not null
        [Column(_Script, SqlDbType.NText, Nullable = true)]                                       public string Script;         //ntext(16) null

#pragma warning restore

        public X12ElementInstanceDpo()
        {
        }

        public X12ElementInstanceDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public X12ElementInstanceDpo(int elementtemplate_id, int segmentinstance_id)
        {
           this.ElementTemplate_ID = elementtemplate_id; this.SegmentInstance_ID = segmentinstance_id; 

           this.Load();
           if(!this.Exists)
           {
              this.ElementTemplate_ID = elementtemplate_id; this.SegmentInstance_ID = segmentinstance_id;     
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
                return new PrimaryKeys(new string[]{ _ElementTemplate_ID, _SegmentInstance_ID });
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
              return new X12ElementInstanceDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _ElementTemplate_ID = "ElementTemplate_ID";
        public const string _SegmentInstance_ID = "SegmentInstance_ID";
        public const string _Usage = "Usage";
        public const string _Description = "Description";
        public const string _Situational_Rule = "Situational_Rule";
        public const string _Code_Definition = "Code_Definition";
        public const string _Script = "Script";

       
        #endregion 



    }
}

