using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Data;
using Sys.Data;

namespace Sys.DataManager
{
    public class DocumentList
    {
        DPObject rowObject;
        DataTable dt;
        
        /// <summary>
        /// Load documents
        /// </summary>
        /// <param name="dpo"></param>
        public DocumentList(DPObject rowObject)
        {
            this.rowObject = rowObject;
            
            //"Table_id={0} AND Row_ID = {1}
            dt = new TableReader<Doc01Dpo>(
                Doc01Dpo._Table_Id.ColumName() == rowObject.TableId
                & Doc01Dpo._Row_Id.ColumName() == rowObject.RowId).Table;
        }


        public VersionDocument[] Documents
        {
            get
            {
                DPCollection<Doc01Dpo> dpc = new DPCollection<Doc01Dpo>(dt);

                List<VersionDocument> documents = new List<VersionDocument>();
                if (dpc.Count != 0)
                {
                    foreach (Doc01Dpo a in dpc)
                    {
                        documents.Add(a.LatestDocument);
                    }
                }

                return documents.ToArray();
            }
        }


        public void AddDocument(Document document)
        {
            RowDocument doc = new RowDocument(document, rowObject);
            Doc01Dpo doc1 = new Doc01Dpo();
            doc1.AddDocument(doc);
        }

        public void RemoveDocument(Document document)
        {
            RowDocument doc = new RowDocument(document, rowObject);
            Doc01Dpo doc1 = new Doc01Dpo(rowObject, document.FileName);
            doc1.DeleteDocument();
        }


        public void AcceptChanges()
        {
            AcceptTempDocuments(rowObject);
        }
        
        public void RejectChanges()
        {
            DeleteTempDocuments(rowObject);
        }


        public static void AcceptTempDocuments(DPObject rowObject)
        {
            //potential bug, one user may open 1+ documents Windows
            SqlCmd.ExecuteScalar("UPDATE {0} SET Row_Id={1} WHERE Table_Id={2} AND Row_Id = -1 AND Owner = {3}",
                Doc01Dpo.TABLE_NAME,
                rowObject.RowId,
                rowObject.TableId,
                Sys.Security.Account.CurrentUser.User_ID
                );
        }

        public static void DeleteTempDocuments(DPObject rowObject)
        {
            string tableName = Doc01Dpo.TABLE_NAME;
            DataTable dt = SqlCmd.FillDataTable("SELECT * FROM {0} WHERE Table_Id={1} AND Row_Id = -1 AND Owner = {2}", tableName, rowObject.TableId, Sys.Security.Account.CurrentUser.User_ID);

            foreach (DataRow row in dt.Rows)
            {
                Doc01Dpo doc = new Doc01Dpo(row);
                doc.DeleteDocument();
            }

            SqlCmd.ExecuteScalar("DELETE FROM {0} WHERE Table_Id={1} AND Row_Id = -1 AND Owner = {2}", tableName, rowObject.TableId, Sys.Security.Account.CurrentUser.User_ID);
        }
    }
}
