using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAZHeThongQuanLyNhanSu.Migrations
{
    /// <inheritdoc />
    public partial class AddRewardDisciplinaryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RewardDisciplinary_AspNetUsers_EmployeeId",
                table: "RewardDisciplinary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RewardDisciplinary",
                table: "RewardDisciplinary");

            migrationBuilder.RenameTable(
                name: "RewardDisciplinary",
                newName: "RewardDisciplinaries");

            migrationBuilder.RenameIndex(
                name: "IX_RewardDisciplinary_EmployeeId",
                table: "RewardDisciplinaries",
                newName: "IX_RewardDisciplinaries_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RewardDisciplinaries",
                table: "RewardDisciplinaries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RewardDisciplinaries_AspNetUsers_EmployeeId",
                table: "RewardDisciplinaries",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RewardDisciplinaries_AspNetUsers_EmployeeId",
                table: "RewardDisciplinaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RewardDisciplinaries",
                table: "RewardDisciplinaries");

            migrationBuilder.RenameTable(
                name: "RewardDisciplinaries",
                newName: "RewardDisciplinary");

            migrationBuilder.RenameIndex(
                name: "IX_RewardDisciplinaries_EmployeeId",
                table: "RewardDisciplinary",
                newName: "IX_RewardDisciplinary_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RewardDisciplinary",
                table: "RewardDisciplinary",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RewardDisciplinary_AspNetUsers_EmployeeId",
                table: "RewardDisciplinary",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
