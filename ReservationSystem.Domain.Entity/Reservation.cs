using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSystem.Domain.Entity
{
    [Table("Reservation")]
    public class Reservation : Base.Entity
    { 
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        [ForeignKey("Destination")]
        public int DestinationId { get; set; }
        [ForeignKey("Airline")]
        public int AirlineId { get; set; }
        [ForeignKey("Accommodation")]
        public int AccommodationId { get; set; }
        [ForeignKey("Customer")]        
        public int CustomerId { get; set; }
        [ForeignKey("Agreement")]
        public int AgreementId { get; set; }
        public int ReservationNumber { get; set; }
        public double AdultRate { get; set; }
        public double ChildRate { get; set; }
        public double InfantRate { get; set; }
        public int NumberPassengers { get; set; }    
        public string Code { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime TravelDate { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public double TotalValue { get; set; }
        public DateTime InitialAbonDate { get; set; }
        public double InitialAbonValue { get; set; }
        public double BalancePendientToPay { get; set; }
        public DateTime TotalCancelationDate { get; set; }
        public Hotel Hotel { get; set; }
        public Airline Airline { get; set; }
        public Accommodation Accommodation { get; set; }
        public Customer Customer { get; set; }
        public Agreement Agreement { get; set; }
        public Destination Destination { get; set; }      
       
    }
}
