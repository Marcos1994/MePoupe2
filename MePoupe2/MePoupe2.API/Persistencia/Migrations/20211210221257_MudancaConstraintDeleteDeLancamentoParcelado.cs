using Microsoft.EntityFrameworkCore.Migrations;

namespace MePoupe2.API.Persistencia.Migrations
{
    public partial class MudancaConstraintDeleteDeLancamentoParcelado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Lancamentos_tb_LancamentosParcelados_IdLancamentoParcelado",
                table: "tb_Lancamentos");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Lancamentos_tb_LancamentosParcelados_IdLancamentoParcelado",
                table: "tb_Lancamentos",
                column: "IdLancamentoParcelado",
                principalTable: "tb_LancamentosParcelados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Lancamentos_tb_LancamentosParcelados_IdLancamentoParcelado",
                table: "tb_Lancamentos");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Lancamentos_tb_LancamentosParcelados_IdLancamentoParcelado",
                table: "tb_Lancamentos",
                column: "IdLancamentoParcelado",
                principalTable: "tb_LancamentosParcelados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
