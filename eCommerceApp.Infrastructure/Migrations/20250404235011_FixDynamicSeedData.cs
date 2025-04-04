using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerceApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixDynamicSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("829b2c55-f4f6-4101-91a1-714220ed1417"));

            migrationBuilder.RenameColumn(
                name: "CreatedData",
                table: "CheckoutArchive",
                newName: "CreatedDate");

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("3d1e8a3f-9f6f-4b8c-8eb7-9d98b7c7d056"), "Credit Card" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("3d1e8a3f-9f6f-4b8c-8eb7-9d98b7c7d056"));

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "CheckoutArchive",
                newName: "CreatedData");

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("829b2c55-f4f6-4101-91a1-714220ed1417"), "Credit Card" });
        }
    }
}
