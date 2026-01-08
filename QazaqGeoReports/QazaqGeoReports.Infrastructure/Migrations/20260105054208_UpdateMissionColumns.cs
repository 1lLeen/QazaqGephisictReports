using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QazaqGeoReports.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMissionColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Missions_MissionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MissionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MissionId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<List<string>>(
                name: "Workers",
                table: "Missions",
                type: "text[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Workers",
                table: "Missions");

            migrationBuilder.AddColumn<int>(
                name: "MissionId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MissionId",
                table: "AspNetUsers",
                column: "MissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Missions_MissionId",
                table: "AspNetUsers",
                column: "MissionId",
                principalTable: "Missions",
                principalColumn: "Id");
        }
    }
}
