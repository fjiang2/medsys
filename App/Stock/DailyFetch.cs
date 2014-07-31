using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Net;
using Sys.Data;
using Stock.DpoClass;

namespace Stock
{
    public class DailyFetch
    {

        public DataTable CompanyTable { get; set; }
        public DailyFetch()
        {
            //InitilizeCompanies();
            //FetchTransactions();

        }

        public void ReadCompanies()
        {

            TableReader<CompanyDpo> reader = new TableReader<CompanyDpo>(
                (CompanyDpo._Inactive.ColumnName() == 0)
#if DEBUG
                .AND(CompanyDpo._LastSale.ColumnName() > 150)
#endif
                );

            this.CompanyTable = reader.Table;
        }

      


        /// <summary>
        /// Initialize Table [Companies] in SQL Server, Run once.
        /// </summary>
        /// <param name="table"></param>
        public void InitilizeCompanies()
        {
            TableReader<CompanyDpo> reader = new TableReader<CompanyDpo>();


            foreach (DataRow row in reader.Table.Rows)
            {
                CompanyDpo dpo = new CompanyDpo(row);
                if (dpo.Inactive)
                    continue;

                Company company = new Company(dpo.Symbol, null);

                if (dpo.CIK == null)
                {
                    try
                    {
                        company.DownloadCompanyInfo();
                        dpo.CIK = company.CIK;
                        dpo.Has_Insider_Transaction = company.HasInsiderTransactions;
                    }
                    catch (Exception)
                    {
                        dpo.Inactive = true;
                    }
                }
                else
                {
                    //company.Download(dpo.CIK, dpo.Has_Insider_Transaction);
                    //dpo.Has_Insider_Transaction = company.HasInsiderTransactions;
                }

                dpo.Last_Downloaded_Time = DateTime.Now;
                dpo.Save();

            }
        }

      

    }
}
