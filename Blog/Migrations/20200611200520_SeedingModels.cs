using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class SeedingModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPost",
                keyColumn: "BlogPostId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "BlogPost",
                keyColumn: "BlogPostId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 11, 22, 5, 20, 83, DateTimeKind.Local).AddTicks(4394));

            migrationBuilder.InsertData(
                table: "BlogPost",
                columns: new[] { "BlogPostId", "Body", "CreatedAt", "Description", "Slug", "TagListID", "Title", "UpdatedAt" },
                values: new object[] { 3, "The app is simple to use, and will help you decide on your best furniture fit.", new DateTime(2020, 6, 11, 22, 5, 20, 81, DateTimeKind.Local).AddTicks(1372), "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.", "augmented-reality-ios-application", 1, "Augmented Reality iOS Application", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPost",
                keyColumn: "BlogPostId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "BlogPost",
                keyColumn: "BlogPostId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 11, 22, 3, 46, 597, DateTimeKind.Local).AddTicks(183));

            migrationBuilder.InsertData(
                table: "BlogPost",
                columns: new[] { "BlogPostId", "Body", "CreatedAt", "Description", "Slug", "TagListID", "Title", "UpdatedAt" },
                values: new object[] { 1, "The app is simple to use, and will help you decide on your best furniture fit.", new DateTime(2020, 6, 11, 22, 3, 46, 593, DateTimeKind.Local).AddTicks(1602), "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.", "augmented-reality-ios-application", 1, "Augmented Reality iOS Application", null });
        }
    }
}
