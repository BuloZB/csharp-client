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

namespace BitPayAPI
{
    /// <summary>
    /// Provides an interface to a single exchange rate.
    /// </summary>
    public class Rate
    {
        string _name;
        string _code;
        decimal _rate;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">The full display name of the currency.</param>
        /// <param name="code">The three letter code for the currency, in all caps.</param>
        /// <param name="rate">The numeric exchange rate of this currency provided by the BitPay server.</param>
        public Rate(string name, string code, decimal rate)
        {
            _name = name;
            _code = code;
            _rate = rate;
        }

        /// <summary>
        /// The full display name of the currency.
        /// </summary>
        /// <returns></returns>
        public string getName()
        {
            return _name;
        }

        /// <summary>
        /// The three letter code for the currency, in all caps.
        /// </summary>
        /// <returns></returns>
        public string getCode()
        {
            return _code;
        }

        /// <summary>
        /// The numeric exchange rate of this currency provided by the BitPay server.
        /// </summary>
        /// <returns></returns>
        public decimal getRate()
        {
            return _rate;
        }
    }
}
