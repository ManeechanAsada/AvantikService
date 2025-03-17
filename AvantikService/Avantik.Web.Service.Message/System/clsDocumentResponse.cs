using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Avantik.Web.Service.Message.System
{
    [DataContract]
    public class DocumentResponse : ResponseBase
    {
        [DataMember]
        public IEnumerable<DocumentView> DocumentType { get; set; }
    }
}
