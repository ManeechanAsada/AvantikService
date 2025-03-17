using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Booking
{
    public class Payment
    {
        [DataMember]
        public Guid BookingPaymentId { get; set; }
        [DataMember]
        public Guid BookingSegmentId { get; set; }
        [DataMember]
        public Guid BookingId { get; set; }
        [DataMember]
        public Guid VoucherPaymentId { get; set; }
        [DataMember]
        public string FormOfPaymentRcd { get; set; }
        [DataMember]
        public string CurrencyRcd { get; set; }
        [DataMember]
        public string ReceiveCurrencyRcd { get; set; }
        [DataMember]
        public string AgencyPaymentTypeRcd { get; set; }
        [DataMember]
        public string AgencyCode { get; set; }
        [DataMember]
        public string DebitAgencyCode { get; set; }
        [DataMember]
        public decimal PaymentAmount { get; set; }
        [DataMember]
        public decimal ReceivePaymentAmount { get; set; }
        [DataMember]
        public decimal AcctPaymentAmount { get; set; }
        [DataMember]
        public Guid PaymentBy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime PaymentDateTime { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime PaymentDueDateTime { get; set; }
        [DataMember]
        public decimal DocumentAmount { get; set; }
        [DataMember]
        public Guid VoidBy { get; set; }
        [DataMember]
        public int ExpiryMonth { get; set; }
        [DataMember]
        public int ExpiryYear { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime VoidDateTime { get; set; }
        [DataMember]
        public string RecordLocator { get; set; }
        [DataMember]
        public string CvvCode { get; set; }
        [DataMember]
        public string NameOnCard { get; set; }
        [DataMember]
        public string DocumentNumber { get; set; }
        [DataMember]
        public string FormOfPaymentSubtypeRcd { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string PoBox { get; set; }
        [DataMember]
        public string AddressLine1 { get; set; }
        [DataMember]
        public string AddressLine2 { get; set; }
        [DataMember]
        public string ZipCode { get; set; }
        [DataMember]
        public string District { get; set; }
        [DataMember]
        public string Province { get; set; }

        [DataMember]
        public string CountryRcd { get; set; }
        [DataMember]
        public Guid CreateBy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime CreateDateTime { get; set; }
        [DataMember]
        public Guid UpdateBy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime UpdateDateTime { get; set; }
        [DataMember]
        public string PosIndicator { get; set; }
        [DataMember]
        public int IssueMonth { get; set; }
        [DataMember]
        public int IssueYear { get; set; }
        [DataMember]
        public string IssueNumber { get; set; }
        [DataMember]
        public Guid ClientProfileId { get; set; }
        [DataMember]
        public string TransactionReference { get; set; }
        [DataMember]
        public string ApprovalCode { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string BankCode { get; set; }
        [DataMember]
        public string BankIban { get; set; }
        [DataMember]
        public string IpAddress { get; set; }
        [DataMember]
        public string PaymentReference { get; set; }
        [DataMember]
        public decimal AllocatedAmount { get; set; }
        [DataMember]
        public string PaymentTypeRcd { get; set; }
        [DataMember]
        public decimal RefundedAmount { get; set; }
        [DataMember]
        public string PaymentNumber { get; set; }
        [DataMember]
        public string PaymentRemark { get; set; }

    }
}
