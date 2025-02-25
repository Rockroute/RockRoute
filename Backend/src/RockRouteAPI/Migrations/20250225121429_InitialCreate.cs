using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RockRouteAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    RouteId = table.Column<string>(type: "text", nullable: false),
                    RouteName = table.Column<string>(type: "text", nullable: false),
                    SectorId = table.Column<string>(type: "text", nullable: false),
                    ParentSector = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    YDS = table.Column<string>(type: "text", nullable: false),
                    ParentLocation = table.Column<ValueTuple<float, float>>(type: "record", nullable: false),
                    LocationDesciption = table.Column<string>(type: "text", nullable: false),
                    ProtectionNotes = table.Column<string>(type: "text", nullable: false),
                    UserRatings = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.RouteId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
