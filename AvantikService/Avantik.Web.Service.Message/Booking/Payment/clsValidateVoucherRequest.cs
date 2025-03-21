﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Avantik.Web.Service;

namespace Avantik.Web.Service.Message.Booking
{
    [DataContract]
    public class ValidateVoucherRequest
    {
        [DataMember]
        public IList<Voucher> Vouchers { get; set; }
        [DataMember]
        public Payment Payment { get; set; }
    }
}
