using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sigida.LoadManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_init_value_for_position : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "MaxLoad", "MinLoad", "Title" },
                values: new object[,]
                {
                    { new Guid("0e7bf3ac-09fe-466e-8aef-521659c48893"), 1200.0, 0.0, "Ассистент" },
                    { new Guid("36213718-7762-4c67-9674-9d93544a5ae6"), 600.0, 0.0, "Доцент" },
                    { new Guid("371ae21a-9cda-4a07-964e-9a5f27d67fa5"), 900.0, 0.0, "Ст. преподаватель" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("0e7bf3ac-09fe-466e-8aef-521659c48893"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("36213718-7762-4c67-9674-9d93544a5ae6"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("371ae21a-9cda-4a07-964e-9a5f27d67fa5"));
        }
    }
}
