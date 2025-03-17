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
    public class BookingFlightRequest
    {

        [DataMember]
        public string AgencyCode { get; set; }

        [DataMember]
        public string Currency { get; set; }

        [DataMember]
        public IList<Flight> Flight { get; set; }

        [DataMember]
        public string BookingId { get; set; }

        [DataMember]
        public short Adults { get; set; }

        [DataMember]
        public short Children { get; set; }

        [DataMember]
        public short Infants { get; set; }

        [DataMember]
        public short Others { get; set; }

        [DataMember]
        public string StrOthers { get; set; }

        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string StrIpAddress { get; set; }

        [DataMember]
        public string StrLanguageCode { get; set; }

        [DataMember]
        public bool BNoVat { get; set; }

    }
}
