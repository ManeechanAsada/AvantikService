using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Booking
{
    public class Quote 
    {
        [DataMember]
        public Guid BookingSegmentId { get; set; }
        [DataMember]
        public string PassengerTypeRcd { get; set; }
        [DataMember]
        public string CurrencyRcd { get; set; }
        [DataMember]
        public string ChargeType { get; set; }
        [DataMember]
        public string ChargeName { get; set; }
        [DataMember]
        public decimal ChargeAmount { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public decimal TaxAmount { get; set; }
        [DataMember]
        public int PassengerCount { get; set; }
        [DataMember]
        public int SortSequence { get; set; }
        [DataMember]
        public Guid CreateBy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime CreateDateTime { get; set; }
        [DataMember]
        public Guid UpdateBy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime UpdateDateTime { get; set; }
        [DataMember]
        public decimal RedemptionPoints { get; set; }
        [DataMember]
        public decimal ChargeAmountIncl { get; set; }

    }
}
