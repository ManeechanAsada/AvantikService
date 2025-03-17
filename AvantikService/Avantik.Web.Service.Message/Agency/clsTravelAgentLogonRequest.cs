﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Avantik.Web.Service;

namespace Avantik.Web.Service.Message
{
    [DataContract]
    public class TravelAgentLogonRequest
    {
        [DataMember]
        public string AgencyCode { set; get; }
        [DataMember]
        public string AgentLogon { set; get; }
        [DataMember]
        public string AgentPassword { set; get; }


    }
}
