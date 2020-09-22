using Microsoft.EntityFrameworkCore.Migrations;

namespace vsk_betacent.Migrations
{
    public partial class inquary_tbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_inquary",
                columns: table => new
                {
                    inquary_id = table.Column<string>(nullable: false),
                    slno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 250, nullable: false),
                    course = table.Column<string>(maxLength: 250, nullable: false),
                    email = table.Column<string>(maxLength: 250, nullable: false),
                    Contact_no = table.Column<string>(maxLength: 250, nullable: false),
                    query = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_inquary", x => x.inquary_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_inquary");
        }
    }
}
