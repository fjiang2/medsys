using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Data;

namespace Sys.DataManager
{
    class DocumentMan : FilePath
    {
        public const string DOCUMENT_PATH = "Path.Document";
        Document document;
  
        public DocumentMan(string fileName, Document document)
            : base(fileName, new LetterDirectory(DOCUMENT_PATH, document.FileName))
        {
            this.document = document;
        }

        
        public string Load()
        {
            string tempFile = string.Format("{0}{1}", System.IO.Path.GetTempPath(), Guid.NewGuid());
            if (document.Extension != "")
                tempFile = string.Format("{0}{1}", tempFile, document.Extension);
            
            File.Copy(Path, tempFile);
            return tempFile;
        }

        public void Save()
        {
            File.Copy(document.Path, Path);
        }

    }
}
