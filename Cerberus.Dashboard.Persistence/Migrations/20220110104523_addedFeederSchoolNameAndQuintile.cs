using Microsoft.EntityFrameworkCore.Migrations;

namespace Cerberus.Dashboard.Persistence.Migrations
{
    public partial class addedFeederSchoolNameAndQuintile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FeederSchoolName",
                table: "FeederSchoolApplicationAnalytic",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quintile",
                table: "FeederSchoolApplicationAnalytic",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeederSchoolName",
                table: "FeederSchoolApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "Quintile",
                table: "FeederSchoolApplicationAnalytic");
        }
    }
}
