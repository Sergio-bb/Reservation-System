using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReservationSystem.Application.Interface;
using ReservationSystem.Application.Main;
using ReservationSystem.Domain.Core;
using ReservationSystem.Domain.Interface;
using ReservationSystem.Infrastructure.Interface;
using ReservationSystem.Infrastructure.Repository;
using ReservationSystem.Transversal.Common;
using ReservationSystem.Transversal.Logging;
namespace ReservationSystem.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {              
            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped<IReservationPayApplication, ReservationPayApplication>();
            services.AddScoped<IReservationPayDomain, ReservationPayDomain>();
            services.AddScoped<IReservationPayRepository, ReservationPayRepository>();
            services.AddScoped<IIdentityCardTypeRepository, IdentityCardTypeRepository>();
            services.AddScoped<IIdentityCardTypeDomain, IdentityCardTypeDomain>();
            services.AddScoped<IIdentityCardTypeApplication, IdentityCardTypeApplication>();
            services.AddScoped<IHotelApplication, HotelApplication>();
            services.AddScoped<IHotelDomain, HotelDomain>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IAirlineApplication, AirlineApplication>();
            services.AddScoped<IAirlineDomain, AirlineDomain>();
            services.AddScoped<IAirlineRepository, AirlineRepository>();
            services.AddScoped<IIncludeApplication, IncludeApplication>();
            services.AddScoped<IIncludeDomain, IncludeDomain>();
            services.AddScoped<IIncludeRepositoy, IncludeRepository>();
            services.AddScoped<ITouristReservationIncludeApplication, TouristReservationIncludeApplication>();
            services.AddScoped<ITouristReservationIncludeDomain, TouristReservationIcludeDomain>();
            services.AddScoped<ITouristReservationIncludeRepository, TouristReservationIncludeRepository>();
            services.AddScoped<ITouristReservationPassengerApplication, TouristReservationPassengerApplication>();
            services.AddScoped<ITouristReservationPassengerDomain, TouristReservationPassengerDomain>();
            services.AddScoped<ITouristReservationPassengerRepository, TouristReservationPassengerRepository>();
            services.AddScoped<ITouristReservationApplication, TouristReservationApplication>();
            services.AddScoped<ITouristReservationDomain, TouristReservationDomain>();
            services.AddScoped<ITouristReservationRepositoy, TouristReservationRepository>();            
            services.AddScoped<IAppParametersApplication, AppParametersApplication>();
            services.AddScoped<IAppParametersDomain, AppParametersDomain>();
            services.AddScoped<IAppParametersRepository, AppParametersRepository>();          
            services.AddScoped<IAccommodationRoomApplication, AccommodationApplication>();
            services.AddScoped<IAccommodationDomain, AcommodationDomain>();
            services.AddScoped<IAccommodationRepository, AccommodationRepository>();
            services.AddScoped<IAgreementApplication, AgreementApplication>();
            services.AddScoped<IAgreementDomain, AgreementDomain>();
            services.AddScoped<IAgreementRepository, AgreementRepository>();
            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<ICustomerDomain, CustomerDomain>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDestinationApplication, DestinationApplication>();
            services.AddScoped<IDestinationDomain, DestinationDomain>();
            services.AddScoped<IDestinationRepository, DestinationRepository>();
            services.AddScoped<IProviderApplication, ProviderApplication>();
            services.AddScoped<IProviderDomain, ProviderDomain>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ReservationSystemConnection")));
            return services;
        }
    }
}
