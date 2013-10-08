using System;
using Sys.Data;

namespace PTA.DataEnum
{
    [DataEnum]
    public enum AvailabilityEnum
    {
		[Field("Day")]
		Day = 1,

		[Field("Night")]
		Night = 2,

		[Field("Weekend")]
		Weekend = 4
    }
}
