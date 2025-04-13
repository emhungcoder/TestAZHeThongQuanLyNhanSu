using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAZHeThongQuanLyNhanSu.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_AspNetUsers_EmployeeId1",
                table: "Salaries");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_AspNetUsers_EmployeeId",
                table: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_WorkingHours_EmployeeId",
                table: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_EmployeeId1",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "WorkEndTime",
                table: "WorkingHours");

            migrationBuilder.DropColumn(
                name: "WorkStartTime",
                table: "WorkingHours");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "RewardDisciplinary");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "RewardDisciplinary");

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

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Salaries",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "RewardDisciplinary",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsReward",
                table: "RewardDisciplinary",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "Positions",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_EmployeeId1",
                table: "WorkingHours",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmployeeId",
                table: "Salaries",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_AspNetUsers_EmployeeId",
                table: "Salaries",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Salaries_AspNetUsers_EmployeeId",
                table: "Salaries");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_AspNetUsers_EmployeeId1",
                table: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_WorkingHours_EmployeeId1",
                table: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_EmployeeId",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "WorkingHours");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "RewardDisciplinary");

            migrationBuilder.DropColumn(
                name: "IsReward",
                table: "RewardDisciplinary");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Positions");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "WorkingHours",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "WorkEndTime",
                table: "WorkingHours",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "WorkStartTime",
                table: "WorkingHours",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Salaries",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                table: "Salaries",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "RewardDisciplinary",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "RewardDisciplinary",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_EmployeeId",
                table: "WorkingHours",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmployeeId1",
                table: "Salaries",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_AspNetUsers_EmployeeId1",
                table: "Salaries",
                column: "EmployeeId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
