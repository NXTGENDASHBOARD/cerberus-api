using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cerberus.Dashboard.Persistence.Migrations
{
    public partial class AddedRelationsToInstitutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "RaceApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "RaceApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstituteId",
                table: "RaceApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "PipelineApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "PipelineApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstituteId",
                table: "PipelineApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "LocationApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "LocationApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstituteId",
                table: "LocationApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "GenderApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "GenderApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstituteId",
                table: "GenderApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "FeederSchoolApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "FeederSchoolApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstituteId",
                table: "FeederSchoolApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "FacultyApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "FacultyApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstituteId",
                table: "FacultyApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "DistributionApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "DistributionApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstituteId",
                table: "DistributionApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "CourseTypeApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "CourseTypeApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstituteId",
                table: "CourseTypeApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "CompletedApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "CompletedApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstituteId",
                table: "CompletedApplicationAnalytic",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 14, 11, 36, 1, 381, DateTimeKind.Local).AddTicks(8195), new DateTime(2022, 1, 14, 11, 36, 1, 381, DateTimeKind.Local).AddTicks(8209) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 14, 11, 36, 1, 381, DateTimeKind.Local).AddTicks(8213), new DateTime(2022, 1, 14, 11, 36, 1, 381, DateTimeKind.Local).AddTicks(8214) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 14, 11, 36, 1, 381, DateTimeKind.Local).AddTicks(8216), new DateTime(2022, 1, 14, 11, 36, 1, 381, DateTimeKind.Local).AddTicks(8217) });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 14, 11, 36, 1, 382, DateTimeKind.Local).AddTicks(1621), new DateTime(2022, 1, 14, 11, 36, 1, 382, DateTimeKind.Local).AddTicks(1628) });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 14, 11, 36, 1, 382, DateTimeKind.Local).AddTicks(1631), new DateTime(2022, 1, 14, 11, 36, 1, 382, DateTimeKind.Local).AddTicks(1632) });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 14, 11, 36, 1, 382, DateTimeKind.Local).AddTicks(1634), new DateTime(2022, 1, 14, 11, 36, 1, 382, DateTimeKind.Local).AddTicks(1635) });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 14, 11, 36, 1, 382, DateTimeKind.Local).AddTicks(1636), new DateTime(2022, 1, 14, 11, 36, 1, 382, DateTimeKind.Local).AddTicks(1637) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 14, 11, 36, 1, 378, DateTimeKind.Local).AddTicks(7040), new DateTime(2022, 1, 14, 11, 36, 1, 380, DateTimeKind.Local).AddTicks(5811) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 14, 11, 36, 1, 380, DateTimeKind.Local).AddTicks(6513), new DateTime(2022, 1, 14, 11, 36, 1, 380, DateTimeKind.Local).AddTicks(6516) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 14, 11, 36, 1, 380, DateTimeKind.Local).AddTicks(6519), new DateTime(2022, 1, 14, 11, 36, 1, 380, DateTimeKind.Local).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 14, 11, 36, 1, 380, DateTimeKind.Local).AddTicks(6522), new DateTime(2022, 1, 14, 11, 36, 1, 380, DateTimeKind.Local).AddTicks(6523) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "RaceApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "RaceApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "InstituteId",
                table: "RaceApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "PipelineApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "PipelineApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "InstituteId",
                table: "PipelineApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "LocationApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "LocationApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "InstituteId",
                table: "LocationApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "GenderApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "GenderApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "InstituteId",
                table: "GenderApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "FeederSchoolApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "FeederSchoolApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "InstituteId",
                table: "FeederSchoolApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "FacultyApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "FacultyApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "InstituteId",
                table: "FacultyApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "DistributionApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "DistributionApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "InstituteId",
                table: "DistributionApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "CourseTypeApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "CourseTypeApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "InstituteId",
                table: "CourseTypeApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "CompletedApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "CompletedApplicationAnalytic");

            migrationBuilder.DropColumn(
                name: "InstituteId",
                table: "CompletedApplicationAnalytic");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 13, 14, 11, 2, 36, DateTimeKind.Local).AddTicks(8343), new DateTime(2022, 1, 13, 14, 11, 2, 36, DateTimeKind.Local).AddTicks(8351) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 13, 14, 11, 2, 36, DateTimeKind.Local).AddTicks(8354), new DateTime(2022, 1, 13, 14, 11, 2, 36, DateTimeKind.Local).AddTicks(8354) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 13, 14, 11, 2, 36, DateTimeKind.Local).AddTicks(8356), new DateTime(2022, 1, 13, 14, 11, 2, 36, DateTimeKind.Local).AddTicks(8357) });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 13, 14, 11, 2, 37, DateTimeKind.Local).AddTicks(1040), new DateTime(2022, 1, 13, 14, 11, 2, 37, DateTimeKind.Local).AddTicks(1046) });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 13, 14, 11, 2, 37, DateTimeKind.Local).AddTicks(1048), new DateTime(2022, 1, 13, 14, 11, 2, 37, DateTimeKind.Local).AddTicks(1049) });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 13, 14, 11, 2, 37, DateTimeKind.Local).AddTicks(1051), new DateTime(2022, 1, 13, 14, 11, 2, 37, DateTimeKind.Local).AddTicks(1052) });

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 13, 14, 11, 2, 37, DateTimeKind.Local).AddTicks(1053), new DateTime(2022, 1, 13, 14, 11, 2, 37, DateTimeKind.Local).AddTicks(1054) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 13, 14, 11, 2, 31, DateTimeKind.Local).AddTicks(1897), new DateTime(2022, 1, 13, 14, 11, 2, 35, DateTimeKind.Local).AddTicks(8831) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 13, 14, 11, 2, 35, DateTimeKind.Local).AddTicks(9325), new DateTime(2022, 1, 13, 14, 11, 2, 35, DateTimeKind.Local).AddTicks(9328) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 13, 14, 11, 2, 35, DateTimeKind.Local).AddTicks(9330), new DateTime(2022, 1, 13, 14, 11, 2, 35, DateTimeKind.Local).AddTicks(9331) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifyDate" },
                values: new object[] { new DateTime(2022, 1, 13, 14, 11, 2, 35, DateTimeKind.Local).AddTicks(9332), new DateTime(2022, 1, 13, 14, 11, 2, 35, DateTimeKind.Local).AddTicks(9333) });
        }
    }
}
