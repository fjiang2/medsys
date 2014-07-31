using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Sys.Data
{
    class CustomAttributeProvider
    {
        static Dictionary<Type, Dictionary<PropertyInfo, Attribute[]>> cache = new Dictionary<Type, Dictionary<PropertyInfo, Attribute[]>>();

        public static T[] GetAttributes<T>(PropertyInfo propertyInfo) where T : Attribute
        {
            Dictionary<PropertyInfo, Attribute[]> dict;
            if (cache.ContainsKey(typeof(T)))
            {
                dict = cache[typeof(T)];
            }
            else
            {
                dict = new Dictionary<PropertyInfo, Attribute[]>();
                cache.Add(typeof(T), dict);
            }

            T[] attributes;
            if (dict.ContainsKey(propertyInfo))
            {
                attributes = (T[])dict[propertyInfo];
            }
            else
            {
                attributes = (T[])propertyInfo.GetCustomAttributes(typeof(T), true);
                dict.Add(propertyInfo, attributes);
            }

            return attributes;
        }

    }
}
