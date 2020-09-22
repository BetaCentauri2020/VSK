using Microsoft.EntityFrameworkCore.Migrations;

namespace vsk_betacent.Migrations
{
    public partial class tbl_alumini_modification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_demo");

            migrationBuilder.DropColumn(
                name: "image",
                table: "tbl_alumini_details");

            migrationBuilder.AddColumn<string>(
                name: "file",
                table: "tbl_alumini_details",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "file",
                table: "tbl_alumini_details");

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "tbl_alumini_details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tbl_demo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_demo", x => x.id);
                });
        }
    }
}
