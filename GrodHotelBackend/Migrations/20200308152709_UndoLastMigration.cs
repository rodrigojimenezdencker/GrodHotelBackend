using Microsoft.EntityFrameworkCore.Migrations;

namespace GrodHotelBackend.Migrations
{
    public partial class UndoLastMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comodities_RoomComodities_RoomComoditiesId",
                table: "Comodities");

            migrationBuilder.DropIndex(
                name: "IX_RoomComodities_RoomsId",
                table: "RoomComodities");

            migrationBuilder.DropIndex(
                name: "IX_Comodities_RoomComoditiesId",
                table: "Comodities");

            migrationBuilder.DropColumn(
                name: "RoomComoditiesId",
                table: "Comodities");

            migrationBuilder.AddColumn<int>(
                name: "ComoditiesId",
                table: "RoomComodities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoomComodities_ComoditiesId",
                table: "RoomComodities",
                column: "ComoditiesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomComodities_RoomsId",
                table: "RoomComodities",
                column: "RoomsId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomComodities_Comodities_ComoditiesId",
                table: "RoomComodities",
                column: "ComoditiesId",
                principalTable: "Comodities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomComodities_Comodities_ComoditiesId",
                table: "RoomComodities");

            migrationBuilder.DropIndex(
                name: "IX_RoomComodities_ComoditiesId",
                table: "RoomComodities");

            migrationBuilder.DropIndex(
                name: "IX_RoomComodities_RoomsId",
                table: "RoomComodities");

            migrationBuilder.DropColumn(
                name: "ComoditiesId",
                table: "RoomComodities");

            migrationBuilder.AddColumn<int>(
                name: "RoomComoditiesId",
                table: "Comodities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomComodities_RoomsId",
                table: "RoomComodities",
                column: "RoomsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comodities_RoomComoditiesId",
                table: "Comodities",
                column: "RoomComoditiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comodities_RoomComodities_RoomComoditiesId",
                table: "Comodities",
                column: "RoomComoditiesId",
                principalTable: "RoomComodities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}