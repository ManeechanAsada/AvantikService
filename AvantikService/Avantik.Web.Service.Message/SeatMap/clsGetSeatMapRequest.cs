using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Avantik.Web.Service;

namespace Avantik.Web.Service.Message.SeatMap
{
    [DataContract]
    public class GetSeatMapRequest
    {
        [DataMember]
        public string StrOrigin { get; set; }
        [DataMember]
        public string StrDestination { get; set; }
        [DataMember]
        public string StrFlightId { get; set; }
        [DataMember]
        public string StrBoardingClass { get; set; }
        [DataMember]
        public string StrBookingClass { get; set; }
    }
}
