using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QazaqGeoReports.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteGeneralTableImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "Image");

            migrationBuilder.RenameIndex(
                name: "IX_Images_UserId",
                table: "Image",
                newName: "IX_Image_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ReportId",
                table: "Image",
                newName: "IX_Image_ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_EquipmentId",
                table: "Image",
                newName: "IX_Image_EquipmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_UserId",
                table: "Image",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Equipments_EquipmentId",
                table: "Image",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Reports_ReportId",
                table: "Image",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_UserId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Equipments_EquipmentId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Reports_ReportId",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.RenameTable(
                name: "Image",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_Image_UserId",
                table: "Images",
                newName: "IX_Images_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Image_ReportId",
                table: "Images",
                newName: "IX_Images_ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_Image_EquipmentId",
                table: "Images",
                newName: "IX_Images_EquipmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

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
        }
    }
}
