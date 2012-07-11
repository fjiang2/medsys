using System;
using Sys.Data;

namespace App.Data
{
    [EnumType("AddressType")]
    public enum AddressType
    {
        [EnumField("Home")]        Home = 1,
        [EnumField("Work")]        Work = 2
    }
}
