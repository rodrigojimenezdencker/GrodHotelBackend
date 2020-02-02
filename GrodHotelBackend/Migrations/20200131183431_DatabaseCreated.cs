using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrodHotelBackend.Migrations
{
    public partial class DatabaseCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Dni = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Subscribed = table.Column<bool>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comodities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comodities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelsChain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Availability = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelsChain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountriesId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelChainsId = table.Column<int>(nullable: false),
                    HotelsChainId = table.Column<int>(nullable: true),
                    CitiesId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Trending = table.Column<bool>(nullable: false),
                    Availability = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Cities_CitiesId",
                        column: x => x.CitiesId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hotels_HotelsChain_HotelsChainId",
                        column: x => x.HotelsChainId,
                        principalTable: "HotelsChain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelsId = table.Column<int>(nullable: false),
                    ServicesId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Availability = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelServices_Hotels_HotelsId",
                        column: x => x.HotelsId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelServices_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelsId = table.Column<int>(nullable: false),
                    Dimensions = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Availability = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelsId",
                        column: x => x.HotelsId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientsId = table.Column<int>(nullable: false),
                    RoomsId = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    LeavingDate = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    AdultNumbers = table.Column<int>(nullable: false),
                    MinorNumbers = table.Column<int>(nullable: false),
                    ConfirmationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Clients_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomComodities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomsId = table.Column<int>(nullable: false),
                    ComoditiesId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Availability = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomComodities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomComodities_Comodities_ComoditiesId",
                        column: x => x.ComoditiesId,
                        principalTable: "Comodities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomComodities_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingsAgr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingsId = table.Column<int>(nullable: false),
                    BookingAgrTypeId = table.Column<int>(nullable: false),
                    ComoditieServicesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingsAgr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingsAgr_Bookings_BookingsId",
                        column: x => x.BookingsId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ClientsId",
                table: "Bookings",
                column: "ClientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomsId",
                table: "Bookings",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingsAgr_BookingsId",
                table: "BookingsAgr",
                column: "BookingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountriesId",
                table: "Cities",
                column: "CountriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CitiesId",
                table: "Hotels",
                column: "CitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_HotelsChainId",
                table: "Hotels",
                column: "HotelsChainId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelServices_HotelsId",
                table: "HotelServices",
                column: "HotelsId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelServices_ServicesId",
                table: "HotelServices",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomComodities_ComoditiesId",
                table: "RoomComodities",
                column: "ComoditiesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomComodities_RoomsId",
                table: "RoomComodities",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelsId",
                table: "Rooms",
                column: "HotelsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingsAgr");

            migrationBuilder.DropTable(
                name: "HotelServices");

            migrationBuilder.DropTable(
                name: "RoomComodities");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Comodities");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "HotelsChain");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
