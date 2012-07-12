
using System;
using Sys.Data;

namespace App.Data
{
    [EnumType("RelationshipType")]
    public enum RelationshipType
    {
		[EnumField("Mother")]	Mother = 1,
		[EnumField("Father")]	Father = 2,
		[EnumField("Son")]	Son = 3,
		[EnumField("Daughter")]	Daughter = 4,
		[EnumField("Sister")]	Sister = 5,
		[EnumField("Brother")]	Brother = 6,
		[EnumField("Grandmother")]	Grandmother = 7,
		[EnumField("Grandfather")]	Grandfather = 8,
		[EnumField("Other")]	Other = 9
    }
}
