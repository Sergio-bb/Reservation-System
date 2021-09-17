using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationSystem.Infrastructure.Repository.Migrations
{
    public partial class AddCodeInReservationIncludes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "TouristReservationIncludes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "TouristReservationIncludes");
        }
    }
}
