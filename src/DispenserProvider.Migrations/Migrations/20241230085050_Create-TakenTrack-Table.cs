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
                    table.ForeignKey(
                        name: "FK_TakenTrack_Dispenser_DispenserId",
                        column: x => x.DispenserId,
                        principalTable: "Dispenser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TakenTrack_DispenserId",
                table: "TakenTrack",
                column: "DispenserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TakenTrack");
        }
    }
}
