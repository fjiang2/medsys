using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Extensions;
using Sys;
using Sys.Data;

namespace Sys.SmartList
{

    class DpoReportStorage : ReportStorageExtension
    {
        Configuration configuration;

        RepxItemList items;

        public DpoReportStorage(Configuration configuration)
        {
            this.configuration = configuration;

            items = new RepxItemList(configuration);

        }


        public override bool CanSetData(string url)
        {
            return true;
        }

        public override bool IsValidUrl(string url)
        {
            return !string.IsNullOrEmpty(url);
        }

        public override byte[] GetData(string url)
        {
            RepxItem item = new RepxItem(configuration, url);
            if (item == null)
                return new byte[]{};

            return item.Layout;
        }

        public override void SetData(XtraReport report, string url)
        {
            RepxItem item = new RepxItem(configuration, url);

            if (item != null)
                item.Layout = GetBuffer(report);
            else
            {
                item.url = url;
                report.Extensions["StorageID"] = item.ID.ToString();
                item.Layout = GetBuffer(report);
            }

            item.Save();
            
            if (!items.UrlExists(url))
                items.Add(item);
        }


        private byte[] GetBuffer(XtraReport report)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                report.SaveLayout(stream);
                return stream.ToArray();
            }
        }


        public override string GetNewUrl()
        {
            return items.NewUrl;
        }



        public override string SetNewData(XtraReport report, string defaultUrl)
        {
            if (!items.UrlExists(defaultUrl))
            {
                SetData(report, defaultUrl);
                return defaultUrl;
            }
            else
            {
                MessageBox.Show("Incorrect report name", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            return string.Empty;
        }

        public override bool GetStandardUrlsSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override string[] GetStandardUrls(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance is XRSubreport)
            {
                string storageID;
                XRSubreport xrSubreport = context.Instance as XRSubreport;
                if (xrSubreport.RootReport != null && xrSubreport.RootReport.Extensions.TryGetValue("StorageID", out storageID))
                {
                    return items.GetUrlsCore(storageID).ToArray();
                }
            }

            return items.ToArray<string>(RepxItem._url);
        }


        static DpoReportStorage reportStorage = null;
        public static void Register(Configuration configuration)
        {
            if (reportStorage == null)
            {
                reportStorage = new DpoReportStorage(configuration);
                ReportStorageExtension.RegisterExtensionGlobal(reportStorage);
            }

        }
    }



}