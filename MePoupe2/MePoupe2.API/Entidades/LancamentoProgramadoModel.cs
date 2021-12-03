using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Entidades
{
	public class LancamentoProgramadoModel : LancamentoBaseModel
	{
		public LancamentoProgramadoModel(int id, string nome, string categoria, CaixaModel caixa, bool receita, float valor, DateTime proximoLancamento, int periodo)
			: base(id, nome, categoria, caixa, receita, valor)
		{
			ProximoLancamento = proximoLancamento;
			Periodo = periodo;
		}

		public DateTime ProximoLancamento { get; private set; }
		public int Periodo { get; private set; }
	}
}
