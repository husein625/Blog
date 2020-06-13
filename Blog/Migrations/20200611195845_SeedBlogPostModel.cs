using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class SeedBlogPostModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BlogPost",
                columns: new[] { "BlogPostId", "Body", "CreatedAt", "Description", "Slug", "TagListID", "Title", "UpdatedAt" },
                values: new object[] { 1, "The app is simple to use, and will help you decide on your best furniture fit.", new DateTime(2020, 6, 11, 21, 58, 44, 822, DateTimeKind.Local).AddTicks(4104), "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.", null, 1, "Augmented Reality iOS Application", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPost",
                keyColumn: "BlogPostId",
                keyValue: 1);
        }
    }
}
