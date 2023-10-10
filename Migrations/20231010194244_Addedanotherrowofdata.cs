using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Villa_Api.Migrations
{
    /// <inheritdoc />
    public partial class Addedanotherrowofdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 11, 1, 12, 44, 219, DateTimeKind.Local).AddTicks(1290), new DateTime(2023, 10, 11, 1, 12, 44, 219, DateTimeKind.Local).AddTicks(1340) });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "id", "CreatedDate", "Occupancy", "Sqft", "UpdatedDate", "name", "rate" },
                values: new object[] { 2, new DateTime(2023, 10, 11, 1, 12, 44, 219, DateTimeKind.Local).AddTicks(1340), 10000, 10, new DateTime(2023, 10, 11, 1, 12, 44, 219, DateTimeKind.Local).AddTicks(1340), "Kumar", 20.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 2, 2, 49, 49, 24, DateTimeKind.Local).AddTicks(4940), new DateTime(2023, 10, 2, 2, 49, 49, 24, DateTimeKind.Local).AddTicks(4980) });
        }
    }
}
