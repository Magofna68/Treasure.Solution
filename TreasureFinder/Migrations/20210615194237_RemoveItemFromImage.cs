using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Treasure.Solution.Migrations
{
    public partial class RemoveItemFromImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 12, 42, 37, 41, DateTimeKind.Local).AddTicks(3290));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 15, 10, 8, 2, 442, DateTimeKind.Local).AddTicks(9960));
        }
    }
}
