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
    public class BookingPaymentCreditCardRequest 
    {
        [DataMember]
        public BookingRequest Booking { get; set; }
        [DataMember]
        public Fee PaymentFee { get; set; }
        [DataMember]
        public string SecurityToken { get; set; }
        [DataMember]
        public string AuthenticationToken { get; set; }
        [DataMember]
        public string CommerceIndicator { get; set; }
        [DataMember]
        public string BookingReference { get; set; }
        [DataMember]
        public string RequestSource { get; set; }
    }
}
