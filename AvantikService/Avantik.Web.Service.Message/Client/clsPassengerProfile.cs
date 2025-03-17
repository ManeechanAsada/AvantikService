using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Client
{
    public class PassengerProfile
    {
        [DataMember]
        public Guid ClientProfileId { get; set; }
        [DataMember]
        public Guid PassengerProfileId { get; set; }
        [DataMember]
        public string PassengerRoleRcd { get; set; }
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
        public string DocumentTypeRcd { get; set; }
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
