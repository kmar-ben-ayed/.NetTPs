using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<decimal>(type: "numeric", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Films d'action et d'aventure", "Action" },
                    { 2, "Films comiques et humoristiques", "Comédie" },
                    { 3, "Films dramatiques et émotionnels", "Drame" },
                    { 4, "Films de science-fiction", "Science-Fiction" },
                    { 5, "Films d'horreur et thriller", "Horreur" },
                    { 6, "Films romantiques", "Romance" },
                    { 7, "Films d'animation", "Animation" },
                    { 8, "Documentaires", "Documentaire" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Duration", "GenreId", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "Deux hommes emprisonnés créent un lien fort au fil des années.", 142, 3, 9.3m, new DateTime(1994, 9, 23, 0, 0, 0, 0, DateTimeKind.Utc), "The Shawshank Redemption" },
                    { 2, "Le patriarche vieillissant d'une dynastie criminelle transfère le contrôle à son fils réticent.", 175, 3, 9.2m, new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Utc), "The Godfather" },
                    { 3, "Batman affronte le Joker dans une bataille pour l'âme de Gotham City.", 152, 1, 9.0m, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Utc), "The Dark Knight" },
                    { 4, "Les vies de deux tueurs à gages, d'un boxeur et d'un gangster s'entremêlent.", 154, 1, 8.9m, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Pulp Fiction" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
