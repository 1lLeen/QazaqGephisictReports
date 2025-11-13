using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QazaqGeoReports.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Equipments",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Equipments");
        }
    }
}
