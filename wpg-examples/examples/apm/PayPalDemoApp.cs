﻿using System;
using System.Threading.Tasks;
using wpg.connection;
using wpg.connection.auth;
using wpg.domain;
using wpg.domain.redirect;
using wpg.domain.payment;
using wpg.request.apm;

namespace wpgexamples
{
    public class PayPalDemoProgram : DemoApp
    {
        public void Run(string xmlUser, string xmlPass, string merchantCode)
        {
            Auth auth = new UserPassAuth(xmlUser, xmlPass, merchantCode);
            GatewayContext gatewayContext = new GatewayContext(GatewayEnvironment.SANDBOX, auth);

            PayPalPaymentRequest request = new PayPalPaymentRequest();
            request.OrderDetails = new OrderDetails("test order", new Amount("GBP", 2L, 1234L));
            request.Shopper = new Shopper("shopper@worldpay.com");
            request.setResultURLs("https://test.worldpay.com");

            Task<RedirectUrl> asyncResponse = request.Send(gatewayContext);
            RedirectUrl response = asyncResponse.Result;

            Console.WriteLine("Url: " + response.Url);
        }
    }
}