using Microsoft.EntityFrameworkCore.Migrations;

namespace BugtrackerIdentityService.Migrations
{
    public partial class fixsalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "salt",
                table: "users",
                type: "varchar(144)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salt",
                table: "users");
        }
    }
}
