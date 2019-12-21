using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackerIssueApi.Migrations
{
    public partial class Fresh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
//            migrationBuilder.CreateTable(
//                name: "issues",
//                columns: table => new
//                {
//                    id = table.Column<int>(type: "int(11)", nullable: false)
//                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
//                    name = table.Column<string>(type: "varchar(144)", nullable: false),
//                    priority = table.Column<int>(type: "int(11)", nullable: false, defaultValueSql: "'1'"),
//                    active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
//                    created_on = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
//                    created_by = table.Column<int>(type: "int(11)", nullable: false),
//                    modified_on = table.Column<DateTime>(type: "DATETIME", nullable: true),
//                    closed_on = table.Column<DateTime>(type: "DATETIME", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_issues", x => x.id);
//                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    owner_id = table.Column<int>(type: "int(11)", nullable: true),
                    issue_id = table.Column<int>(type: "int(11)", nullable: false),
                    comment_body = table.Column<string>(type: "varchar(1440)", nullable: false),
                    created_on = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    modified_on = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.id);
                    table.ForeignKey(
                        name: "comment_FK00",
                        column: x => x.issue_id,
                        principalTable: "issues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_issue_id",
                table: "comments",
                column: "issue_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
//            migrationBuilder.DropTable(
//                name: "comments");
//
//            migrationBuilder.DropTable(
//                name: "issues");
        }
    }
}
