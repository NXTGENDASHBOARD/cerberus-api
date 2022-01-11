using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Cerberus.Dashboard.Persistence.Migrations
{
    public partial class GraphModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompletedApplicationAnalytic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sum = table.Column<int>(type: "integer", nullable: false),
                    DateRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastSum = table.Column<int>(type: "integer", nullable: false),
                    LastDateRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AnalyticType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedApplicationAnalytic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseTypeApplicationAnalytic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sum = table.Column<int>(type: "integer", nullable: false),
                    DateRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastSum = table.Column<int>(type: "integer", nullable: false),
                    LastDateRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AnalyticType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTypeApplicationAnalytic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DistributionApplicationAnalytic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sum = table.Column<int>(type: "integer", nullable: false),
                    DateRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastSum = table.Column<int>(type: "integer", nullable: false),
                    LastDateRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AnalyticType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributionApplicationAnalytic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacultyApplicationAnalytic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sum = table.Column<int>(type: "integer", nullable: false),
                    DateRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastSum = table.Column<int>(type: "integer", nullable: false),
                    LastDateRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AnalyticType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyApplicationAnalytic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeederSchoolApplicationAnalytic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sum = table.Column<int>(type: "integer", nullable: false),
                    DateRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastSum = table.Column<int>(type: "integer", nullable: false),
                    LastDateRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AnalyticType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeederSchoolApplicationAnalytic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenderApplicationAnalytic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sum = table.Column<int>(type: "integer", nullable: false),
                    DateRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastSum = table.Column<int>(type: "integer", nullable: false),
                    LastDateRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AnalyticType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderApplicationAnalytic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationApplicationAnalytic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sum = table.Column<int>(type: "integer", nullable: false),
                    DateRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastSum = table.Column<int>(type: "integer", nullable: false),
                    LastDateRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AnalyticType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationApplicationAnalytic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PipelineApplicationAnalytic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sum = table.Column<int>(type: "integer", nullable: false),
                    DateRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastSum = table.Column<int>(type: "integer", nullable: false),
                    LastDateRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AnalyticType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineApplicationAnalytic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceApplicationAnalytic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sum = table.Column<int>(type: "integer", nullable: false),
                    DateRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastSum = table.Column<int>(type: "integer", nullable: false),
                    LastDateRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AnalyticType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceApplicationAnalytic", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedApplicationAnalytic");

            migrationBuilder.DropTable(
                name: "CourseTypeApplicationAnalytic");

            migrationBuilder.DropTable(
                name: "DistributionApplicationAnalytic");

            migrationBuilder.DropTable(
                name: "FacultyApplicationAnalytic");

            migrationBuilder.DropTable(
                name: "FeederSchoolApplicationAnalytic");

            migrationBuilder.DropTable(
                name: "GenderApplicationAnalytic");

            migrationBuilder.DropTable(
                name: "LocationApplicationAnalytic");

            migrationBuilder.DropTable(
                name: "PipelineApplicationAnalytic");

            migrationBuilder.DropTable(
                name: "RaceApplicationAnalytic");
        }
    }
}
