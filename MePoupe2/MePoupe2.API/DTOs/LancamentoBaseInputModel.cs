using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.DTOs
{
	public abstract record LancamentoBaseInputModel
	{
		public int Id { get; private set; }
		public string Nome { get; private set; }
		public string Categoria { get; private set; }
		public CaixaInputModel Caixa { get; private set; }
		public bool Receita { get; private set; }
		public float Valor { get; private set; }
	}
}
