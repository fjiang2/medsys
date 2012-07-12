using System;
using Sys.Data;

namespace App.Data
{
    [DataEnum]
    public enum AvailabilityEnum
    {
		[Field("Day")]
		Day = 1,

		[Field("Night")]
		Night = 2,

		[Field("Weekend")]
		Weekend = 3
    }
}
