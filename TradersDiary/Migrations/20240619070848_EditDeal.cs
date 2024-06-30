using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradersDiary.Migrations
{
    /// <inheritdoc />
    public partial class EditDeal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ClosingDate",
                table: "Deal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Expiration",
                table: "Deal",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosingDate",
                table: "Deal");

            migrationBuilder.DropColumn(
                name: "Expiration",
                table: "Deal");
        }
    }
}
