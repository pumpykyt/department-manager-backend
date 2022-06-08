using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepartmentManager.Api.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Houses_HouseId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Rules_Houses_HouseId",
                table: "Rules");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Rules_HouseId",
                table: "Rules");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_HouseId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "Apartments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HouseId",
                table: "Rules",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HouseId",
                table: "Apartments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rules_HouseId",
                table: "Rules",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_HouseId",
                table: "Apartments",
                column: "HouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Houses_HouseId",
                table: "Apartments",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rules_Houses_HouseId",
                table: "Rules",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
