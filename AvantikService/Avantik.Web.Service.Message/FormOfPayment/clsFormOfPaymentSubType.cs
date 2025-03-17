using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.FormOfPayment
{
    public class FormOfPaymentSubType 
    {
        #region Property
        [DataMember]
        public Int32 VoucherReference { get; set; }
        [DataMember]
        public Int16 ExpiryDays { get; set; }
        [DataMember]
        public byte CvvRequiredFlag { get; set; }
        [DataMember]
        public byte ValidateDocumentNumberFlag { get; set; }
        [DataMember]
        public byte DisplayCvvFlag { get; set; }
        [DataMember]
        public byte MultiplePaymentFlag { get; set; }
        [DataMember]
        public byte ApprovalCodeRequiredFlag { get; set; }
        [DataMember]
        public byte DisplayApprovalCodeFlag { get; set; }
        [DataMember]
        public byte DisplayExpiryDateFlag { get; set; }
        [DataMember]
        public byte ExpiryDateRequiredFlag { get; set; }
        [DataMember]
        public byte TravelAgencyPaymentFlag { get; set; }
        [DataMember]
        public byte AgencyPaymentFlag { get; set; }
        [DataMember]
        public byte InternetPaymentFlag { get; set; }
        [DataMember]
        public byte RefundPaymentFlag { get; set; }
        [DataMember]
        public byte AddressRequiredFlag { get; set; }
        [DataMember]
        public byte DisplayAddressFlag { get; set; }
        [DataMember]
        public byte ShowPosIndictorFlag { get; set; }
        [DataMember]
        public byte RequirePosIndicatorFlag { get; set; }
        [DataMember]
        public byte DisplayIssueDateFlag { get; set; }
        [DataMember]
        public byte DisplayIssueNumberFlag { get; set; }
        [DataMember]
        public string FormOfPaymentSubtypeRcd { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public string FormOfPaymentRcd { get; set; }
        [DataMember]
        public string CardCode { get; set; }



        #endregion
    }
}
