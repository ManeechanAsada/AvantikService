using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message
{
    public class Voucher : VoucherTemplate
    {
        #region Property
        [DataMember]
        public string AgencyCode { get; set; }
        [DataMember]
        public Guid CreateBy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime CreateDateTime { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime ExpiryDateTime { get; set; }
        [DataMember]
        public decimal PaymentTotal { get; set; }
        [DataMember]
        public byte PercentageFlag { get; set; }
        [DataMember]
        public string RecipientName { get; set; }
        [DataMember]
        public byte RefundableFlag { get; set; }
        [DataMember]
        public byte SingleFlightFlag { get; set; }
        [DataMember]
        public byte SinglePassengerFlag { get; set; }
        [DataMember]
        public Guid UpdateBy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime UpdateDateTime { get; set; }
        [DataMember]
        public string VoucherId { get; set; }
        [DataMember]
        public string VoucherNumber { get; set; }
        [DataMember]
        public string VoucherPassword { get; set; }
        [DataMember]
        public string VoucherStatusRcd { get; set; }
        #endregion
    }
}
