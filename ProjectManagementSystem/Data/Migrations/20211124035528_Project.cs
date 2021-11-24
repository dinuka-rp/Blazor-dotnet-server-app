using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementSystem.Data.Migrations
{
    public partial class Project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Company_CompanyId1",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_CompanyId1",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Project");

            migrationBuilder.AlterColumn<short>(
                name: "CompanyId",
                table: "Project",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_CompanyId",
                table: "Project",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Company_CompanyId",
                table: "Project",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Company_CompanyId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_CompanyId",
                table: "Project");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddColumn<short>(
                name: "CompanyId1",
                table: "Project",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_CompanyId1",
                table: "Project",
                column: "CompanyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Company_CompanyId1",
                table: "Project",
                column: "CompanyId1",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
