using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestfulEvents.Migrations
{
    /// <inheritdoc />
    public partial class ScheduleType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Type",
                table: "ScheduleEntries",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "ScheduleEntries");
        }
    }
}
