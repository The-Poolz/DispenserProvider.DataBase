using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DispenserProvider.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOperationToIsCreationInLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operation",
                table: "Logs");

            migrationBuilder.AddColumn<bool>(
                name: "IsCreation",
                table: "Logs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCreation",
                table: "Logs");

            migrationBuilder.AddColumn<string>(
                name: "Operation",
                table: "Logs",
                type: "nvarchar(32)",
                nullable: false,
                defaultValue: "");
        }
    }
}
