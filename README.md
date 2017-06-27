
#### 使用這個API框架很簡單 只須完成以下幾個步驟

1. Config輸入 財政部申請的appId和appKey
2. 創建兩個Model
>* 一個是財政部回應參數的Model
>* 一個是財政部所需參數的Model
3. 創建一個要實作的Api物件並繼承ApiBase抽象類，並在泛型那邊指定所需 Model的類型
4. 在外部使用 MoblieInvoiceApiFactroy.GetInstace 方法將 傳入所需Model，工廠會反射回應相對應的Api物件
5. 使用Api物件.ExcuteApi方法 傳入所需Model

##### 下面詳細說明使用方法已 "QryWinningList"  查詢中獎發票號碼清單為例子
			
1. 打開webConfig輸入你的appKey和appId 
```xml
<!--在這裡填入跟財政部申請的AppId-->
<add key="GovAppId" value="" />
<!--在這裡填入跟財政部申請的AppKey-->
<add key="GovAPIKey" value=""/>
```
2. 在Model資料夾中創建2個Class
```cs
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
```

3. Service資料夾創建 qryInvDetailApi 類別 並繼承  ApiBase<qryInvDetailModel>在泛型上提供財政部所需參數Model的型別

```cs
public class qryInvDetailApi : ApiBase<qryInvDetailModel>
{
    protected override string SetParamter(qryInvDetailModel model)
    {
        SortedDictionary<string, string> paramter = 
                   new SortedDictionary<string, string>();
        paramter["version"] = "0.3";
        paramter["action"] = "qryInvDetail";
        paramter["invTerm"] = model.invTerm;
        paramter["UUID"] = UUID;
        paramter["type"] = model.type;
        paramter["invNum"] = model.invNum;
        paramter["generation"] = model.generation;
        paramter["invTerm"] = model.invTerm;
        paramter["invDate"] = model.invDate;
        paramter["encrypt"] = model.encrypt;
        paramter["sellerID"] = model.sellerID;
        paramter["randomNumber"] = model.randomNumber;
        paramter["appID"] = GovAppId;
        return PraramterHelper.DictionaryToParamter(paramter);
    }
}
```
在上面實現父類的 SetParamter 方法提供Paramter參數，而可以使用SortedDictionary因為參數要按升冪排列

4. 在InvoiceController 使用工廠創建Api物件將所需參數Model傳入
5. 使用回傳物件的ExcuteApi方法將所需參數Model傳入


