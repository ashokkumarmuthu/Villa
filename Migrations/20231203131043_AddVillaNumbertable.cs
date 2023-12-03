using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Villa_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddVillaNumbertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumber",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumber", x => x.VillaNo);
                });

            migrationBuilder.InsertData(
                table: "VillaNumber",
                columns: new[] { "VillaNo", "CreatedDate", "SpecialDetails", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 3, 18, 40, 43, 387, DateTimeKind.Local).AddTicks(9920), "Blue", new DateTime(2023, 12, 3, 18, 40, 43, 387, DateTimeKind.Local).AddTicks(9920) },
                    { 2, new DateTime(2023, 12, 3, 18, 40, 43, 387, DateTimeKind.Local).AddTicks(9920), "Orange", new DateTime(2023, 12, 3, 18, 40, 43, 387, DateTimeKind.Local).AddTicks(9920) }
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 3, 18, 40, 43, 387, DateTimeKind.Local).AddTicks(9810), new DateTime(2023, 12, 3, 18, 40, 43, 387, DateTimeKind.Local).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 3, 18, 40, 43, 387, DateTimeKind.Local).AddTicks(9850), new DateTime(2023, 12, 3, 18, 40, 43, 387, DateTimeKind.Local).AddTicks(9850) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumber");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 11, 1, 12, 44, 219, DateTimeKind.Local).AddTicks(1290), new DateTime(2023, 10, 11, 1, 12, 44, 219, DateTimeKind.Local).AddTicks(1340) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 11, 1, 12, 44, 219, DateTimeKind.Local).AddTicks(1340), new DateTime(2023, 10, 11, 1, 12, 44, 219, DateTimeKind.Local).AddTicks(1340) });
        }
    }
}
