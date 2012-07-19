//
// Machine Generated Code
//   by devel at 7/19/2012 12:12:41 AM
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
    [Revision(11)]
    [Table("sys00403", Level.System)]    //Primary Keys = FormClass;  Identity = ;
    public class FormRuleDpo : DPObject
    {

#pragma warning disable

        [Column(_FormClass, SqlDbType.NVarChar, Primary = true, Length = 256)]                    public string FormClass;      //nvarchar(256) not null
        [Column(_Script, SqlDbType.NText, Nullable = true)]                                       public string Script;         //ntext(16) null
        [Column(_Released, SqlDbType.Bit)]                                                        public bool Released;         //bit(1) not null

#pragma warning restore

        public FormRuleDpo()
        {
        }

        public FormRuleDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public FormRuleDpo(string formclass)
        {
           this.FormClass = formclass; 

           this.Load();
           if(!this.Exists)
           {
              this.FormClass = formclass;     
           }
        }
        


        //must override when logger is used
        protected override int DPObjectId
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        


        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _FormClass });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys();
            }
        }
        

        public static string TABLE_NAME
        { 
            get
            {
              return new FormRuleDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _FormClass = "FormClass";
        public const string _Script = "Script";
        public const string _Released = "Released";

       
        #endregion 



    }
}

