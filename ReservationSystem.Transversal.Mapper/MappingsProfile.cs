using System;
using AutoMapper;
using ReservationSystem.Domain.Entity;
using ReservationSystem.Application.DTO;

namespace ReservationSystem.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<IdentityCardType, IdentityCardTypeDto>().ReverseMap();
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Hotel, HotelGetDto>().ReverseMap();
            CreateMap<Airline, AirlineDto>().ReverseMap();
            CreateMap<Include, IncludeDto>().ReverseMap();
            CreateMap<AppParameters, AppParametersDto>().ReverseMap();
            CreateMap<Agreement, AgreementDto>().ReverseMap();           
            CreateMap<User, UsersDto>().ReverseMap();
            CreateMap<Destination, DestinationDto>().ReverseMap();
            CreateMap<Accommodation, AccommodationDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerGetDto>().ReverseMap();
            CreateMap<Provider, ProviderDto>().ReverseMap();
            CreateMap<Provider, ProviderGetDto>().ReverseMap();
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<Reservation, ReservationGetDto>().ReverseMap();
            CreateMap<ReservationPay, ReservationPayGetDto>().ReverseMap();
            CreateMap<ReservationPay, ReservationPayDto>().ReverseMap();
            CreateMap<ReservationInclude, ReservationIncludeDto>().ReverseMap();
            CreateMap<ReservationPassenger, ReservationPassengerDto>().ReverseMap();
        }
    }
}
