using System;
using Sys.Data;

namespace App.Data.DataEnum
{
    [DataEnum]
    public enum PhoneEnum
    {
		[Field("Home")]
		Home = 1,

		[Field("Work")]
		Work = 2
    }
}
