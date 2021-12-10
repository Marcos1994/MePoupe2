using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Aplicacao.UpdateModels
{
	public record LancamentoUpdateModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Categoria { get; set; }
		public float Valor { get; set; }
		public DateTime DataLancamento { get; set; }
		public DateTime DataVencimento { get; set; }
	}
}
