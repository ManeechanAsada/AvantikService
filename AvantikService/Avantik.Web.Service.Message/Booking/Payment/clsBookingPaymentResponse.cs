using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Avantik.Web.Service;

namespace Avantik.Web.Service.Message.Booking
{
    [DataContract]
    public class BookingPaymentResponse : ResponseBase
    {
    }

    public class BookingExternalPaymentResponse : ResponseBase
    {
        [DataMember]
        public string Result { get; set; }
    }

}
