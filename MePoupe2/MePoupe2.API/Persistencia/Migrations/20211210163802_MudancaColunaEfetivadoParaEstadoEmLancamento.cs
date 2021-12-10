using Microsoft.EntityFrameworkCore.Migrations;

namespace MePoupe2.API.Persistencia.Migrations
{
    public partial class MudancaColunaEfetivadoParaEstadoEmLancamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Efetivado",
                table: "tb_Lancamentos",
                newName: "Estado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "tb_Lancamentos",
                newName: "Efetivado");
        }
    }
}
