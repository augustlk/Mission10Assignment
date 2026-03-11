using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission10Assignment.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "Bowlers",
                columns: table => new
                {
                    BowlerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BowlerLastName = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerFirstName = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerMiddleInit = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerAddress = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerCity = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerState = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerZip = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerPhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    TeamID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bowlers", x => x.BowlerID);
                    table.ForeignKey(
                        name: "FK_Bowlers_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bowlers_TeamID",
                table: "Bowlers",
                column: "TeamID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bowlers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
