using Microsoft.EntityFrameworkCore.Migrations;

namespace vsk_betacent.Migrations
{
    public partial class ModifyInquaryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_inquary",
                table: "tbl_inquary");

            migrationBuilder.DropColumn(
                name: "inquary_id",
                table: "tbl_inquary");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_inquary",
                table: "tbl_inquary",
                column: "slno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_inquary",
                table: "tbl_inquary");

            migrationBuilder.AddColumn<string>(
                name: "inquary_id",
                table: "tbl_inquary",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_inquary",
                table: "tbl_inquary",
                column: "inquary_id");
        }
    }
}
