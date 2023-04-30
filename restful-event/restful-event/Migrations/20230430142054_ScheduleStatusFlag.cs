using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestulEvent.Migrations
{
    /// <inheritdoc />
    public partial class ScheduleStatusFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "StatusFlags",
                table: "ScheduleEntries",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusFlags",
                table: "ScheduleEntries");
        }
    }
}
