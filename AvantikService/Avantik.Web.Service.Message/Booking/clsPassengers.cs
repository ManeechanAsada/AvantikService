using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Booking
{
    public class Passenger
    {
        #region General Information
 	 	 [DataMember] 
        public string TitleRcd { get; set; }
 	 	 [DataMember] 
        public string Lastname { get; set; }
 	 	 [DataMember] 
        public string Firstname { get; set; }
 	 	 [DataMember] 
        public string Middlename { get; set; }
 	 	 [DataMember] 
        public string NationalityRcd { get; set; }
 	 	 [DataMember] 
        public decimal PassengerWeight { get; set; }
 	 	 [DataMember] 
        public string GenderTypeRcd { get; set; }
 	 	 [DataMember] 
        public string PassengerTypeRcd { get; set; }
 	 	 [DataMember] 
        public Guid ClientProfileId { get; set; }
 	 	 [DataMember] 
        public long ClientNumber { get; set; }
        #endregion

        #region Address information
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
        public string Street { get; set; }
 	 	 [DataMember] 
        public string City { get; set; }
        #endregion

        #region Document Information
 	 	 [DataMember] 
        public string DocumentTypeRcd { get; set; }
 	 	 [DataMember] 
        public string DocumentNumber { get; set; }
 	 	 [DataMember] 
        public string ResidenceCountryRcd { get; set; }
 	 	 [DataMember] 
        public string PassportNumber { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime PassportIssueDate { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime PassportExpiryDate { get; set; }
 	 	 [DataMember] 
        public string PassportIssuePlace { get; set; }
 	 	 [DataMember] 
        public string PassportBirthPlace { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime DateOfBirth { get; set; }
 	 	 [DataMember] 
        public string PassportIssueCountryRcd { get; set; }
         [DataMember]
         public string CountryCodeLong { get; set; }

        #endregion

        #region Contact Information
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
        public string ReceivedFrom { get; set; }
 	 	 [DataMember] 
        #endregion

        #region Update Information
        public Guid CreateBy { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime CreateDateTime { get; set; }
 	 	 [DataMember] 
        public Guid UpdateBy { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime UpdateDateTime { get; set; }
        #endregion

        #region Properties
         [DataMember]
         public Guid PassengerId { get; set; }
         [DataMember]
         public Guid BookingId { get; set; }
         [DataMember]
         public Guid PassengerProfileId { get; set; }
         [DataMember]
         public Guid GuardianPassengerId { get; set; }
         [DataMember]
         public string EmployeeNumber { get; set; }
         [DataMember]
         public string PassengerRoleRcd { get; set; }
         [DataMember]
         public string MemberLevelRcd { get; set; }
         [DataMember]
         public string MemberNumber { get; set; }
         [DataMember]
         public string RedressNumber { get; set; }
         [DataMember]
         public string PnrName { get; set; }
         [DataMember]
         public string MemberAirlineRcd { get; set; }
         [DataMember]
         public byte WheelchairFlag { get; set; }
         [DataMember]
         public byte VipFlag { get; set; }
         [DataMember]
         public byte WindowSeatFlag { get; set; }
        #endregion

         [DataMember]
         public string KnownTravelerNumber { get; set; }

    }
}
