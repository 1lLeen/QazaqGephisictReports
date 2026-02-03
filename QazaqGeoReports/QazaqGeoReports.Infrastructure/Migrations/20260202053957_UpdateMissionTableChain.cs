using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QazaqGeoReports.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMissionTableChain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_AspNetUsers_SupervisorId",
                table: "Missions");

            migrationBuilder.RenameColumn(
                name: "Workers",
                table: "Missions",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CreatedByUser",
                table: "Missions",
                newName: "CreatedByUserId");

            migrationBuilder.CreateTable(
                name: "MissionUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MissionId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MissionUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MissionUser_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Missions_CreatedByUserId",
                table: "Missions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_UserId",
                table: "Missions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionUser_MissionId",
                table: "MissionUser",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionUser_UserId",
                table: "MissionUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_AspNetUsers_CreatedByUserId",
                table: "Missions",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_AspNetUsers_SupervisorId",
                table: "Missions",
                column: "SupervisorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_AspNetUsers_UserId",
                table: "Missions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_AspNetUsers_CreatedByUserId",
                table: "Missions");

            migrationBuilder.DropForeignKey(
                name: "FK_Missions_AspNetUsers_SupervisorId",
                table: "Missions");

            migrationBuilder.DropForeignKey(
                name: "FK_Missions_AspNetUsers_UserId",
                table: "Missions");

            migrationBuilder.DropTable(
                name: "MissionUser");

            migrationBuilder.DropIndex(
                name: "IX_Missions_CreatedByUserId",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Missions_UserId",
                table: "Missions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Missions",
                newName: "Workers");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "Missions",
                newName: "CreatedByUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_AspNetUsers_SupervisorId",
                table: "Missions",
                column: "SupervisorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
