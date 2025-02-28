using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fiiApi.Migrations
{
    /// <inheritdoc />
    public partial class AddInvestidor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Investidores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investidores", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InvestidorFundos",
                columns: table => new
                {
                    CarteiraId = table.Column<int>(type: "int", nullable: false),
                    InvestidoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestidorFundos", x => new { x.CarteiraId, x.InvestidoresId });
                    table.ForeignKey(
                        name: "FK_InvestidorFundos_FundosImobiliarios_CarteiraId",
                        column: x => x.CarteiraId,
                        principalTable: "FundosImobiliarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvestidorFundos_Investidores_InvestidoresId",
                        column: x => x.InvestidoresId,
                        principalTable: "Investidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_InvestidorFundos_InvestidoresId",
                table: "InvestidorFundos",
                column: "InvestidoresId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestidorFundos");

            migrationBuilder.DropTable(
                name: "Investidores");
        }
    }
}
