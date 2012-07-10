using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.SmartList.Dpo;
using System.IO;

namespace Sys.SmartList
{
    public class RepxItem : RepxDpo
    {
        public RepxItem()
        {
        }

        public RepxItem(Configuration configuration, string url)
            :base(configuration.ID, url)
        {

        }

     
        public byte[] Layout
        {
            get
            {
                return this.repx.GetBytes();
            }
            set
            {
                this.repx = value.GetString();
            }
        }


        public MemoryStream Stream
        {
            get
            {
                if (this.repx != null)
                    return new MemoryStream(this.repx.GetBytes());

                return null;
            }
            set
            {
                MemoryStream stream = value;
                byte[] bytes = stream.ToArray();
                this.repx = bytes.GetString();
            }
        }
    }
}
