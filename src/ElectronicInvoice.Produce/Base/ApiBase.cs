using ElectronicInvoice.Produce.Infrastructure.Helper;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using ElectronicInvoice.Produce.Facade;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce.Attributes;

/*
 * 創建者：Daniel.shih
 * 目的：方便日後實作財政部電子發票API
 * 使用：每個api可以繼承此類別(ApiBase)，子類只需提供api參數呼叫 IApiRunner.ExcuteApi 並將參數傳入即可完成操作
 * **/

namespace ElectronicInvoice.Produce.Base
{
    public abstract class ApiBase<TModel> : MarshalByRefObject, IApiRunner<TModel>
        where TModel : class, new()
    {
        private IConfig _configSetting;

        public IConfig ConfigSetting {
            get
            {
                _configSetting = _configSetting ?? new AppsettingConfig();

                return _configSetting;
            }
            set
            {
                _configSetting = value; 
            }
        }

        /// <summary>
        /// 子類繼承提供參數
        /// </summary>
        /// <returns></returns>
        protected abstract string SetParamter(TModel model);

        /// <summary>
        /// 取得api的Url路徑
        /// </summary>
        /// <returns></returns>
        protected virtual string GetApiURL()
        {
            var urlTable  = ConfigSetting.GetApiURLTable();
            string apiName = this.GetType().Name;
            string result;

            if (!urlTable.TryGetValue(apiName,out result))
                throw new Exception(string.Format("請確認Config的appsetting有無此參數 {0}",apiName));
            
            return result;
        }

        /// <summary>
        /// 執行Api
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Log]
        public virtual string ExcuteApi(TModel model)
        {
            //建立所需參數
            string result = string.Empty;
            string postData = string.Empty;
            string posturl = GetApiURL();

            //取得加密後的參數
            postData = GetInvoiceParamter(SetParamter(model));

            ServicePointManager.ServerCertificateValidationCallback
                     = HttpTool.ValidateServerCertificate;
            result = HttpTool.HttpPost(posturl, postData);

            return result;
        }

        public TRtn ExcuteApi<TRtn>(TModel model)
        {
           return JsonConvertFacde.DeserializeObject<TRtn>(ExcuteApi(model));
        }



        /// <summary>
        /// 將參數做簽章(signature) 並附加到最後且返回
        /// </summary>
        /// <returns></returns>
        private string GetInvoiceParamter(string paraData)
        {
            //###進行加密動作
            string signature = CiphertextHelper.
                EncryptionHMACSHA1Base64(ConfigSetting.GovAPIKey, paraData);
            return string.Format("{0}&signature={1}",
                ReplacePlus(paraData),
                HttpUtility.UrlEncode(signature));
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