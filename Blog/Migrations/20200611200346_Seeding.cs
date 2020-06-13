using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPost",
                keyColumn: "BlogPostId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Slug" },
                values: new object[] { new DateTime(2020, 6, 11, 22, 3, 46, 593, DateTimeKind.Local).AddTicks(1602), "augmented-reality-ios-application" });

            migrationBuilder.InsertData(
                table: "BlogPost",
                columns: new[] { "BlogPostId", "Body", "CreatedAt", "Description", "Slug", "TagListID", "Title", "UpdatedAt" },
                values: new object[] { 2, "The app is simple to use, and will help you decide on your best furniture fit.", new DateTime(2020, 6, 11, 22, 3, 46, 597, DateTimeKind.Local).AddTicks(183), "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.", "augmented-reality-ios-application-2", 2, "Augmented Reality iOS Application-2", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPost",
                keyColumn: "BlogPostId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "BlogPost",
                keyColumn: "BlogPostId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Slug" },
                values: new object[] { new DateTime(2020, 6, 11, 21, 58, 44, 822, DateTimeKind.Local).AddTicks(4104), null });
        }
    }
}
