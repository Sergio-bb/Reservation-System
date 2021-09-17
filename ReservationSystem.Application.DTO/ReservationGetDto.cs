using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ReservationSystem.Application.DTO
{
    public class ReservationGetDto : DtoBase    
    {
        public int AirlineId { get; set; }
        public int HotelId { get; set; }
        public int DestinationId { get; set; }       
        public int AccommodationId { get; set; }
        public int CustomerId { get; set; }  
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
        public double InitialAbonValue { get; set; }
        public double BalancePendientToPay { get; set; }
        public DateTime InitialAbonDate { get; set; }
        public DateTime TotalCancelationDate { get; set; }
           
        [JsonIgnore]
        public DestinationDto Destination { get; set; }
        [JsonIgnore]
        public HotelDto Hotel { get; set; }
        [JsonIgnore]
        public AirlineDto Airline { get; set; }
        [JsonIgnore]
        public AccommodationDto Accommodation { get; set; }
        [JsonIgnore]
        public CustomerDto Customer { get; set; }
        [JsonIgnore]
        public AgreementDto Agreement { get; set; }        
        public string AgreeementDescription { get => Agreement.Name; }
        public string AccommdationDescription { get => Accommodation.Description; }
        public string AirlineName { get => Airline.Name; }
        public string HotelName { get => Hotel.Name; }        
        public string CustomerName { get => Customer.Name; }
        public string PhoneNumberCustomer { get => Customer.PhoneNumber; }
        public string DestinationName { get => Destination.Name; }        
        public virtual IEnumerable<ReservationIncludeDto> ReservationIncludes { get; set; }
        public virtual IEnumerable<ReservationPassengerDto> ReservationPassengers { get; set; }
        public virtual IEnumerable<ReservationPayGetDto> ReservationPays { get; set; }
    }
}
