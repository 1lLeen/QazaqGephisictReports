using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QazaqGeoReports.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMissionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Missions_MissionId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Missions_MissionId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Missions_MissionId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_MissionId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_MissionId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Cars_MissionId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "MissionId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "MissionId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "MissionId",
                table: "Cars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MissionId",
                table: "Reports",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MissionId",
                table: "Equipments",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MissionId",
                table: "Cars",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_MissionId",
                table: "Reports",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_MissionId",
                table: "Equipments",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_MissionId",
                table: "Cars",
                column: "MissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Missions_MissionId",
                table: "Cars",
                column: "MissionId",
                principalTable: "Missions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Missions_MissionId",
                table: "Equipments",
                column: "MissionId",
                principalTable: "Missions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Missions_MissionId",
                table: "Reports",
                column: "MissionId",
                principalTable: "Missions",
                principalColumn: "Id");
        }
    }
}
