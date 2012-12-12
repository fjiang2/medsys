using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using Tie;
using System.Data;

namespace Sys
{
    public static class SysExtension
    {

   
        public static F[] GetArray<T, F>(this List<T> list, string fieldName)
        {
            FieldInfo fieldInfo = typeof(T).GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            F[] values = new F[list.Count];
            int i = 0;
            foreach (T t in list)
            {
                values[i++] = (F)fieldInfo.GetValue(t);
            }
            return values;
        }

  
      
        public static bool HasAttribute<T>(this Type type) where T : Attribute
        {
            return GetAttributes<T>(type).Length != 0;
        }

        public static T[] GetAttributes<T>(this Type type) where T : Attribute
        {
            return (T[])type.GetCustomAttributes(typeof(T), true);
        }

        public static bool HasInterface<TInterface>(this Type type)
        {
            Type[] I = type.GetInterfaces();
            foreach (Type i in I)
            {
                if (i == typeof(TInterface))
                    return true;
            }

            return false;

        }

        public static Type InnullableType(this Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return type.GetGenericArguments()[0];
            else
                return type;
        }

        public static Assembly[] GetInstalledAssemblies()
        {
            /*
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.GetName().Name.StartsWith("Sys.") || assembly.GetName().Name.StartsWith("App."))
                .ToArray();
            */

            List<Assembly> list = new List<Assembly>();
            string path = Directory.GetCurrentDirectory();
            string[] wildcards = new string[] { "*.dll", "*.exe" };

            foreach (string wildcard in wildcards)
            {
                string[] files = Directory.GetFiles(path, wildcard, SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    try
                    {
                        string f = Path.GetFileNameWithoutExtension(file);
                        Assembly assembly = Assembly.Load(f);
                        
                        string name = assembly.GetName().Name;
                        if(!name.StartsWith("DevExpress"))
                            list.Add(assembly);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return list.ToArray();
        }


        public static void CopyFields(object source, object sink)
        {
            Type t1 = source.GetType();
            Type t2 = sink.GetType();

            FieldInfo[] f2 = t2.GetFields();
            foreach (FieldInfo f in f2)
            {
                FieldInfo f1 = t1.GetField(f.Name);
                if (f1 != null)
                {
                    object val = f1.GetValue(source);
                    f.SetValue(sink, val);
                }
            }
        }


        public static void WriteFile(string fileName, string text)
        {
            string path = System.IO.Path.GetDirectoryName(fileName);
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName);
            sw.Write(text);
            sw.Close();
        }

    }
}
