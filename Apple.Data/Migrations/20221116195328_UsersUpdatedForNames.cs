using Microsoft.EntityFrameworkCore.Migrations;

namespace Apple.Data.Migrations
{
    public partial class UsersUpdatedForNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "tbl_Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "tbl_Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "tbl_Users");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "tbl_Users");
        }
    }
}
