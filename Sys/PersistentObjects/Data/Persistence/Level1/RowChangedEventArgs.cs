using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Sys.Data
{

    public delegate void RowChangedHandler(object sender, RowChangedEventArgs e);

    public class RowChangedEventArgs : EventArgs
    {
        public readonly RowAdapter adapter;
        public readonly ObjectState state;
        public bool confirmed;
        public bool saved;    //RowChanged fired twice during Adding a record; 
                              //true: after record saved
                              //false: before record saving, give a chance to deny saving


        public RowChangedEventArgs(RowAdapter adapter, ObjectState state, bool saved)
        {
            this.adapter = adapter;
            this.state = state;
            this.confirmed = true;
            this.saved = saved;
        }
    }



}
