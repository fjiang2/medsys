using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;

namespace Sys.DataManager
{
    public class RowDocument  : Document
    {
        private DPObject rowObject;

        public RowDocument(string path, DPObject rowObject)
            : base(path)
        {
            this.rowObject = rowObject;
        }

        public RowDocument(string path, string description, DPObject rowObject)
            : base(path, description)
        {
            this.rowObject = rowObject;
        }


        public RowDocument(Document document, DPObject rowObject)
            : this(document.Path, document.Description, rowObject)
        {
        }

        public DPObject RowObject
        {
            get
            {
                return this.rowObject;
            }
        }
    }
}
