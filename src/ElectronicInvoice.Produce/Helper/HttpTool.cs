using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Produce.Infrastructure.Helper
{
    public class HttpTool
    {
        /// <summary>
        /// POST傳輸
        /// </summary>
        /// <param name="posturl"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string HttpPost(string posturl, string postData)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(posturl);
            request.Method = "POST";
            byte[] postcontentsArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postcontentsArray.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(postcontentsArray, 0, postcontentsArray.Length);
                requestStream.Close();
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        #region 設定是否忽略SSL
        /// <summary>
        /// 設定 HTTPS 連線時，不要理會憑證的有效性問題
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certification"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns></returns>
        public static bool ValidateServerCertificate(
            Object sender,
            X509Certificate certification,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        #endregion
    }
}
