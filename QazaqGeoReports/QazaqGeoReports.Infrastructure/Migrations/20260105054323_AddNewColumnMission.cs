using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QazaqGeoReports.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnMission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Workers",
                table: "Missions");

            migrationBuilder.AddColumn<string>(
                name: "WorkersIds",
                table: "Missions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkersIds",
                table: "Missions");

            migrationBuilder.AddColumn<List<string>>(
                name: "Workers",
                table: "Missions",
                type: "text[]",
                nullable: true);
        }
    }
}
