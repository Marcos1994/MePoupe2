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
using MePoupe2.API.Aplicacao.UpdateModels;

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

			float quantiaEfetivada = 0;

			for (int i = 0; i < inputLancamento.Parcelas.Count; i++)
			{
				inputLancamento.Parcelas[i].Lancamento = inputLancamento;

				switch(inputLancamento.Parcelas[i].Estado)
				{
					case (int)EnumEstadoLancamento.Efetivado:
						quantiaEfetivada += inputLancamento.Parcelas[i].Valor;
						break;
					case (int)EnumEstadoLancamento.Cancelado:
						throw new Exception("Não é possível criar um lançamento com parcelas canceladas.");
				}
			}

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

		public void AtualizarLancamento(LancamentoUpdateModel updateLancamento)
		{
			Lancamento lancamento = lancamentoContext.GetById(updateLancamento.Id);

			if (lancamento.Estado == (int)EnumEstadoLancamento.Efetivado)
				throw new Exception("Não é possível editar um lançamento já efetivado.");

			lancamento.Update(updateLancamento.Nome, updateLancamento.Valor, updateLancamento.DataLancamento, updateLancamento.DataVencimento);

			if(lancamento.Categoria != updateLancamento.Categoria)
			{
				if (lancamento.IdLancamentoParcelado == null)
					lancamento.UpdateCategoria(updateLancamento.Categoria);
				else
				{
					LancamentoParcelado lancamentoParcelado = lancamentoContext.GetLancamentoParcelado((int)lancamento.IdLancamentoParcelado);
					lancamentoParcelado.Parcelas.AddRange(lancamentoContext.GetParcelas((int)lancamento.IdLancamentoParcelado));
					for (int i = 0; i < lancamentoParcelado.Parcelas.Count; i++)
						lancamentoParcelado.Parcelas[i].UpdateCategoria(updateLancamento.Categoria);
					lancamentoContext.Update(lancamentoParcelado);
					return;
				}
			}
			lancamentoContext.Update(lancamento);
		}

		public void EfetivarLancamento(int idLancamento)
		{
			Lancamento lancamento = lancamentoContext.GetById(idLancamento);

			switch(lancamento.Estado)
			{
				case (int)EnumEstadoLancamento.Cancelado:
					throw new Exception("Não é possível efetivar um lançamento cancelado");
				case (int)EnumEstadoLancamento.Efetivado:
					return;
			}

			if (!lancamento.Receita)
			{
				float quantiaEmCaixa = caixaContext.GetQuantia(lancamento.IdCaixa);
				if (lancamento.Valor > quantiaEmCaixa)
					throw new Exception("Não há quantia suficiente em caixa para efetivar esta despesa.");
			}

			lancamento.UpdateEstado((int)EnumEstadoLancamento.Efetivado);
			lancamentoContext.Update(lancamento);
		}

		public LancamentoParceladoViewModel ParcelarLancamento(int idLancamento, int quantidadeParcelas)
		{
			Lancamento lancamentoInput = lancamentoContext.GetById(idLancamento);

			if (lancamentoInput.IdLancamentoParcelado != null)
				throw new Exception("Não é possível parcelar um lançamento parcelado.");

			if(lancamentoInput.Estado != (int) EnumEstadoLancamento.Pendente)
				throw new Exception("Só é possível parcelar lançamentos pendentes.");

			if (quantidadeParcelas < 2)
				throw new Exception("Não é possível parcelar um lançamento em menos de 2 parcelas.");

			float valor = (float)Math.Floor((lancamentoInput.Valor / quantidadeParcelas) * 100) / 100;

			LancamentoParceladoInputModel lancamentoParceladoInput = mapper.Map<LancamentoParceladoInputModel>(lancamentoInput);
			for (int i = 1; i <= quantidadeParcelas; i++)
			{
				lancamentoParceladoInput.Parcelas
					.Add(new LancamentoInputModel() {
						Nome = $"{lancamentoInput.Nome} ({i}/{quantidadeParcelas})",
						Estado = (int) EnumEstadoLancamento.Pendente,
						DataVencimento = lancamentoInput.DataVencimento,
						Valor = valor
					});
			}
			lancamentoParceladoInput.Parcelas[0].Valor += (float)((lancamentoInput.Valor * 100) % quantidadeParcelas) / 100;

			string transacao = "ParcelandoLancamento";
			int idLancamentoView = 0;
			try
			{
				lancamentoContext.StartTransaction(transacao);
				LancamentoViewModel lancamentoView = CriarLancamento(lancamentoParceladoInput);
				ExcluirLancamento(idLancamento);
				lancamentoContext.FinishTransaction();
				idLancamentoView = lancamentoView.IdLancamentoParcelado;
			}
			catch (Exception ex)
			{
				lancamentoContext.RollbackTransaction(transacao);
				throw new Exception("Não foi possível realizar o parcelamento.\n"+ex.Message);
			}
			return CarregarLancamentoParcelado(idLancamentoView);
		}

		public void ExcluirLancamento(int idLancamento)
		{
			Lancamento lancamento = lancamentoContext.GetById(idLancamento);

			if (lancamento.Estado == (int)EnumEstadoLancamento.Efetivado)
				throw new Exception("Não é possível excluir um lançamento já efetivado.");

			if (lancamento.IdLancamentoParcelado != null)
				throw new Exception("Não é possível excluir apenas uma parcela de um lançamento.");

			lancamentoContext.Delete(lancamento);
		}

		public void ExcluirParcelamento(int idLancamentoParcelado)
		{
			LancamentoParcelado lancamentoParcelado = lancamentoContext.GetLancamentoParcelado(idLancamentoParcelado);
			lancamentoParcelado.Parcelas.AddRange(lancamentoContext.GetParcelas(idLancamentoParcelado));

			bool possuiParcelasEfetivadas = lancamentoParcelado.Parcelas.Any(p => p.Estado == (int) EnumEstadoLancamento.Efetivado);

			if(possuiParcelasEfetivadas)
			{
				for (int i = 0; i < lancamentoParcelado.Parcelas.Count; i++)
				{
					if (lancamentoParcelado.Parcelas[i].Estado == (int)EnumEstadoLancamento.Pendente)
						lancamentoParcelado.Parcelas[i].UpdateEstado((int)EnumEstadoLancamento.Cancelado);
				}
				lancamentoContext.Update(lancamentoParcelado);
			}
			else
			{
				lancamentoContext.Delete(lancamentoParcelado);
			}
		}

		public IEnumerable<LancamentoBasicViewModel> ListarTodos(int idCaixa)
		{
			return mapper.Map<List<LancamentoBasicViewModel>>(lancamentoContext.GetAll(idCaixa));
		}

		public IEnumerable<LancamentoBasicViewModel> ListarTodos(int idCaixa, bool receita)
		{
			return mapper.Map<List<LancamentoBasicViewModel>>(lancamentoContext.GetAll(idCaixa, receita));
		}

		public IEnumerable<LancamentoBasicViewModel> ListarPendentes(int idCaixa)
		{
			return mapper.Map<List<LancamentoBasicViewModel>>(lancamentoContext.GetAll(idCaixa).Select(l=>l.Estado == (int) EnumEstadoLancamento.Pendente));
		}

		public IEnumerable<LancamentoBasicViewModel> ListarPendentes(int idCaixa, bool receita)
		{
			return mapper.Map<List<LancamentoBasicViewModel>>(lancamentoContext.GetAll(idCaixa, receita).Select(l => l.Estado == (int)EnumEstadoLancamento.Pendente));
		}

		public LancamentoViewModel CarregarLancamento(int idLancamento)
		{
			return mapper.Map<LancamentoViewModel>(lancamentoContext.GetById(idLancamento));
		}

		public LancamentoParceladoViewModel CarregarLancamentoParcelado(int idLancamentoParcelado)
		{
			LancamentoParcelado lancamentoParcelado = lancamentoContext.GetLancamentoParcelado(idLancamentoParcelado);
			lancamentoParcelado.Parcelas.AddRange(lancamentoContext.GetParcelas(idLancamentoParcelado));
			LancamentoParceladoViewModel lancamentoParceladoView = mapper.Map<LancamentoParceladoViewModel>(lancamentoParcelado);
			return lancamentoParceladoView;
		}
	}
}
