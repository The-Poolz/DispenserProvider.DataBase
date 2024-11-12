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
                name: "TransactionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChainId = table.Column<long>(type: "bigint", nullable: false),
                    PoolId = table.Column<long>(type: "bigint", nullable: false),
                    DispenserProviderId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Builders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(36,18)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    FinishTime = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    TransactionDetailId = table.Column<int>(type: "int", nullable: false)
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
                name: "DispenserProvider",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(42)", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WithdrawalDetailId = table.Column<int>(type: "int", nullable: false),
                    RefundDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispenserProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DispenserProvider_TransactionDetails_RefundDetailId",
                        column: x => x.RefundDetailId,
                        principalTable: "TransactionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DispenserProvider_TransactionDetails_WithdrawalDetailId",
                        column: x => x.WithdrawalDetailId,
                        principalTable: "TransactionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Signatures",
                columns: table => new
                {
                    Signature = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    IsRefund = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signatures", x => x.Signature);
                    table.ForeignKey(
                        name: "FK_Signatures_DispenserProvider_Signature",
                        column: x => x.Signature,
                        principalTable: "DispenserProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Builders_TransactionDetailId",
                table: "Builders",
                column: "TransactionDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_DispenserProvider_RefundDetailId",
                table: "DispenserProvider",
                column: "RefundDetailId",
                unique: true,
                filter: "[RefundDetailId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DispenserProvider_WithdrawalDetailId",
                table: "DispenserProvider",
                column: "WithdrawalDetailId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Builders");

            migrationBuilder.DropTable(
                name: "Signatures");

            migrationBuilder.DropTable(
                name: "DispenserProvider");

            migrationBuilder.DropTable(
                name: "TransactionDetails");
        }
    }
}
