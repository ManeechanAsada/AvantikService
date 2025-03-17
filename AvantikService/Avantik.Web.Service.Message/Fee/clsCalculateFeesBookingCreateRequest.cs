using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Avantik.Web.Service;
using Avantik.Web.Service.Message.Booking;

namespace Avantik.Web.Service.Message
{
    [DataContract]
    public class CalculateFeesBookingCreateRequest
    {
        [DataMember]
        public BookingRequest Booking { set; get; }
        [DataMember]
        public string AgencyCode { set; get; }
        [DataMember]
        public string Currency { set; get; }

        [DataMember]
        public string Language { set; get; }

    }
}
