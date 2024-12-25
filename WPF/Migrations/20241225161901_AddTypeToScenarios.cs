using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPF.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeToScenarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ScenarioDTO",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "ScenarioDTO");
        }
    }
}
