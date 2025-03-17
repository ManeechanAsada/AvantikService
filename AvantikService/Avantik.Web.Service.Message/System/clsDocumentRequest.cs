using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Avantik.Web.Service.Message.System
{
    [DataContract]
    public class DocumentRequest
    {
        [DataMember]
        public string Language { get; set; }
    }
}
