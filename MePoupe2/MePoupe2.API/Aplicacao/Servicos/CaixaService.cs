using MePoupe2.API.Aplicacao.InputModels;
using MePoupe2.API.Aplicacao.Interfaces;
using MePoupe2.API.Aplicacao.UpdateModels;
using MePoupe2.API.Aplicacao.ViewModels;
using MePoupe2.API.Persistencia.Entidades;
using MePoupe2.API.Persistencia.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Aplicacao.Servicos
{
	public class CaixaService : ICaixaService
	{
		private readonly ICaixaReposiroty caixaContext;
		public CaixaService(ICaixaReposiroty caixaContext)
		{
			this.caixaContext = caixaContext;
		}

		public CaixaViewModel CriarCaixa(CaixaInputModel inputCaixa)
		{
			Caixa caixa = new Caixa(inputCaixa.Dono, inputCaixa.Nome, inputCaixa.Descricao, inputCaixa.Quantia, null, true);
			caixaContext.Add(caixa);
			return new CaixaViewModel { Id=caixa.Id, Ativo=caixa.Ativo, Descricao=caixa.Descricao, Nome=caixa.Nome, Quantia=caixa.Quantia };
		}

		public void AtualizarCaixa(CaixaUpdateModel inputCaixa)
		{
			Caixa caixa = caixaContext.GetById(inputCaixa.Id);
			caixa.Update(inputCaixa.Nome, inputCaixa.Descricao, caixa.Quantia, caixa.Ativo);
			caixaContext.Update(caixa);
		}

		public void AtivarCaixa(int idCaixa, bool ativo)
		{
			Caixa caixa = caixaContext.GetById(idCaixa);
			caixa.Update(caixa.Nome, caixa.Descricao, caixa.Quantia, ativo);
			if (!ativo)
			{
				//Caso haja algum lançamento que ainda não foi efetivado, impedir a desativação até que os lançamenso sejam transferidos para outro caixa.
			}
			caixaContext.Update(caixa);
		}

		public void ExcluirCaixa(int idCaixa)
		{
			if(false) //Verifica se tem algum lançamento nesse caixa.
			{
				AtivarCaixa(idCaixa, false);
			}
			else
			{
				Caixa caixa = caixaContext.GetById(idCaixa);
				caixaContext.Delete(caixa);
			}
		}

		public IEnumerable<CaixaBasicViewModel> ListarCaixas(int idUsuario)
		{
			var caixas = caixaContext.GetAll(idUsuario).ToList();
			List<CaixaBasicViewModel> caixasViewModel = new List<CaixaBasicViewModel>();
			for (int i = 0; i < caixas.Count; i++)
				caixasViewModel.Add(new CaixaBasicViewModel { Id=caixas[i].Id, Ativo=caixas[i].Ativo, Nome=caixas[i].Nome, Quantia=caixas[i].Quantia });
			return caixasViewModel;
		}

		public CaixaViewModel CarregarCaixa(int idCaixa)
		{
			Caixa caixa = caixaContext.GetById(idCaixa);
			if (caixa == null)
				return null;
			return new CaixaViewModel { Id = caixa.Id, Ativo = caixa.Ativo, Descricao = caixa.Descricao, Nome = caixa.Nome, Quantia=caixa.Quantia };
		}
	}
}
