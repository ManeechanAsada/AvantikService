using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Avantik.Web.Service.Message.Booking
{
    public class Remark 
    {
        [DataMember]
        public Guid BookingRemarkId { get; set; }
        [DataMember]
        public string RemarkTypeRcd { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime TimelimitDateTime { get; set; }
        [DataMember]
        public byte CompleteFlag { get; set; }
        [DataMember]
        public string RemarkText { get; set; }
        [DataMember]
        public Guid BookingId { get; set; }
        [DataMember]
        public string AddedBy { get; set; }
        [DataMember]
        public Guid ClientProfileId { get; set; }
        [DataMember]
        public string AgencyCode { get; set; }
        [DataMember]
        public Guid CreateBy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime CreateDateTime { get; set; }
        [DataMember]
        public Guid UpdateBy { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime UpdateDateTime { get; set; }
        [DataMember]
        public byte SystemFlag { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime UtcTimelimitDateTime { get; set; }
        [DataMember]
        public string Nickname { get; set; }
        [DataMember]
        public byte ProtectedFlag { get; set; }
        [DataMember]
        public byte WarningFlag { get; set; }
        [DataMember]
        public byte ProcessMessageFlag { get; set; }
    }
}
