using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avantik.Web.Service.Entity.Flight;
using Avantik.Web.Service.Infrastructure;
using Avantik.Web.Service.Entity.Booking;
using Avantik.Web.Service.Entity.Agency;

namespace Avantik.Web.Service.Model.Contract
{
    public interface IBookingModelService 
    {
          bool SaveBooking(Booking booking,
                           bool createTickets,
                           bool readBooking,
                           bool readOnly,
                           bool bSetLock,
                           bool bCheckSeatAssignment,
                           bool bCheckSessionTimeOut);

          bool VoidFee(string strBookingId, string strUserId);

          Booking ReadBooking(string bookingId,
                                     string bookingReference,
                                     double bookingNumber,
                                     bool bReadonly,
                                     bool bSeatLock,
                                     string userId,
                                     bool bReadHeader,
                                     bool bReadSegment,
                                     bool bReadPassenger,
                                     bool bReadRemark,
                                     bool bReadPayment,
                                     bool bReadMapping,
                                     bool bReadService,
                                     bool bReadTax,
                                     bool bReadFee,
                                     bool bReadOd,
                                     string releaseBookingId,
                                     string CompleteRemarkId);
          bool CancelBooking(string bookingId,
                                   string bookingReference,
                                   double bookingNumber,
                                   string userId,
                                   string agencyCode,
                                   bool bWaveFee,
                                   bool bVoid, 
                                   bool IsVoidAllFee);
          Booking BookFlight(string agencyCode,
                          string currency,
                          IList<Flight> flight,
                          string bookingId,
                          short adults,
                          short children,
                          short infants,
                          short others,
                          string strOthers,
                          string userId,
                          string strIpAddress,
                          string strLanguageCode,
                          bool bNoVat);
          Booking GetQuoteSummary(IList<FlightSegment> flights, 
                                  IList<Passenger> passengers, 
                                  string agencyCode, 
                                  string language, 
                                  string currencyCode, 
                                  bool bNovat);
    }
}
