using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationsManagement.Migrations
{
    public partial class Seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientVMId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientVMId",
                table: "Reservations",
                column: "ClientVMId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ClientVM_ClientVMId",
                table: "Reservations",
                column: "ClientVMId",
                principalTable: "ClientVM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ClientVM_ClientVMId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ClientVMId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ClientVMId",
                table: "Reservations");
        }
    }
}
