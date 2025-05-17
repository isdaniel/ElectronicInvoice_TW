[![ElectronicInvoice_TW](https://img.shields.io/nuget/v/ElectronicInvoice_TW.svg?style=plastic)](https://www.nuget.org/packages/ElectronicInvoice_TW/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/ElectronicInvoice_TW.svg)](https://www.nuget.org/packages/ElectronicInvoice_TW/) 
[![Build status](https://ci.appveyor.com/api/projects/status/4ktwufjfsxmpishy/branch/master?svg=true)](https://ci.appveyor.com/project/isdaniel/electronicinvoice-tw/branch/master)
[![Ask DeepWiki](https://deepwiki.com/badge.svg)](https://deepwiki.com/isdaniel/ElectronicInvoice_TW)

-----

Nuget下載

    PM > Install-Package ElectronicInvoice_TW 

---

## 範例程式
### `EInvoiceDemo`專案範例:

範例是呼叫【撈取中獎發票API】

## 使用工廠模式

```cs
//設定使用哪個抓取Setting類別
var setting  = new AppsettingConfig();

//建立工廠 將配置檔傳入建構子中
InvoiceApiFactory factory = new InvoiceApiFactory(setting);

//建立查詢參數  
//下面範例查詢 發票民國106年7.8月中獎發票
QryWinningListModel model = new QryWinningListModel()
{
    invTerm = "10608"
};

//在工廠中藉由傳入參數 取得Api產品
var api = factory.GetProxyInstace(model);

//api回傳結果
var result = api.ExecuteApi(model);
```

-----

## 使用InvoiceApiContext 

* 簡化使用創建流程
1. 創建一個 `InvoiceApiContext` 物件
2. 傳入要使用的Model,即可獲得使用的值

```c#
var setting  = new AppsettingConfig();
DonateQueryModel donateModel = new DonateQueryModel()
{
    qKey = "伊甸"
};
InvoiceApiContext apiContext = new InvoiceApiContext(setting);
result = apiContext.ExecuteApi(donateModel); 
```
使用Model可以參考

* [Model使用對應表](docs/ModelMapper.md)

-----

WebConfig配置
```xml
<appSettings>
  <!--查詢api的url  api名稱為key,請求網址為value-->
  <add key="QryWinningListApi" value="https://api.einvoice.nat.gov.tw/PB2CAPIVAN/invapp/InvApp" />
  <!--是否開啟API模擬-->
  <add key="IsMockAPI" value="0" />
  <!--設置你們Key和IV-->
  <add key="GovAppId" value="" />
  <add key="GovAPIKey" value=""/>
</appSettings>
```

JsonConfig 範例

```json
{
	"GovAppId":"",
	"GovAPIKey":"",
	"IsMockAPI":"0",
	"ApiURLTable":{
		"QryWinningListApi":"https://wwwtest.einvoice.nat.gov.tw/PB2CAPIVAN/invapp/InvApp",
		"QryCarrierAggApi":"https://www.einvoice.nat.gov.tw/PB2CAPIVAN/Carrier/Aggregate",
		"DonateQueryApi":"https://wwwtest.einvoice.nat.gov.tw/PB2CAPIVAN/loveCodeapp/qryLoveCode",
		"MyApi":"https://wwwtest.einvoice.nat.gov.tw/PB2CAPIVAN/invapp/InvApp"
	}
}
```


[SDK說明連結](https://www.slideshare.net/slideshow/invoice-tw-sdk/140842837) 

[Blog原理解說](https://dotblogs.com.tw/daniel/2017/10/15/203221) 

----

## Todo List

**基礎建設：**

- [X] 建立`InvoiceApiContext`封裝**Factory Api**實做
- [X] 撰寫單元測試 
- [X] API文件和Model類別使用對應表 

**API實做：**

- [X] [電子發票應用API規格(v1.7)](https://www.einvoice.nat.gov.tw/download/ptl003w/AC20000002)
- [ ] [電子發票營業人應用API規格(v1.6)](https://www.einvoice.nat.gov.tw/download/ptl003w/AC20000002)
- [ ] [雲端發票行動支付應用API規格(v1.6)](https://www.einvoice.nat.gov.tw/download/ptl003w/AC20000002)
- [ ] [電子發票政府應用API規格(v1.2)](https://www.einvoice.nat.gov.tw/download/ptl003w/AC20000002) 

### Release Note:

* 1.5.0 ~ 2.0.0 支援.net core和.net framework 4.6.1以上

### Contributors :  

![](https://contrib.rocks/image?repo=isdaniel/ElectronicInvoice_TW)


### Contributing Guidelines

To contribute to this repository, please follow these guidelines:

> Please make sure you write unit-test for your modification code, and pass all previous unit-test case.

1. Fork the repository.
2. Create a new branch (git checkout -b feature-branch-name).
3. Make your changes.
4. Commit your changes (git commit -m 'Add some feature').
5. Push to the branch (git push origin feature-branch-name).
6. Open a pull request.
