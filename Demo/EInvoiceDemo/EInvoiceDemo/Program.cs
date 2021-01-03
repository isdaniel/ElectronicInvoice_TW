﻿using ElectronicInvoice.Produce.Mapping;
using System;
using System.Collections.Generic;
using System.Reflection;
using ElectronicInvoice.Produce;
using ElectronicInvoice.Produce.Attributes;
using ElectronicInvoice.Produce.Base;
using ElectronicInvoice.Produce.Factory;
using ElectronicInvoice.Produce.Helper;
using ElectronicInvoice.Produce.Infrastructure;


namespace EInvoiceDemo
{


    class Program
    {
        static void Main(string[] args)
        {
            //Register Assembly you want to inject.
            ApiTypeProvider.Instance.RegisterAssembly(Assembly.GetExecutingAssembly());
    
            string result = string.Empty;
            #region 使用工廠模式
            //建立查詢參數  
            //下面範例查詢 發票民國106年7.8月中獎發票
            QryWinningListModel model = new QryWinningListModel()
            {
                invTerm = "10610"
            };

            //建立工廠 將配置檔傳入建構子中
            InvoiceApiFactory factory = new InvoiceApiFactory();

            //在工廠中藉由傳入參數 取得Api產品
            var api = factory.GetProxyInstace(model);

            //api回傳結果
            result = api.ExecuteApi(model);
            Console.WriteLine(result);
            #endregion

            #region 使用 InvoiceApiContext 

            DonateQueryModel donateModel = new DonateQueryModel()
            {
                qKey = "伊甸"
            };
            InvoiceApiContext apiContext = new InvoiceApiContext();
            result = apiContext.ExecuteApi(donateModel); 
            #endregion

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
