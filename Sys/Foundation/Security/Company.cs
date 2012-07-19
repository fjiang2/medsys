using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Foundation.DpoClass;


namespace Sys.Security
{
    public class Company : CompanyDpo
    {
        public Company()
        { 
        }

        public Company(int comany_id)
            : base(comany_id)
        { 
        }

        public void CreateService(string serviceName, string databaseName)
        {
            this.Name = serviceName;
            this.Default_DB = databaseName;
            this.Inactive = false;

            Save();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
