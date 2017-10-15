using ElectronicInvoice.Infrastructure.Common;
using ElectronicInvoice.Service;

namespace ElectronicInvoice.Model
{
    [ApiType(ApiType = typeof(QryWinningListApi), MockApiType = typeof(QryWinningListMockApi))]
    public class QryWinningListModel
    {
        public string invTerm { get; set; }
    }

    public class QryWinningListViewModel
    {
        public string code { get; set; }
        public string msg { get; set; }
        public string invoYm { get; set; }
        public string superPrizeNo { get; set; }
        public string spcPrizeNo { get; set; }
        public string spcPrizeNo2 { get; set; }
        public string spcPrizeNo3 { get; set; }
        public string firstPrizeNo1 { get; set; }
        public string firstPrizeNo2 { get; set; }
        public string firstPrizeNo3 { get; set; }
        public string firstPrizeNo4 { get; set; }
        public string firstPrizeNo5 { get; set; }
        public string firstPrizeNo6 { get; set; }
        public string firstPrizeNo7 { get; set; }
        public string firstPrizeNo8 { get; set; }
        public string firstPrizeNo9 { get; set; }
        public string firstPrizeNo10 { get; set; }
        public string sixthPrizeNo1 { get; set; }
        public string sixthPrizeNo2 { get; set; }
        public string sixthPrizeNo3 { get; set; }
        public string superPrizeAmt { get; set; }
        public string spcPrizeAmt { get; set; }
        public string firstPrizeAmt { get; set; }
        public string secondPrizeAmt { get; set; }
        public string thirdPrizeAmt { get; set; }
        public string fourthPrizeAmt { get; set; }
        public string fifthPrizeAmt { get; set; }
        public string sixthPrizeAmt { get; set; }
        public string sixthPrizeNo4 { get; set; }
        public string sixthPrizeNo5 { get; set; }
        public string sixthPrizeNo6 { get; set; }
    }
}