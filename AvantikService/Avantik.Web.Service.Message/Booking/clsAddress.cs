using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Booking
{
    public class Address 
    {
        #region Property
        [DataMember]
        public string AddressLine1  { get; set; }
        [DataMember]
        public string AddressLine2 { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string PoBox { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string District { get; set; }
        [DataMember]
        public string Province { get; set; }
        [DataMember]
        public string ZipCode { get; set; }
        [DataMember]
        public string CountryRccd { get; set; }

        #endregion
    }
}
