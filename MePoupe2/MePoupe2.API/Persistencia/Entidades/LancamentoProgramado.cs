using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Persistencia.Entidades
{
	public class LancamentoProgramado : LancamentoBase
	{
		public LancamentoProgramado(int id, string nome, string categoria, int idCaixa, bool receita, float valor, DateTime proximoLancamento, int periodo)
			: base(nome, categoria, idCaixa, receita, valor)
		{
			ProximoLancamento = proximoLancamento;
			Periodo = periodo;
		}

		public DateTime ProximoLancamento { get; private set; }
		public int Periodo { get; private set; }
	}
}
