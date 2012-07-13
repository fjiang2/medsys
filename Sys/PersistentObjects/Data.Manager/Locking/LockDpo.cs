using System;
using System.Collections.Generic;
using System.Text;
using Sys.Data;
using Sys.PersistentObjects.Dpo;

namespace Sys.Data.Manager
{
    class LockDpo : RecordLockDpo
    {
        ILockable obj;
        
        public LockDpo(ILockable obj)
        {
            this.obj = obj;

            this.Ty = obj.LockType;
            this.LockID = obj.LockID;
            Load();

            //in case of RECORD not existed
            this.Ty = obj.LockType;
            this.LockID = obj.LockID;
        }

        public override Locator Locator
        {
            get
            {
                return new Locator("Ty=@Ty AND LockID=@LockID AND CI_Time IS NULL");
            }
        }

        public bool Locked
        {
            get
            {
                return CO_Time != null && CI_Time == null;
            }
        }

     
        public void CheckOut(int userID)
        {
            if (Locked)
                return;
            
            this.Ty = obj.LockType;
            this.LockID = obj.LockID;

            this.CO_User_ID = userID;
            this.CO_Time = DateTime.Now;
            this.CI_Time = null;
            this.Last_Access_Time = this.CO_Time;
            Save();
        }


        public int MustCheckIn(int userID)
        {
            if (!Locked)                //the task is not checked out
                return this.ID;
           
            this.Ty = obj.LockType;
            this.LockID = obj.LockID;

            this.CI_User_ID = userID;
            this.CI_Time = DateTime.Now;
            this.Last_Access_Time = (DateTime)this.CI_Time;
            Save();

            return this.ID;
        }

        public int CheckIn(int userID)
        {

            if (this.CO_User_ID != 0 && this.CO_User_ID != userID)
                throw new ApplicationException("cannot check in other's check out");

            return MustCheckIn(userID);
        }

        public void PolishLock()
        {
            if (Locked)
                return;
            
            SqlCmd.ExecuteScalar("UPDATE {0} SET {1} = getdate() WHERE {2} = {3}", TableName, _Last_Access_Time,  _ID, this.ID);
        }

        public override string ToString()
        {
            return string.Format("Lock(ID={0}, Type={1}, LockID={2}, UserID={3}, Time={4})", this.ID, this.Ty, this.LockID, this.CO_User_ID, this.CO_Time);
        }
    }
}

