using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sigida.LoadManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("66d37ac6-0906-4696-80f0-072612d4fecf"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("672e1613-1b8f-4fcc-b8d3-5d6f2e933f2d"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("8c5cb5f0-6ada-4421-8c93-fad46d0ff8b5"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("bfb381cd-c500-4ed9-86a4-64664942b16e"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Loads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SubjectSchedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LectureHours = table.Column<int>(type: "int", nullable: false),
                    LabHours = table.Column<int>(type: "int", nullable: false),
                    PracticeHours = table.Column<int>(type: "int", nullable: false),
                    SelfHours = table.Column<int>(type: "int", nullable: false),
                    LoadId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectSchedule_Loads_LoadId",
                        column: x => x.LoadId,
                        principalTable: "Loads",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_SubjectSchedule_LoadId",
                table: "SubjectSchedule",
                column: "LoadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectSchedule");

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

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Loads");

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "MaxLoad", "MinLoad", "Title" },
                values: new object[,]
                {
                    { new Guid("66d37ac6-0906-4696-80f0-072612d4fecf"), 1200.0, 0.0, "Профессор" },
                    { new Guid("672e1613-1b8f-4fcc-b8d3-5d6f2e933f2d"), 800.0, 0.0, "Ассистент" },
                    { new Guid("8c5cb5f0-6ada-4421-8c93-fad46d0ff8b5"), 600.0, 0.0, "Доцент" },
                    { new Guid("bfb381cd-c500-4ed9-86a4-64664942b16e"), 900.0, 0.0, "Ст. преподаватель" }
                });
        }
    }
}
