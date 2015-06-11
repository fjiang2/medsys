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
            
            dt = new TableReader<Doc01Dpo>(
                (Doc01Dpo._Table_Id.ColumnName() == rowObject.TableId)
                .AND(Doc01Dpo._Row_Id.ColumnName() == rowObject.RowId)).Table;
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
            //TableName tableName = typeof(Doc01Dpo).TableName();

            ////potential bug, one user may open 1+ documents Windows
            //SqlCmd.ExecuteScalar(
            //    tableName.Provider,
            //    "UPDATE {0} SET Row_Id={1} WHERE Table_Id={2} AND Row_Id = -1 AND Owner = {3}",
            //    tableName.FullName,
            //    rowObject.RowId,
            //    rowObject.TableId,
            //    Sys.Security.Account.CurrentUser.User_ID
            //    );

            //potential bug, one user may open 1+ documents Windows
            new SqlBuilder()
            .UPDATE<Doc01Dpo>()
            .SET(Doc01Dpo._Row_Id.ColumnName() == rowObject.RowId)
            .WHERE(
                (Doc01Dpo._Table_Id.ColumnName() == rowObject.TableId)
                .AND(Doc01Dpo._Row_Id.ColumnName() == -1)
                .AND(Doc01Dpo._Owner.ColumnName() == Sys.Security.Account.CurrentUser.User_ID)
                )
             .SqlCmd.ExecuteNonQuery();
        }

        public static void DeleteTempDocuments(DPObject rowObject)
        {
            TableName tableName = typeof(Doc01Dpo).TableName();
            
            DataTable dt = new TableReader<Doc01Dpo>(
                        (Doc01Dpo._Table_Id.ColumnName() == rowObject.TableId)
                        .AND(Doc01Dpo._Row_Id.ColumnName() == -1)
                        .AND(Doc01Dpo._Owner.ColumnName() == Sys.Security.Account.CurrentUser.User_ID)
                        ).Table;

            foreach (DataRow row in dt.Rows)
            {
                Doc01Dpo doc = new Doc01Dpo(row);
                doc.DeleteDocument();
            }

            //SqlCmd.ExecuteScalar(
            //    tableName.Provider,
            //    "DELETE FROM {0} WHERE Table_Id={1} AND Row_Id = -1 AND Owner = {2}", 
            //    tableName, 
            //    rowObject.TableId, 
            //    Sys.Security.Account.CurrentUser.User_ID);

            SqlCmd.Delete<Doc01Dpo>(
                (Doc01Dpo._Table_Id.ColumnName() == rowObject.TableId)
                .AND(Doc01Dpo._Row_Id.ColumnName() == -1)
                .AND(Doc01Dpo._Owner.ColumnName() == Sys.Security.Account.CurrentUser.User_ID)
                );
        }
    }
}
