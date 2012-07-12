using System;
using Sys.Data;

namespace PTA
{
    [DataEnum]
    public enum MemeberEnum
    {
		[Field("Teacher")]
		Teacher = 1,

		[Field("Student")]
		Student = 2,

		[Field("Parent")]
		Parent = 3
    }
}
