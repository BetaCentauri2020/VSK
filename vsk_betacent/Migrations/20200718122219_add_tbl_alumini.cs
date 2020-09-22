using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vsk_betacent.Migrations
{
    public partial class add_tbl_alumini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_alumini_details",
                columns: table => new
                {
                    registration_number = table.Column<string>(nullable: false),
                    name = table.Column<string>(maxLength: 250, nullable: false),
                    organisation = table.Column<string>(maxLength: 250, nullable: false),
                    profession = table.Column<string>(maxLength: 250, nullable: false),
                    passout_year = table.Column<string>(maxLength: 250, nullable: false),
                    gender = table.Column<string>(maxLength: 10, nullable: true),
                    marital_status = table.Column<string>(maxLength: 20, nullable: false),
                    eamil = table.Column<string>(maxLength: 50, nullable: false),
                    dob = table.Column<DateTime>(nullable: true),
                    mobile = table.Column<string>(maxLength: 12, nullable: false),
                    address = table.Column<string>(maxLength: 250, nullable: false),
                    image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_alumini_details", x => x.registration_number);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_alumini_details");
        }
    }
}
