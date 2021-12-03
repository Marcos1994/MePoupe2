using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Entidades
{
	public class FaturaModel : LancamentoModel
	{
		public FaturaModel(int id, string nome, string categoria, CaixaModel caixa, bool receita, float valor, DateTime dataLancamento, DateTime dataVencimento, bool cancelado, CaixaModel caixaOrigem, List<LancamentoModel> lancamentosFatura)
			: base(id, nome, categoria, caixa, receita, valor, dataLancamento, dataVencimento, cancelado)
		{
			CaixaOrigem = caixaOrigem;
			LancamentosFatura = lancamentosFatura;
		}

		public CaixaModel CaixaOrigem { get; private set; } //Caixa ao qual a fatura pertence
		public List<LancamentoModel> LancamentosFatura { get; private set; }
	}
}
