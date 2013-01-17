using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Sys.BusinessRules
{
    class RuleEvent
    {
        private int errorCode;
        public readonly string keyName;

        private MessageLevel severityLevel;
        private string message;
        public Color OriginalColor = Color.Black;

        public RuleEvent(int errorCode, string keyName, MessageLevel severityLevel, string message)
        {
            this.severityLevel = severityLevel;
            this.keyName = keyName;
            this.message = message;
            this.errorCode = errorCode;
        }

        public RuleEvent(string keyName, MessageLevel severityLevel, string message)
            :this(-1, keyName, severityLevel , message)
        {
        }

        public void Update(RuleEvent ruleEvent)
        {
            errorCode = ruleEvent.errorCode;
            severityLevel = ruleEvent.MessageLevel;
            message = ruleEvent.Message;
        }

        public void Clear()
        {
            severityLevel = MessageLevel.None;
        }

        public MessageLevel MessageLevel
        {
            get
            {
                return this.severityLevel;
            }
        }

        public int ErrorCode
        {
            get
            {
                return this.errorCode;
            }
        }



        public string Message
        {
            get
            {
                return this.message;
            }
        }

     

        public override String ToString()
        {
            string level = "";
            switch (severityLevel)
            {
                case MessageLevel.None:
                    return "";
                
                case MessageLevel.Information:
                    level = "Info";
                    break;

                case MessageLevel.Error:
                    level = "Error";
                    break;
                
                case MessageLevel.Warning:
                    level = "Warning";
                    break;

                case MessageLevel.Fatal:
                    level = "Fatal";
                    break;

                case MessageLevel.Confirmation:
                    level = "Confirm";
                    break;
            }
            if(errorCode != -1)
                return String.Format("{0} {1} - {2}", level, errorCode, message);
            else
                return String.Format("{0}: {1}", level, message);

        }

        public Color ErrorColor
        {
            get
            {
                switch (severityLevel)
                {
                    case MessageLevel.None:
                        break;

                    case MessageLevel.Information:
                        return Color.LightBlue;

                    case MessageLevel.Error:
                        return Color.Red;

                    case MessageLevel.Warning:
                        return Color.Blue;

                    case MessageLevel.Fatal:
                        return Color.LightYellow;
                   
                    case MessageLevel.Confirmation:
                        return Color.Brown;
                }

                return OriginalColor;
            }
        }

        public bool Confirmed = false;
        public bool Passed
        {
            get
            {
                if (severityLevel == MessageLevel.Confirmation)
                    return Confirmed;

                return severityLevel == MessageLevel.None || severityLevel == MessageLevel.Warning || severityLevel == MessageLevel.Information;
            }
        }
       
    }
}
