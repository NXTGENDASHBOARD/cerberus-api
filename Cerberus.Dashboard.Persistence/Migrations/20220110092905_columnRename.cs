using Microsoft.EntityFrameworkCore.Migrations;

namespace Cerberus.Dashboard.Persistence.Migrations
{
    public partial class columnRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassMark",
                table: "DistributionApplicationAnalytic",
                newName: "APS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "APS",
                table: "DistributionApplicationAnalytic",
                newName: "PassMark");
        }
    }
}
