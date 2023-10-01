using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Villa_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddVillaRow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "id", "CreatedDate", "Occupancy", "Sqft", "UpdatedDate", "name", "rate" },
                values: new object[] { 1, new DateTime(2023, 10, 2, 2, 49, 49, 24, DateTimeKind.Local).AddTicks(4940), 10000, 10, new DateTime(2023, 10, 2, 2, 49, 49, 24, DateTimeKind.Local).AddTicks(4980), "Ashok", 20.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
