using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Client
{
    public class Client 
    {
        [DataMember]
        public Guid ClientProfileId { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string ClientNumber { get; set; }
        [DataMember]
        public string ClientPassword { get; set; }
        [DataMember]
        public bool CompanyFlag { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime ProfileOnHoldDateTime { get; set; }
        [DataMember]
        public string ProfileOnHoldComment { get; set; }
        [DataMember]
        public Guid ProfileOnHoldBy { get; set; }
        [DataMember]
        public Guid CompanyClientProfileId { get; set; }
        [DataMember]
        public double FfpTotal { get; set; }
        [DataMember]
        public double FfpPeriod { get; set; }
        [DataMember]
        public double FfpBalance { get; set; }
        [DataMember]
        public string ClientTypeRcd { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime MemberSinceDate { get; set; }
        [DataMember]
        public string MemberLevelDisplayName { get; set; }
        [DataMember]
        public double KeepPoint { get; set; }

        [DataMember]
        public string TitleRcd { get; set; }
        [DataMember]
        public string Lastname { get; set; }
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string Middlename { get; set; }
        [DataMember]
        public string LanguageRcd { get; set; }
        [DataMember]
        public string NationalityRcd { get; set; }
        [DataMember]
        public string PassengerWeight { get; set; }
        [DataMember]
        public string GenderTypeRcd { get; set; }
        [DataMember]
        public string PassengerTypeRcd { get; set; }
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
        public bool ZipCode { get; set; }
        [DataMember]
        public string PoBox { get; set; }
        [DataMember]
        public bool CountryRcd { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string DocumentTypeRcd { get; set; }
        [DataMember]
        public string DocumentNumber { get; set; }
        [DataMember]
        public string ResidenceCountryRcd { get; set; }
        [DataMember]
        public string PassportNumber { get; set; }
        [DataMember]
        public string PassportIssueDate { get; set; }
        [DataMember]
        public string PassportExpiryDate { get; set; }
        [DataMember]
        public string PassportIssuePlace { get; set; }
        [DataMember]
        public string PassportBirthPlace { get; set; }
        [DataMember]
        public string DateOfBirth { get; set; }
        [DataMember]
        public string PassportIssueCountryRcd { get; set; }
        [DataMember]
        public string ContactName { get; set; }
        [DataMember]
        public string ContactEmail { get; set; }
        [DataMember]
        public string MobileEmail { get; set; }
        [DataMember]
        public string PhoneMobile { get; set; }
        [DataMember]
        public string PhoneHome { get; set; }
        [DataMember]
        public string PhoneFax { get; set; }
        [DataMember]
        public string PhoneBusiness { get; set; }
        [DataMember]
        public string EmployeeNumber { get; set; }
        [DataMember]
        public byte WheelchairFlag { get; set; }
        [DataMember]
        public byte VipFlag { get; set; }
        [DataMember]
        public string MemberLevelRcd { get; set; }
        [DataMember]
        public string MemberNumber { get; set; }
        [DataMember]
        public byte WindowSeatFlag { get; set; }
        [DataMember]
        public string RedressNumber { get; set; }

    }
}
