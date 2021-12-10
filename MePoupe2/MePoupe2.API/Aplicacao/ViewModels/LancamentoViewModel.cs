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
		public int Estado { get; set; }
	}

	public record LancamentoViewModel : LancamentoBasicViewModel
	{
		public int IdLancamentoParcelado { get; set; }
		public LancamentoParceladoViewModel LancamentoParcelado { get; set; }
	}
}
