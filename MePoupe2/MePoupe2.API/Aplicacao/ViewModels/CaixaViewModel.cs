using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Aplicacao.ViewModels
{
	public record CaixaBasicViewModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public float Quantia { get; set; }
		public bool Ativo { get; set; }
	}

	public record CaixaViewModel : CaixaBasicViewModel
	{
		public CaixaViewModel()
		{
			Lancamentos = new List<LancamentoBaseViewModel>();
		}
		public string Descricao { get; set; }
		public LancamentoProgramadoBasicViewModel FaturaCartaoCredito { get; set; }
		public List<LancamentoBaseViewModel> Lancamentos { get; set; }
	}
}
