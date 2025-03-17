using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Avantik.Web.Service;
using Avantik.Web.Service.Message.Booking;

namespace Avantik.Web.Service.Message
{
    [DataContract]
    public class GetSegmentFeeRequest
    {
        
        [DataMember]
        public string AgencyCode { set; get; }
        [DataMember]
        public string CurrencyCode { set; get; }

        [DataMember]
        public string LanguageCode { set; get; }

        [DataMember]
        public int NumberOfPassenger { set; get; }

        [DataMember]
        public int NumberOfInfant { set; get; }
        [DataMember]
        public bool SpecialService { set; get; }
        [DataMember]
        public bool bNoVat { set; get; }

        [DataMember]
        public IList<Message.Booking.PassengerService> services { set; get; }

        [DataMember]
        public IList<Message.Fee.SegmentService> segmentService { set; get; }

    }
}
