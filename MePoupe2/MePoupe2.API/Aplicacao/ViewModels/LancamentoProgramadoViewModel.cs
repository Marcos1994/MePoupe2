using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Aplicacao.ViewModels
{
	public record LancamentoProgramadoBasicViewModel : LancamentoBaseViewModel
	{
		public DateTime ProximoLancamento { get; private set; }
	}

	public record LancamentoProgramadoViewModel : LancamentoProgramadoBasicViewModel
	{
		public int Periodo { get; private set; }
	}
}
