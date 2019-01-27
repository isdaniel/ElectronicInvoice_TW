using ElectronicInvoice.Produce.Factroy;
using ElectronicInvoice.Produce.Infrastructure.Helper;
using ElectronicInvoice.Produce.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Infrastructure;


namespace EInvoiceDemo
{
    public class MyApi : ApiBase<MyQryWinningListModel>
    {
        protected override string SetParamter(MyQryWinningListModel model)
        {
            SortedDictionary<string, string> paramter = new SortedDictionary<string, string>();
            paramter["version"] = "0.2";
            paramter["action"] = "QryWinningList";
            paramter["invTerm"] = model.invTerm;
            paramter["UUID"] = model.UUID;
            paramter["appID"] = _config.GovAppId;
            return PraramterHelper.DictionaryToParamter(paramter);
        }
    }


    [ApiType(ApiType = typeof(MyApi))]
    public class MyQryWinningListModel : CommonBaseModel
    {
        public string invTerm { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Register Assembly you want to inject.
            ApiTypeProvier.Instance.RegistertAssembly(Assembly.GetExecutingAssembly());

            string result = string.Empty;
            #region 使用工廠模式
            //建立查詢參數  
            //下面範例查詢 發票民國106年7.8月中獎發票
            MyQryWinningListModel model = new MyQryWinningListModel()
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
