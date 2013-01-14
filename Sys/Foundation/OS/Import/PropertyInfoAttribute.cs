using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Sys.Import
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class PropertyInfoAttribute : Attribute
    {
        public PropertyInfo propertyInfo;

        public PropertyInfoAttribute()
        {
        }

        public Type Type
        { get { return propertyInfo.PropertyType; } }


    }
}
