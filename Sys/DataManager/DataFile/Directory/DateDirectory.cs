using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Sys.DataManager
{
    public class DateDirectory : IDirectory
    {

        private string VIRTUAL_DIRECTORY = null;
        private DateTime dateCreated;

        public DateDirectory(string virtualDirectory)
            : this(virtualDirectory, DateTime.Today)
        { 
        
        }
        
        public DateDirectory(string virtualDirectory, DateTime dateCreated)
        {
            VIRTUAL_DIRECTORY = (string)Sys.Configuration.Instance[virtualDirectory];
            this.dateCreated = dateCreated;
        }

        public DateTime DateCreated
        {
            get
            {
                return this.dateCreated;
            }
            set
            {
                this.dateCreated = value;
            }
        }

        public string PhysicalDirectory
        {
            get
            {
                return string.Format("{0}\\{1}\\{2}\\{3}", VIRTUAL_DIRECTORY, dateCreated.Year, dateCreated.Month, dateCreated.Day);
            }
        }

        public string GetFilePath(string fileName)
        {
            string folder = PhysicalDirectory;
            
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            return string.Format("{0}\\{1}", folder, fileName);
        }

    
     
    }
}
