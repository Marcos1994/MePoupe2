using AutoMapper;
using MePoupe2.API.Aplicacao.Enumerators;
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
		private readonly ICaixaRepository caixaContext;
		private readonly IMapper mapper;
		public CaixaService(ICaixaRepository caixaContext, IMapper mapper)
		{
			this.caixaContext = caixaContext;
			this.mapper = mapper;
		}

		public CaixaViewModel CriarCaixa(CaixaInputModel inputCaixa)
		{
			Caixa caixa = mapper.Map<Caixa>(inputCaixa);
			caixaContext.Add(caixa);
			return mapper.Map<CaixaViewModel>(caixa);
		}

		public void AtualizarCaixa(CaixaUpdateModel inputCaixa)
		{
			Caixa caixa = caixaContext.GetById(inputCaixa.Id);
			caixa.Update(inputCaixa.Nome, inputCaixa.Descricao, caixa.Ativo);
			caixaContext.Update(caixa);
		}

		public void AtivarCaixa(int idCaixa, bool ativo)
		{
			Caixa caixa = caixaContext.GetById(idCaixa);
			caixa.Update(caixa.Nome, caixa.Descricao, ativo);
			if (!ativo)
			{
				//Caso haja algum lançamento que ainda não foi efetivado, impedir a desativação até que os lançamenso sejam transferidos para outro caixa.
			}
			caixaContext.Update(caixa);
		}

		public void ExcluirCaixa(int idCaixa)
		{
			if (false) //Verifica se tem algum lançamento nesse caixa.
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
			List<CaixaBasicViewModel> caixas = mapper.Map<List<CaixaBasicViewModel>>(caixaContext.GetAll(idUsuario));

			return caixas;
		}

		public CaixaViewModel CarregarCaixa(int idCaixa)
		{
			Caixa caixa = caixaContext.GetById(idCaixa);
			if (caixa == null)
				return null;
			CaixaViewModel caixaView = mapper.Map<CaixaViewModel>(caixa);
			caixaView.Quantia = QuantiaCaixa(idCaixa);
			return caixaView;
		}

		public float QuantiaCaixa(int idCaixa)
		{
			return caixaContext.GetQuantia(idCaixa);
		}
	}
}
