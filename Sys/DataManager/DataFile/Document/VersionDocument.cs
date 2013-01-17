using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.DataManager
{
    public class VersionDocument : Document
    {
        private int version;
        private string docName;
        private string tempPath;

        internal VersionDocument(string docName, string path, string description, int version)
            : base(path, description)
        {
            this.docName = docName;
            this.version = version;
        }


        public int Version
        {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
            }
        }

        public override void Open()
        {
            DocumentMan man = new DocumentMan(docName, this);
            tempPath = man.Load();
            System.Diagnostics.Process.Start(tempPath); 
        }


        public override string ToString()
        {
            return string.Format("{0} v{1}", base.ToString(), version);
        }

    }
}
