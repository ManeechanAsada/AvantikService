using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Booking
{
    public class Flight
    {
        [DataMember]
        public string BoardingClassRcd { get; set; }

        [DataMember]
        public string BookingClassRcd { get; set; }

        [DataMember]
        public Guid FlightId { get; set; }

        [DataMember]
        public string OriginRcd { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime DepartureDate { get; set; }

        [DataMember]
        public Guid FairId { get; set; }

        [DataMember]
        public byte EticketFlag { get; set; }

        [DataMember]
        public string OdOriginRcd { get; set; }

        [DataMember]
        public string OdDestinationRcd { get; set; }

        [DataMember]
        public Guid FlightConnectionId { get; set; }

        [DataMember]
        public string DestinationRcd { get; set; }

        [DataMember]
        public string TransitPoints { get; set; }

        [DataMember]
        public string TransitPointsName { get; set; }

        [DataMember]
        public string AirlineRcd { get; set; }

        [DataMember]
        public string FlightNumber { get; set; }

        [DataMember]
        public int NumberOfUnits { get; set; }
    }
}
