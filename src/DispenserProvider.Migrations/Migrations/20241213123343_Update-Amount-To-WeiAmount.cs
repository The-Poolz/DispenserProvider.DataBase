using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DispenserProvider.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAmountToWeiAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Builders");

            migrationBuilder.AddColumn<string>(
                name: "WeiAmount",
                table: "Builders",
                type: "nvarchar(78)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeiAmount",
                table: "Builders");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Builders",
                type: "decimal(36,18)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
