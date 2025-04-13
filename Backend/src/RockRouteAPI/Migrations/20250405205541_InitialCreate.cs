using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    Type = table.Column<int>(type: "integer", nullable: false),
                    YDS = table.Column<string>(type: "text", nullable: false),
                    ParentLocation_Lat = table.Column<double>(type: "double precision", nullable: false),
                    ParentLocation_Long = table.Column<double>(type: "double precision", nullable: false),
                    LocationDescription = table.Column<string>(type: "text", nullable: false),
                    Protection_Notes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.RouteId);
                });

            migrationBuilder.CreateTable(
                name: "CRating",
                columns: table => new
                {
                    ClimbRouteId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRating", x => new { x.ClimbRouteId, x.Id });
                    table.ForeignKey(
                        name: "FK_CRating_Entries_ClimbRouteId",
                        column: x => x.ClimbRouteId,
                        principalTable: "Entries",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CRating");

            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
