using System;
using System.Collections.Generic;

namespace MePoupe2.API.DTOs
{
	public record LancamentoInputModel : LancamentoBaseInputModel
	{
		public DateTime DataLancamento { get; private set; }
		public DateTime DataVencimento { get; private set; }
		public bool Cancelado { get; private set; }
	}

	public record LancamentoParceladoInputModel
	{
		public int Id { get; private set; }
		public string Nome { get; private set; }
		public List<LancamentoInputModel> Parcelas { get; private set; }
	}
}
