using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QazaqGeoReports.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "ImageEquipments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "ImageCars",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ImageEquipments_ReportId",
                table: "ImageEquipments",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageCars_ReportId",
                table: "ImageCars",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageCars_Reports_ReportId",
                table: "ImageCars",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageEquipments_Reports_ReportId",
                table: "ImageEquipments",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageCars_Reports_ReportId",
                table: "ImageCars");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageEquipments_Reports_ReportId",
                table: "ImageEquipments");

            migrationBuilder.DropIndex(
                name: "IX_ImageEquipments_ReportId",
                table: "ImageEquipments");

            migrationBuilder.DropIndex(
                name: "IX_ImageCars_ReportId",
                table: "ImageCars");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "ImageEquipments");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "ImageCars");
        }
    }
}
