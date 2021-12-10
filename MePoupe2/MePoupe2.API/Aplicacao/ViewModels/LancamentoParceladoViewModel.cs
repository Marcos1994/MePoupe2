using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Aplicacao.ViewModels
{
	public record LancamentoParceladoViewModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Categoria { get; set; }
		public int IdCaixa { get; set; }
		public bool Receita { get; set; }
		public float ValorTotal { get; set; }
		public DateTime DataLancamento { get; set; }
		public List<LancamentoBasicViewModel> Parcelas { get; set; }
	}

	public record ParcelaViewModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public float Valor { get; set; }
		public DateTime DataVencimento { get; set; }
		public int Estado { get; set; }
	}
}
