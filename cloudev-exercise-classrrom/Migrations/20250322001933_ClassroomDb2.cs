using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cloudev_exercise_classrrom.Migrations
{
    /// <inheritdoc />
    public partial class ClassroomDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomFloor",
                table: "Classrooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomFloor",
                table: "Classrooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
