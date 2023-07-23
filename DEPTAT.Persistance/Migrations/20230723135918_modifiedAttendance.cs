using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEPTAT.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class modifiedAttendance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "Attendances");
        }
    }
}
