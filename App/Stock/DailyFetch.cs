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
                (CompanyDpo._Has_Insider_Transaction.ColumnName() == 1)
#if DEBUG
                .AND(CompanyDpo._LastSale.ColumnName() > 150)
#endif
                );

            this.CompanyTable = reader.Table;
        }

        public void FetchTransactions()
        {

            foreach (DataRow row in CompanyTable.Rows)
            {
                CompanyDpo dpo = new CompanyDpo(row);

                if ((DateTime.Now - dpo.Last_Downloaded_Time).TotalHours >= 24)
                {
                    Company company = new Company(dpo.Symbol, dpo.CIK);
                    company.DownloadTransactionAndParse(dpo.Has_Insider_Transaction);
                    dpo.Has_Insider_Transaction = company.HasInsiderTransactions;


                    foreach (DataRow row1 in company.Ownerships.Rows)
                    {
                        OwnershipDpo dpo1 = new OwnershipDpo(row1);
                        dpo1.Save();
                    }

                    foreach (DataRow row2 in company.Transactions.Rows)
                    {
                        TransactionDpo dpo2 = new TransactionDpo(row2);
                        dpo2.Save();
                    }

                    dpo.Last_Downloaded_Time = DateTime.Now;
                    dpo.Save();
                }
            }

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
