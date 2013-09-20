//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        DPO(Data Persistent Object)                                                               //
//                                                                                                  //
//          Copyright(c) Datum Connect Inc.                                                         //
//                                                                                                  //
// This source code is subject to terms and conditions of the Datum Connect Software License. A     //
// copy of the license can be found in the License.html file at the root of this distribution. If   //
// you cannot locate the  Datum Connect Software License, please send an email to                   //
// datconn@gmail.com. By using this source code in any fashion, you are agreeing to be bound        //
// by the terms of the Datum Connect Software License.                                              //
//                                                                                                  //
// You must not remove this notice, or any other, from this software.                               //
//                                                                                                  //
//                                                                                                  //
//--------------------------------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    /// <summary>
    /// Singleton collection
    /// </summary>
    public static class Active
    {
        static Dictionary<Type, object> dict;

        static Active()
        {
            dict = new Dictionary<Type, object>();
        }

        private static void Add(Type type, object obj)
        {
            if (dict.ContainsKey(type))
                dict.Remove(type);

            dict.Add(type, obj);
        }

        public static T Set<T>() where T : new()
        {
            T obj = new T();
            Add(typeof(T), obj);
            return obj;
        }

        public static void Set<T>(object obj)
        {
            Add(typeof(T), obj);
        }

        public static void Set(object obj)
        {
            Add(obj.GetType(), obj);
        }

        public static T Get<T>()
        {
            if (dict.ContainsKey(typeof(T)))
                return (T)dict[typeof(T)];
            else
                throw new NotSupportedException("not registered type");
        }
    }
}
