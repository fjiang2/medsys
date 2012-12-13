using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    /// <summary>
    /// message list
    /// </summary>
    public class MessageBuilder : List<Message>
    {
        public MessageBuilder()
        { 
        }


        /// <summary>
        /// return all message collected
        /// </summary>
        /// <returns></returns>
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
