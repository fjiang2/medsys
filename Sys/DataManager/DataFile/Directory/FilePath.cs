using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Sys.DataManager
{
    class FilePath
    {
        /// <summary>
        /// simple file name in server
        /// </summary>
        private string fileName;
        IDirectory directory;

        public FilePath(string fileName, IDirectory directory)
        {
            this.directory = directory;
            this.fileName = fileName;
        }


        protected string Path
        {
            get
            {
                return directory.GetFilePath(fileName);
            }
        }

        protected FileStream FileWriter()
        {
            string path = Path;

            System.IO.FileStream stream;
            if (File.Exists(path))
            {
                stream = new FileStream(path, FileMode.Create);
            }
            else
                stream = new FileStream(path, FileMode.CreateNew);

            return stream;
        }



        protected FileStream FileReader()
        {
            System.IO.FileStream stream = new FileStream(Path, FileMode.Open);

            return stream;
        }

        public void Delete()
        {
            string path = Path;

            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
