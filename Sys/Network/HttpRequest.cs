using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;
using System.Runtime.Serialization.Json;

namespace Sys.Network
{
    public static class HttpRequest
    {
        public static T HttpPost<T>(Uri uri, long size, Action<Stream> requestWriter, Func<Stream, T> responseReader)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            //request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = size;

            if (requestWriter != null)
            {
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestWriter(requestStream);
                }
            }

            if (responseReader != null)
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                try
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        T result = responseReader(responseStream);
                        return result;
                    }
                }
                finally
                {
                    response.Close();
                }
            }

            return default(T);
        }


        public static T HttpGet<T>(Uri uri, Func<Stream, T> responseReader)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            try
            {
                Stream responseStream = response.GetResponseStream();
                try
                {
                    T result = responseReader(responseStream);
                    return result;
                }
                finally
                {
                    responseStream.Close();
                }
            }
            finally
            {
                response.Close();
            }
        }


        private static T HttpGetReader<T>(Uri uri, Func<StreamReader, T> responseReader)
        {
            return HttpGet<T>(uri, responseStream =>
            {
                using (StreamReader streamReader = new StreamReader(responseStream))
                {
                    T result = responseReader(streamReader);
                    return result;
                }
            });
        }


        public static DataSet ReadXml(Uri uri)
        {
            return HttpGetReader<DataSet>(uri, reader =>
            {
                DataSet ds = new DataSet();
                ds.ReadXml(reader, XmlReadMode.ReadSchema);
                return ds;
            });
        }

        public static DataSet ReadXml(Uri uri, string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            return HttpPost<DataSet>(uri, bytes.Length,
                  requestStream =>
                  {
                      requestStream.Write(bytes, 0, bytes.Length);
                  },

                  responseStream =>
                  {
                      DataSet ds = new DataSet();
                      using (StreamReader streamReader = new StreamReader(responseStream))
                      {
                          ds.ReadXml(streamReader, XmlReadMode.ReadSchema);
                      }
                      return ds;
                  }

             );

        }

        public static T ReadJson<T>(Uri uri, string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            return HttpPost<T>(uri, bytes.Length,
                  requestStream =>
                  {
                      requestStream.Write(bytes, 0, bytes.Length);
                  },

                  responseStream =>
                  {
                      DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                      return (T)serializer.ReadObject(responseStream);
                  }

             );

        }

        public static string DownloadTextFile(Uri uri)
        {
            return HttpGetReader<string>(uri, reader => reader.ReadToEnd());
        }


        public static void DownloadBinaryFile(string localFile, Uri downloaduri, int size)
        {
            HttpGet<object>(downloaduri, responseStream =>
            {
                using (FileStream fstream = new FileStream(localFile, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    byte[] inData = new byte[size];
                    int bytesRead = responseStream.Read(inData, 0, inData.Length);
                    fstream.Write(inData, 0, bytesRead);

                    while (bytesRead < size)
                    {
                        int moreBytes = responseStream.Read(inData, 0, inData.Length);
                        fstream.Write(inData, 0, moreBytes);

                        bytesRead += moreBytes;

                    }

                    return null;
                }

            });
        }




        public static void UploadBinaryFile(string localFile, Uri uploaduri)
        {
            byte[] bytes = ReadFileToBytes(localFile);

            HttpPost<object>(uploaduri, (long)bytes.Length, requestStream => requestStream.Write(bytes, 0, bytes.Length), null);

        }


        private static byte[] ReadFileToBytes(string fileName)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            StreamReader streamReader = new StreamReader(fileName);
            BinaryReader binaryReader = new BinaryReader(streamReader.BaseStream, encoding);
            FileInfo fileInfo = new FileInfo(fileName);
            byte[] bytes = binaryReader.ReadBytes((int)fileInfo.Length);
            binaryReader.Close();
            return bytes;
        }


    }
}
