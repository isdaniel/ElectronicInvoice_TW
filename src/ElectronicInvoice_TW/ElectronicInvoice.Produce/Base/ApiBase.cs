using System;
using System.Collections.Generic;
using ElectronicInvoice.Produce.Facade;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce.Helper;
using System.Threading.Tasks;
using System.Web;
/*
 * 創建者：Daniel.shih
 * 目的：方便日後實作財政部電子發票API
 * 使用：每個api可以繼承此類別(ApiBase)，子類只需提供api參數呼叫 IApiRunner.ExcuteApi 並將參數傳入即可完成操作
 * **/

namespace ElectronicInvoice.Produce.Base
{
    public abstract partial class ApiBase<TModel> : IApiRunner<TModel>
        where TModel : class, new()
    {
        public ApiBase(IConfig config,ISysLog log)
        {
            ConfigSetting = config;
            Logger = log;
            InvoiceContainer.Instance.TryToAdd(config);
            InvoiceContainer.Instance.TryToAdd(log);
        }

        /// <summary>
        /// Provide TW Invoice action parameter mapping
        /// </summary>
        private readonly Dictionary<string,string> _actionMapper = new Dictionary<string, string>()
        {
            { "CarrierDetailApi","carrierInvDetail"},
            { "CarrierTitleApi","carrierInvChk"},
            { "DonateQueryApi","qryLoveCode"},
            { "InvoiceDetailApi","qryInvDetail"},
            { "InvoiceTitleApi","qryInvHeader"},
            { "QryCarrierAggApi","qryCarrierAgg"},
            { "QryWinningListApi","QryWinningList"},
            { "CarrierDonateApi","carrierInvDnt"},
            { "CellphoneVerifyApi","bcv"},
            { "DonateVerifyApi","preserveCodeCheck"},
            { "GetBarcodeApi","getBarcode"},
        };

        internal virtual string GetMapperAction
        {
            get
            {
                if (!_actionMapper.TryGetValue(GetType().Name, out string result))
                {
                    result = string.Empty;
                }

                return result;
            }
        }

        protected ISysLog Logger { get; set; }

        protected IConfig ConfigSetting { get; set; }

        /// <summary>
        /// 子類繼承提供參數
        /// </summary>
        /// <returns></returns>
        protected abstract string SetParameter(TModel model);

        /// <summary>
        /// 取得api的Url路徑
        /// </summary>
        /// <returns></returns>
        protected virtual string GetApiURL()
        {
            string apiName = this.GetType().Name;
            string result;

            if (!ConfigSetting.GetApiURLTable().TryGetValue(apiName,out result))
                throw new NotSupportedException($"請確認Config有ApiURL設定： {apiName}");
            
            return result;
        }

        /// <summary>
        /// 執行Api
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual string ExecuteApi(TModel model)
        {
            if (model == null) 
                throw new ArgumentNullException("傳入 model 不能為 NULL");
            //取得加密後的參數
            string postData = GetInvoiceParameter(SetParameter(model));
            var result = HttpTool.HttpPost(GetApiURL(), postData);
            Logger.WriteLog($"Recive Api Result：{result}");
            return result;
        }

        public TRtn ExecuteApi<TRtn>(TModel model)
        {
           return JsonConvertFacde.DeserializeObject<TRtn>(ExecuteApi(model));
        }

        /// <summary>
        /// 將參數做簽章(signature) 並附加到最後且返回
        /// </summary>
        /// <returns></returns>
        private string GetInvoiceParameter(string paraData)
        {
            string signature = CiphertextHelper.
                EncryptionHMACSHA1Base64(ConfigSetting.GovAPIKey, paraData);
            string fullParameter = $"{ReplacePlus(paraData)}&signature={HttpUtility.UrlEncode(signature)}";
            Logger.WriteLog($"Send Api Parametr：{fullParameter}");
            return fullParameter;
        }

        /// <summary>
        /// 將加號 => %2b
        /// </summary>
        /// <param name="paraData"></param>
        /// <returns></returns>
        private string ReplacePlus(string paraData)
        {
            return paraData.Replace("+", "%2b");
        }

    }
}