using System;
using System.Collections.Generic;

namespace MePoupe2.API.DTOs
{
	public record LancamentoInputModel : LancamentoBaseInputModel
	{
		public DateTime DataLancamento { get; set; }
		public DateTime DataVencimento { get; set; }
		public bool Cancelado { get; set; }
	}

	public record LancamentoParceladoInputModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public List<LancamentoInputModel> Parcelas { get; set; }
	}
}
