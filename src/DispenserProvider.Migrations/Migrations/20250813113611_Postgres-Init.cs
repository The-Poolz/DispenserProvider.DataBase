using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DispenserProvider.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class PostgresInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Signature = table.Column<string>(type: "character varying(132)", maxLength: 132, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp(0) with time zone", precision: 0, nullable: false),
                    IsCreation = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Signature);
                });

            migrationBuilder.CreateTable(
                name: "TransactionDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserAddress = table.Column<string>(type: "character varying(42)", maxLength: 42, nullable: false),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProviderAddress = table.Column<string>(type: "character varying(42)", maxLength: 42, nullable: false),
                    WeiAmount = table.Column<string>(type: "character varying(78)", maxLength: 78, nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    FinishTime = table.Column<DateTime>(type: "timestamp(0) with time zone", precision: 0, nullable: true),
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
                    Id = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    RefundFinishTime = table.Column<DateTime>(type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    WithdrawalDetailId = table.Column<long>(type: "bigint", nullable: false),
                    RefundDetailId = table.Column<long>(type: "bigint", nullable: true),
                    CreationLogSignature = table.Column<string>(type: "character varying(132)", maxLength: 132, nullable: false),
                    DeletionLogSignature = table.Column<string>(type: "character varying(132)", maxLength: 132, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispenser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dispenser_Logs_CreationLogSignature",
                        column: x => x.CreationLogSignature,
                        principalTable: "Logs",
                        principalColumn: "Signature",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dispenser_Logs_DeletionLogSignature",
                        column: x => x.DeletionLogSignature,
                        principalTable: "Logs",
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

            migrationBuilder.CreateTable(
                name: "Signatures",
                columns: table => new
                {
                    Signature = table.Column<string>(type: "character varying(132)", maxLength: 132, nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "timestamp(0) with time zone", precision: 0, nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "timestamp(0) with time zone", precision: 0, nullable: false),
                    IsRefund = table.Column<bool>(type: "boolean", nullable: false),
                    DispenserId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signatures", x => x.Signature);
                    table.ForeignKey(
                        name: "FK_Signatures_Dispenser_DispenserId",
                        column: x => x.DispenserId,
                        principalTable: "Dispenser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TakenTrack",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsRefunded = table.Column<bool>(type: "boolean", nullable: false),
                    DispenserId = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakenTrack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TakenTrack_Dispenser_DispenserId",
                        column: x => x.DispenserId,
                        principalTable: "Dispenser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Builders_TransactionDetailId",
                table: "Builders",
                column: "TransactionDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Dispenser_CreationLogSignature",
                table: "Dispenser",
                column: "CreationLogSignature");

            migrationBuilder.CreateIndex(
                name: "IX_Dispenser_DeletionLogSignature",
                table: "Dispenser",
                column: "DeletionLogSignature");

            migrationBuilder.CreateIndex(
                name: "IX_Dispenser_RefundDetailId",
                table: "Dispenser",
                column: "RefundDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dispenser_WithdrawalDetailId",
                table: "Dispenser",
                column: "WithdrawalDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Signatures_DispenserId",
                table: "Signatures",
                column: "DispenserId");

            migrationBuilder.CreateIndex(
                name: "IX_TakenTrack_DispenserId",
                table: "TakenTrack",
                column: "DispenserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetails_UserAddress_ChainId_PoolId",
                table: "TransactionDetails",
                columns: new[] { "UserAddress", "ChainId", "PoolId" },
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
                name: "TakenTrack");

            migrationBuilder.DropTable(
                name: "Dispenser");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "TransactionDetails");
        }
    }
}
