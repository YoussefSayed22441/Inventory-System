using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_System.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddatabaseEntityToProductSupplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ProductSuppliers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ProductSuppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ProductSuppliers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductSuppliers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ProductSuppliers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ProductSuppliers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ProductSuppliers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProductSuppliers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductSuppliers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductSuppliers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ProductSuppliers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ProductSuppliers");
        }
    }
}
