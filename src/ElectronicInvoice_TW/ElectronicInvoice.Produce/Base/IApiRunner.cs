namespace ElectronicInvoice.Produce.Base
{
    /// <summary>
    /// ����api������
    /// </summary>
    public interface IApiRunner<T>
    {
        /// <summary>
        /// ����api
        /// </summary>
        /// <param name="model">�ǤJ���Ѽ�</param>
        /// <returns>�^�Ǹ��</returns>
        string ExecuteApi(T model);
    }
}