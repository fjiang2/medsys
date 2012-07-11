
using System;
using Sys.Data;

namespace App.Data
{
    [EnumType("PhoneType")]
    public enum PhoneType
    {
		[EnumField("Home")]	Home = 1,
		[EnumField("Work")]	Work = 2,
		[EnumField("Mobile")]	Mobile = 3,
		[EnumField("Fax")]	Fax = 4
    }
}
