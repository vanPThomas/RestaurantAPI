using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    internal class ContactException : Exception
    {
        public ContactException()
            : base() { }

        public ContactException(string message)
            : base(message) { }

        public ContactException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
