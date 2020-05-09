# API使用Model對應表

## 電子發票應用API規格(v1.7) 

|         Name         	|      UseModel      	|                 Url                 	|  Config Key ApiUrl(Api Class)  |
|:--------------------:	|:-------------------:	|:-----------------------------------:	|:-------------------------------:
| 查詢中獎發票號碼清單 	| QryWinningListModel 	|      /PB2CAPIVAN/invapp/InvApp      	|        QryWinningListApi       |
|     查詢發票表頭     	|  InvoiceTitleModel  	|      /PB2CAPIVAN/invapp/InvApp      	|        InvoiceTitleApi         |
|     查詢發票明細     	|  InvoiceDetailModel 	|      /PB2CAPIVAN/invapp/InvApp      	|        InvoiceDetailApi        |
|      捐贈碼查詢      	|   DonateQueryModel  	| /PB2CAPIVAN/loveCodeapp/qryLoveCode 	|        DonateQueryApi          |
|   載具發票表頭查詢   	|  CarrierTitleModel  	|     /PB2CAPIVAN/invServ/InvServ     	|        CarrierTitleApi         |
|   載具發票明細查詢   	|  CarrierDetailModel 	|     /PB2CAPIVAN/invServ/InvServ     	|        CarrierDetailApi        |
|     載具發票捐贈     	|  CarrierDonateModel 	|      /PB2CAPIVAN/CarInv/Donate      	|        CarrierDonateApi        |
| 手機條碼歸戶載具查詢 	|  QryCarrierAggModel 	|    /PB2CAPIVAN/Carrier/Aggregate    	|        QryCarrierAggApi        |