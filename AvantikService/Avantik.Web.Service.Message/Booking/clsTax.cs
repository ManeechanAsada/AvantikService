using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Booking
{
    public class Tax 
    {
        [DataMember]
        public Guid PassengerSegmentTaxId { get; set; }
        [DataMember]
        public decimal TaxAmount { get; set; }
        [DataMember]
        public decimal TaxAmountIncl { get; set; }
        [DataMember]
        public decimal AcctAmount { get; set; }
        [DataMember]
        public decimal AcctAmountIncl { get; set; }
        [DataMember]
        public decimal SalesAmount { get; set; }
        [DataMember]
        public decimal SalesAmountIncl { get; set; }
        [DataMember]
        public string TaxRcd { get; set; }
        [DataMember]
        public Guid PassengerId { get; set; }
        [DataMember]
        public Guid TaxId { get; set; }
        [DataMember]
        public Guid BookingSegmentId { get; set; }
        [DataMember]
        public string TaxCurrencyRcd { get; set; }
        [DataMember]
        public string SalesCurrencyRcd { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public string SummarizeUp { get; set; }
        [DataMember]
        public string CoverageType { get; set; }
        [DataMember]
        public Guid CreateBy { get; set; }
        [DataMember]
        public Guid UpdateBy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime CreateDateTime { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime UpdateDateTime { get; set; }
        [DataMember]
        public decimal VatPercentage { get; set; }
    }
}
