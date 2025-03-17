using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avantik.Web.Service.Entity.Agency;
using Avantik.Web.Service.Entity;

namespace Avantik.Web.Service.Entity.Booking
{
    public class Booking
    {
        public BookingHeader Header { get; set; }
        public IList<FlightSegment> Segments { get; set; }
        public IList<Passenger> Passengers { get; set; }
        public IList<Remark> Remarks { get; set; }
        public IList<Payment> Payments { get; set; }
        public IList<Mapping> Mappings { get; set; }
        public IList<PassengerService> Services { get; set; }
        public IList<Tax> Taxs { get; set; }
        public IList<Fee> Fees { get; set; }
        public IList<Quote> Quotes { get; set; }

        #region Method
        // create allocate payment
        public IList<PaymentAllocation> CreateAllocation()
        {
            IList<PaymentAllocation> paymentAllocations = new List<PaymentAllocation>();

            if (Payments != null && Mappings != null)
            {
                foreach (Avantik.Web.Service.Entity.Booking.Payment pay in Payments)
                {
                    foreach (Avantik.Web.Service.Entity.Booking.Mapping m in Mappings)
                    {
                        if (m != null)
                        {
                            PaymentAllocation allocation = m.GetAllocation(pay.BookingPaymentId, pay.CreateBy);

                            if (allocation != null)
                                paymentAllocations.Add(allocation);
                        }
                    }

                    if (Fees != null)
                    {
                        foreach (Avantik.Web.Service.Entity.Booking.Fee f in Fees)
                        {
                            if (f != null)
                            {
                                PaymentAllocation allocation = f.GetAllocation(pay.BookingPaymentId, pay.CreateBy);

                                if (allocation != null)
                                    paymentAllocations.Add(allocation);
                            }
                        }
                    }

                }
            }

            return paymentAllocations;
        }
        public bool FindUSSegment()
        {
            try
            {
                if (Segments.Count > 0)
                {
                    foreach (FlightSegment se in Segments)
                    {
                        if (se.SegmentStatusRcd == "US")
                        {
                            return true;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return false;
        }
        public FlightSegment GetUSSegment()
        {
            try
            {
                if (Segments.Count > 0)
                {
                    foreach (FlightSegment se in Segments)
                    {
                        if (se.SegmentStatusRcd == "US")
                        {
                            return se;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return null;
        }

        public bool ValidateSaveBooking(BookingHeader headers, IList<FlightSegment> segments, IList<Passenger> passengers, IList<Mapping> mappings)
        {
            bool result = false;

            if(headers == null)
                result = false;
            else if (segments == null || segments.Count == 0)
                result = false;
            else if(passengers == null || passengers.Count == 0)
                result = false;
            else if(mappings == null || mappings.Count == 0)
                result = false;
            else{
                if(headers.GroupName.Equals(string.Empty)){
                    for(int i = 0; i < passengers.Count ; i++){
                        if(passengers[i].Lastname.Equals(string.Empty) || passengers[i].Lastname.Length == 0){
                            result = false;
                            break;
                        }
                    }

                    for(int i = 0; i < mappings.Count ; i++){
                        if(mappings[i].Lastname.Equals(string.Empty) || mappings[i].Lastname.Length == 0){
                            result = false;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public bool ValidateVoucherDuplicate(IList<Voucher> vouchers)
        {
            return ValidateVoucherDuplicate(vouchers);
        }
        public bool ValidateVoucherPaymentAmount(IList<Voucher> vouchers, Payment payment)
        {
            return ValidateVoucherPaymentAmount(vouchers, payment);
        }
        public bool ValidateCreditAgencyFOP()
        {
            return ValidateCreditAgencyFOP();
        }
        public bool ValidateCreditAgencyCurrencyRCD(Agent agent)
        {
            return ValidateCreditAgencyCurrencyRCD(agent);
        }
        public bool ValidateCreditAgencyBalance(Agent agent)
        {
            return ValidateCreditAgencyBalance(agent);
        }

        public void SetBookingSource(byte ownAgencyFlag, byte webAgencyFlag)
        {
            if (Header != null)
            {
                if (ownAgencyFlag == 1 && webAgencyFlag == 1)
                    Header.BookingSourceRcd = "B2C";
                else if (ownAgencyFlag == 0 && webAgencyFlag == 1)
                    Header.BookingSourceRcd = "B2B";
            }
        }

        #endregion

    }
}
