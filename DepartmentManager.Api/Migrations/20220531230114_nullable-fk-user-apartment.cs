using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepartmentManager.Api.Migrations
{
    public partial class nullablefkuserapartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Apartments_ApartmentId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "ApartmentId",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Apartments_ApartmentId",
                table: "Users",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Apartments_ApartmentId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "ApartmentId",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Apartments_ApartmentId",
                table: "Users",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
