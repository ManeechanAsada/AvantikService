using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Avantik.Web.Service;

namespace Avantik.Web.Service.Message.Booking
{
    [DataContract]
    public class BookingPaymentVoucherRequest
    {
        [DataMember]
        public BookingMessage Booking { get; set; }
        //[DataMember]
        //public IList<Voucher> Vouchers { get; set; }
        //[DataMember]
        //public string RecordLocator { get; set; }
        //[DataMember]
        //public string ClientProfileId { get; set; }
        //[DataMember]
        //public bool IncludeOpenVoucher { get; set; }
        //[DataMember]
        //public bool IncludeExpiredVoucher { get; set; }
        //[DataMember]
        //public bool IncludeUsedVoucher { get; set; }
        //[DataMember]
        //public bool IncludeVoidedVoucher { get; set; }
        //[DataMember]
        //public bool IncludeRefundable { get; set; }
        //[DataMember]
        //public bool IncludeFareOnly { get; set; }
        //[DataMember]
        //public bool Write { get; set; }
    }
}
