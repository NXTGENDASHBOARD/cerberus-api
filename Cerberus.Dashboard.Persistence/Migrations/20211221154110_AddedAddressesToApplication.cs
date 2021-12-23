using Microsoft.EntityFrameworkCore.Migrations;

namespace Cerberus.Dashboard.Persistence.Migrations
{
    public partial class AddedAddressesToApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationStage",
                table: "Applications",
                type: "text",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationStage",
                table: "Applications");

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
        }
    }
}
