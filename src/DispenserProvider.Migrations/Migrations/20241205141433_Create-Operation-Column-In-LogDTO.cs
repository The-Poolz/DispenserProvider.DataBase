using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DispenserProvider.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class CreateOperationColumnInLogDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Operation",
                table: "Logs",
                type: "nvarchar(32)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operation",
                table: "Logs");
        }
    }
}
