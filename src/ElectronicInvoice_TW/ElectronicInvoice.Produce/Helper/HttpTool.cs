using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Produce.Helper
{
    internal class HttpTool
    {
        /// <summary>
        /// POST傳輸
        /// </summary>
        /// <param name="posturl"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        internal static string HttpPost(string posturl, string postData)
        {
            return HttpPostAsync(posturl,postData).GetAwaiter().GetResult();   
        }

        internal async static Task<string> HttpPostAsync(string posturl, string postData)
        {
            SetSecurityProtocol();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(posturl);
            request.Method = "POST";
            byte[] postcontentsArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postcontentsArray.Length;

            using (Stream requestStream = await request.GetRequestStreamAsync().ConfigureAwait(false))
            {
                await requestStream.WriteAsync(postcontentsArray, 0, postcontentsArray.Length).ConfigureAwait(false);
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    return await reader.ReadToEndAsync().ConfigureAwait(false);
                }
            }
        }

        private static void SetSecurityProtocol()
        {
            ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
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
        private static bool ValidateServerCertificate(
            Object sender,
            X509Certificate certification,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors != SslPolicyErrors.None)
            {
                return false; 
            }

            if (chain != null)
            {
                foreach (var chainStatus in chain.ChainStatus)
                {
                    if (chainStatus.Status != X509ChainStatusFlags.NoError)
                    {
                        return false; 
                    }
                }
            }

            return true;
        }
        #endregion
    }
}
