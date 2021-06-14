using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Treasure.Solution.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Adress", "Condition", "CreatedAt", "Description", "Dimensions", "Title", "Url", "UserId", "Weight" },
                values: new object[] { 1, null, "Like New", new DateTime(2021, 6, 14, 14, 29, 10, 871, DateTimeKind.Local).AddTicks(1740), "Free floral sectional", "40X115X80", "Free Couch", "http://www.google.com", 1, "50" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1);
        }
    }
}
