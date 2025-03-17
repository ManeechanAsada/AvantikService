using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Avantik.Web.Service.Message
{
    [DataContract]
    public class DestinationsRequest
    {
        [DataMember]
        public bool B2CFlag { get; set; }
        [DataMember]
        public bool B2BFlag { get; set; }
        [DataMember]
        public bool B2EFlag { get; set; }
        [DataMember]
        public bool B2SFlag { get; set; }
        [DataMember]
        public bool APIFlag { get; set; }
        [DataMember]
        public string Language { get; set; }
    }
}
