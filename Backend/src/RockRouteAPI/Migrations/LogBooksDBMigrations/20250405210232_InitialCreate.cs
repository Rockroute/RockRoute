using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RockRouteAPI.Migrations.LogBooksDBMigrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogBook",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RouteId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogBook", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    LogBookUserId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => new { x.LogBookUserId, x.Id });
                    table.ForeignKey(
                        name: "FK_Activity_LogBook_LogBookUserId",
                        column: x => x.LogBookUserId,
                        principalTable: "LogBook",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CRoute",
                columns: table => new
                {
                    LogBookUserId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RouteID = table.Column<string>(type: "text", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PartnerID = table.Column<List<string>>(type: "text[]", nullable: true),
                    Attempts = table.Column<int>(type: "integer", nullable: true),
                    IsOnSite = table.Column<bool>(type: "boolean", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRoute", x => new { x.LogBookUserId, x.Id });
                    table.ForeignKey(
                        name: "FK_CRoute_LogBook_LogBookUserId",
                        column: x => x.LogBookUserId,
                        principalTable: "LogBook",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    LogBookUserId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatorID = table.Column<string>(type: "text", nullable: false),
                    CollabID = table.Column<List<string>>(type: "text[]", nullable: true),
                    ListOfRoute_ID = table.Column<List<string>>(type: "text[]", nullable: true),
                    PlaylistPicture = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => new { x.LogBookUserId, x.Id });
                    table.ForeignKey(
                        name: "FK_Playlist_LogBook_LogBookUserId",
                        column: x => x.LogBookUserId,
                        principalTable: "LogBook",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "CRoute");

            migrationBuilder.DropTable(
                name: "Playlist");

            migrationBuilder.DropTable(
                name: "LogBook");
        }
    }
}
