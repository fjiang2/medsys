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


namespace Sys.PersistentObjects.Dpo
{
    [Revision(10)]
    [Table("sys00703", Level.System, Pack = false)]    //Primary Keys = Version;  Identity = ;
    internal class MigrationVersionDpo : DPObject
    {

#pragma warning disable

        [Column(_Version, SqlDbType.BigInt, Primary = true)]                                      public long Version;          //bigint(8) not null

#pragma warning restore

        public MigrationVersionDpo()
        {
        }

        public MigrationVersionDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public MigrationVersionDpo(long version)
        {
           this.Version = version; 

           this.Load();
           if(!this.Exists)
           {
              this.Version = version;     
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
                return new PrimaryKeys(new string[]{ _Version });
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
              return new MigrationVersionDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _Version = "Version";

       
        #endregion 



    }
}

