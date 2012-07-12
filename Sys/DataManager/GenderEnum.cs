using System;
using Sys.Data;

namespace Sys.DataManager
{
    [DataEnum]
    public enum GenderEnum
    {
		[Field("Male")]
		Male = 1,

		[Field("Female")]
		Female = 2,

		[Field("Unknown")]
		Unknown = 3
    }
}
