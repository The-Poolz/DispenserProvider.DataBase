using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DispenserProvider.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMessageIndexColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageIndex",
                table: "Dispenser");

            migrationBuilder.DropColumn(
                name: "MessageIndex",
                table: "Builders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessageIndex",
                table: "Dispenser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MessageIndex",
                table: "Builders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
