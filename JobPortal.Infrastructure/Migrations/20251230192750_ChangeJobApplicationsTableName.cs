using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeJobApplicationsTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobsApplication_AspNetUsers_UserId",
                table: "JobsApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_JobsApplication_Jobs_JobId",
                table: "JobsApplication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobsApplication",
                table: "JobsApplication");

            migrationBuilder.RenameTable(
                name: "JobsApplication",
                newName: "JobApplications");

            migrationBuilder.RenameIndex(
                name: "IX_JobsApplication_UserId",
                table: "JobApplications",
                newName: "IX_JobApplications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobsApplication_JobId",
                table: "JobApplications",
                newName: "IX_JobApplications_JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_AspNetUsers_UserId",
                table: "JobApplications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Jobs_JobId",
                table: "JobApplications",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_AspNetUsers_UserId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Jobs_JobId",
                table: "JobApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobApplications",
                table: "JobApplications");

            migrationBuilder.RenameTable(
                name: "JobApplications",
                newName: "JobsApplication");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplications_UserId",
                table: "JobsApplication",
                newName: "IX_JobsApplication_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplications_JobId",
                table: "JobsApplication",
                newName: "IX_JobsApplication_JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobsApplication",
                table: "JobsApplication",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobsApplication_AspNetUsers_UserId",
                table: "JobsApplication",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobsApplication_Jobs_JobId",
                table: "JobsApplication",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
