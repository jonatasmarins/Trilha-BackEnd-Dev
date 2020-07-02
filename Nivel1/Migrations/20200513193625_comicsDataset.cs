using Microsoft.EntityFrameworkCore.Migrations;

namespace Nivel1.Migrations
{
    public partial class comicsDataset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UrlWiki = table.Column<string>(nullable: true),
                    UrlImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CharacterID", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Ean = table.Column<string>(nullable: true),
                    PageCount = table.Column<int>(nullable: false),
                    UrlWiki = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_ComicID", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Creator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CreatorID", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComicCharacters",
                columns: table => new
                {
                    ComicID = table.Column<int>(nullable: false),
                    CharacterID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicCharacters", x => new { x.CharacterID, x.ComicID });
                    table.ForeignKey(
                        name: "FK_ComicCharacters_Character_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComicCharacters_Comic_ComicID",
                        column: x => x.ComicID,
                        principalTable: "Comic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComicCreators",
                columns: table => new
                {
                    ComicID = table.Column<int>(nullable: false),
                    CreatorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicCreators", x => new { x.CreatorID, x.ComicID });
                    table.ForeignKey(
                        name: "FK_ComicCreators_Comic_ComicID",
                        column: x => x.ComicID,
                        principalTable: "Comic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComicCreators_Creator_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "Creator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_Code",
                table: "Character",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Code_Comic",
                table: "Comic",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComicCharacters_ComicID",
                table: "ComicCharacters",
                column: "ComicID");

            migrationBuilder.CreateIndex(
                name: "IX_ComicCreators_ComicID",
                table: "ComicCreators",
                column: "ComicID");

            migrationBuilder.CreateIndex(
                name: "IX_Creator_Code",
                table: "Creator",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComicCharacters");

            migrationBuilder.DropTable(
                name: "ComicCreators");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Comic");

            migrationBuilder.DropTable(
                name: "Creator");
        }
    }
}
