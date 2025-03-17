using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Avantik.Web.Service.Exception.Booking
{
    [Serializable]
    public class BookingException : System.Exception
    {
        string _ErrorCode = string.Empty;
        public string ErrorCode
        {
            get { return _ErrorCode; }
        }

        public BookingException()
        {
        }

        public BookingException(string message)
            : base(message)
        {
        }

        public BookingException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
        public BookingException(string message, string errorCode)
            : base(message)
        {
            _ErrorCode = errorCode;
        }
    }
}
