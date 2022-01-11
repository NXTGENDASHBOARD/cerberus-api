using Microsoft.EntityFrameworkCore.Migrations;

namespace Cerberus.Dashboard.Persistence.Migrations
{
    public partial class addedPassMarkcolumnDistribution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PassMark",
                table: "DistributionApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassMark",
                table: "DistributionApplicationAnalytic");
        }
    }
}
