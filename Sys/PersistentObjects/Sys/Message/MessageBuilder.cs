using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    public class MessageBuilder : List<Message>
    {
        public MessageBuilder()
        { 
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Message message in this)
            {
                builder.AppendLine(message.ToString());
            }

            return builder.ToString();
        }
    }
}
