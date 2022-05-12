using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPosCR.Data.Migrations
{
    public partial class DroppingFirstAndLastNameCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
