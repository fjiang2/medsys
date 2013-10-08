using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Sys.DataManager
{
    public class LetterDirectory : IDirectory
    {

        private string VIRTUAL_DIRECTORY = null;
        private string letters;


     
        public LetterDirectory(string virtualDirectory, string letters)
        {
            VIRTUAL_DIRECTORY = Sys.Configuration.Instance.GetValue<string>(virtualDirectory);
            this.letters = letters;
        }

        public virtual string PhysicalDirectory
        {
            get
            {
                if(letters.Length >= 3)
                    return string.Format("{0}\\{1}\\{2}\\{3}", VIRTUAL_DIRECTORY, letters[0], letters[1], letters[2]);
                else if(letters.Length ==2)
                    return string.Format("{0}\\{1}\\{2}", VIRTUAL_DIRECTORY, letters[0], letters[1]);
                else
                    return string.Format("{0}\\{1}", VIRTUAL_DIRECTORY, letters[0]);
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
