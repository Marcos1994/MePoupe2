using Microsoft.EntityFrameworkCore.Migrations;

namespace MePoupe2.API.Persistencia.Migrations
{
    public partial class RemocaoColunaQuantiaEmCaixa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantia",
                table: "tb_Caixas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Quantia",
                table: "tb_Caixas",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
