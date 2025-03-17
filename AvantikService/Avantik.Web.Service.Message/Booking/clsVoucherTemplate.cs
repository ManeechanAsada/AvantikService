using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message
{
    public class VoucherTemplate
    {
        [DataMember]
        public byte AirlineFlag { get; set; }
        [DataMember]
        public byte B2bFlag { get; set; }
        [DataMember]
        public byte B2cFlag { get; set; }
        [DataMember]
        public byte B2eFlag { get; set; }
        [DataMember]
        public decimal ChargeAmount { get; set; }
        [DataMember]
        public string CurrencyRcd { get; set; }
        [DataMember]
        public string Destinations { get; set; }
        [DataMember]
        public decimal DiscountPercentage { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public byte FareOnlyFlag { get; set; }
        [DataMember]
        public string FormOfPaymentRcd { get; set; }
        [DataMember]
        public string FormOfPaymentSubtypeRcd { get; set; }
        [DataMember]
        public byte MultiplePaymentFlag { get; set; }
        [DataMember]
        public string Origins { get; set; }
        [DataMember]
        public byte OtherFeeFlag { get; set; }
        [DataMember]
        public short PassengerSegments { get; set; }
        [DataMember]
        public byte RecipientOnlyFlag { get; set; }
        [DataMember]
        public byte SeatFeeFlag { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public byte TicketFlag { get; set; }
        [DataMember]
        public int ValidDays { get; set; }
        [DataMember]
        public string ValidForClass { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime ValidFromDate { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime ValidToDate { get; set; }
        [DataMember]
        public Guid VoucherTemplateId { get; set; }
        [DataMember]
        public string VoucherUseCode { get; set; }
        [DataMember]
        public decimal VoucherValue { get; set; }
    }
}
