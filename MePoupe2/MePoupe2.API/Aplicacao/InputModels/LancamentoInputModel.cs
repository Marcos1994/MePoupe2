using System;
using System.Collections.Generic;

namespace MePoupe2.API.Aplicacao.InputModels
{
	public record LancamentoInputModel : LancamentoBaseInputModel
	{
		public DateTime DataLancamento { get; set; }
		public DateTime DataVencimento { get; set; }
		public int Efetivado { get; set; }
	}

	public record LancamentoParceladoInputModel
	{
		public string Nome { get; set; }
		public List<LancamentoInputModel> Parcelas { get; set; }
	}
}
