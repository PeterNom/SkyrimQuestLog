using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyrimQuestLog.Migrations
{
    /// <inheritdoc />
    public partial class QuestChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "QuestType",
                table: "Quests");

            migrationBuilder.AlterColumn<string>(
                name: "QuestDescription",
                table: "Quests",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Cities",
                table: "Quests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Faction",
                table: "Quests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Main",
                table: "Quests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mischellaneous",
                table: "Quests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrcStringholds",
                table: "Quests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Other",
                table: "Quests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Settlements",
                table: "Quests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Towns",
                table: "Quests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cities",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Faction",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Main",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Mischellaneous",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "OrcStringholds",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Other",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Settlements",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Towns",
                table: "Quests");

            migrationBuilder.AlterColumn<string>(
                name: "QuestDescription",
                table: "Quests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Quests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuestType",
                table: "Quests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
