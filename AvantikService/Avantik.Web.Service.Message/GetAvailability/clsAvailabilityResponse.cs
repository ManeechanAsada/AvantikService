using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message
{
    [DataContract]
    public class AvailabilityResponse : ResponseBase
    {
        [DataMember]
        public IEnumerable<AvailabilityView> AvailabilityOutbound { get; set; }
        [DataMember]
        public IEnumerable<AvailabilityView> AvailabilityReturn { get; set; }
    }
}
