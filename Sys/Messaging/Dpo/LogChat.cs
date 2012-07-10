using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Sys.ViewManager;
using Sys.Security;
using agsXMPP;
using agsXMPP.protocol;
using agsXMPP.protocol.client;
using agsXMPP.Collections;
using Sys.Data;

namespace Sys.Messaging.Dpo
{
    [Locator("User_Name=@User_Name AND Friend_Name=@Friend_Name AND End_Time IS NULL")]
    class LogChat : LogChatDpo 
    {
        public LogChat(Account account, Jid jid)
        {
            this.User_Name = account.UserName;
            this.Friend_Name = jid.User;
            this.Start_Time = DateTime.Now;
        }
        
        public string LatestChat()
        {
            DataRow dataRow = SqlCmd.FillDataRow(@"
                                SELECT * FROM {0}
                                WHERE  User_Name='{1}' 
                                    AND Friend_Name ='{2}' 
	                                AND End_Time = 
	                                ( SELECT TOP 1 End_Time 
	                                    FROM {0} 
	                                    WHERE User_Name='{1}' AND Friend_Name ='{2}'
	                                    ORDER BY End_Time DESC
	                                )
                                ",
                                 this.TableName,
                                 this.User_Name,
                                 this.Friend_Name);

            if (dataRow == null)
                return null;

            string history = string.Format("Last chat({0} - {1})\r\n{2}", dataRow[LogChat._Start_Time], dataRow[LogChat._End_Time], dataRow[LogChat._History]);
            return history;
        }

        public void Save(string history)
        {
            this.End_Time = DateTime.Now;
            this.History = history;
            
            if(history !="")
                this.Save();
        }


    }
}
