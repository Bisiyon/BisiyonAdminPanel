using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisiyonAdminPanel.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DatabaseInfo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SiteAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OwnerEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OwnerAlternateEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OwnerPhone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OwnerAlternatePhone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OwnerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sites");
        }
    }
}
