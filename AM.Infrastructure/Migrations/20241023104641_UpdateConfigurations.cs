using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Flights_FlightsFlightID",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Passengers_PassengersPassportNumber",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Planes",
                table: "Planes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.RenameTable(
                name: "Planes",
                newName: "MyPlanes");

            migrationBuilder.RenameTable(
                name: "FlightPassenger",
                newName: "FlightPassengers");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "MyPlanes",
                newName: "PlaneCapacity");

            migrationBuilder.RenameIndex(
                name: "IX_FlightPassenger_PassengersPassportNumber",
                table: "FlightPassengers",
                newName: "IX_FlightPassengers_PassengersPassportNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyPlanes",
                table: "MyPlanes",
                column: "PlaneID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassengers",
                table: "FlightPassengers",
                columns: new[] { "FlightsFlightID", "PassengersPassportNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassengers_Flights_FlightsFlightID",
                table: "FlightPassengers",
                column: "FlightsFlightID",
                principalTable: "Flights",
                principalColumn: "FlightID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassengers_Passengers_PassengersPassportNumber",
                table: "FlightPassengers",
                column: "PassengersPassportNumber",
                principalTable: "Passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_MyPlanes_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "MyPlanes",
                principalColumn: "PlaneID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassengers_Flights_FlightsFlightID",
                table: "FlightPassengers");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassengers_Passengers_PassengersPassportNumber",
                table: "FlightPassengers");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_MyPlanes_PlaneId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyPlanes",
                table: "MyPlanes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassengers",
                table: "FlightPassengers");

            migrationBuilder.RenameTable(
                name: "MyPlanes",
                newName: "Planes");

            migrationBuilder.RenameTable(
                name: "FlightPassengers",
                newName: "FlightPassenger");

            migrationBuilder.RenameColumn(
                name: "PlaneCapacity",
                table: "Planes",
                newName: "Capacity");

            migrationBuilder.RenameIndex(
                name: "IX_FlightPassengers_PassengersPassportNumber",
                table: "FlightPassenger",
                newName: "IX_FlightPassenger_PassengersPassportNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planes",
                table: "Planes",
                column: "PlaneID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "FlightsFlightID", "PassengersPassportNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Flights_FlightsFlightID",
                table: "FlightPassenger",
                column: "FlightsFlightID",
                principalTable: "Flights",
                principalColumn: "FlightID",
                onDelete: ReferentialAction.Cascade);

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
    }
}
