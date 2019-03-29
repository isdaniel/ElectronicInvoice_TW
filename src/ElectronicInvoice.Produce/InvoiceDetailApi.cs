using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;

namespace ElectronicInvoice.Produce
{
    internal sealed class InvoiceDetailApi : ApiBase<InvoiceDetailModel>
    {
        protected override string SetParameter(InvoiceDetailModel model)
        {
            SortedDictionary<string, string> paramter = new SortedDictionary<string, string>();

            paramter["version"] = "0.3";
            paramter["type"] = model.Type.ToString();
            paramter["invNum"] = model.InvNum;
            paramter["action"] = ActionParameter.InvoiceDetailApi;
            paramter["generation"] = "V2";
            paramter["invTerm"] = model.InvTerm;
            paramter["invDate"] = model.InvDate.ToString("yyyy/MM/dd");
            paramter["encrypt"] = model.Encrypt;
            paramter["sellerID"] = model.SellerID;
            paramter["randomNumber"] = model.RandomNumber; 
            paramter["UUID"] = model.UUID;
            paramter["appID"] = ConfigSetting.GovAppId;

            return PraramterHelper.DictionaryToParamter(paramter);
        }
    }
}
