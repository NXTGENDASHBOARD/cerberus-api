using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Cerberus.Dashboard.Persistence.Migrations
{
    public partial class AddedAddressEntityRefactoredApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhysicalAddressCity",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PhysicalAddressLine1",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PhysicalAddressLine2",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PhysicalAddressLine3",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PhysicalAddressPostalCode",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PostalAddressCity",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PostalAddressLine1",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PostalAddressLine2",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PostalAddressLine3",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PostalAddressPostalCode",
                table: "Applications");

            migrationBuilder.CreateTable(
                name: "Addresss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationId = table.Column<int>(type: "integer", nullable: false),
                    InstitutionId = table.Column<int>(type: "integer", nullable: false),
                    PhysicalAddressLine1 = table.Column<string>(type: "text", nullable: true),
                    PhysicalAddressLine2 = table.Column<string>(type: "text", nullable: true),
                    PhysicalAddressLine3 = table.Column<string>(type: "text", nullable: true),
                    PhysicalAddressCity = table.Column<string>(type: "text", nullable: true),
                    PhysicalAddressPostalCode = table.Column<string>(type: "text", nullable: true),
                    PostalAddressLine1 = table.Column<string>(type: "text", nullable: true),
                    PostalAddressLine2 = table.Column<string>(type: "text", nullable: true),
                    PostalAddressLine3 = table.Column<string>(type: "text", nullable: true),
                    PostalAddressCity = table.Column<string>(type: "text", nullable: true),
                    PostalAddressPostalCode = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreateUserId = table.Column<string>(type: "text", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifyUserId = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresss_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresss_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_ApplicationId",
                table: "Addresss",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_InstitutionId",
                table: "Addresss",
                column: "InstitutionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresss");

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAddressCity",
                table: "Applications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAddressLine1",
                table: "Applications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAddressLine2",
                table: "Applications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAddressLine3",
                table: "Applications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAddressPostalCode",
                table: "Applications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalAddressCity",
                table: "Applications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalAddressLine1",
                table: "Applications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalAddressLine2",
                table: "Applications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalAddressLine3",
                table: "Applications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalAddressPostalCode",
                table: "Applications",
                type: "text",
                nullable: true);
        }
    }
}
