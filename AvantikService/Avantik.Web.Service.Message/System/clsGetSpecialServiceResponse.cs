using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Avantik.Web.Service;

namespace Avantik.Web.Service.Message
{
      [DataContract]
    public class GetSpecialServiceResponse : ResponseBase
    {
          [DataMember]
          public IList<Message.SpecialService> SpecialServices { get; set; }

    }
}
