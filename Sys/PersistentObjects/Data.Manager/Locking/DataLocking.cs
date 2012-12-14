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
using System.Text;

namespace Sys.Data.Manager
{
    public class DataLocking  
    {
        private LockDpo locker;

        public DataLocking(ILockable obj)
        {
            this.locker = new LockDpo(obj);
        }

        /// <summary>
        /// Is it locked?
        /// </summary>
        public bool Locked
        {
            get
            {
                return locker.Locked;
            }
        }

        /// <summary>
        /// When it is locked?
        /// </summary>
        public DateTime? TimeCheckedOut
        {
            get
            {
                return this.locker.CO_Time;
            }
        }

        /// <summary>
        /// How long it is locked?
        /// </summary>
        public TimeSpan TimeSpanCheckedOut
        {
            get
            {
                return DateTime.Now - (DateTime)TimeCheckedOut;
            }
        }

        /// <summary>
        /// How long it is locked since last accessed
        /// </summary>
        public TimeSpan TimeSpanSinceLastAccess
        {
            get
            {
                return DateTime.Now - (DateTime)locker.Last_Access_Time;
            }
        }

        /// <summary>
        /// Who locked it?
        /// </summary>
        public int CheckedOutBy
        {
            get
            {
                return this.locker.CO_User_ID;
            }
        }

        public void PolishLock()
        {
            this.locker.PolishLock();
        }

        /// <summary>
        /// Is it locked by me?
        /// </summary>
        public bool MyLocked
        {
            get
            {
                return this.Locked && this.locker.CO_User_ID == Active.Account.UserID;
            }
        }
        
        /// <summary>
        /// It is locked by others, not me?
        /// </summary>
        public bool OtherLocked
        {
            get
            {
                return this.Locked && this.locker.CO_User_ID != Active.Account.UserID;
            }
        }

        public void CheckOutByMe()
        {
            locker.CheckOut(Active.Account.UserID);
        }

        public void CheckOut(int userID)
        {
            locker.CheckOut(userID);
        }

        public int CheckInByMe()
        {
            return locker.CheckIn(Active.Account.UserID);
        }

        public int CheckIn(int userID)
        {
            return locker.CheckIn(userID);
        }

        public int MustCheckIn()
        {
            return locker.MustCheckIn(Active.Account.UserID);
        }

        public override string ToString()
        {
            return locker.ToString();
        }


        public static DataLocking CheckOut(ILockable obj)
        {
            DataLocking theLock = new DataLocking(obj);
            theLock.CheckOutByMe();
            return theLock;
        }

        public static DataLocking CheckIn(ILockable obj)
        {
            DataLocking theLock = new DataLocking(obj);
            theLock.CheckInByMe();
            return theLock;
        }

        public static DataLocking MustCheckIn(ILockable obj)
        {
            DataLocking theLock = new DataLocking(obj);
            theLock.MustCheckIn();
            return theLock;
        }

        public static DataLocking PolishLock(ILockable obj)
        {
            DataLocking theLock = new DataLocking(obj);
            theLock.PolishLock();
            return theLock;
        }
      

    }
}

