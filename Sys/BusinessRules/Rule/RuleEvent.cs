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

        private SeverityLevel severityLevel;
        private string message;
        public Color OriginalColor = Color.Black;

        public RuleEvent(int errorCode, string keyName, SeverityLevel severityLevel, string message)
        {
            this.severityLevel = severityLevel;
            this.keyName = keyName;
            this.message = message;
            this.errorCode = errorCode;
        }

        public RuleEvent(string keyName, SeverityLevel severityLevel, string message)
            :this(-1, keyName, severityLevel , message)
        {
        }

        public void Update(RuleEvent ruleEvent)
        {
            errorCode = ruleEvent.errorCode;
            severityLevel = ruleEvent.SeverityLevel;
            message = ruleEvent.Message;
        }

        public void Clear()
        {
            severityLevel = SeverityLevel.None;
        }

        public SeverityLevel SeverityLevel
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
                case SeverityLevel.None:
                    return "";
                
                case SeverityLevel.Information:
                    level = "Info";
                    break;

                case SeverityLevel.Error:
                    level = "Error";
                    break;
                
                case SeverityLevel.Warning:
                    level = "Warning";
                    break;

                case SeverityLevel.Fatal:
                    level = "Fatal";
                    break;

                case SeverityLevel.Confirmation:
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
                    case SeverityLevel.None:
                        break;

                    case SeverityLevel.Information:
                        return Color.LightBlue;

                    case SeverityLevel.Error:
                        return Color.Red;

                    case SeverityLevel.Warning:
                        return Color.Blue;

                    case SeverityLevel.Fatal:
                        return Color.LightYellow;
                   
                    case SeverityLevel.Confirmation:
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
                if (severityLevel == SeverityLevel.Confirmation)
                    return Confirmed;

                return severityLevel == SeverityLevel.None || severityLevel == SeverityLevel.Warning || severityLevel == SeverityLevel.Information;
            }
        }
       
    }
}
