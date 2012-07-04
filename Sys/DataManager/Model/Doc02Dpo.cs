using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Data;
using Sys.Data;
using Sys.DataManager.Dpo;


namespace Sys.DataManager
{
    public class Doc02Dpo : sysDOC02Dpo
    {

        public Doc02Dpo()
        {
            this.ID = -1;
            this.Doc_Name = Guid.NewGuid().ToString();
            this.Label = "";
            this.Comment = "";
            this.Date_Modified = DateTime.Now;
            this.User_Id = Sys.Security.Account.CurrentUser.User_ID;

            this.Doc_Id = -1;
            this.Version = 0;
            
        }

        public Doc02Dpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public Doc02Dpo(int docId, int version)
        {
            this.Doc_Id = docId;
            this.Version = version;
            this.Load();
        }
    
        public static Doc02Dpo GetLatestVersion(Doc01Dpo document)
        {
            DataRow dataRow = SqlCmd.FillDataRow("SELECT TOP 1 * FROM {0} WHERE Doc_Id={1} ORDER BY Version DESC", Doc02Dpo.TABLE_NAME, document.ID);
            
            if(dataRow != null)
                return  new Doc02Dpo(dataRow);
            
            return null;
        }

        public static Doc02Dpo GetVersion(Doc01Dpo document, int version)
        {
            Doc02Dpo doc2 = new Doc02Dpo(document.ID, version);

            if (doc2.Exists)
                return doc2;

            return null;
        }

        public void AddVersion(Doc01Dpo document)
        {
            Doc02Dpo latest = GetLatestVersion(document);
            int ver = 0;
            if (latest != null)
                ver = latest.Version;

            this.Doc_Id = document.ID;
            this.Version = ver + 1;
            this.Save();
        }


      
    }
}
