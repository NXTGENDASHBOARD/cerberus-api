using Microsoft.EntityFrameworkCore.Migrations;

namespace Cerberus.Dashboard.Persistence.Migrations
{
    public partial class RefinedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresss_Applications_ApplicationId",
                table: "Addresss");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresss_Institutions_InstitutionId",
                table: "Addresss");

            migrationBuilder.DropIndex(
                name: "IX_Addresss_ApplicationId",
                table: "Addresss");

            migrationBuilder.DropIndex(
                name: "IX_Addresss_InstitutionId",
                table: "Addresss");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Addresss");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "Addresss");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Institutions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Applications",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_AddressId",
                table: "Institutions",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_AddressId",
                table: "Applications",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Addresss_AddressId",
                table: "Applications",
                column: "AddressId",
                principalTable: "Addresss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_Addresss_AddressId",
                table: "Institutions",
                column: "AddressId",
                principalTable: "Addresss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Addresss_AddressId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Addresss_AddressId",
                table: "Institutions");

            migrationBuilder.DropIndex(
                name: "IX_Institutions_AddressId",
                table: "Institutions");

            migrationBuilder.DropIndex(
                name: "IX_Applications_AddressId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Institutions");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Applications");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Addresss",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstitutionId",
                table: "Addresss",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Addresss_Applications_ApplicationId",
                table: "Addresss",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresss_Institutions_InstitutionId",
                table: "Addresss",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
