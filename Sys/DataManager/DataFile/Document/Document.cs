using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sys.DataManager
{
    public enum FileType
    {
        DOC,
        PDF,
        XLS,
        JPG,
        TIF,
        GIF,
        BMP,
        DWG
    }

    public class Document
    {
        //FileType fileType;

        string path;
        string description;
    

        public Document(string path)
        {
            this.path = path;
            this.description = FileName;
        }

        public Document(string path, string description)
        {
            this.path = path;
            this.description = description;
        }

        public string Path
        {
            get
            {
                return this.path;
            }
        }

        public string FileName
        {
            get
            {
                return System.IO.Path.GetFileName(path); 
            }
        }

        public string Description
        {
            get
            {
                if (this.description != "")
                    return this.description;
                else
                    return FileName;
            }
            set
            {
                this.description = value;
            }
        }

  

        public string Extension
        {
            get
            {
                return System.IO.Path.GetExtension(path); 
            }
        }

        public virtual void Open()
        {
            System.Diagnostics.Process.Start(path);
            //System.Diagnostics.Process p = new System.Diagnostics.Process();
            //p.EnableRaisingEvents = false;
            //p.StartInfo.FileName = "iexplore";
            //p.StartInfo.Arguments = path;
            //p.Start();
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", description, FileName);
        }

    }
}
