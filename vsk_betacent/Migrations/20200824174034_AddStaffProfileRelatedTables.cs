using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vsk_betacent.Migrations
{
    public partial class AddStaffProfileRelatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_blood_gr",
                columns: table => new
                {
                    int_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    txt_bld_gr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_blood_gr", x => x.int_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_desig_type",
                columns: table => new
                {
                    int_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    txt_desig = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_desig_type", x => x.int_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_profesn",
                columns: table => new
                {
                    int_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    txt_profs = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_profesn", x => x.int_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_qualification",
                columns: table => new
                {
                    int_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    txt_qua = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_qualification", x => x.int_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_sub_area_type",
                columns: table => new
                {
                    int_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    txt_sub = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_sub_area_type", x => x.int_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_staff_profile",
                columns: table => new
                {
                    int_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    txt_nm = table.Column<string>(nullable: true),
                    int_fk_qua = table.Column<int>(nullable: false),
                    int_fk_prof = table.Column<int>(nullable: false),
                    int_fk_desg = table.Column<int>(nullable: false),
                    int_fk_sub_area = table.Column<int>(nullable: false),
                    dt_dob = table.Column<DateTime>(nullable: false),
                    int_mob = table.Column<int>(nullable: false),
                    txt_email = table.Column<string>(nullable: true),
                    int_fk_bld_grp = table.Column<int>(nullable: false),
                    txt_address = table.Column<string>(nullable: true),
                    txt_img = table.Column<string>(nullable: true),
                    txt_pwd = table.Column<string>(nullable: true),
                    int_status = table.Column<int>(nullable: false),
                    dt_doc = table.Column<DateTime>(nullable: false),
                    dt_dom = table.Column<DateTime>(nullable: false),
                    txt_mod_by = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_staff_profile", x => x.int_id);
                    table.ForeignKey(
                        name: "FK_tbl_staff_profile_tbl_blood_gr_int_fk_bld_grp",
                        column: x => x.int_fk_bld_grp,
                        principalTable: "tbl_blood_gr",
                        principalColumn: "int_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_staff_profile_tbl_desig_type_int_fk_desg",
                        column: x => x.int_fk_desg,
                        principalTable: "tbl_desig_type",
                        principalColumn: "int_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_staff_profile_tbl_profesn_int_fk_prof",
                        column: x => x.int_fk_prof,
                        principalTable: "tbl_profesn",
                        principalColumn: "int_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_staff_profile_tbl_qualification_int_fk_qua",
                        column: x => x.int_fk_qua,
                        principalTable: "tbl_qualification",
                        principalColumn: "int_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_staff_profile_tbl_sub_area_type_int_fk_sub_area",
                        column: x => x.int_fk_sub_area,
                        principalTable: "tbl_sub_area_type",
                        principalColumn: "int_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_staff_profile_int_fk_bld_grp",
                table: "tbl_staff_profile",
                column: "int_fk_bld_grp");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_staff_profile_int_fk_desg",
                table: "tbl_staff_profile",
                column: "int_fk_desg");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_staff_profile_int_fk_prof",
                table: "tbl_staff_profile",
                column: "int_fk_prof");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_staff_profile_int_fk_qua",
                table: "tbl_staff_profile",
                column: "int_fk_qua");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_staff_profile_int_fk_sub_area",
                table: "tbl_staff_profile",
                column: "int_fk_sub_area");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_staff_profile");

            migrationBuilder.DropTable(
                name: "tbl_blood_gr");

            migrationBuilder.DropTable(
                name: "tbl_desig_type");

            migrationBuilder.DropTable(
                name: "tbl_profesn");

            migrationBuilder.DropTable(
                name: "tbl_qualification");

            migrationBuilder.DropTable(
                name: "tbl_sub_area_type");
        }
    }
}
