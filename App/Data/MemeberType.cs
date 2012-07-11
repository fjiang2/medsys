
using System;
using Sys.Data;

namespace App.Data
{
    [EnumType("MemeberType")]
    public enum MemeberType
    {
		[EnumField("Teacher")]	Teacher = 1,
		[EnumField("Student")]	Student = 2,
		[EnumField("Parent")]	Parent = 3
    }
}
