using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Avantik.Web.Service.Message
{
    [DataContract]
    public class DestinationsResponse : ResponseBase
    {
        [DataMember]
        public IEnumerable<RouteView> Routes { get; set; }
    }
}
