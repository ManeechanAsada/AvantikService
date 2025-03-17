using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Avantik.Web.Service.Message.Fee
{
    public class BaggageFeeView
    {
        [DataMember]
        public Guid baggage_fee_option_id { get; set; }
        [DataMember]
        public Guid passenger_id { get; set; }
        [DataMember]
        public Guid booking_segment_id { get; set; }
        [DataMember]
        public Guid fee_id { get; set; }
        [DataMember]
        public string fee_rcd { get; set; }
        [DataMember]
        public string fee_category_rcd { get; set; }
        [DataMember]
        public string currency_rcd { get; set; }
        [DataMember]
        public string display_name { get; set; }
        [DataMember]
        public decimal number_of_units { get; set; }
        [DataMember]
        public decimal fee_amount { get; set; }
        [DataMember]
        public decimal fee_amount_incl { get; set; }
        [DataMember]
        public decimal total_amount { get; set; }
        [DataMember]
        public decimal total_amount_incl { get; set; }
        [DataMember]
        public decimal vat_percentage { get; set; }      
    }
}
