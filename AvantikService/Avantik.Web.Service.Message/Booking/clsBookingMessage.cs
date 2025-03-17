using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Booking
{
    [DataContract]
    public class BookingMessage
    {
        [DataMember]
        public BookingHeader Header { get; set; }
        [DataMember]
        public Contact Contact { get; set; }
        [DataMember]
        public IList<FlightSegment>  FlightSegments { get; set; }
        [DataMember]
        public IList<Passenger> Passengers { get; set; }
        [DataMember]
        public IList<Mapping> Mappings { get; set; }
        [DataMember]
        public IList<PassengerService> Services { get; set; }
        [DataMember]
        public IList<Fee> Fees { get; set; }
        [DataMember]
        public IList<Tax> Taxs { get; set; }
        [DataMember]
        public IList<Payment> Payments { get; set; }
        [DataMember]
        public IList<Remark> Remarks { get; set; }
        [DataMember]
        public IList<Quote> Quotes { get; set; }
    }
}
