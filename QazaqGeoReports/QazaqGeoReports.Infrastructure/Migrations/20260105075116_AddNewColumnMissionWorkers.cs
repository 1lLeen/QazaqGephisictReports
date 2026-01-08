using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QazaqGeoReports.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnMissionWorkers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkersIds",
                table: "Missions",
                newName: "Workers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Workers",
                table: "Missions",
                newName: "WorkersIds");
        }
    }
}
