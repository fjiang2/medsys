using System;
using System.Collections.Generic;
using System.Text;
using Tie;

namespace Sys.Data
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class AssociationAttribute : NonValizedAttribute
    {
        private Locator locator = null;
        public string OrderBy;

        public AssociationAttribute(string stringCollectionLocator)
        {
            this.locator = new Locator(stringCollectionLocator);
            this.locator.Unique = false;

            this.OrderBy = "";
        }


        public Locator Locator
        {
            get
            {
                 return this.locator;
            }
        }
    }

   
}
