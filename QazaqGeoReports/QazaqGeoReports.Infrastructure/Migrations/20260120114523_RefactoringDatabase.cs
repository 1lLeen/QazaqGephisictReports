using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QazaqGeoReports.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactoringDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Workers",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "CreatedByUser",
                table: "Cars",
                newName: "Marka");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Missions",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Cars",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Mileage",
                table: "Cars",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "CurrentLocationId",
                table: "Cars",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReady",
                table: "Cars",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MissionId",
                table: "Cars",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AvailabilityStatus",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmploymentStatus",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MissionId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: true),
                    Longitude = table.Column<double>(type: "double precision", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DriverId = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_AspNetUsers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Missions_LocationId",
                table: "Missions",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CurrentLocationId",
                table: "Cars",
                column: "CurrentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_MissionId",
                table: "Cars",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MissionId",
                table: "AspNetUsers",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_DriverId",
                table: "Location",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Missions_MissionId",
                table: "AspNetUsers",
                column: "MissionId",
                principalTable: "Missions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Location_CurrentLocationId",
                table: "Cars",
                column: "CurrentLocationId",
                principalTable: "Location",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Missions_MissionId",
                table: "Cars",
                column: "MissionId",
                principalTable: "Missions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Location_LocationId",
                table: "Missions",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Missions_MissionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Location_CurrentLocationId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Missions_MissionId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Location_LocationId",
                table: "Missions");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Missions_LocationId",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CurrentLocationId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_MissionId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MissionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "CurrentLocationId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsReady",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "MissionId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "AvailabilityStatus",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmploymentStatus",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MissionId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Marka",
                table: "Cars",
                newName: "CreatedByUser");

            migrationBuilder.AddColumn<string>(
                name: "Workers",
                table: "Missions",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Mileage",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
