using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Farmers",
                columns: table => new
                {
                    FarmerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FarmerCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FarmerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FarmerNameEN = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone1 = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Phone2 = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmers", x => x.FarmerId);
                });

            migrationBuilder.InsertData(
                table: "Farmers",
                columns: new[] { "FarmerId", "Address", "FarmerCode", "FarmerName", "FarmerNameEN", "InsertDate", "Phone1", "Phone2", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("453d9985-5b77-42f7-91c7-c1ab9022cf4b"), "123 Đường ABC, TP.HCM", "F001", "Nguyễn Văn A", "Nguyen Van A", new DateTime(2025, 8, 16, 16, 37, 47, 456, DateTimeKind.Local).AddTicks(1469), "0901234567", "0912345678", null },
                    { new Guid("6fecbe2b-e2b0-4825-9984-2e437bff42d0"), "456 Đường XYZ, Hà Nội", "F002", "Trần Thị B", "Tran Thi B", new DateTime(2025, 8, 16, 16, 37, 47, 456, DateTimeKind.Local).AddTicks(1730), "0987654321", "0976543210", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Farmers");
        }
    }
}
