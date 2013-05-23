using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.Text.RegularExpressions;
using Sys.ViewManager.Forms;
using Tie;

namespace Sys.Platform.Forms
{
    public partial class SendMailForm : BaseForm
    {
        static bool mailSent = false;
      
        SmtpClient client;
        MailAddress from;
        MailMessage message;

        public SendMailForm()
        {
            InitializeComponent();


            VAL smtp = Configuration.Instance.GetValue("server.smtp");
            string smtpServer = (string)smtp["host"];
            int smtpPort = (int)smtp["port"];
            bool ssl = (bool)smtp["ssl"];
        
            client = new SmtpClient(smtpServer, smtpPort);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(account.Email, account.Plain_Password);
            client.EnableSsl = ssl;
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

            message = new MailMessage();
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.BodyEncoding = System.Text.Encoding.UTF8;

            AddFrom(account.Name, account.Email);
        }

        public string Host
        { set { client.Host = value; } }

        public int Port
        { set { client.Port = value; } }



        public string To
        {
            get { return tbTO.Text; }
            set { tbTO.Text = value; }
        }

        public string From
        {
            get { return tbFrom.Text; }
            set { tbFrom.Text = value; }
        }

        public string Cc
        {
            get { return tbCC.Text; }
            set { tbCC.Text = value; }
        }

        public string Subject
        {
            get { return tbSubject.Text; }
            set { tbSubject.Text = value; }
        }

        public string Attachment
        {
            get { return this.tbAttachement.Text; }
            set { tbAttachement.Text = value; }
        }

        public string Body
        {
            get { return this.richTextBody.Text; }
            set { this.richTextBody.Text = value; }
        }


        public void AddFrom(string senderName, string emailAddress)
        {
            string senderAddress = emailAddress;
            string displayName = senderName;
            from = new MailAddress(senderAddress, displayName, System.Text.Encoding.UTF8);
            message.From = from;
            tbFrom.Text = encodeMailAddress(from);
        }

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

            string address="";
            string displayName="";
            
            int i = 0;
            int length = emailAddress.Length;
            char ch;

            while(i<length)
            {
                ch = i<length?emailAddress[i++]:'\0';
                switch (ch)
                {
                    case '\0':
                        goto L1;

                    case ' ':
                    case '\t':
                        break;

                    case  '"':
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

            if(address!=null)
                message.To.Add(address);

            return address != null;
        }

        public bool AddBcc(string emailAddress)
        {
            MailAddress address = decodeMailAddress(emailAddress);

            if(address!=null)
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
                showMessage(string.Format("File {0} does not exist.", fileName));
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
                showMessage(string.Format("{0} is illegal email address.", emailAddress));
                return false;
            }

            return true;
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            message.CC.Clear();
            message.Bcc.Clear();
            message.Attachments.Clear();

            string[] to = tbTO.Text.Trim().Split(new char[] { ',' });
            foreach (string x in to)
            {
                if(x.Trim()!="")
                    if(!AddTo(x))
                        return;
            }

            string[] cc = tbCC.Text.Trim().Split(new char[] { ',' });
            foreach (string x in cc)
            {
                if (x.Trim() != "")
                    if (!AddCC(x))
                        return;
            }

            string[] attachment = tbAttachement.Text.Trim().Split(new char[] { ',' });
            foreach (string x in attachment)
            {
                if (x.Trim() != "")
                    if (!AddAttachement(x))
                        return;
            }
            
            message.Body = this.richTextBody.Text;
            message.Subject = this.tbSubject.Text;
            
            
            string userToken = "your message";
            try
            {
                client.SendAsync(message, userToken);
                showMessage("Sending message... ...");
            }

            catch (Exception ex)
            {
                showMessage(ex.Message);
            }
            
           
        }

        private  void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                showMessage("[{0}] send canceled.", token);
            }
            if (e.Error != null)
            {
                MessageBox.Show(string.Format("[{0}] {1}", token, e.Error.ToString()));
            }
            else
            {
                showMessage("Message sent successfully.");
                MessageBox.Show("Message sent out.");
                message.Dispose();
                this.Close();
            }

            mailSent = true;
        }

        private void toolStripButtonSend_Click(object sender, EventArgs e)
        {
            btnSend_Click(sender, e);
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            // If the user canceled the send, and mail hasn't been sent yet,
            // then cancel the pending operation.
            if (mailSent == false)
            {
                client.SendAsyncCancel();
            }
        }

        private void showMessage(string format, params object[] args)
        {
            string s = string.Format(format, args);
            this.toolStripStatusLabel1.Text = s;
        }

        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string[] fileNames = openFileDialog1.FileNames;
            foreach (string fileName in fileNames)
            {
                if (tbAttachement.Text != "")
                    tbAttachement.Text += ",";

                tbAttachement.Text += fileName;
            }
 
        }

        public void send()
        {
            btnSend_Click(this, new EventArgs());
        }
    }
}