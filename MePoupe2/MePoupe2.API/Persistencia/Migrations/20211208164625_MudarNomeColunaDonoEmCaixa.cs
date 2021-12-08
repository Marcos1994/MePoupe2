using Microsoft.EntityFrameworkCore.Migrations;

namespace MePoupe2.API.Persistencia.Migrations
{
    public partial class MudarNomeColunaDonoEmCaixa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dono",
                table: "tb_Caixas",
                newName: "IdDono");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdDono",
                table: "tb_Caixas",
                newName: "Dono");
        }
    }
}
