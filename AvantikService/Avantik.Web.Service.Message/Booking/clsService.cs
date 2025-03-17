using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Booking
{
    public class PassengerService 
    {
        [DataMember]
        public Guid PassengerSegmentServiceId { get; set; }
 	 	 [DataMember] 
        public Guid PassengerId  { get; set; }
 	 	 [DataMember] 
        public Guid BookingSegmentId  { get; set; }
 	 	 [DataMember] 
        public string SpecialServiceStatusRcd  { get; set; }
 	 	 [DataMember] 
        public string SpecialServiceChangeStatusRcd  { get; set; }
 	 	 [DataMember] 
        public string SpecialServiceRcd  { get; set; }
 	 	 [DataMember] 
        public string ServiceText  { get; set; }
 	 	 [DataMember] 
        public Guid CreateBy  { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime CreateDateTime  { get; set; }
 	 	 [DataMember] 
        public Guid UpdateBy  { get; set; }
 	 	 [DataMember(EmitDefaultValue = false)]
        public DateTime UpdateDateTime  { get; set; }
 	 	 [DataMember] 
        public string FlightId  { get; set; }
 	 	 [DataMember] 
        public string FeeId  { get; set; }
 	 	 [DataMember] 
        public Int16 NumberOfUnits  { get; set; }
 	 	 [DataMember] 
        public string OriginRcd  { get; set; }
 	 	 [DataMember] 
        public string DestinationRcd  { get; set; }
 	 	 [DataMember] 
        public bool NewRecord  { get; set; }
 	 	 [DataMember] 
        public string DisplayName  { get; set; }
 	 	 [DataMember] 
        public int CutOffTime  { get; set; }
 	 	 [DataMember] 
        public string StatusCode  { get; set; }
 	 	 [DataMember] 
        public string HelpText  { get; set; }
 	 	 [DataMember] 
        public string SpecialServiceGroupRcd  { get; set; }
 	 	 [DataMember] 
        public byte ServiceOnRequestFlag  { get; set; }
 	 	 [DataMember] 
        public byte TextAllowedFlag  { get; set; }
 	 	 [DataMember] 
        public byte ManifestFlag  { get; set; }
 	 	 [DataMember] 
        public byte TextRequiredFlag  { get; set; }
 	 	 [DataMember] 
        public byte IncludePassengerNameFlag  { get; set; }
 	 	 [DataMember] 
        public byte IncludeFlightSegmentFlag  { get; set; }
 	 	 [DataMember] 
        public byte IncludeActionCodeFlag  { get; set; }
 	 	 [DataMember] 
        public byte IncludeNumberOfServiceFlag  { get; set; }
 	 	 [DataMember] 
        public byte IncludeCateringFlag  { get; set; }
 	 	 [DataMember] 
        public byte IncludePassengerAssistanceFlag  { get; set; }
 	 	 [DataMember] 
        public byte ServiceSupportedFlag  { get; set; }
 	 	 [DataMember] 
        public byte SendInterlineReplyFlag  { get; set; }
 	 	 [DataMember] 
        public byte InventoryControlFlag  { get; set; }
         [DataMember]
         public string UnitRcd { get; set; }

    }
}
