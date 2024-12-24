using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DispenserProvider.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class ManySignaturesToOneDispenser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispenser_Signatures_Signature",
                table: "Dispenser");

            migrationBuilder.DropIndex(
                name: "IX_Dispenser_Signature",
                table: "Dispenser");

            migrationBuilder.DropColumn(
                name: "Signature",
                table: "Dispenser");

            migrationBuilder.AddColumn<string>(
                name: "DispenserId",
                table: "Signatures",
                type: "nvarchar(64)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Signatures_DispenserId",
                table: "Signatures",
                column: "DispenserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Signatures_Dispenser_DispenserId",
                table: "Signatures",
                column: "DispenserId",
                principalTable: "Dispenser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Signatures_Dispenser_DispenserId",
                table: "Signatures");

            migrationBuilder.DropIndex(
                name: "IX_Signatures_DispenserId",
                table: "Signatures");

            migrationBuilder.DropColumn(
                name: "DispenserId",
                table: "Signatures");

            migrationBuilder.AddColumn<string>(
                name: "Signature",
                table: "Dispenser",
                type: "nvarchar(132)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dispenser_Signature",
                table: "Dispenser",
                column: "Signature",
                unique: true,
                filter: "[Signature] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispenser_Signatures_Signature",
                table: "Dispenser",
                column: "Signature",
                principalTable: "Signatures",
                principalColumn: "Signature",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
