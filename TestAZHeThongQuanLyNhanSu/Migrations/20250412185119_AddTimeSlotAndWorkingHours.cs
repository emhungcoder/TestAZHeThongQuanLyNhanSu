using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAZHeThongQuanLyNhanSu.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeSlotAndWorkingHours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "WorkingHours");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalHours",
                table: "WorkingHours",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
