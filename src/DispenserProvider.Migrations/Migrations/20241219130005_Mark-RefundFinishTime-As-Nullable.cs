using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DispenserProvider.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class MarkRefundFinishTimeAsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RefundFinishTime",
                table: "Dispenser",
                type: "datetime2(0)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RefundFinishTime",
                table: "Dispenser",
                type: "datetime2(0)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldNullable: true);
        }
    }
}
