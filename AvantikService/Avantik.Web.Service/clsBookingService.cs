using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Avantik.Web.Service.Message;
using Avantik.Web.Service.Contracts;
using Avantik.Web.Service.Helpers;
using Avantik.Web.Service.Entity;
using Avantik.Web.Service.Model;
using Avantik.Web.Service.Model.Contract;
using Avantik.Web.Service.Exception.Flight;
using Avantik.Web.Service.Message.Booking;
using Avantik.Web.Service.Model.Booking;
using Avantik.Web.Service.Extension;
using Avantik.Web.Service.Entity.Booking;
using Avantik.Web.Service.Entity.Agency;
using Avantik.Web.Service.Message.Fee;
using Avantik.Web.Service.Message.SeatMap;
using Avantik.Web.Service.Exception.Booking;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace Avantik.Web.Service
{
    public class BookingService : IBookingService
    {
        public BookingSaveResponse SaveBooking(BookingSaveRequest Request)
        {
            IBookingModelService objBookingService = BookingServiceFactory.CreateInstance();
            BookingSaveResponse response = new BookingSaveResponse();
            BookingPaymentResponse paymentResponse = null;
            Booking booking = new Booking();
            bool result = false;
            bool createTickets = false;
            bool readBooking = false;
            bool readOnly = false;
            bool bSetLock = false;
            bool bCheckSeatAssignment = Request.CheckSeatAssignment;
            bool bCheckSessionTimeOut = Request.CheckSessionTimeOut;

            // map from message to entity
            try
            {
                if (Request != null)
                {
                    booking.Header = Request.Booking.Header.ToEntity();
                    booking.Segments = Request.Booking.FlightSegments.ToListEntity();
                    booking.Passengers = Request.Booking.Passengers.ToListEntity();
                    booking.Mappings = Request.Booking.Mappings.ToListEntity();
                    booking.Payments = Request.Booking.Payments.ToListEntity();
                    booking.Fees = Request.Booking.Fees.ToListEntity();
                    booking.Remarks = Request.Booking.Remarks.ToListEntity();
                    booking.Services = Request.Booking.Services.ToListEntity();
                    booking.Taxs = Request.Booking.Taxs.ToListEntity();

                    //fix new edw
                    //header

                    //segment

                    //passenger
                    foreach(var p in booking.Passengers)
                    {
                        p.ResidenceCountryRcd = null;
                    }

                }
            }
            catch(System.Exception ex)
            {
              //  Logger.Instance(Logger.LogType.File).WriteLog(ex, XMLHelper.JsonSerializer(typeof(BookingSaveRequest), Request));
            }

            try
            {
                result = objBookingService.SaveBooking(booking,
                                                       createTickets,
                                                       readBooking,
                                                       readOnly,
                                                       bSetLock,
                                                       bCheckSeatAssignment,
                                                       bCheckSessionTimeOut);

                if (result == true && booking.Payments != null && booking.Payments.Count > 0)
                {
                    BookingPaymentRequest payRequest = new BookingPaymentRequest();
                    payRequest.Mappings = Request.Booking.Mappings;
                    payRequest.Payments = Request.Booking.Payments;
                    payRequest.Fees = Request.Booking.Fees;

                    paymentResponse = BookingPayment(payRequest);

                    if (paymentResponse.Success == false) result = false;
                }

                if (result == true )
                {
                    response.Success = true;
                    response.Message = "Success request.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "No Booking Save";
                }
            }
            catch (BookingSaveException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Code = ex.ErrorCode;
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                Logger.Instance(Logger.LogType.Mail).WriteLog(ex, XMLHelper.JsonSerializer(typeof(BookingSaveRequest), Request));
            }

            return response;
        }

        public BookingReadResponse VoidFeeComplete(string bookingId)
        {
            IBookingModelService objBookingService = BookingServiceFactory.CreateInstance();
            BookingReadResponse response = new BookingReadResponse();
            Booking booking = new Booking();
            bool result = false;
            string user = "09C3D18C-4893-4A7D-AAF6-15E4FEF57797";
            try
            {
                result = objBookingService.VoidFee(bookingId, user);

                if (result == true)
                {
                    BookingReadRequest Request = new BookingReadRequest();
                    Request.BookingId = bookingId;
                    response = ReadBooking(Request);

                   // booking.Header = response.BookingResponse.Header.ToEntity();
                    booking.Fees = response.BookingResponse.Fees.ToListEntity();
                    //booking.Mappings = response.BookingResponse.Mappings.ToListEntity();
                    //booking.Passengers = response.BookingResponse.Passengers.ToListEntity();
                    //booking.Segments = response.BookingResponse.FlightSegments.ToListEntity();
                    //booking.Remarks = response.BookingResponse.Remarks.ToListEntity();
                    //booking.Services = response.BookingResponse.Services.ToListEntity();
                    //booking.Payments = response.BookingResponse.Payments.ToListEntity();



                    response.Success = true;
                    response.Message = "Success request.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "No Booking Save";
                }
            }
            catch (BookingSaveException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Code = ex.ErrorCode;
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public BookingReadResponse ReadBooking(BookingReadRequest Request)
        {
           // IBookingModelService objBookingService = BookingServiceFactory.CreateInstance();
            BookingReadResponse response = new BookingReadResponse();
          //  string apiURL = "https://localhost:7021/api/Booking/ReadBooking";
            string baseURL = ConfigHelper.ToString("RESTURL");
            string apiURL = baseURL + "api/Booking/ReadBooking";

            try
            {
                if (!String.IsNullOrEmpty(Request.BookingId))
                {
                    var BookingRESTRequest = new Avantik.Web.Service.BookingRead.BookingReadRequest
                    {
                        booking_id = new Guid(Request.BookingId),
                        bReadHeader = true,
                        bReadPassenger = true,
                        bReadSegment = true,
                        bReadMapping = true,
                        bReadPayment = true,
                        bReadTax = true,
                        bReadFee = true,
                        bReadRemark = true,
                        bReadOd = true,
                        bReadService = true
                    };

                    var jsonContent = JsonConvert.SerializeObject(BookingRESTRequest);
                    var content = System.Text.Encoding.UTF8.GetBytes(jsonContent);

                    var requestUri = new Uri(apiURL);

                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);

                    var userlogon = string.Format("{0}:{1}", "DLXAPI", "dlxapi");
                    byte[] bytes = Encoding.UTF8.GetBytes(userlogon);
                    string base64String = Convert.ToBase64String(bytes);


                    httpWebRequest.Headers["Authorization"] = "Basic " + base64String;
                  //  httpWebRequest.Headers["AnotherHeader"] = "HeaderValue";

                    httpWebRequest.Method = "POST";
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.ContentLength = content.Length;

                    using (Stream requestStream = httpWebRequest.GetRequestStream())
                    {
                        requestStream.Write(content, 0, content.Length);
                    }
                    using (HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                    {
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            using (StreamReader reader = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                var responseContent = reader.ReadToEnd();
                                Avantik.Web.Service.BookingRead.BookingRead bookingRead = JsonConvert.DeserializeObject<Avantik.Web.Service.BookingRead.BookingRead>(responseContent);

                                BookingResponse bookingResponse = new BookingResponse();

                                bookingResponse.Header = bookingRead.Header.ToBookingMessage();
                                bookingResponse.FlightSegments = bookingRead.Segments.ToBookingMessage();
                                bookingResponse.Passengers = bookingRead.Passengers.ToBookingMessage();
                                bookingResponse.Mappings = bookingRead.Mappings.ToBookingMessage();
                                bookingResponse.Fees = bookingRead.Fees.ToBookingMessage();
                                bookingResponse.Services = bookingRead.Services.ToBookingMessage();
                                bookingResponse.Payments = bookingRead.Payments.ToBookingMessage();
                                bookingResponse.Remarks = bookingRead.Remarks.ToBookingMessage();
                                bookingResponse.Taxs = bookingRead.Taxs.ToBookingMessage();
                                bookingResponse.Quotes = bookingRead.Quotes.ToBookingMessage();

                                bookingResponse.BookingId = bookingResponse.Header.BookingId.ToString();
                                bookingResponse.RecordLocator = bookingResponse.Header.RecordLocator;

                                response.BookingResponse = new BookingResponse();
                                response.BookingResponse.Header = bookingResponse.Header;
                                response.BookingResponse.FlightSegments = bookingResponse.FlightSegments;
                                response.BookingResponse.Passengers = bookingResponse.Passengers;
                                response.BookingResponse.Mappings = bookingResponse.Mappings;
                                response.BookingResponse.Payments = bookingResponse.Payments;
                                response.BookingResponse.Remarks = bookingResponse.Remarks;
                                response.BookingResponse.Fees = bookingResponse.Fees;
                                response.BookingResponse.Taxs = bookingResponse.Taxs;
                                response.BookingResponse.Services = bookingResponse.Services;
                                response.BookingResponse.Quotes = bookingResponse.Quotes;

                                response.Success = true;
                                response.BookingResponse = bookingResponse;
                            }

                        }
                    }

                    #region old
                    /*
                    string bookingReference = string.Empty;
                    double bookingNumber = 0;
                    bool bReadonly = false;
                    bool bSeatLock = false;
                    string userId = string.Empty;
                    bool bReadHeader = true;
                    bool bReadSegment = true;
                    bool bReadPassenger = true;
                    bool bReadRemark = true;
                    bool bReadPayment = true;
                    bool bReadMapping = true;
                    bool bReadService = true;
                    bool bReadTax = true;
                    bool bReadFee = true;
                    bool bReadOd = true;
                    string releaseBookingId = string.Empty;
                    string CompleteRemarkId = string.Empty;

                    
                    Booking booking = objBookingService.ReadBooking(Request.BookingId,
                                                                     bookingReference,
                                                                     bookingNumber,
                                                                     bReadonly,
                                                                     bSeatLock,
                                                                     userId,
                                                                     bReadHeader,
                                                                     bReadSegment,
                                                                     bReadPassenger,
                                                                     bReadRemark,
                                                                     bReadPayment,
                                                                     bReadMapping,
                                                                     bReadService,
                                                                     bReadTax,
                                                                     bReadFee,
                                                                     bReadOd,
                                                                     releaseBookingId,
                                                                     CompleteRemarkId);

                    if (booking != null && booking.Header != null && booking.Segments != null && booking.Segments.Count > 0 &&
                        booking.Passengers != null && booking.Passengers.Count > 0 && booking.Mappings != null && booking.Mappings.Count > 0)
                    {
                        response.BookingResponse = new BookingResponse();
                        response.BookingResponse.Header = booking.Header.ToBookingMessage();
                        response.BookingResponse.FlightSegments = booking.Segments.ToBookingMessage();
                        response.BookingResponse.Passengers = booking.Passengers.ToBookingMessage();
                        response.BookingResponse.Mappings = booking.Mappings.ToBookingMessage();
                        response.BookingResponse.Payments = booking.Payments.ToBookingMessage();
                        response.BookingResponse.Remarks = booking.Remarks.ToBookingMessage();
                        response.BookingResponse.Fees = booking.Fees.ToBookingMessage();
                        response.BookingResponse.Taxs = booking.Taxs.ToBookingMessage();
                        response.BookingResponse.Services = booking.Services.ToBookingMessage();
                        response.BookingResponse.Quotes = booking.Quotes.ToBookingMessage();

                        response.Message = "Success";
                        response.Success = true;
                    }
                    else
                    {
                        response.Message = "Fail";
                        response.Success = false;
                    }
                    */

                    #endregion
                }
                else
                {
                    response.Message = "Fail";
                    response.Success = false;
                }
            }
            catch(System.Exception ex)
            {
                response.Message = "Booking Read is error";
                response.Success = false;
                Logger.Instance(Logger.LogType.Mail).WriteLog(ex, XMLHelper.JsonSerializer(typeof(BookingReadRequest), Request));
            }

            return response;
        }

        public BookingReadResponse ReadBooking_bk(BookingReadRequest Request)
        {
            // IBookingModelService objBookingService = BookingServiceFactory.CreateInstance();
            BookingReadResponse response = new BookingReadResponse();
            //  string apiURL = "https://localhost:7021/api/Booking/ReadBooking";
            string baseURL = ConfigHelper.ToString("RESTURL");
            string apiURL = baseURL + "api/Booking/ReadBooking";

            try
            {
                if (!String.IsNullOrEmpty(Request.BookingId))
                {
                    var BookingRESTRequest = new Avantik.Web.Service.BookingRead.BookingReadRequest
                    {
                        booking_id = new Guid(Request.BookingId),
                        bReadHeader = true,
                        bReadPassenger = true,
                        bReadSegment = true,
                        bReadMapping = true,
                        bReadPayment = true,
                        bReadTax = true,
                        bReadFee = true,
                        bReadRemark = true,
                        bReadOd = true,
                        bReadService = true
                    };

                    var jsonContent = JsonConvert.SerializeObject(BookingRESTRequest);
                    var content = System.Text.Encoding.UTF8.GetBytes(jsonContent);

                    var requestUri = new Uri(apiURL);

                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);

                    var userlogon = string.Format("{0}:{1}", "DLXAPI", "dlxapi");
                    byte[] bytes = Encoding.UTF8.GetBytes(userlogon);
                    string base64String = Convert.ToBase64String(bytes);


                    httpWebRequest.Headers["Authorization"] = "Basic " + base64String;
                    //  httpWebRequest.Headers["AnotherHeader"] = "HeaderValue";

                    httpWebRequest.Method = "POST";
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.ContentLength = content.Length;

                    using (Stream requestStream = httpWebRequest.GetRequestStream())
                    {
                        requestStream.Write(content, 0, content.Length);
                    }
                    using (HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                    {
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            using (StreamReader reader = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                var responseContent = reader.ReadToEnd();
                                Avantik.Web.Service.BookingRead.BookingRead bookingRead = JsonConvert.DeserializeObject<Avantik.Web.Service.BookingRead.BookingRead>(responseContent);

                                BookingResponse bookingResponse = new BookingResponse();

                                bookingResponse.Header = bookingRead.Header.ToBookingMessage();
                                bookingResponse.FlightSegments = bookingRead.Segments.ToBookingMessage();
                                bookingResponse.Passengers = bookingRead.Passengers.ToBookingMessage();
                                bookingResponse.Mappings = bookingRead.Mappings.ToBookingMessage();
                                bookingResponse.Fees = bookingRead.Fees.ToBookingMessage();
                                bookingResponse.Services = bookingRead.Services.ToBookingMessage();
                                bookingResponse.Payments = bookingRead.Payments.ToBookingMessage();
                                bookingResponse.Remarks = bookingRead.Remarks.ToBookingMessage();
                                bookingResponse.Taxs = bookingRead.Taxs.ToBookingMessage();
                                bookingResponse.Quotes = bookingRead.Quotes.ToBookingMessage();

                                bookingResponse.BookingId = bookingResponse.Header.BookingId.ToString();
                                bookingResponse.RecordLocator = bookingResponse.Header.RecordLocator;

                                response.BookingResponse = new BookingResponse();
                                response.BookingResponse.Header = bookingResponse.Header;
                                response.BookingResponse.FlightSegments = bookingResponse.FlightSegments;
                                response.BookingResponse.Passengers = bookingResponse.Passengers;
                                response.BookingResponse.Mappings = bookingResponse.Mappings;
                                response.BookingResponse.Payments = bookingResponse.Payments;
                                response.BookingResponse.Remarks = bookingResponse.Remarks;
                                response.BookingResponse.Fees = bookingResponse.Fees;
                                response.BookingResponse.Taxs = bookingResponse.Taxs;
                                response.BookingResponse.Services = bookingResponse.Services;
                                response.BookingResponse.Quotes = bookingResponse.Quotes;

                                response.Success = true;
                                response.BookingResponse = bookingResponse;
                            }

                        }
                    }

                    #region old
                    /*
                    string bookingReference = string.Empty;
                    double bookingNumber = 0;
                    bool bReadonly = false;
                    bool bSeatLock = false;
                    string userId = string.Empty;
                    bool bReadHeader = true;
                    bool bReadSegment = true;
                    bool bReadPassenger = true;
                    bool bReadRemark = true;
                    bool bReadPayment = true;
                    bool bReadMapping = true;
                    bool bReadService = true;
                    bool bReadTax = true;
                    bool bReadFee = true;
                    bool bReadOd = true;
                    string releaseBookingId = string.Empty;
                    string CompleteRemarkId = string.Empty;

                    
                    Booking booking = objBookingService.ReadBooking(Request.BookingId,
                                                                     bookingReference,
                                                                     bookingNumber,
                                                                     bReadonly,
                                                                     bSeatLock,
                                                                     userId,
                                                                     bReadHeader,
                                                                     bReadSegment,
                                                                     bReadPassenger,
                                                                     bReadRemark,
                                                                     bReadPayment,
                                                                     bReadMapping,
                                                                     bReadService,
                                                                     bReadTax,
                                                                     bReadFee,
                                                                     bReadOd,
                                                                     releaseBookingId,
                                                                     CompleteRemarkId);

                    if (booking != null && booking.Header != null && booking.Segments != null && booking.Segments.Count > 0 &&
                        booking.Passengers != null && booking.Passengers.Count > 0 && booking.Mappings != null && booking.Mappings.Count > 0)
                    {
                        response.BookingResponse = new BookingResponse();
                        response.BookingResponse.Header = booking.Header.ToBookingMessage();
                        response.BookingResponse.FlightSegments = booking.Segments.ToBookingMessage();
                        response.BookingResponse.Passengers = booking.Passengers.ToBookingMessage();
                        response.BookingResponse.Mappings = booking.Mappings.ToBookingMessage();
                        response.BookingResponse.Payments = booking.Payments.ToBookingMessage();
                        response.BookingResponse.Remarks = booking.Remarks.ToBookingMessage();
                        response.BookingResponse.Fees = booking.Fees.ToBookingMessage();
                        response.BookingResponse.Taxs = booking.Taxs.ToBookingMessage();
                        response.BookingResponse.Services = booking.Services.ToBookingMessage();
                        response.BookingResponse.Quotes = booking.Quotes.ToBookingMessage();

                        response.Message = "Success";
                        response.Success = true;
                    }
                    else
                    {
                        response.Message = "Fail";
                        response.Success = false;
                    }
                    */

                    #endregion
                }
                else
                {
                    response.Message = "Fail";
                    response.Success = false;
                }
            }
            catch (System.Exception ex)
            {
                response.Message = "Booking Read is error";
                response.Success = false;
                Logger.Instance(Logger.LogType.Mail).WriteLog(ex, XMLHelper.JsonSerializer(typeof(BookingReadRequest), Request));
            }

            return response;
        }


        public BookingCancelResponse CancelBooking(BookingCancelRequest Request)
        {
            //IBookingModelService objBookingService = BookingServiceFactory.CreateInstance();
            BookingCancelResponse response = new BookingCancelResponse();
            //string bookingReference = string.Empty;
            string userId = string.Empty;
            string agencyCode = string.Empty;
            //double bookingNumber = 0;
            //bool bWaveFee = false;
            //bool bVoid = false;
            //bool result = false;
            bool IsVoidAllFee = false;

            IsVoidAllFee = Request.IsVoidAllFees;


            //  string apiURL = "https://localhost:7021/api/Booking/ReadBooking";
            string baseURL = ConfigHelper.ToString("RESTURL");
            string apiURL = baseURL + "api/Booking/CancelBooking";

            try
            {
                if (!String.IsNullOrEmpty(Request.BookingId) && !String.IsNullOrEmpty(Request.UserId))
                {

                    var BookingRESTRequest = new Avantik.Web.Service.BookingCancel.BookingCancelRequest
                    {
                        AgencyCode = "B2C",
                        UserLogon = "B2C",
                        Password = "B2C111",
                        IsVoidAllFees = IsVoidAllFee,
                        booking_id = new Guid(Request.BookingId)

                    };

                    var jsonContent = JsonConvert.SerializeObject(BookingRESTRequest);
                    var content = System.Text.Encoding.UTF8.GetBytes(jsonContent);

                    var requestUri = new Uri(apiURL);

                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);

                    var userlogon = string.Format("{0}:{1}", "DLXAPI", "dlxapi");
                    byte[] bytes = Encoding.UTF8.GetBytes(userlogon);
                    string base64String = Convert.ToBase64String(bytes);


                    httpWebRequest.Headers["Authorization"] = "Basic " + base64String;
                    //  httpWebRequest.Headers["AnotherHeader"] = "HeaderValue";

                    httpWebRequest.Method = "POST";
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.ContentLength = content.Length;

                    using (Stream requestStream = httpWebRequest.GetRequestStream())
                    {
                        requestStream.Write(content, 0, content.Length);
                    }
                    using (HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                    {
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            using (StreamReader reader = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                var responseContent = reader.ReadToEnd();
                                Avantik.Web.Service.BookingCancel.BookingCancelResponse bookingCancel= JsonConvert.DeserializeObject<Avantik.Web.Service.BookingCancel.BookingCancelResponse>(responseContent);

                                if (bookingCancel != null)
                                {
                                    if (bookingCancel.booking_id != Guid.Empty)
                                    {
                                        response.Success = true;
                                        response.Message = "Success";
                                      //  response.booking_id = bookingCancel.booking_id;
                                        
                                    }
                                    else
                                    {
                                        response.Message = "Fail";
                                        response.Success = false;
                                    }
                                }
                                else
                                {
                                    response.Message = "Fail";
                                    response.Success = false;
                                }
                            }

                        }
                    }

                    #region old
                    //userId = Request.UserId;

                    //result = objBookingService.CancelBooking(Request.BookingId,
                    //                                          bookingReference,
                    //                                          bookingNumber,
                    //                                          userId,
                    //                                          agencyCode,
                    //                                          bWaveFee,
                    //                                          bVoid,
                    //                                          IsVoidAllFee);

                    //if (result)
                    //{
                    //    response.Message = "Success";
                    //    response.Success = true;
                    //}
                    //else
                    //{
                    //    response.Message = "Fail";
                    //    response.Success = false;
                    //}
                    #endregion
                }
                else
                {
                    response.Message = "Fail";
                    response.Success = false;
                }

            }
            catch (System.Exception ex)
            {
                response.Message = "Cancel Booking is error";
                response.Success = false;
                Logger.Instance(Logger.LogType.Mail).WriteLog(ex, XMLHelper.JsonSerializer(typeof(BookingCancelRequest), Request));
            }

            return response;
        }

        public BookingPaymentResponse BookingPayment(BookingPaymentRequest Request)
        {
            IPaymentService objPaymentService = PaymentServiceFactory.CreateInstance();
            BookingPaymentResponse response = new BookingPaymentResponse();

            Booking booking = null;

            bool resultPayment = false;
            IList<PaymentAllocation> paymentAllocations = null;

            try
            {
                booking = new Booking();
                booking.Payments = Request.Payments.ToListEntity();
                booking.Mappings = Request.Mappings.ToListEntity();
                booking.Fees = Request.Fees.ToListEntity();
                paymentAllocations = booking.CreateAllocation();

                if (paymentAllocations != null)
                    resultPayment = objPaymentService.SavePayment(booking.Payments, paymentAllocations, Request.CreateTicket);
               
                if(resultPayment == true)
                {
                    response.Message = "Success";
                    response.Success = true;
                    response.Code = "000";
                }
                else
                {
                    response.Message = "Fail";
                    response.Success = false;
                    response.Code = "999";
                }
            }
            catch (System.Exception ex)
            {
                response.Message = "Save payment is error";
                response.Success = false;
                Logger.Instance(Logger.LogType.Mail).WriteLog(ex, XMLHelper.JsonSerializer(typeof(BookingPaymentRequest), Request));
            }

            return response;
        }

        public BookingPaymentCreditCardResponse BookingPaymentCreditCard(BookingPaymentCreditCardRequest Request)
        {
            IPaymentService objPaymentService = PaymentServiceFactory.CreateInstance();
            BookingPaymentCreditCardResponse response = new BookingPaymentCreditCardResponse();

            Booking booking = null;
            bool resultPayment = false;
            IList<PaymentAllocation> paymentAllocations = null;

            try
            {
                if (Request != null)
                {
                    booking = new Booking();
                    booking.Header = Request.Booking.Header.ToEntity();
                    booking.Segments = Request.Booking.FlightSegments.ToListEntity();
                    booking.Passengers = Request.Booking.Passengers.ToListEntity();
                    booking.Remarks = Request.Booking.Remarks.ToListEntity();
                    booking.Payments = Request.Booking.Payments.ToListEntity();
                    booking.Mappings = Request.Booking.Mappings.ToListEntity();
                    booking.Services = Request.Booking.Services.ToListEntity();
                    booking.Taxs = Request.Booking.Taxs.ToListEntity();

                    booking.Fees = Request.Booking.Fees.ToListEntity();
                    booking.Fees.Add(Request.PaymentFee.ToEntity());

                    paymentAllocations = booking.CreateAllocation();

                    resultPayment = objPaymentService.PaymentCreditCard(booking, paymentAllocations,
                                                                        Request.SecurityToken, Request.AuthenticationToken,
                                                                        Request.CommerceIndicator, Request.BookingReference,
                                                                        Request.RequestSource, true, false, false);
                    if (resultPayment == true)
                    {
                        response.Message = "Success";
                        response.Success = true;
                    }
                    else
                    {
                        response.Message = "PaymentCreditCard fail";
                        response.Success = false;
                    }
                }
                else
                {
                    response.Message = "BookingPaymentCreditCardRequest is null";
                    response.Success = false;
                }
            }
            catch
            {
                response.Message = "BookingPaymentCreditCard Error";
                response.Success = false;
            }

            return response;
        }

        public BookingReadVoucherResponse BookingReadVoucher(BookingReadVoucherRequest Request)
        {
            IVoucherService objVoucherService = VoucherServiceFactory.CreateInstance();
            BookingReadVoucherResponse response = new BookingReadVoucherResponse();
            List<Entity.Voucher> vouchers = new List<Entity.Voucher>();
            Entity.Voucher voucher = null;
            bool bResult = true;

            try
            {
                if (Request != null)
                {
                    foreach (Message.Voucher v in Request.Vouchers)
                    {
                        voucher = objVoucherService.GetVoucher(v.ToVoucherEntity());
                        if (voucher != null)
                        {
                            vouchers.Add(voucher);
                        }
                        else
                        {
                            bResult = false;
                        }
                    }

                    if (bResult)
                    {
                        response.Vouchers = vouchers.ToVoucherMessage();
                        response.Message = "Success";
                        response.Success = true;
                    }
                    else
                    {
                        response.Message = "Read voucher fail";
                        response.Success = false;
                    }
                }
                else
                {
                    response.Message = "BookingReadVoucherRequest is null";
                    response.Success = false;
                }
            }
            catch
            {
                response.Message = "BookingReadVoucher error";
                response.Success = false;
            }

            return response;
        }

        public BookingPaymentVoucherResponse BookingPaymentVoucher(BookingPaymentVoucherRequest Request)
        {
            IVoucherService objVoucherService  = VoucherServiceFactory.CreateInstance();
            IPaymentService objPaymentService = PaymentServiceFactory.CreateInstance();
            BookingPaymentVoucherResponse response = new BookingPaymentVoucherResponse();
            Entity.Voucher voucher = new Entity.Voucher();
            IList<Entity.Booking.Payment> payments = null;
            IList<PaymentAllocation> paymentAllocations = null;
            Booking booking = null;
            bool bResult = true;

            try
            {
                if (Request != null)
                {
                    //check duplicate
                    payments = Request.Booking.Payments.ToListEntity();
                    bResult = voucher.ValidateVoucherDuplicate(payments);
                    if (bResult)
                    {
                        foreach (Entity.Booking.Payment p in payments)
                        {
                            voucher.VoucherNumber = p.DocumentNumber;

                            voucher = objVoucherService.GetVoucher(voucher);

                            if (voucher == null)
                            {
                                bResult = false;
                            }
                        }

                        if (bResult)
                        {
                            if (voucher.ValidateVoucherPayment(payments) == true)
                            {
                                booking = new Booking();
                                booking.Payments = Request.Booking.Payments.ToListEntity();
                                booking.Mappings = Request.Booking.Mappings.ToListEntity();
                                booking.Fees = Request.Booking.Fees.ToListEntity();
                                paymentAllocations = booking.CreateAllocation();
                                bResult = objPaymentService.SavePayment(Request.Booking.Payments.ToListEntity(), paymentAllocations, true);

                                if (bResult)
                                {
                                    response.Message = "Success";
                                    response.Success = true;
                                }
                                else
                                {
                                    response.Message = "SavePayment fail";
                                    response.Success = false;
                                }
                            }
                            else
                            {
                                bResult = false;
                                response.Message = "Vouchers amount not enough";
                                response.Success = false;
                            }
                        }
                        else
                        {
                            response.Message = "Read voucher fail";
                            response.Success = false;
                        }
                    }
                    else
                    {
                        response.Message = "Duplicate vouchers";
                        response.Success = false;
                    }
                }
                else
                {
                    response.Message = "BookingPaymentVoucherRequest is null";
                    response.Success = false;
                }
            }
            catch
            {
                response.Message = "BookingPaymentVoucher error";
                response.Success = false;
            }

            return response;
        }

        public BookingPaymentCreditAgencyResponse BookingPaymentCreditAgency(BookingPaymentCreditAgencyRequest Request)
        {
            IAgencyService objAgencyService = AgencyServiceFactory.CreateInstance();
            IPaymentService objPaymentService = PaymentServiceFactory.CreateInstance();
            BookingPaymentCreditAgencyResponse response = new BookingPaymentCreditAgencyResponse();
            IList<Entity.Booking.Payment> payments = null;
            IList<PaymentAllocation> paymentAllocations = null;
            Booking booking = null;
            Agent agent = new Agent();
            bool bResult = true;

            try
            {
                if (Request != null)
                {
                    agent = objAgencyService.GetAgencySessionProfile(Request.Booking.Header.AgencyCode, string.Empty);
                    if (agent != null)
                    {
                        payments = Request.Booking.Payments.ToListEntity();
                        if (payments != null)
                        {
                            foreach (Entity.Booking.Payment p in payments)
                            {
                                if (!p.ValidateCreditAgency(agent))
                                {
                                    bResult = false;
                                    response.Message = "ValidateCreditAgency fail";
                                    response.Success = false;
                                }
                            }

                            if (bResult)
                            {
                                booking = new Booking();
                                booking.Payments = Request.Booking.Payments.ToListEntity();
                                booking.Mappings = Request.Booking.Mappings.ToListEntity();
                                booking.Fees = Request.Booking.Fees.ToListEntity();
                                paymentAllocations = booking.CreateAllocation();
                                bResult = objPaymentService.SavePayment(Request.Booking.Payments.ToListEntity(), paymentAllocations, true);

                                if (bResult)
                                {
                                    response.Message = "Success";
                                    response.Success = true;
                                }
                                else
                                {
                                    response.Message = "SavePayment fail";
                                    response.Success = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        response.Message = "GetAgencySessionProfile fail";
                        response.Success = false;
                    }
                }
                else
                {
                    response.Message = "BookingPaymentCreditAgencyRequest is null";
                    response.Success = false;
                }
            }
            catch
            {
                response.Message = "BookingPaymentCreditAgency error";
                response.Success = false;
            }
            return response;
        }

        public AgencySessionProfileResponse GetAgencySessionProfile(AgencySessionProfileRequest Request)
        {
            IAgencyService objAgencyService = AgencyServiceFactory.CreateInstance();
            AgencySessionProfileResponse response = new AgencySessionProfileResponse();
            Agent agent = new Agent();

            try
            {
                agent = objAgencyService.GetAgencySessionProfile(Request.AgencyCode, Request.UserId);

                if (agent != null)
                {
                    response.AgentResponse = agent.ToAgentLogonMessage();
                    response.Message = "Success";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Fail";
                    response.Success = false;
                }
            }
            catch
            {
                response.Message = "Get Agency Profile is error";
                response.Success = false;
            }

            return response;
        }

        public TravelAgentLogonResponse TravelAgentLogon(TravelAgentLogonRequest Request)
        {
           // IAgencyService objAgencyService = AgencyServiceFactory.CreateInstance();
            TravelAgentLogonResponse response = new TravelAgentLogonResponse();
            Agent agent = new Agent();

            try
            {
                //  agent = objAgencyService.TravelAgentLogon(Request.AgencyCode, Request.AgentLogon, Request.AgentPassword);
                string user_account_id = GetAgencyUserDetails(Request.AgencyCode, Request.AgentLogon, Request.AgentPassword);

                List<User> users = new List<User>();
                User user = new User();
                users.Add(user);
                user.UserAccountId = new Guid(user_account_id);
                agent.Users = users;
                agent.UserAccountId = new Guid(user_account_id);

                if (agent != null && agent.Users != null)
                {
                    response.AgentResponse = agent.ToAgentLogonMessage();
                    response.Message = "Success";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Fail";
                    response.Success = false;
                }
            }
            catch(System.Exception ex)
            {
                response.Message = "Agent logon is error";
                response.Success = false;
                Logger.Instance(Logger.LogType.Mail).WriteLog(ex, "Travel Agent Logon");
            }

            return response;
        }

        public BookingFlightResponse BookFlight(BookingFlightRequest Request)
        {
            IBookingModelService objBookingService = BookingServiceFactory.CreateInstance();
            BookingFlightResponse response = new BookingFlightResponse();
            Booking booking = null;

            IList<Entity.Booking.Flight> flights = null;

            try
            {
                //map from message to entity
                if (Request != null)
                {
                    flights = Request.Flight.ToListEntity();
                    response.Success = true;
                }
                else
                {
                    response.Message = "Map message to entity fail";
                    response.Success = false;
                }
                
                if (response.Success)
                {

                    // Initialize and populate the BookingSaveRequest object
                    var bookingFlightAddRequest = new Avantik.Web.Service.Entity.Booking.REST.BookingFlightAddRequest
                    {
                        AgencyCode = Request.AgencyCode,
                        Currency = Request.Currency,
                        Flight = flights,
                        BookingId = Request.BookingId.ToString(),
                        Adults = Request.Adults,
                        Children = Request.Children,
                        Infants = Request.Infants,
                        Others = Request.Others,
                        StrOthers = null,
                        UserId = Request.UserId.ToString(),
                        StrIpAddress = Request.StrIpAddress,
                        StrLanguageCode = Request.StrLanguageCode,
                        BNoVat = Request.BNoVat
                    };

                    //call REST API
                    string baseURL = ConfigHelper.ToString("RESTURL");
                    //string baseURL = "https://localhost:7021/";//ConfigHelper.ToString("RESTURL");
                    string apiURL = baseURL + "api/Booking/BookFlight";

                    var jsonContent = JsonConvert.SerializeObject(bookingFlightAddRequest);
                    var content = System.Text.Encoding.UTF8.GetBytes(jsonContent);

                    var requestUri = new Uri(apiURL);

                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);

                    var userlogon = string.Format("{0}:{1}", "DLXAPI", "dlxapi");
                    byte[] bytes = Encoding.UTF8.GetBytes(userlogon);
                    string base64String = Convert.ToBase64String(bytes);
                    httpWebRequest.Headers["Authorization"] = "Basic " + base64String;


                    httpWebRequest.Method = "POST";
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.ContentLength = content.Length;


                    try
                    {
                        using (System.IO.Stream requestStream = httpWebRequest.GetRequestStream())
                        {
                            requestStream.Write(content, 0, content.Length);
                        }
                        using (HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                        {
                            if (httpResponse.StatusCode == HttpStatusCode.OK)
                            {
                                using (StreamReader reader = new StreamReader(httpResponse.GetResponseStream()))
                                {
                                    var responseContent = reader.ReadToEnd();
                                    Avantik.Web.Service.BookingRead.BookingRead bookingRead = JsonConvert.DeserializeObject<Avantik.Web.Service.BookingRead.BookingRead>(responseContent);

                                    BookingResponse bookingResponse = new BookingResponse();
                                    response.BookFlightResponse = new BookFlightResponse();

                                    response.BookFlightResponse.Header = bookingRead.Header.ToBookingMessage();
                                    response.BookFlightResponse.FlightSegments = bookingRead.Segments.ToBookingMessage();
                                    response.BookFlightResponse.Passengers = bookingRead.Passengers.ToBookingMessage();
                                    response.BookFlightResponse.Mappings = bookingRead.Mappings.ToBookingMessage();

                                    if (booking.FindUSSegment() == true)
                                    {
                                        response.Message = "Selected flight is full";
                                        response.Success = false;
                                    }
                                    else
                                    {
                                        response.Message = "Success";
                                        response.Success = true;
                                    }
                                }

                            }
                        }

                    }
                    catch (System.Exception ex)
                    {

                    }
                                  
                }
                
            }
            catch (BookingException ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            catch(System.Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                Logger.Instance(Logger.LogType.Mail).WriteLog(ex, XMLHelper.JsonSerializer(typeof(BookingFlightRequest), Request));
            }
            return response;
        }

        public GetFeeResponse GetFee(GetFeeRequest Request)
        {
            IFeeService objFeeService = FeeServiceFactory.CreateInstance();
            GetFeeResponse response = new GetFeeResponse();
            try
            {
                IList<Entity.Fee> Fees = objFeeService.GetFee(Request.StrFeeRcd, Request.StrCurrencyCode, Request.StrAgencyCode, Request.StrClass, Request.StrFareBasis, Request.StrOrigin, Request.StrDestination, Request.StrFlightNumber, Request.DtDate, Request.StrLanguage, Request.bNoVat);

                if (Fees != null)
                {
                    // map to response
                    response.Fees = Fees.ToFeeMessage();
                    response.Message = "Success";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Fail";
                    response.Success = false;
                }
            }
            catch
            {
                response.Message = "Get fee  is error";
                response.Success = false;
            }

            return response;
        }
       
        public CalculateFeesBookingResponse CalculateFeesBookingCreate(CalculateFeesBookingCreateRequest Request)
        {
            IFeeService objFeeService = FeeServiceFactory.CreateInstance();
            CalculateFeesBookingResponse response = new CalculateFeesBookingResponse();

            Booking booking = new Booking();

            // map from message to entity
            if (Request != null)
            {
                booking.Header = Request.Booking.Header.ToEntity();
                booking.Segments = Request.Booking.FlightSegments.ToListEntity();
                booking.Passengers = Request.Booking.Passengers.ToListEntity();
                booking.Mappings = Request.Booking.Mappings.ToListEntity();
                booking.Payments = Request.Booking.Payments.ToListEntity();
                booking.Fees = Request.Booking.Fees.ToListEntity();
                booking.Remarks = Request.Booking.Remarks.ToListEntity();
                booking.Services = Request.Booking.Services.ToListEntity();
                booking.Taxs = Request.Booking.Taxs.ToListEntity();
            }

            try
            {
                IList<Avantik.Web.Service.Entity.Booking.Fee> BookingFees = objFeeService.CalculateFeesBookingCreate(Request.AgencyCode, Request.Currency, booking, Request.Language);

                if (BookingFees != null)
                {
                    // map to response
                    response.Fees = BookingFees.ToBookingMessage();
                    response.Message = "Success";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Fail";
                    response.Success = false;
                }
            }
            catch
            {
                response.Message = "CalculateFeesBookingCreate is error";
                response.Success = false;
            }

            return response;
        }
       
        public CalculateFeesBookingResponse CalculateFeesBookingChange(CalculateFeesBookingCreateRequest Request)
        {
            IFeeService objFeeService = FeeServiceFactory.CreateInstance();
            CalculateFeesBookingResponse response = new CalculateFeesBookingResponse();

            Booking booking = new Booking();

            // map from message to entity
            if (Request != null)
            {
                booking.Header = Request.Booking.Header.ToEntity();
                booking.Segments = Request.Booking.FlightSegments.ToListEntity();
                booking.Passengers = Request.Booking.Passengers.ToListEntity();
                booking.Mappings = Request.Booking.Mappings.ToListEntity();
                booking.Payments = Request.Booking.Payments.ToListEntity();
                booking.Fees = Request.Booking.Fees.ToListEntity();
                booking.Remarks = Request.Booking.Remarks.ToListEntity();
                booking.Services = Request.Booking.Services.ToListEntity();
                booking.Taxs = Request.Booking.Taxs.ToListEntity();
            }

            try
            {
                IList<Avantik.Web.Service.Entity.Booking.Fee> BookingFees = objFeeService.CalculateFeesBookingChange(Request.AgencyCode, Request.Currency, booking, Request.Language);

                if (BookingFees != null)
                {
                    // map to response
                    response.Fees = BookingFees.ToBookingMessage();
                    response.Message = "Success";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Fail";
                    response.Success = false;
                }
            }
            catch
            {
                response.Message = "CalculateFeesBookingChange is error";
                response.Success = false;
            }

            return response;
        }
        
        public CalculateFeesBookingResponse CalculateFeesSeatAssignment(CalculateFeesSeatAssignmentRequest Request)
        {
            IFeeService objFeeService = FeeServiceFactory.CreateInstance();
            CalculateFeesBookingResponse response = new CalculateFeesBookingResponse();

            Booking booking = new Booking();

            // map from message to entity
            if (Request != null)
            {
                booking.Header = Request.Booking.Header.ToEntity();
                booking.Segments = Request.Booking.FlightSegments.ToListEntity();
                booking.Passengers = Request.Booking.Passengers.ToListEntity();
                booking.Mappings = Request.Booking.Mappings.ToListEntity();
                booking.Payments = Request.Booking.Payments.ToListEntity();
                booking.Fees = Request.Booking.Fees.ToListEntity();
                booking.Remarks = Request.Booking.Remarks.ToListEntity();
                booking.Services = Request.Booking.Services.ToListEntity();
                booking.Taxs = Request.Booking.Taxs.ToListEntity();
            }

            try
            {
                IList<Avantik.Web.Service.Entity.Booking.Fee> BookingFees = objFeeService.CalculateFeesSeatAssignment(Request.AgencyCode, Request.Currency, booking, Request.Language, Request.bNovat);

                if (BookingFees != null)
                {
                    // map to response
                    response.Fees = BookingFees.ToBookingMessage();
                    response.Message = "Success";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Fail";
                    response.Success = false;
                }
            }
            catch
            {
                response.Message = "CalculateFeesSeatAssignment is error";
                response.Success = false;
            }

            return response;
        }
        
        public CalculateFeesBookingResponse CalculateFeesNameChange(CalculateFeesNameChangeRequest Request)
        {
            IFeeService objFeeService = FeeServiceFactory.CreateInstance();
            CalculateFeesBookingResponse response = new CalculateFeesBookingResponse();

            Booking booking = new Booking();

            // map from message to entity
            if (Request != null)
            {
                booking.Header = Request.Booking.Header.ToEntity();
                booking.Segments = Request.Booking.FlightSegments.ToListEntity();
                booking.Passengers = Request.Booking.Passengers.ToListEntity();
                booking.Mappings = Request.Booking.Mappings.ToListEntity();
                booking.Payments = Request.Booking.Payments.ToListEntity();
                booking.Fees = Request.Booking.Fees.ToListEntity();
                booking.Remarks = Request.Booking.Remarks.ToListEntity();
                booking.Services = Request.Booking.Services.ToListEntity();
                booking.Taxs = Request.Booking.Taxs.ToListEntity();
            }

            try
            {
                IList<Avantik.Web.Service.Entity.Booking.Fee> BookingFees = objFeeService.CalculateFeesNameChange(Request.AgencyCode, Request.Currency, booking, Request.Language);

                if (BookingFees != null)
                {
                    // map to response
                    response.Fees = BookingFees.ToBookingMessage();
                    response.Message = "Success";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Fail";
                    response.Success = false;
                }
            }
            catch
            {
                response.Message = "CalculateFeesNameChange is error";
                response.Success = false;
            }

            return response;
        }
        
        public CalculateFeesBookingResponse CalculateFeesSpecialService(CalculateFeesSpecialServiceRequest Request)
        {
            IFeeService objFeeService = FeeServiceFactory.CreateInstance();
            CalculateFeesBookingResponse response = new CalculateFeesBookingResponse();

            Booking booking = new Booking();

            // map from message to entity
            if (Request != null)
            {
                booking.Header = Request.Booking.Header.ToEntity();
                booking.Segments = Request.Booking.FlightSegments.ToListEntity();
                booking.Passengers = Request.Booking.Passengers.ToListEntity();
                booking.Mappings = Request.Booking.Mappings.ToListEntity();
                booking.Payments = Request.Booking.Payments.ToListEntity();
                booking.Fees = Request.Booking.Fees.ToListEntity();
                booking.Remarks = Request.Booking.Remarks.ToListEntity();
                booking.Services = Request.Booking.Services.ToListEntity();
                booking.Taxs = Request.Booking.Taxs.ToListEntity();
            }

            try
            {
                IList<Avantik.Web.Service.Entity.Booking.Fee> BookingFees = objFeeService.CalculateFeesSpecialService(Request.AgencyCode, Request.Currency, booking, Request.Language, Request.bNovat);

                if (BookingFees != null)
                {
                    // map to response
                    response.Fees = BookingFees.ToBookingMessage();
                    response.Message = "Success";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Fail";
                    response.Success = false;
                }
            }
            catch
            {
                response.Message = "CalculateFeesSpecialService is error";
                response.Success = false;
            }

            return response;
        }
        
        public GetSegmentFeeResponse GetServiceFee(GetSegmentFeeRequest Request)
        {
            IFeeService objFeeService = FeeServiceFactory.CreateInstance();
            GetSegmentFeeResponse response = new GetSegmentFeeResponse();

            IList<Entity.Booking.PassengerService> passengerServices = Request.services.ToListEntity();
            IList<Entity.SegmentService> segmentServices = Request.segmentService.ToFeeEntity();

            try
            {
                IList<Entity.ServiceFee> ServiceFees = objFeeService.GetSegmentFee(Request.AgencyCode, Request.CurrencyCode, Request.LanguageCode, Request.NumberOfPassenger, Request.NumberOfInfant, passengerServices, segmentServices, Request.SpecialService, Request.bNoVat);

                if (ServiceFees != null)
                {
                    // map to response
                    response.ServiceFees = ServiceFees.ToFeeMessage();
                    response.Message = "Success";
                    response.Success = true;
                }
                else
                {
                    response.Message = "Fail";
                    response.Success = false;
                }
            }
            catch
            {
                response.Message = "GetSegmentFee is error";
                response.Success = false;
            }

            return response;
        }

        public BaggageFeeResponse GetBaggageFee(BaggageFeeRequest request)
        {
            IFeeService objFeeService = FeeServiceFactory.CreateInstance();
            BaggageFeeResponse response = new BaggageFeeResponse();

            try
            {
                if (string.IsNullOrEmpty(request.AgencyCode))
                {
                    response.Success = false;
                    response.Message = "Agency Code is required";
                }
                else if (request.BookingSegmentId.Equals(Guid.Empty))
                {
                    response.Success = false;
                    response.Message = "Booking Segment Id is required";
                }
                else if (request.Mappings.Count == 0)
                {
                    response.Success = false;
                    response.Message = "Mappings is required";
                }
                else
                {
                    if (string.IsNullOrEmpty(request.LanguageCode))
                    {
                        request.LanguageCode = "EN";
                    }

                    IList<Entity.Booking.Fee> bkf = request.BookingFees.ToListEntity();
                    IList<Entity.Booking.Mapping> mpp = request.Mappings.ToListEntity();

                    IList<Avantik.Web.Service.Entity.Booking.Fee> fee = objFeeService.GetBaggageFee(mpp, 
                                                                 request.BookingSegmentId, 
                                                                 request.PassengerId, 
                                                                 request.AgencyCode, 
                                                                 request.LanguageCode, 
                                                                 request.MaxUnit,
                                                                 bkf, 
                                                                 request.bNovat);
                    if (fee != null && fee.Count > 0)
                    {
                        response.Success = true;
                        response.Message = "SUCCESS";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "FAILED";
                    }
                }
            }
            catch (SystemException ex)
            {
                response.Success = false;
                response.Message = ex.Message;

                Logger.Instance(Logger.LogType.Mail).WriteLog(ex, XMLHelper.JsonSerializer(typeof(BaggageFeeRequest), request));
            }
            return response;
        }

        public QuoteSummaryResponse GetQuoteSummary(QuoteSummaryRequest Request)
        {
            IBookingModelService objBookingService = BookingServiceFactory.CreateInstance();
            QuoteSummaryResponse response = new QuoteSummaryResponse();


            try
            {
                if (Request.FlightSegments != null && Request.FlightSegments.Count > 0)
                {
                    IList<Entity.Booking.FlightSegment> flightSegments = Request.FlightSegments.ToListEntity();
                    IList<Entity.Booking.Passenger> passengers = Request.Passengers.ToListEntity();
                    Booking booking = objBookingService.GetQuoteSummary(flightSegments, passengers, Request.AgencyCode, Request.Language, Request.CurrencyCode, Request.bNovat);

                    if (booking != null && booking.Segments != null && booking.Segments.Count > 0)
                    {
                        response.BookingResponse.FlightSegments = booking.Segments.ToBookingMessage();
                        response.BookingResponse.Passengers = booking.Passengers.ToBookingMessage();
                        response.BookingResponse.Taxs = booking.Taxs.ToBookingMessage();
                        response.BookingResponse.Mappings = booking.Mappings.ToBookingMessage();
                        response.BookingResponse.Fees = booking.Fees.ToBookingMessage();
                        response.BookingResponse.Quotes = booking.Quotes.ToBookingMessage();

                        response.Message = "Success";
                        response.Success = true;
                    }
                    else
                    {
                        response.Message = "Fail";
                        response.Success = false;
                    }
                }
                else
                {
                    response.Message = "Fail";
                    response.Success = false;
                }
            }
            catch(SystemException ex)
            {
                response.Message = "Booking Read is error";
                response.Success = false;
                Logger.Instance(Logger.LogType.Mail).WriteLog(ex, XMLHelper.JsonSerializer(typeof(QuoteSummaryRequest), Request));
            }

            return response;
        }


        public PaymentMultipleFOPResponse PaymentMultipleFOP(PaymentMultipleFOPRequest Request)
        {
            IAgencyService objAgencyService = AgencyServiceFactory.CreateInstance();
            IPaymentService objPaymentService = PaymentServiceFactory.CreateInstance();
            IVoucherService objVoucherService = VoucherServiceFactory.CreateInstance();
            PaymentMultipleFOPResponse response = new PaymentMultipleFOPResponse();

            Booking booking = null;
            bool resultPayment = false;
            IList<PaymentAllocation> paymentAllocations = null;

            List<Entity.Booking.Payment> PaymentsVoucher = new List<Entity.Booking.Payment>();
            List<Entity.Booking.Payment> PaymentsCreitCard = new List<Entity.Booking.Payment>();
            List<Entity.Booking.Payment> PaymentsCreditAgency = new List<Entity.Booking.Payment>();
            List<Entity.Booking.Payment> PaymentsToSave = new List<Entity.Booking.Payment>();
            Entity.Voucher voucher = new Entity.Voucher();
            PaymentsToSave = Request.Booking.Payments.ToListEntity() as List<Entity.Booking.Payment>;
            Comparison<Entity.Booking.Payment> comparePaymentAmount = new Comparison<Entity.Booking.Payment>(Entity.Booking.Payment.ComparePaymentAmount);

            try
            {
                if (Request != null)
                {
                    booking = new Booking();
                    booking.Header = Request.Booking.Header.ToEntity();
                    booking.Segments = Request.Booking.FlightSegments.ToListEntity();
                    booking.Passengers = Request.Booking.Passengers.ToListEntity();
                    booking.Remarks = Request.Booking.Remarks.ToListEntity();
                    booking.Payments = Request.Booking.Payments.ToListEntity();
                    booking.Mappings = Request.Booking.Mappings.ToListEntity();
                    booking.Services = Request.Booking.Services.ToListEntity();
                    booking.Taxs = Request.Booking.Taxs.ToListEntity();
                    booking.Fees = Request.Booking.Fees.ToListEntity();

                    foreach (Entity.Booking.Payment p in booking.Payments)
                    {
                        if (p.FormOfPaymentRcd.Equals("CC"))
                        {
                            PaymentsCreitCard.Add(p);
                        }
                        else if (p.FormOfPaymentRcd.Equals("VOUCHER"))
                        {
                            voucher.VoucherNumber = p.DocumentNumber;
                            voucher = objVoucherService.GetVoucher(voucher);

                            if (voucher == null)
                            {
                                resultPayment = false;
                            }
                            else
                            {
                                PaymentsVoucher.Add(p);
                            }

                        }
                        else if (p.FormOfPaymentRcd.Equals("INV") || p.FormOfPaymentRcd.Equals("CRAGT"))
                        {
                            PaymentsCreditAgency.Add(p);
                        }
                    }

                    if (booking.ValidateSaveBooking(booking.Header, booking.Segments, booking.Passengers, booking.Mappings))
                    {
                        if (PaymentsVoucher.Count > 0)
                        {
                            PaymentsVoucher.Sort(comparePaymentAmount);
                            PaymentsToSave.AddRange(PaymentsVoucher);
                            if (voucher.ValidateVoucherPayment(PaymentsVoucher) == true)
                            {
                                if (PaymentsCreitCard.Count > 0)
                                {
                                    PaymentsToSave.AddRange(PaymentsCreitCard);
                                    paymentAllocations = booking.CreateAllocation();


                                    bool validCreditCard = objPaymentService.PaymentCreditCard(booking, paymentAllocations,
                                                                                        Request.SecurityToken, Request.AuthenticationToken,
                                                                                        Request.CommerceIndicator, Request.BookingReference,
                                                                                        Request.RequestSource, true, false, false);
                                    if (validCreditCard)
                                    {
                                        resultPayment = objPaymentService.SavePayment(PaymentsToSave, paymentAllocations, true);

                                        if (resultPayment)
                                        {
                                            response.Message = "Success";
                                            response.Success = true;
                                        }
                                        else
                                        {
                                            response.Message = "SavePayment CC && Voucher fail";
                                            response.Success = false;
                                        }
                                    }
                                }
                                if (PaymentsCreditAgency.Count > 0)
                                {
                                    Agent agent = new Agent();
                                    bool agentResult = true;
                                    PaymentsToSave.AddRange(PaymentsCreditAgency);
                                    paymentAllocations = booking.CreateAllocation();

                                    agent = objAgencyService.GetAgencySessionProfile(Request.Booking.Header.AgencyCode, string.Empty);
                                    if (agent != null)
                                    {

                                        foreach (Entity.Booking.Payment p in PaymentsCreditAgency)
                                        {
                                            if (!p.ValidateCreditAgency(agent))
                                            {
                                                agentResult = false;
                                                response.Message = "ValidateCreditAgency fail";
                                                response.Success = false;
                                            }
                                        }

                                        if (agentResult)
                                        {
                                            booking = new Booking();
                                            booking.Payments = Request.Booking.Payments.ToListEntity();
                                            booking.Mappings = Request.Booking.Mappings.ToListEntity();
                                            booking.Fees = Request.Booking.Fees.ToListEntity();
                                            paymentAllocations = booking.CreateAllocation();
                                            resultPayment = objPaymentService.SavePayment(PaymentsToSave, paymentAllocations, true);

                                            if (resultPayment)
                                            {
                                                response.Message = "Success";
                                                response.Success = true;
                                            }
                                            else
                                            {
                                                response.Message = "SavePayment Agent && Voucher fail";
                                                response.Success = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        response.Message = "GetAgencySessionProfile fail";
                                        response.Success = false;
                                    }

                                    
                                }
                            }
                        }
                    }

                    if (resultPayment == true)
                    {
                        response.Message = "Success";
                        response.Success = true;
                    }
                    else
                    {
                        response.Message = "Multiple Payment fail";
                        response.Success = false;
                    }
                }
                else
                {
                    response.Message = "Booking Multiple Payment is null";
                    response.Success = false;
                }
            }
            catch
            {
                response.Message = "Booking Multiple Payment Error";
                response.Success = false;
            }

            return response;
        }

        public GetSeatMapResponse GetSeatMap(GetSeatMapRequest request)
        {
            Model.Contract.IFlightService objFlightService = FlightServiceFactory.CreateInstance();
            GetSeatMapResponse response = new GetSeatMapResponse();
            List<Entity.Flight.SeatMap> seatMaps = new List<Entity.Flight.SeatMap>();
            Entity.Booking.Flight flight = new Entity.Booking.Flight();

            // map request to entity
            flight.OriginRcd = request.StrOrigin;
            flight.DestinationRcd = request.StrDestination;
            flight.FlightId = new Guid(request.StrFlightId);
            flight.BoardingClassRcd = request.StrBoardingClass;
            flight.BookingClassRcd = request.StrBookingClass;

            try
            {
                seatMaps = objFlightService.GetSeatMap(flight);
                if (seatMaps != null && seatMaps.Count > 0)
                {
                    response.SeatMaps = seatMaps.ToSeatMapMessage();
                    response.Success = true;
                    response.Message = "SUCCESS";
                }
                else
                {
                    response.Success = false;
                    response.Message = "FAIL";
                }
            }
            catch
            {
                response.Success = false;
                response.Message = "FAIL";
            }

            return response;
        }

        public BookingPaymentResponse BookingExternalPayment(BookingPaymentRequest Request)
        {
            IPaymentService objPaymentService = PaymentServiceFactory.CreateInstance();
            BookingPaymentResponse response = new BookingPaymentResponse();

            string strLanguage = "EN";
            string resultPayment = string.Empty; ;

            string strBookingId = Request.Payments[0].BookingId.ToString();
            string strUserId = Request.Payments[0].PaymentBy.ToString();
            double dPaymentAmount = decimal.ToDouble(Request.Payments[0].PaymentAmount);
            double dReceivePaymentAmount = decimal.ToDouble(Request.Payments[0].ReceivePaymentAmount);

            Request.CreateTicket = true;

            // get outstanding balance
            BookingService objService = new BookingService();
            BookingReadResponse readResponse = new BookingReadResponse();
            BookingReadRequest readRequest = new BookingReadRequest();
            readRequest.BookingId = Request.Payments[0].BookingId.ToString();
            Booking booking = new Booking();
           // decimal CalOutStandingBalance = 0;
            //bool bNotYetIssuedTicket = false;

            try
            {
                //read booking
                readResponse = objService.ReadBooking(readRequest);

                if(readResponse.Success)
                {
                    booking.Header = readResponse.BookingResponse.Header.ToEntity();
                    booking.Segments = readResponse.BookingResponse.FlightSegments.ToListEntity();
                    booking.Passengers = readResponse.BookingResponse.Passengers.ToListEntity();
                    booking.Mappings = readResponse.BookingResponse.Mappings.ToListEntity();
                    booking.Services = readResponse.BookingResponse.Services.ToListEntity();
                    booking.Fees = readResponse.BookingResponse.Fees.ToListEntity();

                }

                if (dPaymentAmount != 0)
                {
                    resultPayment = objPaymentService.ExternalPaymentAddPayment(
                                                                 strBookingId,
                                                                 Request.Payments[0].AgencyCode,
                                                                 Request.Payments[0].FormOfPaymentRcd,
                                                                 Request.Payments[0].CurrencyRcd,
                                                                 dPaymentAmount,
                                                                 Request.Payments[0].FormOfPaymentSubtypeRcd,
                                                                 strUserId,
                                                                 Request.Payments[0].DocumentNumber,
                                                                 Request.Payments[0].PaymentNumber,
                                                                 Request.Payments[0].ApprovalCode,
                                                                 Request.Payments[0].PaymentRemark,
                                                                 strLanguage,
                                                                 Request.Payments[0].PaymentDateTime,
                                                                 Request.Payments[0].TransactionReference,
                                                                 Request.Payments[0].PaymentReference,
                                                                 Request.Payments[0].ReceiveCurrencyRcd,
                                                                 dReceivePaymentAmount,
                                                                 booking.Mappings,
                                                                 booking.Fees
                                                                 );
                }


                if (resultPayment != null && resultPayment != string.Empty)
                {
                    if (resultPayment.Contains(strBookingId))
                    {
                        response.Message = "Success";
                        response.Success = true;
                        response.Code = "000";
                    }
                    else
                    {
                        if (resultPayment.Contains("404"))
                        {
                            response.Message = "Agency Code is invalid.";
                            response.Success = false;
                            response.Code = "404";
                        }
                        if (resultPayment.Contains("411"))
                        {
                            response.Message = "Currency Code is invalid.";
                            response.Success = false;
                            response.Code = "411";
                        }
                        if (resultPayment.Contains("412"))
                        {
                            response.Message = "Payment Amount does not match outstanding Balance (Summary).";
                            response.Success = false;
                            response.Code = "412";
                        }
                        if (resultPayment.Contains("413"))
                        {
                            response.Message = "Booking is not balanced after Payment.";
                            response.Success = false;
                            response.Code = "413";
                        }
                        if (resultPayment.Contains("999"))
                        {
                            response.Message = "Payment not processed.";
                            response.Success = false;
                            response.Code = "999";
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                response.Message = "Save payment is error";
                response.Success = false;
                Logger.Instance(Logger.LogType.Mail).WriteLog(ex, XMLHelper.JsonSerializer(typeof(BookingPaymentRequest), Request));
            }

            return response;
        }

        public string GetAgencyUserDetails(string agencyCode, string userLogon, string userPassword)
        {
            List<AgencyUserDetails> userDetailsList = new List<AgencyUserDetails>();
            string strSQLConnectionString = ConfigHelper.ToString("SQLConnectionString");

            using (SqlConnection conn = new SqlConnection(strSQLConnectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetAgencyUserDetails_api", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.Add(new SqlParameter("@agency_code", SqlDbType.VarChar, 50)).Value = agencyCode;
                        cmd.Parameters.Add(new SqlParameter("@user_logon", SqlDbType.VarChar, 50)).Value = userLogon;
                        cmd.Parameters.Add(new SqlParameter("@user_password", SqlDbType.VarChar, 50)).Value = userPassword;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AgencyUserDetails userDetails = new AgencyUserDetails
                                {
                                    agency_code = agencyCode,
                                    user_logon = userLogon,
                                    user_account_id = reader["user_account_id"] != DBNull.Value ? reader["user_account_id"].ToString() : null
                                };

                                userDetailsList.Add(userDetails);
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    // Console.WriteLine("Error: " + ex.Message);
                }
            }

            return userDetailsList[0].user_account_id;
        }
    }
}
