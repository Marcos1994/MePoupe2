using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.DTOs
{
	public abstract record LancamentoBaseInputModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Categoria { get; set; }
		public CaixaInputModel Caixa { get; set; }
		public bool Receita { get; set; }
		public float Valor { get; set; }
	}
}
