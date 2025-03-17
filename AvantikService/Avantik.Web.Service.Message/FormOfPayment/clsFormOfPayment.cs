using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.FormOfPayment
{
    public class FormOfPayment 
    {
        #region Property
        [DataMember]
        public IList<FormOfPaymentSubType> FormOfPaymentSubType { get; set; }

        #endregion
    }
}
