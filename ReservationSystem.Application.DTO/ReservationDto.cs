using System;
using System.Collections.Generic;

namespace ReservationSystem.Application.DTO
{
    public class ReservationDto : DtoBase
    {
        public int ReservationNumber { get; set; }
        public int DestinationId { get; set; }
        public int HotelId { get; set; }
        public int AccommodationId { get; set; }
        public double AdultRate { get; set; }
        public double ChildRate { get; set; }
        public double InfantRate { get; set; }
        public int NumberPassengers { get; set; }
        public int AirlineId { get; set; }
        public int AgreementId { get; set; }
        public string Code { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime TravelDate { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public double TotalValue { get; set; }
        public double InitialAbonValue { get; set; }
        public double BalancePendientToPay { get; set; }
        public DateTime InitialAbonDate { get; set; }
        public DateTime TotalCancelationDate { get; set; }       
        public int CustomerId { get; set; }

    }
}
