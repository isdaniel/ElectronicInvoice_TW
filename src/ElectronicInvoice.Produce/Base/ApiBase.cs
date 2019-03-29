using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using ElectronicInvoice.Produce.Facade;
using ElectronicInvoice.Produce.Infrastructure;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Helper;

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
                throw new Exception($"請確認Config有ApiURL設定： {apiName}");
            
            return result;
        }

        /// <summary>
        /// 執行Api
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Log]
        public virtual string ExecuteApi(TModel model)
        {
            //取得加密後的參數
            string postData = GetInvoiceParamter(SetParameter(model));

            return HttpTool.HttpPost(GetApiURL(), postData);
        }

        public TRtn ExecuteApi<TRtn>(TModel model)
        {
           return JsonConvertFacde.DeserializeObject<TRtn>(ExecuteApi(model));
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
            return $"{ReplacePlus(paraData)}&signature={HttpUtility.UrlEncode(signature)}";
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