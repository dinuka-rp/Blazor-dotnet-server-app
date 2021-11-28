using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementSystem.Data.Migrations
{
    public partial class Projects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserProject_Project_ProjectsId",
                table: "ApplicationUserProject");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Companies_CompanyId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Project_ProjectId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameIndex(
                name: "IX_Project_CompanyId",
                table: "Projects",
                newName: "IX_Projects_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserProject_Projects_ProjectsId",
                table: "ApplicationUserProject",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Companies_CompanyId",
                table: "Projects",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projects_ProjectId",
                table: "Tickets",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserProject_Projects_ProjectsId",
                table: "ApplicationUserProject");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Companies_CompanyId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_ProjectId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_CompanyId",
                table: "Project",
                newName: "IX_Project_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserProject_Project_ProjectsId",
                table: "ApplicationUserProject",
                column: "ProjectsId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Companies_CompanyId",
                table: "Project",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Project_ProjectId",
                table: "Tickets",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
