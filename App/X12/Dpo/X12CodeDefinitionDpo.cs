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
using Sys.Data.Manager;


namespace X12.Dpo
{
    [Revision(4)]
    [Table("X12CodeDefinition", Level=Level.System)]    //Primary Keys = Code + ElementInstance_ID;  Identity = ID;
    public class X12CodeDefinitionDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true)]                                             public int ID;                //int(4) not null
        [Column(_ElementInstance_ID, SqlDbType.Int, Primary = true)]                              public int ElementInstance_ID;//int(4) not null
        [Column(_Code, SqlDbType.VarChar, Primary = true, Length = 50)]                           public string Code;           //varchar(50) not null
        [Column(_Definition, SqlDbType.VarChar, Length = 500)]                                    public string Definition;     //varchar(500) not null

#pragma warning restore

        public X12CodeDefinitionDpo()
        {
        }

        public X12CodeDefinitionDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public X12CodeDefinitionDpo(string code, int elementinstance_id)
        {
           this.Code = code; this.ElementInstance_ID = elementinstance_id; 

           this.Load();
           if(!this.Exists)
           {
              this.Code = code; this.ElementInstance_ID = elementinstance_id;     
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
                return new PrimaryKeys(new string[]{ _Code, _ElementInstance_ID });
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
              return new X12CodeDefinitionDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _ElementInstance_ID = "ElementInstance_ID";
        public const string _Code = "Code";
        public const string _Definition = "Definition";

       
        #endregion 



    }
}

