using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce;
using ElectronicInvoice.Produce.Factroy;
using ElectronicInvoice.Produce.Infrastructure.Helper;
using ElectronicInvoice.Produce.Mapping;

namespace EInvoiceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //設定使用哪個抓取Setting類別
            var setting  = new AppsettingConfig();

            //建立工廠 將配置檔傳入建構子中
            InvoiceApiFactroy factory = new InvoiceApiFactroy(setting);

            //建立查詢參數  
            //下面範例查詢 發票民國106年7.8月中獎發票
            QryWinningListModel model = new QryWinningListModel()
            {
                invTerm = "10608"
            };

            //在工廠中藉由傳入參數 取得Api產品
            var api = factory.GetProxyInstace(model);

            //api回傳結果
            var result = api.ExcuteApi(model);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
