using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class v2_enable_project_employees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("4658a028-edad-406d-9225-abe22bd1e29a"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("9a0d274e-65e4-4f68-a3cf-5d0edf2599e9"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("bbe222ce-0088-4a65-a308-c27d84552c0f"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("f6d8e996-945c-45b7-b6b8-186ef7b08bbc"));

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "ProjectEmployees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("09f8fc6f-3c2d-4875-bcf7-6eef1a8b27e4"), "Software Development" },
                    { new Guid("8b8d307f-c78a-4bfe-bb27-f81d7e287189"), "Accountant" },
                    { new Guid("b3158a44-03ba-4aee-bbe8-2d5c7ebfb345"), "Finance" },
                    { new Guid("ca35dfef-f729-4b6d-a9dd-ac58ab816fb8"), "HR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("09f8fc6f-3c2d-4875-bcf7-6eef1a8b27e4"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("8b8d307f-c78a-4bfe-bb27-f81d7e287189"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("b3158a44-03ba-4aee-bbe8-2d5c7ebfb345"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("ca35dfef-f729-4b6d-a9dd-ac58ab816fb8"));

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "ProjectEmployees");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4658a028-edad-406d-9225-abe22bd1e29a"), "Accountant" },
                    { new Guid("9a0d274e-65e4-4f68-a3cf-5d0edf2599e9"), "Finance" },
                    { new Guid("bbe222ce-0088-4a65-a308-c27d84552c0f"), "HR" },
                    { new Guid("f6d8e996-945c-45b7-b6b8-186ef7b08bbc"), "Software Development" }
                });
        }
    }
}
