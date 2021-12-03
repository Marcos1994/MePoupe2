using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Entidades
{
	public class LancamentoModel : LancamentoBaseModel
	{
		public LancamentoModel(int id, string nome, string categoria, CaixaModel caixa, bool receita, float valor, DateTime dataLancamento, DateTime dataVencimento, bool cancelado)
			: base(id, nome, categoria, caixa, receita, valor)
		{
			DataLancamento = dataLancamento;
			DataVencimento = dataVencimento;
			Cancelado = cancelado;
		}

		public DateTime DataLancamento { get; private set; }
		public DateTime DataVencimento { get; private set; }
		public bool Cancelado { get; private set; }
	}

	public record LancamentoParceladoModel
	{
		public LancamentoParceladoModel(int id, string nome, List<LancamentoModel> parcelas)
		{
			Id = id;
			Nome = nome;
			Parcelas = parcelas;
		}

		public int Id { get; private set; }
		public string Nome { get; private set; }
		public List<LancamentoModel> Parcelas { get; private set; }
	}
}
