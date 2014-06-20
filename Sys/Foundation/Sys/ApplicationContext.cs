using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Text;
using Tie;

namespace Sys
{
    public class ApplicationContext //: IEnumerable
    {
        protected static ApplicationContext self = null;
        protected Memory memory;

        protected ApplicationContext()
        {
            memory = new Memory();
        }
        
        public Memory Memory { get { return memory; } }

        public IEnumerator GetEnumerator()
        {
            return memory.Keys.GetEnumerator();
        }

        public bool ContainsKey(string keyName)
        {
            return memory[keyName].Defined;
        }


        public void  Add(string keyName, object v)
        {
            if (v is byte[])
            {
                memory.Add(keyName, new VAL(StringExtension.ByteArrayToHexString((byte[])v)));
                return;
            }
            else
            {
               memory.Add(keyName, VAL.Boxing(v));
               return;
            }
        }

        //public object this[string key]
        //{
        //    get
        //    {
        //        return memory[key].value;
        //    }
        //}

        public VAL GetValue(string key)
        {
            return memory[key];
        }

        public T GetValue<T>(string key)
        {
            VAL v = memory[key];
            object obj = v.HostValue;
            if (obj != null)
                return (T)obj;
            else
                return default(T);
        }

        public T GetValue<T>(string key, T D)
        {
            VAL v = memory[key];
            object obj = v.HostValue;
            if (obj != null)
                return (T)obj;
            else
                return default(T);
        }

        /*
         *  key="X.a";
         *  
         * */
        public object Evaluate(string key)
        {
            VAL v = Script.Evaluate(key, memory);

            if (v.IsNull)
                return null;
            else
                return v.value;
        }

        public byte[] GetBytesValue(string key)
        {
            if (memory[key].value is string)
            {
                string hexString = memory[key].value as string;
                return StringExtension.HexStringToByteArray(hexString);
            }
            return null;
        }

        public static ApplicationContext Instance
        {
            get
            {
                if (ApplicationContext.self == null)
                    ApplicationContext.self = new ApplicationContext();

                return ApplicationContext.self;
            }
        }

        public virtual void Save()
        {
            VAL v = new VAL();
            foreach (var key in memory.Keys)
            {
                VAL val = memory[key];
                if (val.IsHostType)
                    continue;
                v[(string)key] = val;
            }
        

        }

        public virtual void Load()
        {
        }


        public override string ToString()
        {
            return memory.ToString();
        }
    }
}
