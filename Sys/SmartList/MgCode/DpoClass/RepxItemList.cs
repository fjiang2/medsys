using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;
using System.Data;

namespace Sys.SmartList
{
    class RepxItemList : DPList<RepxItem>
    {

        public RepxItemList(Configuration configuration)
            :base(new TableReader<RepxItem>(RepxItem._Command_ID.ColumnName() == configuration.ID))
        {
        }

        public bool UrlExists(string url)
        {
            return this.Where(item => item.url == url).Count() != 0;
        }

        public string NewUrl
        {
            get
            {
                int count = ToArray<string>(RepxItem._url).Count();
                count++;
                return count.ToString();
            }
        }

        public List<string> GetUrlsCore(string storageId)
        {
            List<string> list = new List<string>();
            foreach (RepxItem item in this)
                if (storageId != item.ID.ToString())
                    list.Add(item.url);

            return list;

            //return items.Where(item => item.ID.ToString() != storageID).Select(item => item.url).ToArray();
        }
     
    }
}
