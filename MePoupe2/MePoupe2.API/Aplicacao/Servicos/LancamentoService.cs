using AutoMapper;
using MePoupe2.API.Aplicacao.Interfaces;
using MePoupe2.API.Aplicacao.ViewModels;
using MePoupe2.API.Persistencia.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MePoupe2.API.Persistencia.Entidades;
using MePoupe2.API.Aplicacao.InputModels;
using MePoupe2.API.Aplicacao.Enumerators;

namespace MePoupe2.API.Aplicacao.Servicos
{
	public class LancamentoService : ILancamentoService
	{
		private readonly ILancamentoRepository lancamentoContext;
		private readonly IMapper mapper;
		private readonly ICaixaRepository caixaContext;

		public LancamentoService(ILancamentoRepository lancamentoContext, ICaixaRepository caixaContext, IMapper mapper)
		{
			this.lancamentoContext = lancamentoContext;
			this.caixaContext = caixaContext;
			this.mapper = mapper;
		}

		public LancamentoViewModel CriarLancamento(LancamentoParceladoInputModel inputLancamento)
		{
			Caixa caixa = caixaContext.GetById(inputLancamento.IdCaixa);
			if (caixa == null)
				return null;

			float quantiaTotal = 0;
			float quantiaEfetivada = 0;

			for (int i = 0; i < inputLancamento.Parcelas.Count; i++)
			{
				quantiaTotal += inputLancamento.Parcelas[i].Valor;

				if (inputLancamento.Parcelas[i].IdCaixa != inputLancamento.IdCaixa)
					throw new Exception("Não é possível criar um lançamento cujas parcelas sejam de caixas diferentes.");

				if (inputLancamento.Parcelas[i].Receita != inputLancamento.Receita)
					throw new Exception("Não é possível criar um lançamento cujas parcelas possuam receiras e despesas.");

				if (inputLancamento.Parcelas[i].Estado == Convert.ToInt16(EnumEstadoLancamento.Efetivado))
					quantiaEfetivada += inputLancamento.Parcelas[i].Valor;

				if (inputLancamento.Parcelas[i].Estado == Convert.ToInt16(EnumEstadoLancamento.Cancelado))
					throw new Exception("Não é possível criar um lançamento com parcelas canceladas.");
			}

			if(quantiaTotal != inputLancamento.Valor)
				throw new Exception("O valor das parcelas do lançamento é diferente do valor total do lançamento.");

			if (inputLancamento.Receita)
			{
				//Validacao para cartões de credito
				if (caixa.IdFaturaCartaoCredito != null && inputLancamento.Parcelas.Count > 1)
					throw new Exception("Não é possível lançar uma receita parcelada em um caixa do tipo Cartão de Crédito.");
			}
			else
			{
				if(quantiaEfetivada > caixaContext.GetQuantia(caixa.Id))
					throw new Exception("O caixa não tem valor sucifiente para receber esta despesa.");
			}

			if(inputLancamento.Parcelas.Count == 1)
			{
				Lancamento lancamento = mapper.Map<Lancamento>(inputLancamento.Parcelas[0]);
				lancamentoContext.Add(lancamento);
				return mapper.Map<LancamentoViewModel>(lancamento);
			}
			LancamentoParcelado lancamentoParcelado = mapper.Map<LancamentoParcelado>(inputLancamento);
			lancamentoContext.Add(lancamentoParcelado);
			return mapper.Map<LancamentoViewModel>(lancamentoParcelado.Parcelas[0]);
		}

		public void AtualizarLancamento(LancamentoUpdanteModel inputLancamento)
		{
			throw new NotImplementedException();
		}

		public void EfetivarLancamento(int idLancamento)
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

		public IEnumerable<LancamentoBasicViewModel> ListarTodos(int idCaixa)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<LancamentoBasicViewModel> ListarTodos(int idCaixa, bool receita)
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
