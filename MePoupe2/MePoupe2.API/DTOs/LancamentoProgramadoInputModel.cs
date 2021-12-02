using System;


namespace MePoupe2.API.DTOs
{
	public record LancamentoProgramadoInputModel : LancamentoBaseInputModel
	{
		public DateTime ProximoLancamento { get; private set; }
		public int Periodo { get; private set; }
	}
}