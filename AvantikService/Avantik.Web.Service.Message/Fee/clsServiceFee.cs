using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Fee
{
    public class ServiceFee : SegmentService
    {
        [DataMember]
        public string FeeRcd { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public string CurrencyRcd { get; set; }
        [DataMember]
        public decimal FeeAmount { get; set; }
        [DataMember]
        public decimal FeeAmountIncl { get; set; }
        [DataMember]
        public decimal TotalFeeAmount { get; set; }
        [DataMember]
        public decimal TotalFeeAmountIncl { get; set; }
        [DataMember]
        public bool ServiceOnRequestFlag { get; set; }
        [DataMember]
        public bool CutOffTime { get; set; }

    }
}
