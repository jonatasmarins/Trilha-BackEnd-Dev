using Microsoft.EntityFrameworkCore.Migrations;

namespace Nivel1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 300, nullable: true, defaultValue: ""),
                    YearOld = table.Column<int>(maxLength: 3, nullable: true),
                    Document = table.Column<string>(maxLength: 11, nullable: true, defaultValue: ""),
                    Email = table.Column<string>(maxLength: 300, nullable: true, defaultValue: ""),
                    Phone = table.Column<string>(maxLength: 11, nullable: true, defaultValue: ""),
                    Address = table.Column<string>(maxLength: 300, nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
