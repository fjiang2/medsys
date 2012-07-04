using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Sys.Data
{

    public delegate void ValueChangedHandler(object sender, ValueChangedEventArgs e);



    public class ValueChangedEventArgs : EventArgs
    {
        public readonly string columnName;
        public readonly object originValue;
        public readonly object value;

        public ValueChangedEventArgs(string columnName, object originValue, object value)
        {
            this.columnName = columnName;
            this.originValue = originValue;
            this.value = value;
        }
    }


 



}
