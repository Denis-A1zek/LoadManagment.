using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sigida.LoadManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_course_and_semesterTo_subjectSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("1ba7e478-21d8-4bfb-9fb3-0d4e5681c8d8"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("1c920cfd-7394-4dc8-991f-b939741c0285"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("a006f1dc-f3e7-4bd1-9647-f818e035c5db"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("dbe931e0-7d09-4180-8b20-c644f0451932"));

            migrationBuilder.AddColumn<int>(
                name: "Course",
                table: "SubjectSchedule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "SubjectSchedule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "MaxLoad", "MinLoad", "Title" },
                values: new object[,]
                {
                    { new Guid("2c56322f-6f32-4148-8924-d7b99960f2aa"), 1200.0, 0.0, "Профессор" },
                    { new Guid("8eb290bf-79dc-45b7-9915-b6fdb4c3a117"), 800.0, 0.0, "Ассистент" },
                    { new Guid("af43dd23-3a9f-4892-b44c-fbf21154f5da"), 900.0, 0.0, "Ст. преподаватель" },
                    { new Guid("e288436d-c4ce-45aa-b5fd-4e4dfb3506fa"), 600.0, 0.0, "Доцент" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("2c56322f-6f32-4148-8924-d7b99960f2aa"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("8eb290bf-79dc-45b7-9915-b6fdb4c3a117"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("af43dd23-3a9f-4892-b44c-fbf21154f5da"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("e288436d-c4ce-45aa-b5fd-4e4dfb3506fa"));

            migrationBuilder.DropColumn(
                name: "Course",
                table: "SubjectSchedule");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "SubjectSchedule");

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "MaxLoad", "MinLoad", "Title" },
                values: new object[,]
                {
                    { new Guid("1ba7e478-21d8-4bfb-9fb3-0d4e5681c8d8"), 1200.0, 0.0, "Профессор" },
                    { new Guid("1c920cfd-7394-4dc8-991f-b939741c0285"), 600.0, 0.0, "Доцент" },
                    { new Guid("a006f1dc-f3e7-4bd1-9647-f818e035c5db"), 800.0, 0.0, "Ассистент" },
                    { new Guid("dbe931e0-7d09-4180-8b20-c644f0451932"), 900.0, 0.0, "Ст. преподаватель" }
                });
        }
    }
}
