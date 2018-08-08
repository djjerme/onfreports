using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using PBA.OnfInfo;

namespace PBA.OnfDAL
{
    /// <summary>
    /// This class implements Data Access logic
    /// associated with the Order Summary Report.
    /// </summary>
    public class CreditCardReportData : DataAccess
    {
        static public CreditCardReportInfo[] GetCreditCardReport(DateTime startdate, DateTime enddate)
        {
            ArrayList c = new ArrayList();

            const string sql = "select * from "
                               + "(SELECT * FROM v_CreditCardReport vccr1 "
                               + "WHERE vccr1.ship_date BETWEEN @StartDate AND @EndDate "
                               + "UNION ALL "
                               + "SELECT * FROM JNP_SQL.estore.dbo.v_CreditCardReport vccr2 "
                               + "WHERE vccr2.ship_date BETWEEN @StartDate AND @EndDate) a "
                               + "ORDER BY a.store_id, a.order_id, a.order_suffix";

            SqlParameter parm1 = new SqlParameter("@StartDate", SqlDbType.DateTime);
            parm1.Value = startdate;

            SqlParameter parm2 = new SqlParameter("@EndDate", SqlDbType.DateTime);
            parm2.Value = enddate;

            SqlParameter[] cmdParms = new SqlParameter[] { parm1, parm2 };

            SqlDataReader d = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sql, cmdParms);

            while (d.Read())
            {
                CreditCardReportInfo al = new CreditCardReportInfo();

                al.StoreId = NCI(d["store_id"]);
                al.OrderId = NCI(d["order_id"]);
                al.OrderSuffix = NCI(d["order_suffix"]);
                al.OrderWhen = NCD(d["order_when"]);
                al.ShipDate = NCD(d["ship_date"]);
                al.QuoteId = NCS(d["quote_id"]);
                al.TransactionId = NCS(d["transaction_id"]);
                al.PaymentAmount = NCDbl(d["payment_amount"]);
                al.SalesTax = NCDbl(d["sales_tax"]);
                al.FirstName = NCS(d["first_name"]);
                al.LastName = NCS(d["last_name"]);
                al.Company = NCS(d["company"]);
                al.StoreName = NCS(d["store_name"]);
                al.Discount = NCDbl(d["total_discount"]);

                c.Add(al);
            }

            d.Close();

            return (CreditCardReportInfo[])c.ToArray(typeof(CreditCardReportInfo));
        }

    }
}
