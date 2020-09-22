using Microsoft.EntityFrameworkCore.Migrations;

namespace vsk_betacent.Migrations
{
    public partial class UpdateNoticeTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "txt_proiority",
                table: "tbl_notice");

            migrationBuilder.RenameColumn(
                name: "txt_Description",
                table: "tbl_notice",
                newName: "txt_description");

            migrationBuilder.AddColumn<int>(
                name: "int_proiority",
                table: "tbl_notice",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "int_status",
                table: "tbl_notice",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "int_proiority",
                table: "tbl_notice");

            migrationBuilder.DropColumn(
                name: "int_status",
                table: "tbl_notice");

            migrationBuilder.RenameColumn(
                name: "txt_description",
                table: "tbl_notice",
                newName: "txt_Description");

            migrationBuilder.AddColumn<int>(
                name: "txt_proiority",
                table: "tbl_notice",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
