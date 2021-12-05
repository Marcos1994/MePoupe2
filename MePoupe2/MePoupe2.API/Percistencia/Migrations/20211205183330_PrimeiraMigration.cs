using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MePoupe2.API.Percistencia.Migrations
{
    public partial class PrimeiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Caixas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dono = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantia = table.Column<float>(type: "real", nullable: false),
                    IdFaturaCartaoCredito = table.Column<int>(type: "int", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Caixas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_LancamentosParcelados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_LancamentosParcelados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Lancamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Efetivado = table.Column<int>(type: "int", nullable: false),
                    IdLancamentoParcelado = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCaixa = table.Column<int>(type: "int", nullable: false),
                    Receita = table.Column<bool>(type: "bit", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Lancamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Lancamentos_tb_Caixas_IdCaixa",
                        column: x => x.IdCaixa,
                        principalTable: "tb_Caixas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_Lancamentos_tb_LancamentosParcelados_IdLancamentoParcelado",
                        column: x => x.IdLancamentoParcelado,
                        principalTable: "tb_LancamentosParcelados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Lancamentos_IdCaixa",
                table: "tb_Lancamentos",
                column: "IdCaixa");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Lancamentos_IdLancamentoParcelado",
                table: "tb_Lancamentos",
                column: "IdLancamentoParcelado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Lancamentos");

            migrationBuilder.DropTable(
                name: "tb_Caixas");

            migrationBuilder.DropTable(
                name: "tb_LancamentosParcelados");
        }
    }
}
