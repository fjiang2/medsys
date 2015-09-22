using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using agsXMPP;
using agsXMPP.protocol.client;
using Tie;
using Sys.ViewManager;
using Sys.Security;
using Sys.Data;
using Sys.PersistentObjects.DpoClass;
using Sys.ViewManager.Security;
using Sys.Foundation.DpoClass;


namespace Sys.Xmpp
{

    public class XmppChannel 
    {
        private int channelID;                  
        private string label;            

        private UserCollectionProtocol subscribers = new UserCollectionProtocol();

        public XmppChannel(int channelID, string label)
        {
            this.channelID = channelID;
            this.label = label;
            GetSubscribers();
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", channelID, label);
        }

        public UserCollectionProtocol Subscribers
        {
            get { return this.subscribers; }
        }

        private void GetSubscribers()
        {
            string SQL = @"
				SELECT DISTINCT 
                    U.User_Name,
                    U.User_ID,
                    U.First_Name + ' '+ U.Last_Name AS Full_Name
                FROM {0} IP
                INNER JOIN {1} UR ON UR.Role_ID = IP.Role_ID
                INNER JOIN {2} U ON U.User_ID = UR.User_ID AND Inactive = 0
                WHERE Ty={3} AND ID= {4}
            ";

            DataTable dataTable = DataExtension.FillDataTable<Sys.ViewManager.DpoClass.ItemPermissionDpo>(SQL,
                Sys.ViewManager.DpoClass.ItemPermissionDpo.TABLE_NAME, UserRoleDpo.TABLE_NAME, UserDpo.TABLE_NAME,
                (int)SecurityType.Workflow, channelID);
            subscribers = new UserCollectionProtocol(dataTable);
        }


        //userList = {1227,585,....}
        public static UserCollectionProtocol GetUserList(VAL userIDList)
        {
            if (userIDList.Size == 0)
                return new UserCollectionProtocol();
            ;
            string SQL = @"
				SELECT DISTINCT 
                    U.User_Name,
                    U.User_ID,
                    U.First_Name + ' '+ U.Last_Name AS Full_Name
                FROM {0} U
                WHERE U.User_ID IN ({1})
            ";

            DataTable dataTable = DataExtension.FillDataTable<UserDpo>(SQL,
                UserDpo.TABLE_NAME,
                userIDList.ToString().Replace("{","").Replace("}","")
                );
            return new UserCollectionProtocol(dataTable);
        }

   


    }
}
