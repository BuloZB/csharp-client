//
// The MIT License (MIT)
//
// Copyright (c) 2011-2014 BitPay
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BitPayAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitPayTest.Unittests
{
    [TestClass]
    public class InvoiceTests
    {
        [TestMethod]
        public void ctor_CurrentCultureUsesCommaAsDecimalSeparator_ParsesCorrectly()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");
            dynamic d = new ExpandoObject();
            d.id = "";
            d.url = "";
            d.status = "";
            d.btcPrice = "1.23";
            d.price = "2.34";
            d.currency = "SEK";

            var invoice = new Invoice(d);

            Assert.AreEqual(1.23,invoice.btcPrice);
            Assert.AreEqual(2.34,invoice.price);
        }
    }
}
