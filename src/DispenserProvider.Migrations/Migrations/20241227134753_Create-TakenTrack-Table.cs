using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DispenserProvider.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class CreateTakenTrackTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TakenTrackId",
                table: "Dispenser",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TakenTrack",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Taken = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    DispenserId = table.Column<string>(type: "nvarchar(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakenTrack", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dispenser_TakenTrackId",
                table: "Dispenser",
                column: "TakenTrackId",
                unique: true,
                filter: "[TakenTrackId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispenser_TakenTrack_TakenTrackId",
                table: "Dispenser",
                column: "TakenTrackId",
                principalTable: "TakenTrack",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispenser_TakenTrack_TakenTrackId",
                table: "Dispenser");

            migrationBuilder.DropTable(
                name: "TakenTrack");

            migrationBuilder.DropIndex(
                name: "IX_Dispenser_TakenTrackId",
                table: "Dispenser");

            migrationBuilder.DropColumn(
                name: "TakenTrackId",
                table: "Dispenser");
        }
    }
}
