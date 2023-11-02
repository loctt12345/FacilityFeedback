using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacilityFeedback.Data.Migrations
{
    /// <inheritdoc />
    public partial class migrationv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StaffEmail",
                table: "TaskProcess",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffEmail",
                table: "TaskProcess");
        }
    }
}
