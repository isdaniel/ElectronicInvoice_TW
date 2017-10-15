using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using ElectronicInvoice.Infrastructure.Helper;
using Newtonsoft.Json;

/*
 * 創建者：Daniel.shih
 * 目的：方便日後實作財政部電子發票API
 * 使用：每個api可以繼承此類別(ApiBase)，子類只需提供api參數呼叫 IApiRunner.ExcuteApi 並將參數傳入即可完成操作
 * **/

namespace ElectronicInvoice.Service
{
    public abstract class ApiBase<T> : MarshalByRefObject, IApiRunner
        where T : class, new()
    {
        protected readonly string UUID = "9774d56d682e549c";
        protected string GovAPIKey = ConfigurationManager.AppSettings["GovAPIKey"];
        protected string GovAppId = ConfigurationManager.AppSettings["GovAppId"];
        protected string TimeStamp = (CommonHelper.GetTimeStamp() + 15).ToString();
        protected string TimeStampMAX = (CommonHelper.GetTimeStamp() + 10000).ToString();

        /// <summary>
        /// 子類繼承提供參數
        /// </summary>
        /// <returns></returns>
        protected abstract string SetParamter(T model);

        /// <summary>
        /// 取得api的Url路徑
        /// </summary>
        /// <returns></returns>
        protected virtual string GetApiName()
        {
            string apiname = this.GetType().Name;
            if (!ConfigurationManager.AppSettings.AllKeys.Contains(apiname))
            {
                throw new Exception(string.Format("請確認Config的appsetting有無此參數 {0}",
                    apiname));
            }
            return ConfigurationManager.AppSettings[apiname];
        }

        /// <summary>
        /// 執行Api
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual string ExcuteApi(object model)
        {
            //建立所需參數
            string result = string.Empty;
            string postData = string.Empty;
            string posturl = GetApiName();

            var data = ObjectToModel(model);

            //取得加密後的參數
            postData = GetInvoiceParamter(SetParamter(data));

            //###寄送前的Log
            //WriteLog(postData, "Send");

            try
            {
                ServicePointManager.ServerCertificateValidationCallback
                    = HttpTool.ValidateServerCertificate;
                result = HttpTool.HttpPost(posturl, postData);
            }
            catch (Exception ex)
            {
                throw ex;
                //result = GetSysErrorMsg();
                //WriteLog(ex.ToString(), "Error");
            }

            //###寄送後的Log
            //WriteLog(result, "Recivce");

            return result;
        }

        /// <summary>
        /// 將參數做簽章(signature) 並附加到最後且返回
        /// </summary>
        /// <returns></returns>
        private string GetInvoiceParamter(string paraData)
        {
            //###進行加密動作
            string signature = CiphertextHelper.
                EncryptionHMACSHA1Base64(GovAPIKey, paraData);
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

        /// <summary>
        /// 將物件轉Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private T ObjectToModel(object model)
        {
            var data = model as T;
            if (data == null)
            {
                throw new Exception("Model參數型別不符，請確認型別");
            }
            return data;
        }

        private string GetSysErrorMsg()
        {
            var result = new
            {
                v = "1.0",
                code = "999",
                msg = "財政部電子發票資訊中心系統異常，請稍候再試或洽客服人員"
            };
            return JsonConvert.SerializeObject(result);
        }
    }
}