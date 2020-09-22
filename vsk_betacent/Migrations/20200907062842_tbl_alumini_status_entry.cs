using Microsoft.EntityFrameworkCore.Migrations;

namespace vsk_betacent.Migrations
{
    public partial class tbl_alumini_status_entry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "tbl_alumini_details",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "tbl_alumini_details");
        }
    }
}
