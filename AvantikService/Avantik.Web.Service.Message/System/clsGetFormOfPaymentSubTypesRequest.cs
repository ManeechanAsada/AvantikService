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
    public class GetFormOfPaymentSubTypesRequest
    {
        [DataMember]
        public string StrLanguage { set; get; }
        [DataMember]
        public string Type { set; get; }


    }
}
