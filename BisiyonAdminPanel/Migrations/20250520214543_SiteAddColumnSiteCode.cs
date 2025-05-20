using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisiyonAdminPanel.Migrations
{
    /// <inheritdoc />
    public partial class SiteAddColumnSiteCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SiteCode",
                table: "Sites",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteCode",
                table: "Sites");
        }
    }
}
