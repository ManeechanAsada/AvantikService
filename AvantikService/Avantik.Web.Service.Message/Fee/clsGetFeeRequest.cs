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
    public class GetFeeRequest
    {
        [DataMember]
        public string StrFeeRcd { set; get; }
        [DataMember]
        public string StrCurrencyCode { set; get; }
        [DataMember]
        public string StrAgencyCode { set; get; }

        [DataMember]
        public string StrClass { set; get; }
        [DataMember]
        public string StrFareBasis { set; get; }
        [DataMember]
        public string StrOrigin { set; get; }
        [DataMember]
        public string StrDestination { set; get; }
        [DataMember]
        public string StrFlightNumber { set; get; }
        [DataMember]
        public string StrLanguage { set; get; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime DtDate { set; get; }
        [DataMember]
        public bool bNoVat { set; get; }


    }
}
