using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avantik.Web.Service.Entity.Booking;

namespace Avantik.Web.Service.Extension
{
    public static class FlightMessageToEntity
    {
        public static Flight ToEntity(this Message.Booking.Flight flightMessage)
        {
            Flight flight = null;
            if (flightMessage != null)
            {
                flight = new Flight();
                flight.BoardingClassRcd = flightMessage.BoardingClassRcd;
                flight.BookingClassRcd = flightMessage.BookingClassRcd;
                flight.DepartureDate = flightMessage.DepartureDate;
                flight.DestinationRcd = flightMessage.DestinationRcd;
                flight.EticketFlag = flightMessage.EticketFlag;
                flight.FairId = flightMessage.FairId;
                flight.FlightConnectionId = flightMessage.FlightConnectionId;
                //PSS2
                //in pss1 we can retrive flight id from getEmpty
                // in pss2 we need to send it to system
                //flight.FlightId = new Guid("E40C7C39-70CB-4FD7-A69C-EA9D6E54DB94");// flightMessage.FlightId;

                flight.FlightId =  flightMessage.FlightId;
                flight.OdDestinationRcd = flightMessage.OdDestinationRcd;
                flight.OdOriginRcd = flightMessage.OdOriginRcd;
                flight.OriginRcd = flightMessage.OriginRcd;
                flight.TransitPoints = flightMessage.TransitPoints;
                flight.TransitpointsName = flightMessage.TransitPointsName;
                flight.NumberOfUnits = flightMessage.NumberOfUnits;
                flight.AirlineRcd = flightMessage.AirlineRcd;
                flight.FlightNumber = flightMessage.FlightNumber;

            }
            return flight;
        }

        public static IList<Flight> ToListEntity(this  IList<Message.Booking.Flight> segment)
        {
            IList<Flight> segmentList = null;
            if (segment != null)
            {
                segmentList = new List<Flight>();

                for (int i = 0; i < segment.Count; i++)
                {
                    segmentList.Add(segment[i].ToEntity());
                }
            }

            return segmentList;
        }
    }
}
