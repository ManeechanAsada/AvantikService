using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Fee
{
    public class SegmentService
    {
        [DataMember]
        public Guid FlightConnectionId { get; set; }
        [DataMember]
        public string SpecialServiceRcd { get; set; }
        [DataMember]
        public string OriginRcd { get; set; }
        [DataMember]
        public string DestinationRcd { get; set; }
        [DataMember]
        public string OdOriginRcd { get; set; }
        [DataMember]
        public string OdDestinationRcd { get; set; }
        [DataMember]
        public string BookingClassRcd { get; set; }
        [DataMember]
        public string FareCode { get; set; }
        [DataMember]
        public string AirlineRcd { get; set; }
        [DataMember]
        public string FlightNumber { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime DepartureDate { get; set; }
    }
}
