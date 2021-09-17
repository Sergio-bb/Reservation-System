using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationSystem.Infrastructure.Repository.Migrations
{
    public partial class addReservationPay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            
            migrationBuilder.CreateTable(
                name: "ReservationPays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationPays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationPays_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationPays_ReservationId",
                table: "ReservationPays",
                column: "ReservationId");
               
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Destination_DestinationId",
                table: "Reservation");

            migrationBuilder.DropTable(
                name: "ReservationPays");

           

         
        }
    }
}
