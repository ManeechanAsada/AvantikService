using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Booking
{
    public class Phone 
    {
        #region Property
        [DataMember]
        public string PhoneMobile { get; set; }
        [DataMember]
        public string PhoneHome { get; set; }
        [DataMember]
        public string PhoneBusiness { get; set; }
        [DataMember]
        public string PhoneFax { get; set; }

        #endregion
    }
}
