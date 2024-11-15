using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DispenserProvider.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Signature = table.Column<string>(type: "nvarchar(132)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Signature);
                });

            migrationBuilder.CreateTable(
                name: "Signatures",
                columns: table => new
                {
                    Signature = table.Column<string>(type: "nvarchar(132)", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    IsRefund = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signatures", x => x.Signature);
                });

            migrationBuilder.CreateTable(
                name: "TransactionDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChainId = table.Column<long>(type: "bigint", nullable: false),
                    PoolId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Builders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(36,18)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    FinishTime = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    TransactionDetailId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Builders_TransactionDetails_TransactionDetailId",
                        column: x => x.TransactionDetailId,
                        principalTable: "TransactionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dispenser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(42)", nullable: false),
                    RefundFinishTime = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(132)", nullable: true),
                    WithdrawalDetailId = table.Column<long>(type: "bigint", nullable: false),
                    RefundDetailId = table.Column<long>(type: "bigint", nullable: true),
                    LogSignature = table.Column<string>(type: "nvarchar(132)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispenser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dispenser_Logs_LogSignature",
                        column: x => x.LogSignature,
                        principalTable: "Logs",
                        principalColumn: "Signature",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dispenser_Signatures_Signature",
                        column: x => x.Signature,
                        principalTable: "Signatures",
                        principalColumn: "Signature",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dispenser_TransactionDetails_RefundDetailId",
                        column: x => x.RefundDetailId,
                        principalTable: "TransactionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dispenser_TransactionDetails_WithdrawalDetailId",
                        column: x => x.WithdrawalDetailId,
                        principalTable: "TransactionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Builders_TransactionDetailId",
                table: "Builders",
                column: "TransactionDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Dispenser_LogSignature",
                table: "Dispenser",
                column: "LogSignature");

            migrationBuilder.CreateIndex(
                name: "IX_Dispenser_RefundDetailId",
                table: "Dispenser",
                column: "RefundDetailId",
                unique: true,
                filter: "[RefundDetailId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Dispenser_Signature",
                table: "Dispenser",
                column: "Signature",
                unique: true,
                filter: "[Signature] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Dispenser_WithdrawalDetailId",
                table: "Dispenser",
                column: "WithdrawalDetailId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Builders");

            migrationBuilder.DropTable(
                name: "Dispenser");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Signatures");

            migrationBuilder.DropTable(
                name: "TransactionDetails");
        }
    }
}
