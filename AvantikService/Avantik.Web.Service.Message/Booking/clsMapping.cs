using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Booking
{
    public class Mapping 
    {
        public string OriginRcd { get; set; }
 	 	 [DataMember] 
        public string DestinationRcd { get; set; }
 	 	 [DataMember] 
        public string DisplayName { get; set; }
 	 	 [DataMember] 
        public Guid CreateBy { get; set; }
 	 	 [DataMember] 
        public Guid UpdateBy { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime CreateDateTime { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime UpdateDateTime { get; set; }
 	 	 [DataMember] 
        public string CurrencyRcd { get; set; }
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
        public Guid BookingId { get; set; }
 	 	 [DataMember] 
        public int NumberOfUnits { get; set; }
 	 	 [DataMember] 
        public byte InfoSegmentFlag { get; set; }
 	 	 [DataMember] 
        public byte HighPriorityWaitlistFlag { get; set; }
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
 	 	 [DataMember] 
        public Guid PassengerId { get; set; }
 	 	 [DataMember] 
        public string Lastname { get; set; }
 	 	 [DataMember] 
        public string Firstname { get; set; }
 	 	 [DataMember] 
        public string GenderTypeRcd { get; set; }
 	 	 [DataMember] 
        public string TitleRcd { get; set; }
 	 	 [DataMember] 
        public string PassengerTypeRcd { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime DateOfBirth { get; set; }
 	 	 [DataMember] 
        public string PassengerStatusRcd { get; set; }
 	 	 [DataMember] 
        public string Middlename { get; set; }
 	 	 [DataMember] 
        public string DocumentTypeRcd { get; set; }
 	 	 [DataMember] 
        public string PassportNumber { get; set; }
 	 	 [DataMember] 
        public string PassportIssuePlace { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime PassportIssueDate { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime PassportExpiryDate { get; set; }
 	 	 [DataMember] 
        public string Sendmail { get; set; }
 	 	 [DataMember] 
        public long ClientNumber { get; set; }
 	 	 [DataMember] 
        public Guid PassengerProfileId { get; set; }
 	 	 [DataMember] 
        public Guid ClientProfileId { get; set; }
 	 	 [DataMember] 
        public string EmployeeNumber { get; set; }
 	 	 [DataMember] 
        public string NationalityRcd { get; set; }
 	 	 [DataMember] 
        public string ContactEmail { get; set; }
 	 	 [DataMember] 
        public string InventoryClassRcd { get; set; }
 	 	 [DataMember] 
        public string SeatNumber { get; set; }
 	 	 [DataMember] 
        public int SeatRow { get; set; }
 	 	 [DataMember] 
        public string SeatColumn { get; set; }
 	 	 [DataMember] 
        public decimal NetTotal { get; set; }
 	 	 [DataMember] 
        public decimal TaxAmount { get; set; }
 	 	 [DataMember] 
        public decimal FareAmount { get; set; }
 	 	 [DataMember] 
        public decimal YqAmount { get; set; }
 	 	 [DataMember] 
        public decimal BaseTicketingFeeAmount { get; set; }
 	 	 [DataMember] 
        public decimal TicketingFeeAmount { get; set; }
 	 	 [DataMember] 
        public decimal ReservationFeeAmount { get; set; }
 	 	 [DataMember] 
        public decimal CommissionAmount { get; set; }
 	 	 [DataMember] 
        public decimal FareVat { get; set; }
 	 	 [DataMember] 
        public decimal TaxVat { get; set; }
 	 	 [DataMember] 
        public decimal YqVat { get; set; }
 	 	 [DataMember] 
        public decimal TicketingFeeVat { get; set; }
 	 	 [DataMember] 
        public decimal ReservationFeeVat { get; set; }
 	 	 [DataMember] 
        public decimal FareAmountIncl { get; set; }
 	 	 [DataMember] 
        public decimal TaxAmountIncl { get; set; }
 	 	 [DataMember] 
        public decimal YqAmountIncl { get; set; }
 	 	 [DataMember] 
        public decimal PublicFareAmountIncl { get; set; }
 	 	 [DataMember] 
        public decimal PublicFareAmount { get; set; }
 	 	 [DataMember] 
        public decimal CommissionAmountIncl { get; set; }
 	 	 [DataMember] 
        public decimal CommissionPercentage { get; set; }
 	 	 [DataMember] 
        public decimal TicketingFeeAmountIncl { get; set; }
 	 	 [DataMember] 
        public decimal ReservationFeeAmountIncl { get; set; }
 	 	 [DataMember] 
        public decimal AcctNetTotal { get; set; }
 	 	 [DataMember] 
        public decimal AcctTaxAmount { get; set; }
 	 	 [DataMember] 
        public decimal AcctFareAmount { get; set; }
 	 	 [DataMember] 
        public decimal AcctYqAmount { get; set; }
 	 	 [DataMember] 
        public decimal AcctTicketingFeeAmount { get; set; }
 	 	 [DataMember] 
        public decimal AcctReservationFeeAmount { get; set; }
 	 	 [DataMember] 
        public decimal AcctCommissionAmount { get; set; }
 	 	 [DataMember] 
        public decimal AcctFareAmountIncl { get; set; }
 	 	 [DataMember] 
        public decimal AcctTaxAmountIncl { get; set; }
 	 	 [DataMember] 
        public decimal AcctYqAmountIncl { get; set; }
 	 	 [DataMember] 
        public decimal AcctCommissionAmountIncl { get; set; }
 	 	 [DataMember] 
        public decimal AcctTicketingFeeAmountIncl { get; set; }
 	 	 [DataMember] 
        public decimal AcctReservationFeeAmountIncl { get; set; }
 	 	 [DataMember] 
        public string FareCode { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime FareDateTime { get; set; }
 	 	 [DataMember] 
        public byte ETicketFlag { get; set; }
 	 	 [DataMember] 
        public byte StandbyFlag { get; set; }
 	 	 [DataMember] 
        public byte TransferableFareFlag { get; set; }
 	 	 [DataMember] 
        public string AgencyCode { get; set; }
 	 	 [DataMember] 
        public string TicketNumber { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime TicketingDateTime { get; set; }
 	 	 [DataMember] 
        public Guid TicketingBy { get; set; }
 	 	 [DataMember] 
        public int CheckInSequence { get; set; }
 	 	 [DataMember] 
        public int GroupSequence { get; set; }
 	 	 [DataMember] 
        public Guid UnloadBy { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime UnloadDateTime { get; set; }
 	 	 [DataMember] 
        public int NumberOfPieces { get; set; }
 	 	 [DataMember] 
        public decimal BaggageWeight { get; set; }
 	 	 [DataMember] 
        public decimal ExcessBaggageWeight { get; set; }
 	 	 [DataMember] 
        public decimal CheckInBaggageWeight { get; set; }
 	 	 [DataMember] 
        public Guid CheckInBy { get; set; }
 	 	 [DataMember] 
        public Guid CancelBy { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime ExchangedDateTime { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime CancelDateTime { get; set; }
 	 	 [DataMember] 
        public string RestrictionText { get; set; }
 	 	 [DataMember] 
        public string EndorsementText { get; set; }
 	 	 [DataMember] 
        public byte ExcludePricingFlag { get; set; }
 	 	 [DataMember] 
        public string CreateName { get; set; }
 	 	 [DataMember] 
        public string UpdateName { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime VoidDateTime { get; set; }
 	 	 [DataMember] 
        public decimal RefundCharge { get; set; }
 	 	 [DataMember] 
        public decimal RefundableAmount { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime RefundDateTime { get; set; }
 	 	 [DataMember] 
        public decimal PaymentAmount { get; set; }
 	 	 [DataMember] 
        public int MappingSort { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime CheckInDateTime { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime OnwardDepartureDate { get; set; }
 	 	 [DataMember] 
        public string ETicketStatus { get; set; }
 	 	 [DataMember] 
        public byte HandLuggageFlag { get; set; }
 	 	 [DataMember] 
        public int HandNumberOfPieces { get; set; }
 	 	 [DataMember] 
        public double HandBaggageWeight { get; set; }
 	 	 [DataMember] 
        public byte FreeSeatingFlag { get; set; }
 	 	 [DataMember] 
        public string FareTypeRcd { get; set; }
 	 	 [DataMember] 
        public double RedemptionPoints { get; set; }
 	 	 [DataMember] 
        public string SeatFeeRcd { get; set; }
 	 	 [DataMember] 
        public Int16 RefundWithChargeHours { get; set; }
 	 	 [DataMember] 
        public Int16 RefundNotPossibleHours { get; set; }
 	 	 [DataMember] 
        public byte DutyTravelFlag { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime NotValidAfterDate { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime NotValidBeforeDate { get; set; }
 	 	 [DataMember] 
        public byte AdvancedSeatingFlag { get; set; }
 	 	 [DataMember] 
        public byte FareColumn { get; set; }
 	 	 [DataMember] 
        public Int16 PieceAllowance { get; set; }
 	 	 [DataMember] 
        public int BoardingTime { get; set; }
 	 	 [DataMember] 
        public byte ItFareFlag { get; set; }

         [DataMember]
         public byte ThroughFareFlag { get; set; }



    }
}
