using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface;

namespace ReservationSystem.Infrastructure.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public ApplicationDbContext()
        {

        }
        public DbSet<Accommodation> Accommodation { get; set; }
        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<AppParameters> AppParameters { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<IdentityCardType> IdentityCardTypes { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Reservation> TouristReservations { get; set; }
        public DbSet<ReservationInclude> TouristReservationIncludes { get; set; }
        public DbSet<ReservationPassenger> TouristReservationPassengers { get; set; }
        public DbSet<ReservationPay> ReservationPays { get; set; }
        public DbSet<Include> Includes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //EntityConfig.SetEntityBuilder(modelBuilder.Entity<User>());

            base.OnModelCreating(modelBuilder);
        }

    }
}
