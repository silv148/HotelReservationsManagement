using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationsManagement.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdultsCount",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "EditVM_2");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "EditVM_2",
                newName: "RoomNumber");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "EditVM_2",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ClientFirstName",
                table: "EditVM_2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientLastName",
                table: "EditVM_2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientPhone",
                table: "EditVM_2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberChildren",
                table: "EditVM_2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EditVM_2_ClientId",
                table: "EditVM_2",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_EditVM_2_Clients_ClientId",
                table: "EditVM_2",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EditVM_2_Clients_ClientId",
                table: "EditVM_2");

            migrationBuilder.DropIndex(
                name: "IX_EditVM_2_ClientId",
                table: "EditVM_2");

            migrationBuilder.DropColumn(
                name: "ClientFirstName",
                table: "EditVM_2");

            migrationBuilder.DropColumn(
                name: "ClientLastName",
                table: "EditVM_2");

            migrationBuilder.DropColumn(
                name: "ClientPhone",
                table: "EditVM_2");

            migrationBuilder.DropColumn(
                name: "NumberChildren",
                table: "EditVM_2");

            migrationBuilder.RenameColumn(
                name: "RoomNumber",
                table: "EditVM_2",
                newName: "RoomId");

            migrationBuilder.AddColumn<int>(
                name: "AdultsCount",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "EditVM_2",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalPrice",
                table: "EditVM_2",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
