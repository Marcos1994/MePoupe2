using AutoMapper;
using MePoupe2.API.Aplicacao.Interfaces;
using MePoupe2.API.Aplicacao.ViewModels;
using MePoupe2.API.Persistencia.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Aplicacao.Servicos
{
	public class LancamentoService : ILancamentoService
	{
		private readonly ILancamentoRepository lancamentoContext;
		private readonly IMapper mapper;

		public LancamentoService(ILancamentoRepository lancamentoContext, IMapper mapper)
		{
			this.lancamentoContext = lancamentoContext;
			this.mapper = mapper;
		}

		public LancamentoViewModel CriarLancamento(LancamentoParceladoViewModel lancamento)
		{
			throw new NotImplementedException();
		}

		public void AtualizarLancamento(LancamentoUpdanteModel lancamento)
		{
			throw new NotImplementedException();
		}

		public LancamentoParceladoViewModel ParcelarLancamento(int idLancamento, int quantidadeParcelas)
		{
			throw new NotImplementedException();
		}

		public void ExcluirLancamento(int idLancamento)
		{
			throw new NotImplementedException();
		}

		public void ExcluirParcelamento(int idLancamentoParcelado)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<LancamentoBasicViewModel> ListarTodos(int idCaixa, bool? receita)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<LancamentoBasicViewModel> ListarPendentes(int idCaixa, bool? receita)
		{
			throw new NotImplementedException();
		}

		public LancamentoViewModel CarregarLancamento(int idLancamento)
		{
			throw new NotImplementedException();
		}

		public LancamentoParceladoViewModel CarregarLancamentoParcelado(int idLancamentoParcelado)
		{
			throw new NotImplementedException();
		}
	}
}
