using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationSystem.Domain.Entity;

namespace ReservationSystem.Infrastructure.Repository
{
    public class EntityConfig
    {

        public static void SetEntityBuilder(EntityTypeBuilder<User> entityBuilder)
        {

            entityBuilder.ToTable("User");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Password).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.DateFrom).IsRequired();
            entityBuilder.Property(x => x.DateTo);

        }
    }
}
