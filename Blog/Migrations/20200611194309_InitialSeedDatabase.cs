using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class InitialSeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TagList",
                columns: table => new
                {
                    TagListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagList", x => x.TagListId);
                });

            migrationBuilder.CreateTable(
                name: "BlogPost",
                columns: table => new
                {
                    BlogPostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    Body = table.Column<string>(maxLength: 250, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    TagListID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPost", x => x.BlogPostId);
                    table.ForeignKey(
                        name: "FK_BlogPost_TagList_TagListID",
                        column: x => x.TagListID,
                        principalTable: "TagList",
                        principalColumn: "TagListId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TagList",
                columns: new[] { "TagListId", "Name" },
                values: new object[] { 1, "iOS" });

            migrationBuilder.InsertData(
                table: "TagList",
                columns: new[] { "TagListId", "Name" },
                values: new object[] { 2, "Android" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPost_TagListID",
                table: "BlogPost",
                column: "TagListID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPost");

            migrationBuilder.DropTable(
                name: "TagList");
        }
    }
}
