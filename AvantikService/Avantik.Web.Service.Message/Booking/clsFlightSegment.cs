using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Booking
{
    public class FlightSegment
    {
        [DataMember]
        public string OriginRcd { get; set; }
        [DataMember]
        public string DestinationRcd { get; set; }
        [DataMember]
        public Guid CreateBy { get; set; }
        [DataMember]
        public Guid UpdateBy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime CreateDateTime { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime UpdateDateTime { get; set; }
        [DataMember]
        public Int16 RoutesTot { get; set; }
        [DataMember]
        public Int16 RoutesAvl { get; set; }
        [DataMember]
        public Int16 RoutesB2c { get; set; }
        [DataMember]
        public Int16 RoutesB2b { get; set; }
        [DataMember]
        public Int16 RoutesB2s { get; set; }
        [DataMember]
        public Int16 RoutesApi { get; set; }
        [DataMember]
        public Int16 RoutesB2t { get; set; }
        [DataMember]
        public bool SegmentChangeFeeFlag { get; set; }
        [DataMember]
        public bool TransitFlag { get; set; }
        [DataMember]
        public bool DirectFlag { get; set; }
        [DataMember]
        public bool AvlFlag { get; set; }
        [DataMember]
        public bool B2cFlag { get; set; }
        [DataMember]
        public bool B2bFlag { get; set; }
        [DataMember]
        public bool B2tFlag { get; set; }
        [DataMember]
        public Int16 DayRange { get; set; }
        [DataMember]
        public bool ShowRedressNumberFlag { get; set; }
        [DataMember]
        public bool RequirePassengerTitleFlag { get; set; }
        [DataMember]
        public bool RequirePassengerGenderFlag { get; set; }
        [DataMember]
        public bool RequireDateOfBirthFlag { get; set; }
        [DataMember]
        public bool RequireDocumentDetailsFlag { get; set; }
        [DataMember]
        public bool RequirePassengerWeightFlag { get; set; }
        [DataMember]
        public bool SpecialServiceFeeFlag { get; set; }
        [DataMember]
        public bool ShowInsuranceOnWebFlag { get; set; }
        [DataMember]
        public Guid FlightId { get; set; }
        [DataMember]
        public Guid ExchangedSegmentId { get; set; }
        [DataMember]
        public string AirlineRcd { get; set; }
        [DataMember]
        public string FlightNumber { get; set; }
        [DataMember]
        public byte RefundableFlag { get; set; }
        [DataMember]
        public byte GroupFlag { get; set; }
        [DataMember]
        public byte NonRevenueFlag { get; set; }
        [DataMember]
        public byte EticketFlag { get; set; }
        [DataMember]
        public byte FareReduction { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime DepartureDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime ArrivalDate { get; set; }
        [DataMember]
        public string OdOriginRcd { get; set; }
        [DataMember]
        public string OdDestinationRcd { get; set; }
        [DataMember]
        public byte WaitlistFlag { get; set; }
        [DataMember]
        public byte OverbookFlag { get; set; }
        [DataMember]
        public Guid FlightConnectionId { get; set; }
        [DataMember]
        public byte AdvancedPurchaseFlag { get; set; }
        [DataMember]
        public int JourneyTime { get; set; }
        [DataMember]
        public int DepartureTime { get; set; }
        [DataMember]
        public int ArrivalTime { get; set; }
        [DataMember]
        public string OriginName { get; set; }
        [DataMember]
        public string DestinationName { get; set; }
        [DataMember]
        public Guid TransitFlightId { get; set; }
        [DataMember]
        public Guid TransitFareId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime TransitDepartureDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime TransitArrivalDate { get; set; }
        [DataMember]
        public Guid FareId { get; set; }
        [DataMember]
        public string BookingClassRcd { get; set; }
        [DataMember]
        public string BoardingClassRcd { get; set; }
        [DataMember]
        public string AircraftTypeRcd { get; set; }
        [DataMember]
        public Int16 PlannedDepartureTime { get; set; }
        [DataMember]
        public Int16 PlannedArrivalTime { get; set; }
        [DataMember]
        public byte DepartureDayofweek { get; set; }
        [DataMember]
        public byte ArrivalDayofweek { get; set; }
        [DataMember]
        public int DepartureMonth { get; set; }
        [DataMember]
        public Guid BookingSegmentId { get; set; }
        [DataMember]
        public string SegmentStatusRcd { get; set; }
        [DataMember]
        public Guid BookingId { get; set; }
        [DataMember]
        public int NumberOfUnits { get; set; }
        [DataMember]
        public string SegmentChangeStatusRcd { get; set; }
        [DataMember]
        public byte InfoSegmentFlag { get; set; }
        [DataMember]
        public byte HighPriorityWaitlistFlag { get; set; }
        [DataMember]
        public string SegmentStatusName { get; set; }
        [DataMember]
        public byte SeatmapFlag { get; set; }
        [DataMember]
        public byte TempSeatmapFlag { get; set; }
        [DataMember]
        public byte AllowWebCheckinFlag { get; set; }
        [DataMember]
        public Int16 CloseWebSalesFlag { get; set; }
        [DataMember]
        public Int16 ExcludeQuoteFlag { get; set; }
        [DataMember]
        public double CurrencyRate { get; set; }
        [DataMember]
        public byte OpenSequence { get; set; }
        [DataMember]
        public byte NumberOfStops { get; set; }

    }
}
