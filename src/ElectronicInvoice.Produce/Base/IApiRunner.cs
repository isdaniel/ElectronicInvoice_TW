namespace ElectronicInvoice.Service.Base
{
    /// <summary>
    /// 執行api的介面
    /// </summary>
    public interface IApiRunner
    {
        /// <summary>
        /// 執行api
        /// </summary>
        /// <param name="model">傳入的參數</param>
        /// <returns>回傳資料</returns>
        string ExcuteApi(object model);
    }
}