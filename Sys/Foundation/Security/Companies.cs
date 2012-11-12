using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data.Manager;
using Sys.PersistentObjects.DpoClass;
using Sys.Data;

namespace Sys.Security
{
    public class Companies
    {
        DPCollection<Company> companies;

        private Companies()
        {
            companies = new DPCollection<Company>(new TableReader<Company>(Company._Inactive.ColumnName() == 0).Table);
        }

        public DPCollection<Company> Collection
        {
            get
            {
                return this.companies;
            }
        }

        public static DPCollection<Company> List
        {
            get
            {
                Companies companies = new Companies();
                return companies.Collection;
            }
        }
    }
}
