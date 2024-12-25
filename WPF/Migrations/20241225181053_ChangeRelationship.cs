using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPF.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ScenarioDTO_RequestParametresId",
                table: "ScenarioDTO");

            migrationBuilder.AlterColumn<int>(
                name: "RequestParametresId",
                table: "ScenarioDTO",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScenarioDTO_RequestParametresId",
                table: "ScenarioDTO",
                column: "RequestParametresId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ScenarioDTO_RequestParametresId",
                table: "ScenarioDTO");

            migrationBuilder.AlterColumn<int>(
                name: "RequestParametresId",
                table: "ScenarioDTO",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_ScenarioDTO_RequestParametresId",
                table: "ScenarioDTO",
                column: "RequestParametresId",
                unique: true);
        }
    }
}
