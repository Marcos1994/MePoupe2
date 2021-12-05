using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Persistencia.Entidades
{
	public class Fatura : Lancamento
	{
		public Fatura(string nome, string categoria, int idCaixa, bool receita, float valor, DateTime dataLancamento, DateTime dataVencimento, int efetivado, int idCaixaOrigem, List<LancamentoFatura> lancamentosFatura)
			: base(nome, categoria, idCaixa, receita, valor, dataLancamento, dataVencimento, efetivado, 0)
		{
			IdCaixaOrigem = idCaixaOrigem;
			LancamentosFatura = lancamentosFatura;
		}

		public int IdCaixaOrigem { get; private set; } //Caixa ao qual a fatura pertence
		public List<LancamentoFatura> LancamentosFatura { get; private set; }
	}

	public class LancamentoFatura
	{
		public LancamentoFatura(int idLancamento, int idFatura)
		{
			IdLancamento = idLancamento;
			IdFatura = idFatura;
		}

		public int IdLancamento { get; private set; }
		public int IdFatura { get; private set; }
	}
}
