using ElectronicInvoice.Produce.Factroy;
using ElectronicInvoice.Produce.Infrastructure.Helper;
using ElectronicInvoice.Produce.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce;


namespace EInvoiceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = string.Empty;
            #region 使用工廠模式
            //建立查詢參數  
            //下面範例查詢 發票民國106年7.8月中獎發票
            QryWinningListModel model = new QryWinningListModel()
            {
                invTerm = "10610"
            };

            //建立工廠 將配置檔傳入建構子中
            InvoiceApiFactroy factory = new InvoiceApiFactroy();

            //在工廠中藉由傳入參數 取得Api產品
            var api = factory.GetProxyInstace(model);

            //api回傳結果
            result = api.ExcuteApi(model);

            Console.WriteLine(result);
            #endregion

            #region 使用 InvoiceApiContext 

            DonateQueryModel donateModel = new DonateQueryModel()
            {
                qKey = "伊甸"
            };
            InvoiceApiContext apiContext = new InvoiceApiContext();
            result = apiContext.ExcuteApi(donateModel); 
            #endregion

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
