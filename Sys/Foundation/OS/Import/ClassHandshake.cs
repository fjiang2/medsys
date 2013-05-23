using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Sys.Import
{
    public class ClassHandshake
    {
        /**
         * 
         *  class Demo
         *  {
         *      
         *      [MemberParameters("L.Task", "L.Number")]
         *      public Demo(string p1, int p2)
         *      {
         *      
         *      }
         * 
         *  }
         * 
         * 
         * 
         * */
        public static object NewInstance(string className)
        {
            object instance;

            Type ty = Sys.Reflector.GetType(className);
            ConstructorInfo[] constructors = ty.GetConstructors();
            foreach (ConstructorInfo constructorInfo in constructors)
            {
                if (constructorInfo.GetParameters().Length == 0)
                {
                    instance = Activator.CreateInstance(ty, new object[] { });
                    return instance;
                }

                MemberParametersAttribute[] attributes = (MemberParametersAttribute[])constructorInfo.GetCustomAttributes(typeof(MemberParametersAttribute), true);
                foreach (MemberParametersAttribute constructor in attributes)
                {
                    if (constructorInfo.GetParameters().Length != constructor.parameters.Length)
                    {
                        throw new ApplicationException("number of MemberParameters != number of constructor parameters.");
                    }

                    object[] args  =  new object[constructor.parameters.Length];
                    for(int i=0; i<constructor.parameters.Length; i++)
                    {
                        string key = constructor.parameters[i];
                        args[i] = ApplicationContext.Instance.Evaluate(key);
                    }

                    instance = Activator.CreateInstance(ty, args);
                    return instance;
                }
            }

            return null;
        }


        public static PropertyInfoAttribute[] GetPropertyAttributes(object instance)
        {
            List<PropertyInfoAttribute> L = new List<PropertyInfoAttribute>();
            Type ty = instance.GetType();

            PropertyInfo[] properties = ty.GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                PropertyInfoAttribute[] attributes = (PropertyInfoAttribute[])propertyInfo.GetCustomAttributes(typeof(PropertyInfoAttribute), true);
                foreach (PropertyInfoAttribute pa in attributes)
                {
                    pa.propertyInfo = propertyInfo;
                    L.Add(pa);
                }
            }

            return L.ToArray();
        }



    }
}
