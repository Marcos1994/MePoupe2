using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Persistencia.Entidades
{
	public class Lancamento : LancamentoBase
	{
		public Lancamento(string nome, string categoria, int idCaixa, bool receita, float valor, DateTime dataLancamento, DateTime dataVencimento, int efetivado, int? idLancamentoParcelado)
			: base(nome, categoria, idCaixa, receita, valor)
		{
			DataLancamento = dataLancamento;
			DataVencimento = dataVencimento;
			Efetivado = efetivado;
			IdLancamentoParcelado = idLancamentoParcelado;
		}

		public DateTime DataLancamento { get; private set; }
		public DateTime DataVencimento { get; private set; }
		public int Efetivado { get; private set; }
		public int? IdLancamentoParcelado { get; private set; }
	}

	public class LancamentoParcelado
	{
		public LancamentoParcelado(string nome)
		{
			Nome = nome;
			Parcelas = new List<Lancamento>();
		}

		public int Id { get; private set; }
		public string Nome { get; private set; }
		public List<Lancamento> Parcelas { get; private set; }
	}
}
