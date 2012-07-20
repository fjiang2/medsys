using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Sys.IO
{
    public class File
    {
        public static void CreateFile(string fileName, byte[] buffer)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Create);
            BinaryWriter binaryWriter = new BinaryWriter(fileStream);
            binaryWriter.Write(buffer);
            binaryWriter.Flush();
            fileStream.Close();

        }

        public static void OpenBufferedFile(byte[] buffer, string ext)
        {
            string fileName = System.IO.Path.GetTempFileName() + "." + ext;
            CreateFile(fileName, buffer);
            ExecuteFile(fileName);
        }


        public static void BackupFile(string prefix, string ext, string text)
        {
            WriteFile(string.Format("{0}#{1:yyyy.mm.dd-hhmmss}.{2}", prefix, DateTime.Now, ext), text);
        }
        
        public static void WriteFile(string fileName, string text)
        {
            string path = System.IO.Path.GetDirectoryName(fileName);
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            StreamWriter sw = new StreamWriter(fileName);
            sw.Write(text);
            sw.Close();
        }

      
        public static void ExecuteFile(string fileName)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.EnableRaisingEvents = false;
            process.StartInfo.FileName = fileName;
            process.Start();
        }

        public static void ExecuteFile(string application, string arguments)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.EnableRaisingEvents = false;
            process.StartInfo.FileName = application;
            //process.StartInfo.FileName = "C:\\Program Files\\Adobe\\Reader 8.0\\Reader\\AcroRd32.exe";
            process.StartInfo.Arguments = arguments;
            process.Start();
        }
    }
}
