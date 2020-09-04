using System.Collections.Generic;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce.Mapping;

namespace ElectronicInvoice.Produce.API.Business
{
    internal sealed class GetBarcodeApi : ApiBase<GetBarcodeModel>
    {
        protected override string SetParameter(GetBarcodeModel model)
        {
            SortedDictionary<string, string> parameter = new SortedDictionary<string, string>
            {
                ["version"] = "1.0",
                ["action"] = GetMapperAction,
                ["appID"] = ConfigSetting.GovAppId,
                ["phoneNo"] = model.PhoneNo ,
                ["timeStamp"] = model.TimeStamp,
                ["uuid"] = model.UUID,
                ["verificationCode"] = model.VerificationCode
            };

            return ParameterHelper.DictionaryToParameter(parameter);
        }

        public GetBarcodeApi(IConfig config, ISysLog log) : base(config, log)
        {
        }
    }
}

