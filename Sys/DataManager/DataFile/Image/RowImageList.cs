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
    public class RowImageList
    {
        DPObject rowObject;
        DataTable dt;
        
        /// <summary>
        /// Load images
        /// </summary>
        /// <param name="dpo"></param>
        public RowImageList(DPObject rowObject)
        {
            this.rowObject = rowObject;
            if(rowObject.RowId != -1)
                //"Table_id={0} AND Row_ID = {1}"
                dt = new TableReader<PictureDpo>(
                   (PictureDpo._Table_Id.ColumnName() == rowObject.TableId) 
                   .AND(PictureDpo._Row_Id.ColumnName() == rowObject.RowId)).Table;
            else
                //"Table_id={0} AND Row_ID = -1 AND Owner = {1}"
                dt = new TableReader<PictureDpo>(
                    (PictureDpo._Table_Id.ColumnName() == rowObject.TableId)
                    .AND(PictureDpo._Row_Id.ColumnName() == -1)
                    .AND(PictureDpo._Owner.ColumnName() == Sys.Security.Account.CurrentUser.UserID)).Table;
        }


        public DataTable DataTable
        {
            get
            {
                dt.Columns.Add(new DataColumn(PictureDpo._Image, typeof(Image)));

                DPCollection<PictureDpo> pictures = new DPCollection<PictureDpo>(dt);

                if (pictures.Count == 0)
                    return null;

                foreach (DataRow row in dt.Rows)
                {
                    row[PictureDpo._Image] = pictures[row].Image;
                }

                return dt;
            }
        }

        public Image[] Images
        {
            get
            {
                DPCollection<PictureDpo> pictures = new DPCollection<PictureDpo>(dt);


                List<Image> images = new List<Image>();
                if (pictures.Count != 0)
                {
                    foreach (PictureDpo a in pictures)
                    {
                        images.Add(a.Image);
                    }
                }
                return images.ToArray();
            }
        }


        private int index = 0;
        public Image NextImage()
        {
            if (index >= dt.Rows.Count)
                return null;
            
            PictureDpo pic = new PictureDpo(dt.Rows[index]);
            index++;
            return pic.Image;
        }

        public Image PrevImage()
        {
            if (index < 0)
                return null;

            PictureDpo pic = new PictureDpo(dt.Rows[index]);
            index--;
            return pic.Image;
        }


    

        public DataRow AddImage(Image image)
        {
            PictureDpo pic = new PictureDpo(rowObject, image);
            pic.Save();
            int id = pic.ID;
            
            pic = new PictureDpo();
            pic.ID = id;
            DataRow src = pic.Load();
            DataRow dst = dt.NewRow();
            src.CopyTo(dst);
            dt.Rows.Add(dst);
            
            return dst;
        }


        public void AcceptChanges()
        {
            AcceptTempImages(rowObject);
        }
        
        public void RejectChanges()
        {
            DeleteTempImages(rowObject);
        }


        public static void AcceptTempImages(DPObject rowObject)
        {
            TableName tableName = typeof(PictureDpo).TableName();

            //potential bug, one user may open 1+ Image Windows
            
            //SqlCmd.ExecuteScalar(
            //    tableName.Provider,
            //    "UPDATE {0} SET Row_Id={1} WHERE Table_Id={2} AND Row_Id = -1 AND Owner = {3}",
            //    tableName.FullName,
            //    rowObject.RowId,
            //    rowObject.TableId,
            //    Sys.Security.Account.CurrentUser.User_ID
            //    );

            new SqlBuilder()
                .UPDATE<PictureDpo>()
                .SET(PictureDpo._Row_Id.ColumnName() == rowObject.RowId)
                .WHERE(
                    (PictureDpo._Table_Id.ColumnName() == rowObject.TableId)
                    .AND(PictureDpo._Row_Id.ColumnName() == -1)
                    .AND(PictureDpo._Owner.ColumnName() == Sys.Security.Account.CurrentUser.User_ID)
                )
               .SqlCmd
               .ExecuteNonQuery();
        }

        public static void DeleteTempImages(DPObject rowObject)
        {
            var list = new TableReader<PictureDpo>(
                        (PictureDpo._Table_Id.ColumnName() == rowObject.TableId)
                        .AND(PictureDpo._Row_Id.ColumnName() == -1)
                        .AND(PictureDpo._Owner.ColumnName() == Sys.Security.Account.CurrentUser.User_ID)
                        ).ToList();


            foreach (var pic in list)
            {
                ImageMan man = new ImageMan(pic.File_Name, (DateTime)pic.Date_Created);
                man.Delete();
            }

            //SqlCmd.ExecuteScalar(
            //    tableName.Provider,
            //    "DELETE FROM {0} WHERE Table_Id={1} AND Row_Id = -1 AND Owner = {2}", 
            //    tableName.FullName, 
            //    rowObject.TableId, 
            //    Sys.Security.Account.CurrentUser.User_ID);

            (PictureDpo._Table_Id.ColumnName() == rowObject.TableId)
                .AND(PictureDpo._Row_Id.ColumnName() == -1)
                .AND(PictureDpo._Owner.ColumnName() == Sys.Security.Account.CurrentUser.User_ID).Delete<PictureDpo>();
        }
    }
}
