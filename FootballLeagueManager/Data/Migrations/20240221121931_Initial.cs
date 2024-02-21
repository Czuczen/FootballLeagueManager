using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FootballLeagueManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeTeamGoals = table.Column<int>(type: "int", nullable: false),
                    AwayTeamGoals = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Queue = table.Column<int>(type: "int", nullable: false),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamSeasonsStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchesPlayed = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Draws = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSeasonsStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamSeasonsStats_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSeasonsStats_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "https://assets.skor.id/crop/0x0:0x0/x/photo/2020/04/02/574196038.jpg", "Jupiler League" },
                    { 2, "https://statics-maker.llt-services.com/prl/images/2023/09/28/xlarge/deac0d81-f6a8-41ed-bdd8-794da335dd68.png", "Challenger Pro League" },
                    { 3, "https://static.vecteezy.com/system/resources/previews/010/994/451/non_2x/premier-league-logo-symbol-with-name-design-england-football-european-countries-football-teams-illustration-with-purple-background-free-vector.jpg", "Premier League" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "Belgia", "Genk" },
                    { 2, "Belgia", "Royale Union SG" },
                    { 3, "Belgia", "Antwerp" },
                    { 4, "Belgia", "Club Brugge" },
                    { 5, "Belgia", "Gent" },
                    { 6, "Belgia", "St. Liege" },
                    { 7, "Belgia", "Westerlo" },
                    { 8, "Belgia", "Cercle Brugge" },
                    { 9, "Belgia", "Charleroi" },
                    { 10, "Belgia", "Leuven" },
                    { 11, "Belgia", "Anderlecht" },
                    { 12, "Belgia", "St. Truiden" },
                    { 13, "Belgia", "KV Mechelen" },
                    { 14, "Belgia", "Kortrijk" },
                    { 15, "Belgia", "Eupen" },
                    { 16, "Belgia", "Oostende" },
                    { 17, "Belgia", "Waregem" },
                    { 18, "Belgia", "Seraing" },
                    { 19, "Belgia", "RWDM" },
                    { 20, "Belgia", "Beveren" },
                    { 21, "Anglia", "Manchester City" },
                    { 22, "Anglia", "Liverpool" },
                    { 23, "Anglia", "Chelsea" },
                    { 24, "Anglia", "Tottenham" },
                    { 25, "Anglia", "Arsenal" },
                    { 26, "Anglia", "Manchester Utd" },
                    { 27, "Anglia", "West Ham" }
                });

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "Id", "EndDate", "LeagueId", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "2022/2023", new DateTime(2022, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "2022/2023", new DateTime(2022, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "2021/2022", new DateTime(2021, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "2022/2023", new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "AwayTeamGoals", "AwayTeamId", "Date", "HomeTeamGoals", "HomeTeamId", "Queue", "SeasonId" },
                values: new object[,]
                {
                    { 1, 2, 1, new DateTime(2023, 4, 23, 18, 30, 0, 0, DateTimeKind.Unspecified), 2, 9, 1, 1 },
                    { 2, 2, 11, new DateTime(2023, 4, 16, 13, 30, 0, 0, DateTimeKind.Unspecified), 5, 1, 1, 1 },
                    { 3, 0, 1, new DateTime(2023, 4, 9, 18, 30, 0, 0, DateTimeKind.Unspecified), 2, 6, 2, 1 },
                    { 4, 1, 10, new DateTime(2023, 4, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), 2, 1, 2, 1 },
                    { 5, 1, 1, new DateTime(2023, 3, 17, 20, 45, 0, 0, DateTimeKind.Unspecified), 1, 8, 2, 1 },
                    { 6, 4, 2, new DateTime(2023, 4, 23, 18, 30, 0, 0, DateTimeKind.Unspecified), 2, 14, 1, 1 },
                    { 7, 1, 18, new DateTime(2023, 4, 16, 19, 15, 0, 0, DateTimeKind.Unspecified), 2, 2, 1, 1 },
                    { 8, 1, 2, new DateTime(2023, 4, 8, 20, 45, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 1 },
                    { 9, 1, 12, new DateTime(2023, 4, 2, 19, 15, 0, 0, DateTimeKind.Unspecified), 2, 2, 2, 1 },
                    { 10, 1, 13, new DateTime(2023, 3, 19, 18, 30, 0, 0, DateTimeKind.Unspecified), 2, 2, 2, 1 },
                    { 11, 1, 3, new DateTime(2023, 4, 23, 13, 30, 0, 0, DateTimeKind.Unspecified), 0, 12, 1, 1 },
                    { 12, 0, 14, new DateTime(2023, 4, 16, 18, 30, 0, 0, DateTimeKind.Unspecified), 1, 3, 1, 1 },
                    { 13, 1, 8, new DateTime(2023, 4, 9, 16, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 1, 1 },
                    { 14, 2, 3, new DateTime(2023, 3, 31, 20, 45, 0, 0, DateTimeKind.Unspecified), 0, 17, 2, 1 },
                    { 15, 1, 9, new DateTime(2023, 3, 19, 13, 30, 0, 0, DateTimeKind.Unspecified), 0, 3, 1, 1 },
                    { 16, 0, 15, new DateTime(2023, 4, 23, 18, 30, 0, 0, DateTimeKind.Unspecified), 7, 4, 1, 1 },
                    { 17, 0, 20, new DateTime(2023, 2, 12, 19, 15, 0, 0, DateTimeKind.Unspecified), 1, 19, 1, 2 },
                    { 18, 0, 22, new DateTime(2022, 5, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, 21, 1, 3 },
                    { 19, 2, 21, new DateTime(2022, 5, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, 23, 1, 3 },
                    { 20, 0, 23, new DateTime(2022, 4, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, 22, 1, 3 },
                    { 21, 2, 22, new DateTime(2022, 5, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, 24, 1, 3 },
                    { 22, 0, 24, new DateTime(2022, 5, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 3, 23, 1, 3 },
                    { 23, 2, 23, new DateTime(2022, 5, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, 25, 1, 3 },
                    { 24, 0, 26, new DateTime(2022, 5, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 2, 25, 2, 3 },
                    { 25, 0, 25, new DateTime(2022, 5, 11, 17, 0, 0, 0, DateTimeKind.Unspecified), 3, 24, 1, 3 },
                    { 26, 1, 22, new DateTime(2023, 5, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 2, 21, 1, 4 },
                    { 27, 3, 21, new DateTime(2023, 5, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, 23, 1, 4 },
                    { 28, 0, 23, new DateTime(2023, 4, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, 22, 1, 4 },
                    { 29, 3, 22, new DateTime(2023, 5, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), 1, 24, 1, 4 },
                    { 30, 1, 24, new DateTime(2023, 6, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 3, 23, 1, 4 },
                    { 31, 2, 23, new DateTime(2023, 5, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), 5, 25, 2, 4 },
                    { 32, 0, 26, new DateTime(2023, 5, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 2, 25, 1, 4 },
                    { 33, 0, 25, new DateTime(2023, 5, 11, 17, 0, 0, 0, DateTimeKind.Unspecified), 2, 24, 1, 4 },
                    { 34, 3, 26, new DateTime(2023, 11, 11, 18, 15, 0, 0, DateTimeKind.Unspecified), 1, 27, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "TeamSeasonsStats",
                columns: new[] { "Id", "Draws", "Losses", "MatchesPlayed", "Points", "SeasonId", "TeamId", "Wins" },
                values: new object[,]
                {
                    { 1, 6, 5, 34, 75, 1, 1, 23 },
                    { 2, 6, 5, 34, 75, 1, 2, 23 },
                    { 3, 6, 6, 34, 72, 1, 3, 22 },
                    { 4, 11, 7, 34, 59, 1, 4, 16 },
                    { 5, 8, 10, 34, 56, 1, 5, 16 },
                    { 6, 7, 11, 34, 55, 1, 6, 16 },
                    { 7, 9, 11, 34, 51, 1, 7, 14 },
                    { 8, 11, 10, 34, 50, 1, 8, 13 },
                    { 9, 6, 14, 34, 48, 1, 9, 14 },
                    { 10, 9, 12, 34, 48, 1, 10, 13 },
                    { 11, 9, 12, 34, 46, 1, 11, 13 },
                    { 12, 9, 14, 34, 42, 1, 12, 11 },
                    { 13, 7, 16, 34, 40, 1, 13, 11 },
                    { 14, 7, 19, 34, 31, 1, 14, 8 },
                    { 15, 7, 20, 34, 28, 1, 15, 7 },
                    { 16, 6, 21, 34, 27, 1, 16, 7 },
                    { 17, 9, 19, 34, 27, 1, 17, 6 },
                    { 18, 5, 24, 34, 20, 1, 18, 5 },
                    { 19, 4, 4, 22, 46, 2, 19, 14 },
                    { 20, 7, 3, 22, 43, 2, 20, 12 },
                    { 21, 6, 3, 38, 93, 3, 21, 29 },
                    { 22, 8, 2, 38, 92, 3, 22, 28 },
                    { 23, 11, 6, 38, 74, 3, 23, 21 },
                    { 24, 5, 11, 38, 71, 3, 24, 22 },
                    { 25, 3, 13, 38, 69, 3, 25, 22 },
                    { 26, 10, 12, 38, 58, 3, 26, 16 },
                    { 27, 5, 5, 38, 89, 4, 21, 28 },
                    { 28, 10, 9, 38, 67, 4, 22, 19 },
                    { 29, 11, 16, 38, 44, 4, 23, 11 },
                    { 30, 6, 14, 38, 60, 4, 24, 18 },
                    { 31, 6, 6, 38, 84, 4, 25, 26 },
                    { 32, 6, 9, 38, 75, 4, 26, 23 },
                    { 33, 7, 20, 38, 40, 4, 27, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteTeams_TeamId",
                table: "FavoriteTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamId",
                table: "Matches",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamId",
                table: "Matches",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SeasonId",
                table: "Matches",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_LeagueId",
                table: "Seasons",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSeasonsStats_SeasonId",
                table: "TeamSeasonsStats",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSeasonsStats_TeamId",
                table: "TeamSeasonsStats",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteTeams");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "TeamSeasonsStats");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Leagues");
        }
    }
}
