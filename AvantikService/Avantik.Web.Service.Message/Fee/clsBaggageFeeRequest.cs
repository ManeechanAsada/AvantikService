using Avantik.Web.Service.Message.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Avantik.Web.Service.Message.Fee
{
    [DataContract]
    public class BaggageFeeRequest
    {
        [DataMember]
        public Guid BookingSegmentId { get; set; }
        [DataMember]
        public Guid PassengerId { get; set; }
        [DataMember]
        public string AgencyCode { get; set; }
        [DataMember]
        public string LanguageCode { get; set; }
        [DataMember]
        public IList<Mapping> Mappings { get; set; }
        [DataMember]
        public int MaxUnit { get; set; }
        [DataMember]
        public IList<Message.Booking.Fee> BookingFees { get; set; }

        [DataMember]
        public bool bNovat { get; set; }
    }
}
