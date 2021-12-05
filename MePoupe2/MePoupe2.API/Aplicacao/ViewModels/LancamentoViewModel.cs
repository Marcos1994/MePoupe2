using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Aplicacao.ViewModels
{
	public record LancamentoBasicViewModel : LancamentoBaseViewModel
	{
		public DateTime DataLancamento { get; set; }
		public DateTime DataVencimento { get; set; }
		public int Efetivado { get; set; }
		public int Parcelas { get; set; }
	}

	public record LancamentoViewModel : LancamentoBaseViewModel
	{
		public DateTime DataLancamento { get; set; }
		public DateTime DataVencimento { get; set; }
		public int Efetivado { get; set; }
		public LancamentoParceladoViewModel LancamentoParcelado { get; set; }
	}

	public record LancamentoParceladoViewModel
	{
		public string Nome { get; set; }
		public List<LancamentoBasicViewModel> Parcelas { get; set; }
	}
}
