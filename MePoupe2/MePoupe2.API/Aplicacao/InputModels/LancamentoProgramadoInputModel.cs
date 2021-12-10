using System;


namespace MePoupe2.API.Aplicacao.InputModels
{
	public record LancamentoProgramadoInputModel
	{
		public string Nome { get; set; }
		public string Categoria { get; set; }
		public int IdCaixa { get; set; }
		public bool Receita { get; set; }
		public float Valor { get; set; }
		public DateTime ProximoLancamento { get; set; }
		public int Periodo { get; set; }
	}
}