using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QazaqGeoReports.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeysToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reports_CreatedByUserId",
                table: "Reports",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_EquipmentId",
                table: "Images",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ReportId",
                table: "Images",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_UserId",
                table: "Images",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Equipments_EquipmentId",
                table: "Images",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Reports_ReportId",
                table: "Images",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_CreatedByUserId",
                table: "Reports",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_UserId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Equipments_EquipmentId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Reports_ReportId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_CreatedByUserId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_CreatedByUserId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Images_EquipmentId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ReportId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_UserId",
                table: "Images");
        }
    }
}
