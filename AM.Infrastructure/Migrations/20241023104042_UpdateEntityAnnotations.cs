using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityAnnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Passengers_PassengersPassengerID",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_PlaneID",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.DropIndex(
                name: "IX_FlightPassenger_PassengersPassengerID",
                table: "FlightPassenger");

            migrationBuilder.DropColumn(
                name: "PassengerID",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "AirlineLogo",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "PassengersPassengerID",
                table: "FlightPassenger");

            migrationBuilder.RenameColumn(
                name: "PlaneID",
                table: "Flights",
                newName: "PlaneId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_PlaneID",
                table: "Flights",
                newName: "IX_Flights_PlaneId");

            migrationBuilder.AlterColumn<string>(
                name: "TelNumber",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Passengers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                table: "Passengers",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassengersPassportNumber",
                table: "FlightPassenger",
                type: "nvarchar(7)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "PassportNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "FlightsFlightID", "PassengersPassportNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPassenger_PassengersPassportNumber",
                table: "FlightPassenger",
                column: "PassengersPassportNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Passengers_PassengersPassportNumber",
                table: "FlightPassenger",
                column: "PassengersPassportNumber",
                principalTable: "Passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "PlaneID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Passengers_PassengersPassportNumber",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.DropIndex(
                name: "IX_FlightPassenger_PassengersPassportNumber",
                table: "FlightPassenger");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "PassengersPassportNumber",
                table: "FlightPassenger");

            migrationBuilder.RenameColumn(
                name: "PlaneId",
                table: "Flights",
                newName: "PlaneID");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_PlaneId",
                table: "Flights",
                newName: "IX_Flights_PlaneID");

            migrationBuilder.AlterColumn<int>(
                name: "TelNumber",
                table: "Passengers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<int>(
                name: "PassengerID",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "AirlineLogo",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PassengersPassengerID",
                table: "FlightPassenger",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "PassengerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "FlightsFlightID", "PassengersPassengerID" });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPassenger_PassengersPassengerID",
                table: "FlightPassenger",
                column: "PassengersPassengerID");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Passengers_PassengersPassengerID",
                table: "FlightPassenger",
                column: "PassengersPassengerID",
                principalTable: "Passengers",
                principalColumn: "PassengerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_PlaneID",
                table: "Flights",
                column: "PlaneID",
                principalTable: "Planes",
                principalColumn: "PlaneID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
