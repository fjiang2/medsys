using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.DataManager
{
    public class FileRevision
    {
        string fileName;
        int revision;

        public FileRevision(string fileName, int revision)
        {
            this.fileName = fileName;
            this.revision = revision;
        }

        public FileRevision(string fileName)
            : this(fileName, 0)
        { 
        }


        public string FileName
        {
            get
            {
                return this.fileName;
            }
        }

        public int Revision
        {
            get { return this.revision; }
        }

        public override string ToString()
        {
            return string.Format("{0} Rev. {1}", this.fileName, this.revision);
        }
    }
}
