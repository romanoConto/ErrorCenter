using Microsoft.EntityFrameworkCore.Migrations;

namespace Codenation.ErrorCenter.Models.Migrations
{
    public partial class ErrorCenter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "log",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(maxLength: 255, nullable: false),
                    origin = table.Column<string>(maxLength: 255, nullable: false),
                    level = table.Column<string>(maxLength: 255, nullable: false),
                    data = table.Column<string>(maxLength: 2000, nullable: false),
                    environment = table.Column<string>(maxLength: 255, nullable: false),
                    frequency = table.Column<int>(nullable: false),
                    date = table.Column<string>(nullable: false),
                    isArchived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    email = table.Column<string>(maxLength: 255, nullable: false),
                    password = table.Column<string>(maxLength: 255, nullable: false),
                    token = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "log");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
