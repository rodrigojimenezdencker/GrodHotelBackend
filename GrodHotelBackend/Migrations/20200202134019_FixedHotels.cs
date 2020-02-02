using Microsoft.EntityFrameworkCore.Migrations;

namespace GrodHotelBackend.Migrations
{
    public partial class FixedHotels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_HotelsChain_HotelsChainId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HotelChainsId",
                table: "Hotels");

            migrationBuilder.AlterColumn<int>(
                name: "HotelsChainId",
                table: "Hotels",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_HotelsChain_HotelsChainId",
                table: "Hotels",
                column: "HotelsChainId",
                principalTable: "HotelsChain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_HotelsChain_HotelsChainId",
                table: "Hotels");

            migrationBuilder.AlterColumn<int>(
                name: "HotelsChainId",
                table: "Hotels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "HotelChainsId",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_HotelsChain_HotelsChainId",
                table: "Hotels",
                column: "HotelsChainId",
                principalTable: "HotelsChain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
