using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisiyonAdminPanel.Migrations
{
    /// <inheritdoc />
    public partial class TablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Sites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Sites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Sites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MersisNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Company_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sites_CompanyId",
                table: "Sites",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_DistrictId",
                table: "Sites",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_ProvinceId",
                table: "Sites",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_DistrictId",
                table: "Company",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ProvinceId",
                table: "Company",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_District_ProvinceId",
                table: "District",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_Company_CompanyId",
                table: "Sites",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_District_DistrictId",
                table: "Sites",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_Province_ProvinceId",
                table: "Sites",
                column: "ProvinceId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Company_CompanyId",
                table: "Sites");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_District_DistrictId",
                table: "Sites");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Province_ProvinceId",
                table: "Sites");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropIndex(
                name: "IX_Sites_CompanyId",
                table: "Sites");

            migrationBuilder.DropIndex(
                name: "IX_Sites_DistrictId",
                table: "Sites");

            migrationBuilder.DropIndex(
                name: "IX_Sites_ProvinceId",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Sites");
        }
    }
}
