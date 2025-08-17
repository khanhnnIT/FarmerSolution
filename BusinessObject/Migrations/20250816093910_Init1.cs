using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "FarmerId",
                keyValue: new Guid("453d9985-5b77-42f7-91c7-c1ab9022cf4b"),
                column: "InsertDate",
                value: new DateTime(2025, 8, 16, 14, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "FarmerId",
                keyValue: new Guid("6fecbe2b-e2b0-4825-9984-2e437bff42d0"),
                column: "InsertDate",
                value: new DateTime(2025, 8, 16, 14, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "FarmerId",
                keyValue: new Guid("453d9985-5b77-42f7-91c7-c1ab9022cf4b"),
                column: "InsertDate",
                value: new DateTime(2025, 8, 16, 16, 37, 47, 456, DateTimeKind.Local).AddTicks(1469));

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "FarmerId",
                keyValue: new Guid("6fecbe2b-e2b0-4825-9984-2e437bff42d0"),
                column: "InsertDate",
                value: new DateTime(2025, 8, 16, 16, 37, 47, 456, DateTimeKind.Local).AddTicks(1730));
        }
    }
}
