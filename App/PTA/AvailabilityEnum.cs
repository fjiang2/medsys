using System;
using Sys.Data;

namespace PTA
{
    [Flags]
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
