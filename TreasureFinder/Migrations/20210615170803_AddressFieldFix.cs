using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Treasure.Solution.Migrations
{
    public partial class AddressFieldFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Items",
                newName: "Address");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1,
                columns: new[] { "Address", "CreatedAt" },
                values: new object[] { "123 Main Street", new DateTime(2021, 6, 15, 10, 8, 2, 442, DateTimeKind.Local).AddTicks(9960) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Items",
                newName: "Adress");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1,
                columns: new[] { "Adress", "CreatedAt" },
                values: new object[] { null, new DateTime(2021, 6, 14, 14, 29, 10, 871, DateTimeKind.Local).AddTicks(1740) });
        }
    }
}
