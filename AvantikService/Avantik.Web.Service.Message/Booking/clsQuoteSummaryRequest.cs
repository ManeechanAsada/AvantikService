using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Avantik.Web.Service.Message.Booking
{
    [DataContract]
    public class QuoteSummaryRequest
    {
        [DataMember]
        public IList<FlightSegment> FlightSegments { get; set; }
        [DataMember]
        public IList<Passenger> Passengers { get; set; }
        [DataMember]
        public string AgencyCode { get; set; }
        [DataMember]
        public string Language { get; set; }
        [DataMember]
        public string CurrencyCode { get; set; }
        [DataMember]
        public bool bNovat { get; set; }
    }
}
