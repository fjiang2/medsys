using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tie;

namespace Sys.Platform
{

     public class SendMail
    {
        VAL smtp = Configuration.Instance.GetValue("server.smtp");
        string smtpServer;
        int smtpPort;
        bool ssl;

        SmtpClient client;
        MailMessage message;
        private string _to = string.Empty;
        private string _from = string.Empty;
        private string _cc = string.Empty;
        private string _bcc = string.Empty;
        private string _subject = string.Empty;
        private string _attachment = string.Empty;
        private string _body = string.Empty;
        private string _senderEmail = string.Empty;
        private string _senderName = string.Empty;
        
        public SendMail()
        {
            this.smtpServer = (string)smtp["host"];
            this.smtpPort = (int)smtp["port"];
            this.ssl = (bool)smtp["ssl"];

            client = new SmtpClient(smtpServer, smtpPort);
            client.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

            message = new MailMessage();
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.BodyEncoding = System.Text.Encoding.UTF8;
        }


        #region PROPERTIES
        public string Host
        { 
            set { client.Host = value; } 
        }
        public int Port
        { 
            set { client.Port = value; } 
        }
        public string To
        {
            set { _to = value; }
        }
        private string From
        {
            set { _from = value; }
        }
        private string CC
        {
            set { _cc = value; }
        }
        private string BCC
        {
            set { _bcc = value; }
        }       
        public string Subject
        {
            set { _subject = value; }
        }
        public string Attachment
        {
            set { _attachment = value; }
        }
        public string Body
        {
            set { _body = value; }
        }
        public string SenderName
        {
            set { _senderName = value; }
        }
        public string SenderEmail
        {
            set { _senderEmail = value; }
        }
        #endregion

        private string encodeMailAddress(MailAddress mailAddress)
        {
            if (mailAddress.DisplayName != "")
                return string.Format("\"{0}\"<{1}>", mailAddress.DisplayName, mailAddress.Address);
            else
                return mailAddress.Address;
        }
        //Format: 
        //      "Mike John"<jmike@mail.com>
        //      jmike@mail.com
        //
        private MailAddress decodeMailAddress(string emailAddress)
        {
            emailAddress = emailAddress.Trim();

            string address = "";
            string displayName = "";

            int i = 0;
            int length = emailAddress.Length;
            char ch;

            while (i < length)
            {
                ch = i < length ? emailAddress[i++] : '\0';
                switch (ch)
                {
                    case '\0':
                        goto L1;

                    case ' ':
                    case '\t':
                        break;

                    case '"':
                        ch = i < length ? emailAddress[i++] : '\0';
                        while (ch != '"')
                        {
                            displayName += ch;
                            ch = i < length ? emailAddress[i++] : '\0';
                        }
                        break;

                    case '<':
                        ch = i < length ? emailAddress[i++] : '\0';
                        while (ch != '>')
                        {
                            address += ch;
                            ch = i < length ? emailAddress[i++] : '\0';
                        }
                        break;

                    default:
                        address = emailAddress;
                        i = length;
                        break;
                }
            }

        L1:
            if (isValidEmailAddress(address))
                return new MailAddress(address, displayName, System.Text.Encoding.UTF8);
            else
                return null;
        }


        public bool AddFrom(string senderName, string emailAddress)
        {        
            if (!string.IsNullOrEmpty(emailAddress) && isValidEmailAddress(emailAddress))
            {
                message.From = new MailAddress(emailAddress, senderName, System.Text.Encoding.UTF8);
                return true;
            }
            else
                return false;

        }
        public bool AddTo(string receiverName, string emailAddress)
        {
            if (!isValidEmailAddress(emailAddress))
                return false;

            MailAddress address = new MailAddress(emailAddress, receiverName, System.Text.Encoding.UTF8);
            message.To.Add(address);

            return true;
        }
        public bool AddTo(string emailAddress)
        {
            MailAddress address = decodeMailAddress(emailAddress);

            if (address != null)
                message.To.Add(address);

            return address != null;
        }
        public bool AddBcc(string emailAddress)
        {
            MailAddress address = decodeMailAddress(emailAddress);

            if (address != null)
                message.Bcc.Add(address);

            return address != null;
        }
        public bool AddCC(string emailAddress)
        {
            MailAddress address = decodeMailAddress(emailAddress);

            if (address != null)
                message.CC.Add(address);

            return address != null;
        }
        public bool AddAttachement(string fileName)
        {
            if (!System.IO.File.Exists(fileName))
            {
                MessageBox.Show(string.Format("File {0} does not exist.", fileName));
                return false;
            }

            Attachment data = new Attachment(fileName, MediaTypeNames.Application.Octet);
            // Add time stamp information for the file.
            ContentDisposition disposition = data.ContentDisposition;
            disposition.CreationDate = System.IO.File.GetCreationTime(fileName);
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(fileName);
            disposition.ReadDate = System.IO.File.GetLastAccessTime(fileName);

            message.Attachments.Add(data);

            return true;
        }



        private bool isValidEmailAddress(string emailAddress)
        {
            if (!Regex.IsMatch(emailAddress, @"^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"))
            {
                MessageBox.Show(string.Format("{0} is illegal email address.", emailAddress));
                return false;
            }

            return true;
        }


        public void Send()
        {
            message.CC.Clear();
            message.Bcc.Clear();
            message.Attachments.Clear();

            if (!AddFrom(_senderName, _senderEmail)) return;

            string[] to = _to.Trim().Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string x in to)
            {             
                if (!AddTo(x)) return;
            }

            string[] cc = _cc.Trim().Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string x in cc)
            {                
                if (!AddCC(x)) return;
            }

            string[] bcc = _bcc.Trim().Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string x in bcc)
            {                
                if (!AddBcc(x)) return;
            }

            string[] attachment = _attachment.Trim().Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string x in attachment)
            {
                if (!AddAttachement(x)) return;
            }

            message.Body = _body;
            message.Subject = _subject;


            string userToken = "your message";
            try
            {
                client.SendAsync(message, userToken);
                //showMessage("Sending message... ...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                MessageBox.Show("[{0}] send canceled.", token);
            }
            if (e.Error != null)
            {
                MessageBox.Show(string.Format("[{0}] {1}", token, e.Error.ToString()));
            }
            else
            {
                MessageBox.Show("Message sent.");
                message.Dispose();
            }

           // mailSent = true;
        }

       

       

    }
}
