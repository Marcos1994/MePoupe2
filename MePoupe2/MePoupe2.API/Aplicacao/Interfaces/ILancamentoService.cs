using MePoupe2.API.Aplicacao.InputModels;
using MePoupe2.API.Aplicacao.UpdateModels;
using MePoupe2.API.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Aplicacao.Interfaces
{
	public interface ILancamentoService
	{
		LancamentoViewModel CriarLancamento(LancamentoParceladoInputModel inputLancamento);
		void AtualizarLancamento(LancamentoUpdateModel updateLancamento);
		void EfetivarLancamento(int idLancamento);
		LancamentoParceladoViewModel ParcelarLancamento(int idLancamento, int quantidadeParcelas);
		void ExcluirLancamento(int idLancamento);
		void ExcluirParcelamento(int idLancamentoParcelado);
		IEnumerable<LancamentoBasicViewModel> ListarTodos(int idCaixa);
		IEnumerable<LancamentoBasicViewModel> ListarTodos(int idCaixa, bool receita);
		IEnumerable<LancamentoBasicViewModel> ListarPendentes(int idCaixa);
		IEnumerable<LancamentoBasicViewModel> ListarPendentes(int idCaixa, bool receita);
		LancamentoViewModel CarregarLancamento(int idLancamento);
		LancamentoParceladoViewModel CarregarLancamentoParcelado(int idLancamentoParcelado);
	}
}
