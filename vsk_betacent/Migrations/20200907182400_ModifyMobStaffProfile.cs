using Microsoft.EntityFrameworkCore.Migrations;

namespace vsk_betacent.Migrations
{
    public partial class ModifyMobStaffProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "int_mob",
                table: "tbl_staff_profile");

            migrationBuilder.AddColumn<string>(
                name: "txt_mob",
                table: "tbl_staff_profile",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "txt_mob",
                table: "tbl_staff_profile");

            migrationBuilder.AddColumn<int>(
                name: "int_mob",
                table: "tbl_staff_profile",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
