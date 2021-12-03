using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.DTOs
{
	public record FaturaInputModel : LancamentoInputModel
	{
		public CaixaInputModel CaixaOrigem { get; set; } //Caixa ao qual a fatura pertence
		public List<LancamentoInputModel> LancamentosFatura { get; set; } 
	}
}
