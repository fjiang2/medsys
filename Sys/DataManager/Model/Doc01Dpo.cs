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
    public class Doc01Dpo : sysDOC01Dpo
    {
        private Doc02Dpo latestVersion;

        public Doc01Dpo()
        {
            this.Owner = Sys.Security.Account.CurrentUser.User_ID;
        }

        public Doc01Dpo(DataRow dataRow)
            :base(dataRow)
        {
        }

        public Doc01Dpo(DPObject dpo, string fileName)
        {
            this.Table_Id = dpo.TableId;
            this.Row_Id = dpo.RowId;
            this.File_Name = fileName;
            
            this.Load();

            if(Exists)
                latestVersion = Doc02Dpo.GetLatestVersion(this);

        }

        public override void Fill(DataRow dataRow)
        {
            base.Fill(dataRow);

            if (dataRow.RowState != DataRowState.Added)
            {
                latestVersion = Doc02Dpo.GetLatestVersion(this);
            }
        }


        public void AddDocument(RowDocument document)
        {
            this.Table_Id = document.RowObject.TableId;
            this.Table_Name = document.RowObject.TableName.FullName;
            this.Row_Id = document.RowObject.RowId;

            this.File_Name = document.FileName;
            this.Label = document.Description;
            

            this.Save();
            Doc02Dpo version = new Doc02Dpo();
            version.AddVersion(this);

            DocumentMan man = new DocumentMan(version.Doc_Name, document);
            man.Save();
        }

        public void DeleteDocument()
        {
            string tableName = Doc02Dpo.TABLE_NAME;
            DataTable dt = SqlCmd.FillDataTable("SELECT * FROM {0} WHERE Doc_Id={1}", tableName, this.ID);

            foreach (DataRow row in dt.Rows)
            {
                Doc02Dpo doc = new Doc02Dpo(row);
                DocumentMan man = new DocumentMan(doc.Doc_Name, new Document(this.File_Name));
                man.Delete();
            }

            SqlCmd.ExecuteScalar("DELETE FROM {0} WHERE Doc_Id={1}", tableName, this.ID);

            this.Delete();
        }


        public VersionDocument LatestDocument
        {
            get
            {
                return new VersionDocument(latestVersion.Doc_Name, File_Name, Label, latestVersion.Version);
            }

        }

        public static VersionDocument GetDocument(RowDocument document)
        {
            Doc01Dpo dpo = new Doc01Dpo(document.RowObject, document.FileName);
            if (!dpo.Exists)
                return null;

            return dpo.LatestDocument;
        }


      
     
    }
}
