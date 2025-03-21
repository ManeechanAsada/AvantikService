﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Avantik.Web.Service;

namespace Avantik.Web.Service.Message.SeatMap
{
    [DataContract]
    public class GetSeatMapResponse : ResponseBase
    {
        [DataMember]
        public IList<SeatMap> SeatMaps { get; set; }
    }
}
