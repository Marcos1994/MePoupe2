using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Aplicacao.UpdateModels
{
	public record CaixaUpdateModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
	}
}
