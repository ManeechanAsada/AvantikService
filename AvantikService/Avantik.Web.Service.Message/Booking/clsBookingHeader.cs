using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Booking
{
    public class BookingHeader
    {
        [DataMember]
        public Guid BookingId { get; set; }
        [DataMember]
        public string BookingSourceRcd { get; set; }
        [DataMember]
        public string CurrencyRcd { get; set; }
        [DataMember]
        public Guid ClientProfileId { get; set; }
        [DataMember]
        public long BookingNumber { get; set; }
        [DataMember]
        public string RecordLocator { get; set; }
        [DataMember]
        public int NumberOfAdults { get; set; }
        [DataMember]
        public int NumberOfChildren { get; set; }
        [DataMember]
        public int NumberOfInfants { get; set; }
        [DataMember]
        public string LanguageRcd { get; set; }
        [DataMember]
        public string AgencyCode { get; set; }
        [DataMember]
        public string ContactName { get; set; }
        [DataMember]
        public string ContactEmail { get; set; }
        [DataMember]
        public string PhoneMobile { get; set; }
        [DataMember]
        public string PhoneHome { get; set; }
        [DataMember]
        public string PhoneBusiness { get; set; }
        [DataMember]
        public string ReceivedFrom { get; set; }
        [DataMember]
        public string PhoneFax { get; set; }
        [DataMember]
        public string PhoneSearch { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public byte NotifyByEmailFlag { get; set; }
        [DataMember]
        public byte NotifyBySmsFlag { get; set; }
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public byte GroupBookingFlag { get; set; }
        [DataMember]
        public string AgencyName { get; set; }
        [DataMember]
        public byte OwnAgencyFlag { get; set; }
        [DataMember]
        public byte WebAgencyFlag { get; set; }
        [DataMember]
        public long ClientNumber { get; set; }
        [DataMember]
        public string Lastname { get; set; }
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string CreateName { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime LockDateTime { get; set; }
        [DataMember]
        public string Middlename { get; set; }
        [DataMember]
        public string AddressLine1 { get; set; }
        [DataMember]
        public string AddressLine2 { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string District { get; set; }
        [DataMember]
        public string Province { get; set; }
        [DataMember]
        public string ZipCode { get; set; }
        [DataMember]
        public string PoBox { get; set; }
        [DataMember]
        public string CountryRcd { get; set; }
        [DataMember]
        public string TitleRcd { get; set; }
        [DataMember]
        public string ExternalPaymentReference { get; set; }
        [DataMember]
        public Guid CreateBy { get; set; }
        [DataMember]
        public Guid UpdateBy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime CreateDateTime { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime UpdateDateTime { get; set; }
        [DataMember]
        public string CostCenter { get; set; }
        [DataMember]
        public string PurchaseOrder { get; set; }
        [DataMember]
        public string ProjectNumber { get; set; }
        [DataMember]
        public string LockName { get; set; }
        [DataMember]
        public string IpAddress { get; set; }
        [DataMember]
        public byte ApprovalFlag { get; set; }
        [DataMember]
        public string InvoiceReceiver { get; set; }
        [DataMember]
        public string TaxId { get; set; }
        [DataMember]
        public byte NewsletterFlag { get; set; }
        [DataMember]
        public string ContactEmailCc { get; set; }
        [DataMember]
        public string MobileEmail { get; set; }
        [DataMember]
        public string VendorRcd { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime BookingDateTime { get; set; }
        [DataMember]
        public byte NoVatFlag { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public byte BusinessFlag { get; set; }

    }
}
