
using System;
using Sys.Data;

namespace App.Data
{
    [EnumType("AvailabilityType")]
    public enum AvailabilityType
    {
		[EnumField("Day")]	Day = 1,
		[EnumField("Night")]	Night = 2,
		[EnumField("Weekend")]	Weekend = 3
    }
}
