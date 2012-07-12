using System;
using Sys.Data;

namespace App.Data
{
    [DataEnum]
    public enum PhoneEnum
    {
		[Field("Home")]
		Home = 1,

		[Field("Work")]
		Work = 2,

		[Field("Mobile")]
		Mobile = 3,

		[Field("Fax")]
		Fax = 4,

		[Field("Other")]
		Other = 5
    }
}
