using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Exceptions
{
    public class DemoException : Exception
    {
        public DemoException() : base() { }

        public DemoException(string message) : base(message) { }

        public DemoException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
