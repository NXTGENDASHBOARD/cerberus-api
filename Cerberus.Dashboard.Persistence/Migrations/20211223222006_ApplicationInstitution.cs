using Microsoft.EntityFrameworkCore.Migrations;

namespace Cerberus.Dashboard.Persistence.Migrations
{
    public partial class ApplicationInstitution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstitutionId",
                table: "Applications",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_InstitutionId",
                table: "Applications",
                column: "InstitutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Institutions_InstitutionId",
                table: "Applications",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Institutions_InstitutionId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_InstitutionId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "Applications");
        }
    }
}
