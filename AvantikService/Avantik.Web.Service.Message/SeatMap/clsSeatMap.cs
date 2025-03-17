using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.SeatMap
{
    public class SeatMap
    {
        [DataMember]
        public Guid FlightId { get; set; }
        [DataMember]
        public int FreeSeatingFlag { get; set; }
        [DataMember]
        public string FlightCheckInStatusRcd { get; set; }
        [DataMember]
        public string OriginRcd { get; set; }
        [DataMember]
        public string DestinationRcd { get; set; }
        [DataMember]
        public string AircraftConfigurationCode { get; set; }
        [DataMember]
        public int NumberOfBays { get; set; }
        [DataMember]
        public string BoardingClassRcd { get; set; }
        [DataMember]
        public int NumberOfRows { get; set; }
        [DataMember]
        public int NumberOfColumns { get; set; }
        [DataMember]
        public int LayoutRow { get; set; }
        [DataMember]
        public int LayoutColumn { get; set; }
        [DataMember]
        public string LocationTypeRcd { get; set; }
        [DataMember]
        public string SeatColumn { get; set; }
        [DataMember]
        public int StretcherFlag { get; set; }
        [DataMember]
        public int HanddicappedFlag { get; set; }
        [DataMember]
        public int NoChildFlag { get; set; }
        [DataMember]
        public int BassinetFlag { get; set; }
        [DataMember]
        public int NoInfantFlag { get; set; }
        [DataMember]
        public int InfantFlag { get; set; }
        [DataMember]
        public int EmergencyExitFlag { get; set; }
        [DataMember]
        public int UnAccompaniedMinorsFlag { get; set; }
        [DataMember]
        public int WindowFlag { get; set; }
        [DataMember]
        public int AisleFlag { get; set; }
        [DataMember]
        public int BlockB2cFlag { get; set; }
        [DataMember]
        public int BlockB2bFlag { get; set; }
        [DataMember]
        public int BlockedFlag { get; set; }
        [DataMember]
        public int LowComfortFlag { get; set; }
        [DataMember]
        public int PassengerCount { get; set; }
    }
}
