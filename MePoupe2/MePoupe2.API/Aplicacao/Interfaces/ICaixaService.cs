using MePoupe2.API.Aplicacao.InputModels;
using MePoupe2.API.Aplicacao.UpdateModels;
using MePoupe2.API.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Aplicacao.Interfaces
{
	public interface ICaixaService
	{
		CaixaViewModel CriarCaixa(CaixaInputModel inputCaixa);
		void AtualizarCaixa(CaixaUpdateModel inputCaixa);
		void AtivarCaixa(int idCaixa, bool ativo);
		void ExcluirCaixa(int idCaixa);
		IEnumerable<CaixaBasicViewModel> ListarCaixas(int idUsuario);
		CaixaViewModel CarregarCaixa(int idCaixa);
	}
}
