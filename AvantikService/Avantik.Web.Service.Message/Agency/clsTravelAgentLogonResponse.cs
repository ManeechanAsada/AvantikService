using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Avantik.Web.Service;
using Avantik.Web.Service.Message.Agency;

namespace Avantik.Web.Service.Message
{
      [DataContract]
    public class TravelAgentLogonResponse : ResponseBase
    {
          [DataMember]
          public Agent AgentResponse { get; set; }

    }
}
