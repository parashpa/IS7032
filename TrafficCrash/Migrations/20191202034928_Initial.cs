using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrafficCrash.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrafficCrashVehicle",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrashUnitId = table.Column<long>(nullable: false),
                    RdNo = table.Column<string>(nullable: true),
                    CrashDate = table.Column<DateTimeOffset>(nullable: false),
                    UnitNo = table.Column<long>(nullable: false),
                    UnitType = table.Column<string>(nullable: true),
                    VehicleId = table.Column<long>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    LicPlateState = table.Column<string>(nullable: true),
                    VehicleDefect = table.Column<string>(nullable: true),
                    VehicleType = table.Column<string>(nullable: true),
                    VehicleUse = table.Column<string>(nullable: true),
                    TravelDirection = table.Column<string>(nullable: true),
                    Maneuver = table.Column<string>(nullable: true),
                    OccupantCnt = table.Column<long>(nullable: false),
                    Area12_I = table.Column<string>(nullable: true),
                    FirstContactPoint = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrafficCrashVehicle", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrafficCrashVehicle");
        }
    }
}
