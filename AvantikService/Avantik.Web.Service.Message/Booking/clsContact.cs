using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Booking
{
    [DataContract]
    public  class Contact 
    {
        [DataMember]
        public Address Address { get; set; }
        [DataMember]
        public Phone Phone { get; set; }
    }
}
