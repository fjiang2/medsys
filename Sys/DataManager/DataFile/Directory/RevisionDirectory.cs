using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Sys.DataManager
{
    public class RevisionDirectory : LetterDirectory
    {

        int revision;

        public RevisionDirectory(string virtualDirectory, FileRevision file)
            :base(virtualDirectory, file.FileName)
        {
            this.revision = file.Revision;
        }

        public override string PhysicalDirectory
        {
            get
            {
                return string.Format("{0}\\Rev{1}", base.PhysicalDirectory, this.revision);
            }
        }

    
     
    }
}
