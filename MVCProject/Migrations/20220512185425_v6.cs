using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCProject.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });
        }
    }
}
