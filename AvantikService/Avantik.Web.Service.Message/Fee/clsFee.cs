using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Fee
{
    public class Fee
    {
        [DataMember]
        public Guid AccountFeeBy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime AccountFeeDateTime { get; set; }
        [DataMember]
        public decimal AcctFeeAmount { get; set; }
        [DataMember]
        public decimal AcctFeeAmountIncl { get; set; }
        [DataMember]
        public string AgencyCode { get; set; }
        [DataMember]
        public Guid BaggageFeeOptionId { get; set; }
        [DataMember]
        public Guid BookingFeeId { get; set; }
        [DataMember]
        public Guid BookingId { get; set; }
        [DataMember]
        public Guid BookingSegmentId { get; set; }
        [DataMember]
        public string ChangeComment { get; set; }
        [DataMember]
        public decimal ChargeAmount { get; set; }
        [DataMember]
        public decimal ChargeAmountIncl { get; set; }
        [DataMember]
        public string ChargeCurrencyRcd { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public Guid CreateBy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime CreateDateTime { get; set; }
        [DataMember]
        public string CurrencyRcd { get; set; }
        [DataMember]
        public string DestinationRcd { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime DocumentDateTime { get; set; }
        [DataMember]
        public string DocumentNumber { get; set; }
        [DataMember]
        public string ExternalReference { get; set; }
        [DataMember]
        public decimal FeeAmount { get; set; }
        [DataMember]
        public decimal FeeAmountIncl { get; set; }
        [DataMember]
        public string FeeCalculationRcd { get; set; }
        [DataMember]
        public string FeeCategoryRcd { get; set; }
        [DataMember]
        public Guid FeeId { get; set; }
        [DataMember]
        public string FeeLevel { get; set; }
        [DataMember]
        public decimal FeePercentage { get; set; }
        [DataMember]
        public string FeeRcd { get; set; }
        [DataMember]
        public byte ManualFeeFlag { get; set; }
        [DataMember]
        public byte MinimumFeeAmountFlag { get; set; }
        [DataMember]
        public bool NewRecord { get; set; }
        [DataMember]
        public decimal NumberOfUnits { get; set; }
        [DataMember]
        public string OdDestinationRcd { get; set; }
        [DataMember]
        public byte OdFlag { get; set; }
        [DataMember]
        public string OdOriginRcd { get; set; }
        [DataMember]
        public string OriginRcd { get; set; }
        [DataMember]
        public Guid PassengerId { get; set; }
        [DataMember]
        public Guid PassengerSegmentServiceId { get; set; }
        [DataMember]
        public decimal PaymentAmount { get; set; }
        [DataMember]
        public bool SelectedFee { get; set; }
        [DataMember]
        public byte SkipFareAllowanceFlag { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public decimal TotalAmountIncl { get; set; }
        [DataMember]
        public decimal TotalFeeAmount { get; set; }
        [DataMember]
        public decimal TotalFeeAmountIncl { get; set; }
        [DataMember]
        public string Units { get; set; }
        [DataMember]
        public Guid UpdateBy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime UpdateDateTime { get; set; }
        [DataMember]
        public decimal VatPercentage { get; set; }
        [DataMember]
        public string VendorRcd { get; set; }
        [DataMember]
        public Guid VoidBy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime VoidDateTime { get; set; }
    }
}
