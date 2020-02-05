using Microsoft.EntityFrameworkCore.Migrations;

namespace GrodHotelBackend.Migrations
{
    public partial class dimensiontypeupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Dimensions",
                table: "Rooms",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Dimensions",
                table: "Rooms",
                type: "Money",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
