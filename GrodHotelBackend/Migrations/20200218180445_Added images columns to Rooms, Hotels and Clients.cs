using Microsoft.EntityFrameworkCore.Migrations;

namespace GrodHotelBackend.Migrations
{
    public partial class AddedimagescolumnstoRoomsHotelsandClients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmallImage",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmallImage",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Clients",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Dni",
                table: "Clients",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "SmallImage",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "SmallImage",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Clients",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Dni",
                table: "Clients",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 9);
        }
    }
}