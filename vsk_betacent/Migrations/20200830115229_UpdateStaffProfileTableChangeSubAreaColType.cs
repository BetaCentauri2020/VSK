using Microsoft.EntityFrameworkCore.Migrations;

namespace vsk_betacent.Migrations
{
    public partial class UpdateStaffProfileTableChangeSubAreaColType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_staff_profile_tbl_sub_area_type_int_fk_sub_area",
                table: "tbl_staff_profile");

            migrationBuilder.DropIndex(
                name: "IX_tbl_staff_profile_int_fk_sub_area",
                table: "tbl_staff_profile");

            migrationBuilder.DropColumn(
                name: "int_fk_sub_area",
                table: "tbl_staff_profile");

            migrationBuilder.AddColumn<string>(
                name: "txt_fk_sub_area",
                table: "tbl_staff_profile",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "txt_fk_sub_area",
                table: "tbl_staff_profile");

            migrationBuilder.AddColumn<int>(
                name: "int_fk_sub_area",
                table: "tbl_staff_profile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_staff_profile_int_fk_sub_area",
                table: "tbl_staff_profile",
                column: "int_fk_sub_area");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_staff_profile_tbl_sub_area_type_int_fk_sub_area",
                table: "tbl_staff_profile",
                column: "int_fk_sub_area",
                principalTable: "tbl_sub_area_type",
                principalColumn: "int_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
