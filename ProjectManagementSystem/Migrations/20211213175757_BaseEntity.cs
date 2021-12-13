using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementSystem.Migrations
{
    public partial class BaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Companies");
        }
    }
}
