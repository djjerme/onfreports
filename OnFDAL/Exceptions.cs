using System;
using System.Collections.Generic;
using System.Text;

namespace PBA.OnfDAL
{
    public class DuplicateSerialException : Exception
    {
        public DuplicateSerialException()
        {
        }
        public DuplicateSerialException(string message)
            : base(message)
        {
        }
        public DuplicateSerialException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
