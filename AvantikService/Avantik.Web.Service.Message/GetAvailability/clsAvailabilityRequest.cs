using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Avantik.Web.Service;

namespace Avantik.Web.Service.Message
{
    [DataContract]
    public class AvailabilityRequest
    {
        [DataMember]
        public string OriginRcd { get; set; }
        [DataMember]
        public string DestinationRcd { get; set; }
        [DataMember]
        public string OdOriginRcd { get; set; }
        [DataMember]
        public string OdDestinationRcd { get; set; }
        [DataMember]
        public string OtherPassengerType { get; set; }
        [DataMember]
        public string BoardingClass { get; set; }
        [DataMember]
        public string BookingClass { get; set; }
        [DataMember]
        public string DayTimeIndicator { get; set; }
        [DataMember]
        public string AgencyCode { get; set; }
        [DataMember]
        public string CurrencyCode { get; set; }
        [DataMember]
        public string ReturnDayTimeIndicator { get; set; }
        [DataMember]
        public string PromotionCode { get; set; }
        [DataMember]
        public Infrastructure.AvailabilityFareTypes FareTypes { get; set; }
        [DataMember]
        public string LanguageCode { get; set; }
        [DataMember]
        public string IpAddress { get; set; }
        [DataMember]
        public string Transitpoint { get; set; }
        [DataMember]
        public string FlightId { get; set; }
        [DataMember]
        public string FareId { get; set; }
        [DataMember]
        public string TransactionReference { get; set; }


        [DataMember(EmitDefaultValue = false)]
        public DateTime FromDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime ToDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime ReturnFromDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime ReturnToDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime BookingDate { get; set; }


        [DataMember]
        public decimal MaxAmount { get; set; }

        [DataMember]
        public bool ShowClose { get; set; }
        [DataMember]
        public bool MapWithFares { get; set; }
        [DataMember]
        public bool ApplyFareLogic { get; set; }
        [DataMember]
        public Int16 NoneStopOnly { get; set; }
        
        [DataMember]
        public byte Adult { get; set; }
        [DataMember]
        public byte Child { get; set; }
        [DataMember]
        public byte Infant { get; set; }
        [DataMember]
        public byte Other { get; set; }
        [DataMember]
        public Int16 IncludeDeparted { get; set; }
        [DataMember]
        public Int16 IncludeCancelled { get; set; }
        [DataMember]
        public Int16 IncludeWaitlisted { get; set; }
        [DataMember]
        public Int16 IncludeSoldOut { get; set; }
        [DataMember]
        public Int16 IncludeFares { get; set; }
        [DataMember]
        public Int16 Refundable { get; set; }
        [DataMember]
        public Int16 ReturnRefundable { get; set; }
        [DataMember]
        public Int16 GroupFares { get; set; }
        [DataMember]
        public Int16 ITFaresOnly { get; set; }
        [DataMember]
        public Int16 StaffFares { get; set; }
        [DataMember]
        public Int16 UnknownTransit { get; set; }
        [DataMember]
        public bool NoVat { get; set; }
        
        [DataMember]
        public Infrastructure.AvailabilityTypes AvailabilityTypes { get; set; }
    }
}
