using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{

    /// <summary>
    /// A locator is template string used in SQL WHERE clause
    /// e.g. ColumnaName1=@ColumnaName1 AND ColumnaName2 IS NULL OR ColumnaName3 >= @ColumnaName4
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class LocatorAttribute : Attribute
    {
        private Locator locator = null;
        public bool Unique = true;

        public LocatorAttribute(string any)
        {
            this.locator = new Locator(any);
            this.locator.Unique = this.Unique;
        }

        public LocatorAttribute(string[] columns)
        {
            this.locator = new Locator(columns);
            this.locator.Unique = this.Unique;
        }

        public Locator Locator
        {
            get 
            {
                return this.locator;
            }
        }

        public override string ToString()
        {
            return this.locator.ToString();
        }

    }
}
