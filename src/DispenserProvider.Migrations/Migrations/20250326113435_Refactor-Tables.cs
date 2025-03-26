using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DispenserProvider.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class RefactorTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAddress",
                table: "Dispenser");

            migrationBuilder.AddColumn<string>(
                name: "UserAddress",
                table: "TransactionDetails",
                type: "nvarchar(42)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_UserAddress_ChainId_PoolId",
                table: "TransactionDetails",
                columns: new[] { "UserAddress", "ChainId", "PoolId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TransactionDetails_UserAddress_ChainId_PoolId",
                table: "TransactionDetails");

            migrationBuilder.DropColumn(
                name: "UserAddress",
                table: "TransactionDetails");

            migrationBuilder.AddColumn<string>(
                name: "UserAddress",
                table: "Dispenser",
                type: "nvarchar(42)",
                nullable: false,
                defaultValue: "");
        }
    }
}
