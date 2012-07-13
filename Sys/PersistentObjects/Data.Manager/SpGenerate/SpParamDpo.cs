using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data;
using Sys.PersistentObjects.Dpo;

namespace Sys.Data.Manager
{
    class SpParamDpo : PersistentObject
    {

#pragma warning disable

        public string name;
        public string type;
        public short max_length;
        public byte precision;
        public byte scale;
        public bool is_output;

#pragma warning restore

        public SpParamDpo()
        {
        }

        public SpParamDpo(DataRow dataRow)
            : base(dataRow)
        {
        }
    }
}
