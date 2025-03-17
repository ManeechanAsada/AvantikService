using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Avantik.Web.Service;
using Avantik.Web.Service.Message.Agency;

namespace Avantik.Web.Service.Message.Booking
{
    [DataContract]
    public class BookingSaveRequest
    {
        [DataMember]
        public BookingRequest Booking { get; set; }

        [DataMember]
        public bool CheckSeatAssignment { get; set; }
        
        [DataMember]
        public bool CheckSessionTimeOut { get; set; }

    }
}
