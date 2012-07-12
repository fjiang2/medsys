using System;
using Sys.Data;

namespace App.Data
{
    [DataEnum]
    public enum RelationshipEnum
    {
		[Field("Mother")]
		Mother = 1,

		[Field("Father")]
		Father = 2,

		[Field("Son")]
		Son = 3,

		[Field("Daughter")]
		Daughter = 4,

		[Field("Sister")]
		Sister = 5,

		[Field("Brother")]
		Brother = 6,

		[Field("Grand Mother")]
		Grandmother = 7,

		[Field("Grand Father")]
		Grandfather = 8,

		[Field("Other")]
		Other = 9
    }
}
