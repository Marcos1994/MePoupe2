using System;
using System.Collections.Generic;

namespace MePoupe2.API.Aplicacao.InputModels
{
	public record LancamentoInputModel
	{
		public string Nome { get; set; }
		public float Valor { get; set; }
		public DateTime DataVencimento { get; set; }
		public int Estado { get; set; }
		public LancamentoParceladoInputModel Lancamento { get; set; }
	}

	public record LancamentoParceladoInputModel
	{
		public string Nome { get; set; }
		public string Categoria { get; set; }
		public int IdCaixa { get; set; }
		public bool Receita { get; set; }
		public float Valor { get; set; }
		public DateTime DataLancamento { get; set; }
		public List<LancamentoInputModel> Parcelas { get; set; }
	}
}
