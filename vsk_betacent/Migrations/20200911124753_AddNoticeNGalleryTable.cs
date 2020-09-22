using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vsk_betacent.Migrations
{
    public partial class AddNoticeNGalleryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_gallery",
                columns: table => new
                {
                    int_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    txt_title = table.Column<string>(nullable: true),
                    txt_position = table.Column<string>(nullable: true),
                    txt_file = table.Column<string>(nullable: true),
                    dt_doc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_gallery", x => x.int_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_notice",
                columns: table => new
                {
                    int_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    txt_title = table.Column<string>(nullable: true),
                    txt_proiority = table.Column<string>(nullable: true),
                    txt_Description = table.Column<string>(nullable: true),
                    txt_file = table.Column<string>(nullable: true),
                    dt_dou = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_notice", x => x.int_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_gallery");

            migrationBuilder.DropTable(
                name: "tbl_notice");
        }
    }
}
