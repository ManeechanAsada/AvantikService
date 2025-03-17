using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Avantik.Web.Service.Message.Booking
{
    [DataContract]
    public class QuoteSummaryResponse : ResponseBase
    {
        [DataMember]
        public BookingResponse BookingResponse { get; set; }
    }
}
