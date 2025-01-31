﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace GrodHotelBackend.Migrations
{
    public partial class ChangedPriceTypeRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Rooms",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Rooms",
                type: "Money",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}