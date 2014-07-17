/**
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

using System;

namespace BitPayAPI
{
    /// <summary>
    /// Provides an API specific exception handler.
    /// </summary>
    public class BitPayException : Exception
    {
        private string _message = "Exception information not provided";
        private Exception _inner = null;

        /// <summary>
        /// Constructor.  Creates an empty exception.
        /// </summary>
        public BitPayException()
        {
        }

        /// <summary>
        /// Constructor.  Creates an exception with a message only.
        /// </summary>
        /// <param name="message">The message text for the exception.</param>
        public BitPayException(string message) : base(message)
        {
            _message = message;
        }

        /// <summary>
        /// Constructor.  Creates an exception with a message and root cause exception.
        /// </summary>
        /// <param name="message">The message text for the exception.</param>
        /// <param name="inner">The root cause exception.</param>
        public BitPayException(string message, Exception inner) : base(message, inner)
        {
            _message = message;
            _inner = inner;
        }

        /// <summary>
        /// The exception message text.
        /// </summary>
        /// <returns>The exception message text.</returns>
        public string getMessage()
        {
            return _message;
        }

        /// <summary>
        /// The root cause exception.
        /// </summary>
        /// <returns>The root cause exception.</returns>
        public Exception getInner()
        {
            return _inner;
        }
    }
}