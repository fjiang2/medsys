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
    [Revision(13)]
    [Table("sys00301", Level.System, Pack = false)]    //Primary Keys = date + form_name;  Identity = log_dataset_id;
    public class logDataSetDpo : DPObject
    {

#pragma warning disable

        [Column(_log_dataset_id, CType.Int, Identity = true)]                                 public int log_dataset_id {get; set;} //int(4) not null
        [Column(_form_name, CType.VarChar, Primary = true, Length = 128)]                     public string form_name {get; set;} //varchar(128) not null
        [Column(_date, CType.DateTime, Primary = true)]                                       public DateTime date {get; set;} //datetime(8) not null
        [Column(_user_id, CType.Int)]                                                         public int user_id {get; set;} //int(4) not null
        [Column(_machine_name, CType.VarChar, Nullable = true, Length = 128)]                 public string machine_name {get; set;} //varchar(128) null

#pragma warning restore

        public logDataSetDpo()
        {
        }

        public logDataSetDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public logDataSetDpo(DateTime date, string form_name)
        {
           this.date = date; this.form_name = form_name; 

           this.Load();
           if(!this.Exists)
           {
              this.date = date; this.form_name = form_name;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.log_dataset_id;
            }
        }



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _date, _form_name });
            }
        }



        public override IIdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _log_dataset_id });
            }
        }



        #region CONSTANT

        public const string _log_dataset_id = "log_dataset_id";
        public const string _form_name = "form_name";
        public const string _date = "date";
        public const string _user_id = "user_id";
        public const string _machine_name = "machine_name";

       
        #endregion 



    }
}

