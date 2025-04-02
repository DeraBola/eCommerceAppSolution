using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerceApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixStaticGuids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb4d5d54-5e45-41af-b251-6c8d0c508847");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3b6f917-0bc4-43f0-bbae-ac2b3a59cf75");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6A1EBD8E-8F3A-4B2E-BE41-3D56B21739D5", null, "Admin", "ADMIN" },
                    { "F5A8B4E7-75C9-4D9B-8C12-3F89A3EF6D9D", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6A1EBD8E-8F3A-4B2E-BE41-3D56B21739D5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "F5A8B4E7-75C9-4D9B-8C12-3F89A3EF6D9D");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bb4d5d54-5e45-41af-b251-6c8d0c508847", null, "Admin", "ADMIN" },
                    { "d3b6f917-0bc4-43f0-bbae-ac2b3a59cf75", null, "User", "USER" }
                });
        }
    }
}
