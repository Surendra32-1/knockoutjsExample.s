using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnockoutPrastice.Migrations
{
    /// <inheritdoc />
    public partial class updatedFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "StudentModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolBranch",
                table: "StudentModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "StudentModels");

            migrationBuilder.DropColumn(
                name: "SchoolBranch",
                table: "StudentModels");
        }
    }
}
