﻿/**
 * The MIT License (MIT)
 * 
 * Copyright (c) 2011-2014 BitPay
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using BitPayAPI;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitPayTest
{
    [TestClass]
    public class BitPayTest
    {
        private BitPay bitpay;
        private Invoice basicInvoice;
        private static String API_KEY = "Your BitPay API Key";

        public BitPayTest()
        {
            decimal price = 100.0m;
            this.bitpay = new BitPay(API_KEY);
            basicInvoice = this.bitpay.createInvoice(price, "USD");
        }

        [TestMethod]
        public void testShouldGetInvoiceId()
        {
            Assert.IsNotNull(basicInvoice.id, "Invoice created with id=NULL");
        }

        [TestMethod]
        public void testShouldGetInvoiceURL()
        {
            Assert.IsNotNull(basicInvoice.url, "Invoice created with url=NULL");
        }

        [TestMethod]
        public void testShouldGetInvoiceStatusL()
        {
            Assert.IsNotNull(basicInvoice.status, "Invoice created with status=NULL");
        }

        [TestMethod]
        public void testShouldGetInvoiceBTCPrice()
        {
            Assert.IsNotNull(basicInvoice.btcPrice, "Invoice created with btcPrice=NULL");
        }

        [TestMethod]
        public void testShouldCreateInvoiceOneTenthBTC()
        {
            try
            {
                // Arrange
                decimal price = 0.1m;
                decimal expected = 0.1m;

                // Act
                this.bitpay = new BitPay(API_KEY);
                Invoice invoice = this.bitpay.createInvoice(price, "BTC");

                // Assert
                decimal actual = invoice.btcPrice;
                Assert.AreEqual(expected, actual, "Invoice not created correctly: 0.1BTC");
            }
            catch (BitPayException ex)
            {
                Assert.Fail(ex.getMessage());
            }
        }

        [TestMethod]
        public void testShouldCreateInvoice100USD()
        {
            try
            {
                // Arrange
                decimal price = 100.0m;
                decimal expected = 100.0m;

                // Act
                this.bitpay = new BitPay(API_KEY);
                Invoice invoice = this.bitpay.createInvoice(price, "USD");

                // Assert
                decimal actual = invoice.price;
                Assert.AreEqual(expected, actual, "Invoice not created correctly: 100USD");
            }
            catch (BitPayException ex)
            {
                Assert.Fail(ex.getMessage());
            }
        }

        [TestMethod]
        public void testShouldCreateInvoice100EUR()
        {
            try
            {
                // Arrange
                decimal price = 100.0m;
                decimal expected = 100.0m;

                // Act
                this.bitpay = new BitPay(API_KEY);
                Invoice invoice = this.bitpay.createInvoice(price, "EUR");

                // Assert
                decimal actual = invoice.price;
                Assert.AreEqual(expected, actual, "Invoice not created correctly: 100EUR");
            }
            catch (BitPayException ex)
            {
                Assert.Fail(ex.getMessage());
            }
        }

        [TestMethod]
        public void testShouldGetInvoice()
        {
            try
            {
                // Arrange
                decimal price = 100.0m;

                // Act
                this.bitpay = new BitPay(API_KEY);
                Invoice invoice = this.bitpay.createInvoice(price, "EUR");
                Invoice retreivedInvoice = this.bitpay.getInvoice(invoice.id);

                // Assert
                string expected = invoice.id;
                string actual = retreivedInvoice.id;
                Assert.AreEqual(expected, actual, "Expected invoice not retreived");
            }
            catch (BitPayException ex)
            {
                Assert.Fail(ex.getMessage());
            }
        }

        [TestMethod]
        public void testShouldCreateInvoiceWithAdditionalParams()
        {
            try
            {
                // Arrange
                decimal price = 100.0m;
                InvoiceParams parameters = new InvoiceParams();
                parameters.buyerName = "Satoshi";
                parameters.buyerEmail = "satoshi@bitpay.com";
                parameters.fullNotifications = true;
                parameters.notificationEmail = "satoshi@bitpay.com";

                // Act
                this.bitpay = new BitPay(API_KEY);
                Invoice invoice = this.bitpay.createInvoice(price, "USD", parameters);

                // Assert
                Assert.IsNotNull(invoice, "Invoice not created");
            }
            catch (BitPayException ex)
            {
                Assert.Fail(ex.getMessage());
            }
        }
	
        [TestMethod]
        public void testShouldGetExchangeRates() 
        {
            try
            {
                // Arrange

                // Act
                this.bitpay = new BitPay(API_KEY);		
                Rates rates = this.bitpay.getRates();		

                // Assert
                List<Rate> listRates = rates.getRates();
                Assert.IsNotNull(listRates, "Exchange rates not retrieved");
            }
            catch (BitPayException ex)
            {
                Assert.Fail(ex.getMessage());
            }
        }

        [TestMethod]
        public void testShouldGetUSDExchangeRate()
        {
            // Arrange

            // Act
            this.bitpay = new BitPay(API_KEY);		
            Rates rates = this.bitpay.getRates();

            // Assert
            decimal rate = rates.getRate("USD");
            Assert.IsTrue(rate != 0, "Exchange rate not retrieved: USD");
        }
	
        [TestMethod]
        public void testShouldGetEURExchangeRate()
        {
            // Arrange

            // Act
            this.bitpay = new BitPay(API_KEY);		
            Rates rates = this.bitpay.getRates();

            // Assert
            decimal rate = rates.getRate("EUR");
            Assert.IsTrue(rate != 0, "Exchange rate not retrieved: EUR");
        }
	
        [TestMethod]
        public void testShouldGetCNYExchangeRate() 
        {
            // Arrange

            // Act
            this.bitpay = new BitPay(API_KEY);
            Rates rates = this.bitpay.getRates();

            // Assert
            decimal rate = rates.getRate("CNY");
            Assert.IsTrue(rate != 0, "Exchange rate not retrieved: CNY");
        }
	
        [TestMethod]
        public void testShouldUpdateExchangeRates() 
        {
            // Arrange

            // Act
            this.bitpay = new BitPay(API_KEY);		
            Rates rates = this.bitpay.getRates();		
            rates.update();
		
            // Assert
            List<Rate> listRates = rates.getRates();
            Assert.IsNotNull(listRates, "Exchange rates not retrieved after update");
        }
    }
}
