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
    public class BaggageFeeResponse : ResponseBase
    {
        [DataMember]
        public List<Message.Fee.BaggageFeeView> BaggageFees { get; set; }
    }
}
