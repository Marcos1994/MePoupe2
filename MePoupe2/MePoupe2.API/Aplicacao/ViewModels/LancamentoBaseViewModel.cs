using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Aplicacao.ViewModels
{
	public abstract record LancamentoBaseViewModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Categoria { get; set; }
		public int IdCaixa { get; set; }
		public bool Receita { get; set; }
		public float Valor { get; set; }
	}
}
