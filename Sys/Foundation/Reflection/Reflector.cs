using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tie;

namespace Sys
{
    public static class Reflector
    {
    
        public static Type GetType(string typeName)
        {
            return HostType.GetType(typeName);
        }

        public static object NewInstance(string className, object[] constructorargs)
        {
            Type type = Reflector.GetType(className);
            return Activator.CreateInstance(type, constructorargs);
        }

    

        public static object NewInstance(Assembly assembly, string className, object[] constructorargs)
        {
            Type type = assembly.GetType(className);
            if (type == null)
                type = Reflector.GetType(className);
            return Activator.CreateInstance(type, constructorargs);
        }

        public static bool IsAbstractOf<TInterface>(this Type type) 
        {
            Type[] I = type.GetInterfaces();
            foreach (Type i in I)
            {
                if (i == typeof(TInterface))
                    return true;
            }
            
            return false;

        } 
    }
}
