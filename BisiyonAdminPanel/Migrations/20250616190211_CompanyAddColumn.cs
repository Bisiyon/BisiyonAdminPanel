using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisiyonAdminPanel.Migrations
{
    /// <inheritdoc />
    public partial class CompanyAddColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Company",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Company");
        }
    }
}
