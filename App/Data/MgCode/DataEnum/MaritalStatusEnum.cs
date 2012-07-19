using System;
using Sys.Data;

namespace App.Data.DataEnum
{
    [DataEnum]
    public enum MaritalStatusEnum
    {
		[Field("Married")]
		Married = 1,

		[Field("Single")]
		Single = 2,

		[Field("Divorced")]
		Divorced = 3,

		[Field("Widowed")]
		Widowed = 4,

		[Field("Separated")]
		Separated = 5,

		[Field("Correction")]
		Correction = 6
    }
}
