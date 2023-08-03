using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class _08031 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CustomerInfo",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNum",
                table: "CustomerInfo",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "CustomerInfo");

            migrationBuilder.DropColumn(
                name: "PhoneNum",
                table: "CustomerInfo");
        }
    }
}
