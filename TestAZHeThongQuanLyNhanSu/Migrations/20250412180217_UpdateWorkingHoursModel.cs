using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAZHeThongQuanLyNhanSu.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorkingHoursModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_AspNetUsers_EmployeeId",
                table: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_WorkingHours_EmployeeId",
                table: "WorkingHours");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "WorkingHours",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                table: "WorkingHours",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_EmployeeId1",
                table: "WorkingHours",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_AspNetUsers_EmployeeId1",
                table: "WorkingHours",
                column: "EmployeeId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_AspNetUsers_EmployeeId1",
                table: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_WorkingHours_EmployeeId1",
                table: "WorkingHours");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "WorkingHours");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "WorkingHours",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_EmployeeId",
                table: "WorkingHours",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_AspNetUsers_EmployeeId",
                table: "WorkingHours",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
