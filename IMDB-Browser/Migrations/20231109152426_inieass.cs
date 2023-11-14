using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMDB_Browser.Migrations
{
    /// <inheritdoc />
    public partial class inieass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrimaryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthYear = table.Column<int>(type: "int", nullable: true),
                    DeathYear = table.Column<int>(type: "int", nullable: true),
                    PrimaryProfession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KnownForTitles = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TitleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdult = table.Column<int>(type: "int", nullable: true),
                    StartYear = table.Column<int>(type: "int", nullable: true),
                    EndYear = table.Column<int>(type: "int", nullable: true),
                    RunTimeMinutes = table.Column<int>(type: "int", nullable: true),
                    Genres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ActorMovie",
                columns: table => new
                {
                    ActorsNconst = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MoviesTconst = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovie", x => new { x.ActorsNconst, x.MoviesTconst });
                    table.ForeignKey(
                        name: "FK_ActorMovie_Actors_ActorsNconst",
                        column: x => x.ActorsNconst,
                        principalTable: "Actors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovie_Movies_MoviesTconst",
                        column: x => x.MoviesTconst,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AverageRating = table.Column<double>(type: "float", nullable: false),
                    NumVotes = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ratings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_MoviesTconst",
                table: "ActorMovie",
                column: "MoviesTconst");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MovieId",
                table: "Ratings",
                column: "MovieId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovie");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
