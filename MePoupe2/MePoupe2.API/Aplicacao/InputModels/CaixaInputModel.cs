using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Aplicacao.InputModels
{
	public record CaixaInputModel
	{
		public int IdDono { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public LancamentoProgramadoInputModel FaturaCartaoCredito { get; set; }
	}
}
