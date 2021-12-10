using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Persistencia.Entidades
{
	public class Lancamento : LancamentoBase
	{
		public Lancamento() : base()
		{

		}

		public Lancamento(string nome, string categoria, int idCaixa, bool receita, float valor, DateTime dataLancamento, DateTime dataVencimento, int estado, int? idLancamentoParcelado)
			: base(nome, categoria, idCaixa, receita, valor)
		{
			DataLancamento = dataLancamento;
			DataVencimento = dataVencimento;
			Estado = estado;
			IdLancamentoParcelado = idLancamentoParcelado;
		}

		public DateTime DataLancamento { get; private set; }
		public DateTime DataVencimento { get; private set; }
		public int Estado { get; private set; }
		public int? IdLancamentoParcelado { get; private set; }

		public void Update(string nome, float valor, DateTime dataLancamento, DateTime dataVencimento)
		{
			base.Update(nome, valor);
			DataLancamento = dataLancamento;
			DataVencimento = dataVencimento;
		}

		public void UpdateEstado(int estado)
		{
			Estado = estado;
		}
	}

	public class LancamentoParcelado
	{
		public LancamentoParcelado()
		{
			Parcelas = new List<Lancamento>();
		}

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
