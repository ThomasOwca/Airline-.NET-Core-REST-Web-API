using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline_Web_API.Migrations
{
    public partial class instantiateAzureTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fleets_Aircraft_AircraftId",
                table: "Fleets");

            migrationBuilder.DropForeignKey(
                name: "FK_Fleets_AircraftStatuses_StatusId",
                table: "Fleets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fleets",
                table: "Fleets");

            migrationBuilder.RenameTable(
                name: "Fleets",
                newName: "Fleet");

            migrationBuilder.RenameIndex(
                name: "IX_Fleets_StatusId",
                table: "Fleet",
                newName: "IX_Fleet_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Fleets_AircraftId",
                table: "Fleet",
                newName: "IX_Fleet_AircraftId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fleet",
                table: "Fleet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fleet_Aircraft_AircraftId",
                table: "Fleet",
                column: "AircraftId",
                principalTable: "Aircraft",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fleet_AircraftStatuses_StatusId",
                table: "Fleet",
                column: "StatusId",
                principalTable: "AircraftStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fleet_Aircraft_AircraftId",
                table: "Fleet");

            migrationBuilder.DropForeignKey(
                name: "FK_Fleet_AircraftStatuses_StatusId",
                table: "Fleet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fleet",
                table: "Fleet");

            migrationBuilder.RenameTable(
                name: "Fleet",
                newName: "Fleets");

            migrationBuilder.RenameIndex(
                name: "IX_Fleet_StatusId",
                table: "Fleets",
                newName: "IX_Fleets_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Fleet_AircraftId",
                table: "Fleets",
                newName: "IX_Fleets_AircraftId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fleets",
                table: "Fleets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fleets_Aircraft_AircraftId",
                table: "Fleets",
                column: "AircraftId",
                principalTable: "Aircraft",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fleets_AircraftStatuses_StatusId",
                table: "Fleets",
                column: "StatusId",
                principalTable: "AircraftStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
