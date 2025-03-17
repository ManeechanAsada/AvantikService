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
    public class BookingPaymentRequest
    {
        [DataMember]
        public IList<Mapping> Mappings { get; set; }
        [DataMember]
        public IList<Fee> Fees { get; set; }
        [DataMember]
        public IList<Payment> Payments { get; set; }
        [DataMember]
        public bool CreateTicket { get; set; }
    }
}
