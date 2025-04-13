using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAZHeThongQuanLyNhanSu.Migrations
{
    /// <inheritdoc />
    public partial class AddNewReward : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReward",
                table: "RewardDisciplinary");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RewardDisciplinary",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "RewardDisciplinary",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "RewardDisciplinary");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "RewardDisciplinary");

            migrationBuilder.AddColumn<bool>(
                name: "IsReward",
                table: "RewardDisciplinary",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
