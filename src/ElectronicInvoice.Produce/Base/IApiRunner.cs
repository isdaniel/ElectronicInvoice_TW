namespace ElectronicInvoice.Produce.Base
{
    /// <summary>
    /// 執行api的介面
    /// </summary>
    public interface IApiRunner<T>
    {
        /// <summary>
        /// 執行api
        /// </summary>
        /// <param name="model">傳入的參數</param>
        /// <returns>回傳資料</returns>
        string ExcuteApi(T model);
    }
}