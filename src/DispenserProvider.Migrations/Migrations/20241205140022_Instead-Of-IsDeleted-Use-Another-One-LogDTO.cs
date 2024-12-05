using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DispenserProvider.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class InsteadOfIsDeletedUseAnotherOneLogDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispenser_Logs_LogSignature",
                table: "Dispenser");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Dispenser");

            migrationBuilder.RenameColumn(
                name: "LogSignature",
                table: "Dispenser",
                newName: "CreationLogSignature");

            migrationBuilder.RenameIndex(
                name: "IX_Dispenser_LogSignature",
                table: "Dispenser",
                newName: "IX_Dispenser_CreationLogSignature");

            migrationBuilder.AddColumn<string>(
                name: "DeletionLogSignature",
                table: "Dispenser",
                type: "nvarchar(132)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dispenser_DeletionLogSignature",
                table: "Dispenser",
                column: "DeletionLogSignature");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispenser_Logs_CreationLogSignature",
                table: "Dispenser",
                column: "CreationLogSignature",
                principalTable: "Logs",
                principalColumn: "Signature",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dispenser_Logs_DeletionLogSignature",
                table: "Dispenser",
                column: "DeletionLogSignature",
                principalTable: "Logs",
                principalColumn: "Signature",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispenser_Logs_CreationLogSignature",
                table: "Dispenser");

            migrationBuilder.DropForeignKey(
                name: "FK_Dispenser_Logs_DeletionLogSignature",
                table: "Dispenser");

            migrationBuilder.DropIndex(
                name: "IX_Dispenser_DeletionLogSignature",
                table: "Dispenser");

            migrationBuilder.DropColumn(
                name: "DeletionLogSignature",
                table: "Dispenser");

            migrationBuilder.RenameColumn(
                name: "CreationLogSignature",
                table: "Dispenser",
                newName: "LogSignature");

            migrationBuilder.RenameIndex(
                name: "IX_Dispenser_CreationLogSignature",
                table: "Dispenser",
                newName: "IX_Dispenser_LogSignature");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Dispenser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Dispenser_Logs_LogSignature",
                table: "Dispenser",
                column: "LogSignature",
                principalTable: "Logs",
                principalColumn: "Signature",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
