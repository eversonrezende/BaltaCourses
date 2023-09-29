using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogEF.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaCampoUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Badge",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Badge",
                table: "User");
        }
    }
}
