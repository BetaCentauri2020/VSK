using Microsoft.EntityFrameworkCore.Migrations;

namespace vsk_betacent.Migrations
{
    public partial class ModifyGalleryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "txt_position",
                table: "tbl_gallery");

            migrationBuilder.AddColumn<int>(
                name: "int_position",
                table: "tbl_gallery",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "int_status",
                table: "tbl_gallery",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "int_position",
                table: "tbl_gallery");

            migrationBuilder.DropColumn(
                name: "int_status",
                table: "tbl_gallery");

            migrationBuilder.AddColumn<string>(
                name: "txt_position",
                table: "tbl_gallery",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
