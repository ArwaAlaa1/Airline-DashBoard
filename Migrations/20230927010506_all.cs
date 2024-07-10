using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirLine.Migrations
{
    public partial class all : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirLine_Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Contact_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVisable = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirLine_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVisable = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirCrafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Major_Poilot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assistant_Pilot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Host1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Host2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirlineId = table.Column<int>(type: "int", nullable: false),
                    IsVisable = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirCrafts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirCrafts_AirLine_Companies_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "AirLine_Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Amount_Money = table.Column<decimal>(type: "money", nullable: false),
                    AirlineId = table.Column<int>(type: "int", nullable: false),
                    IsVisable = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_AirLine_Companies_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "AirLine_Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Road_Crafts",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    AirCraftId = table.Column<int>(type: "int", nullable: false),
                    DepatureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    NumPassenger = table.Column<int>(type: "int", nullable: false),
                    RoadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Road_Crafts", x => new { x.AirCraftId, x.RouteId });
                    table.ForeignKey(
                        name: "FK_Road_Crafts_AirCrafts_AirCraftId",
                        column: x => x.AirCraftId,
                        principalTable: "AirCrafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Road_Crafts_Roads_RoadId",
                        column: x => x.RoadId,
                        principalTable: "Roads",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirCrafts_AirlineId",
                table: "AirCrafts",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_Road_Crafts_RoadId",
                table: "Road_Crafts",
                column: "RoadId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AirlineId",
                table: "Transactions",
                column: "AirlineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Road_Crafts");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AirCrafts");

            migrationBuilder.DropTable(
                name: "Roads");

            migrationBuilder.DropTable(
                name: "AirLine_Companies");
        }
    }
}
