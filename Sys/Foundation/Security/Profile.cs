using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Text;
using Tie;
using Sys.Data;
using Sys.Data.Manager;
using Sys.Foundation.DpoClass;

namespace Sys.Security
{
    public class Profile : Sys.ApplicationContext 
    {
        string configuration;

        private Profile()
        {
        }

        public static new Profile Instance
        {
            get
            {
                if (Profile.self == null)
                    Profile.self = new Profile();

                return (Profile) Profile.self;
            }
        }

        public override void Save()
        {
            VAL v = new VAL();
            foreach (KeyValuePair<string, VAL> pair in memory.DS)
            {
                if (pair.Value.IsHostType)
                    continue;
                v[pair.Key] = pair.Value;
            }

            UserProfileDpo dpo = new UserProfileDpo();
            
            dpo.User_ID = ActiveAccount.Account.UserID;
            dpo.Setting = v.ToJson();
            dpo.Configuration = configuration;
            dpo.Save();
        }

        public override void Load()
        {
            UserProfileDpo dpo = new UserProfileDpo();
            dpo.User_ID = ActiveAccount.Account.UserID; ;
            dpo.Load();

            if (dpo.Exists)
            {
                this.configuration = dpo.Configuration;

                if (dpo.Setting != "")
                {
                    try
                    {
                        VAL v = Script.Evaluate(dpo.Setting);
                        memory = (Memory)v;
                    }
                    catch (Exception)
                    {
                        dpo.Delete();
                    }
                }
            }
        }


        public byte[] Configuration
        {

            get
            {
                if(configuration ==null || configuration =="")
                    return null;
                
                return HostType.HexStringToByteArray(configuration); 
            }
            set
            {
                if (value != null)
                    configuration = HostType.ByteArrayToHexString(value);
                else
                    configuration = null;
            }
        }

     
    }
}
