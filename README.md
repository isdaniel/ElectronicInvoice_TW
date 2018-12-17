[![ElectronicInvoice_TW](https://img.shields.io/badge/nuget-1.0.4-blue.svg)](https://www.nuget.org/packages/ElectronicInvoice_TW/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/ElectronicInvoice_TW.svg)](https://www.nuget.org/packages/ElectronicInvoice_TW/)

## Build 

[![NuGet Downloads](https://img.shields.io/badge/Build-succeed-green.svg)](https://ci.appveyor.com/project/WeihanLi/accesscontroldemo)
-----

#### 串接文件下載 [電子發票查詢API 1.4.4](https://www.einvoice.nat.gov.tw/home/DownLoad?fileName=1476855387455_0.4.4.pdf) 

#### 使用這個API框架很簡單 只須完成以下幾個步驟
目前把所有API相關的程式放在 `ElectronicInvoice.Produce` 專案中

1. [預設]抓取WebConfig 財政部申請的appId和appKey
2. `ElectronicInvoice.Produce`專案中創建兩個Model
>* 一個是財政部回應參數的Model (放在InvoiceResult資料夾中)
>* 一個是財政部所需參數的Model (放在Mapping資料夾中)
3. 創建一個要實作的Api物件並繼承ApiBase抽象類，並在泛型那邊指定所需 Model的類型
4. 在外部使用 `InvoiceApiFactroy.GetProxyInstace` 方法將傳入所需Model，經反射回應相對應的Api物件(依靠Model上註冊的apiType)
5. 使用Api物件.ExcuteApi方法 傳入所需Model
6. Webconfig中設置要請求的api連結

##### 下面詳細說明使用方法已 "QryWinningList"  查詢中獎發票號碼清單為例子
			
1. 打開webConfig輸入你的appKey和appId 
```xml
<!--在這裡填入跟財政部申請的AppId-->
<add key="GovAppId" value="" />
<!--在這裡填入跟財政部申請的AppKey-->
<add key="GovAPIKey" value=""/>
```
2-1. 一個是財政部所需參數的Model (放在Mapping資料夾中)
```cs
[ApiType(ApiType = typeof(QryWinningListApi), MockApiType = typeof(QryWinningListMockApi))]
public class QryWinningListModel
{
    public string invTerm { get; set; }
}
```
2-2. 一個是財政部回應參數的Model (放在InvoiceResult資料夾中)
```cs
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


3. `ElectronicInvoice.Produce`專案中 qryInvDetailApi 類別 並繼承  `ApiBase<qryInvDetailModel>`在泛型上提供財政部所需參數Model的型別，在上面實現父類的 SetParamter 方法提供Paramter參數，而可以使用SortedDictionary
因為參數要按升冪排列

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

4. 在`ElectronicInvoice.Service`專案中 `EIvoiceService` 使用工廠創建Api物件將所需參數Model傳入
5. 使用回傳物件的ExcuteApi方法將所需參數Model傳入
6. 在appSetting中設置 以api名稱為key,請求網址為value的設定
```xml
<appSettings>
    <add key="QryWinningListApi" value="https://www.einvoice.nat.gov.tw/PB2CAPIVAN/invapp/InvApp" />
</appSettings>
```
<br/>

## 2017/11/16 新增範例程式
### `EInvoiceDemo`專案範例:

以下範例是呼叫【撈取中獎發票API】
```cs
//設定使用哪個抓取Setting類別
var setting  = new AppsettingConfig();

//建立工廠 將配置檔傳入建構子中
InvoiceApiFactroy factory = new InvoiceApiFactroy(setting);

//建立查詢參數  
//下面範例查詢 發票民國106年7.8月中獎發票
QryWinningListModel model = new QryWinningListModel()
{
    invTerm = "10608"
};

//在工廠中藉由傳入參數 取得Api產品
var api = factory.GetProxyInstace(model);

//api回傳結果
var result = api.ExcuteApi(model);
```

WebConfig配置
```xml
<appSettings>
  <!--查詢api的url  api名稱為key,請求網址為value-->
  <add key="QryWinningListApi" value="https://www.einvoice.nat.gov.tw/PB2CAPIVAN/invapp/InvApp" />
  <!--是否開啟API模擬-->
  <add key="IsMockAPI" value="0" />
  <!--設置你們Key和IV-->
  <add key="GovAppId" value="" />
  <add key="GovAPIKey" value=""/>
</appSettings>
```
 
## 執行結果
![Alt text](https://az787680.vo.msecnd.net/user/九桃/7a594954-113f-45bd-827f-39d19508fcc3/1510882195_20334.png "執行結果")

<br/>

# 使用Dll
## 本框架使用第三方套件(使用前先匯入)
### Json.NET
### 自製AopLib.dll
