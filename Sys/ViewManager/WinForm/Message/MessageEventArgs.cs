using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.ViewManager.Forms
{
    public delegate void MessageHandler(object sender, MessageEventArgs e);
    public delegate void MessagePlaceHandler(object sender, MessagePlaceEventArgs e);

    public class MessagePlaceEventArgs : EventArgs
    {
        public readonly MessagePlace Place;

        public MessagePlaceEventArgs(MessagePlace place)
        {
            this.Place = place;
        }
    }
}
