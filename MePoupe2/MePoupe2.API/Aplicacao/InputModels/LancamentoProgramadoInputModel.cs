using System;


namespace MePoupe2.API.Aplicacao.InputModels
{
	public record LancamentoProgramadoInputModel : LancamentoBaseInputModel
	{
		public DateTime ProximoLancamento { get; set; }
		public int Periodo { get; set; }
	}
}