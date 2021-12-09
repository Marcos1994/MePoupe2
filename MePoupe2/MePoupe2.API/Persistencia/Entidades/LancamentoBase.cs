using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Persistencia.Entidades
{
	public abstract class LancamentoBase
	{
		protected LancamentoBase()
		{

		}

		protected LancamentoBase(string nome, string categoria, int idCaixa, bool receita, float valor)
		{
			//Id = id;
			Nome = nome;
			Categoria = categoria;
			IdCaixa = idCaixa;
			Receita = receita;
			Valor = valor;
		}

		public int Id { get; private set; }
		public string Nome { get; private set; }
		public string Categoria { get; private set; }
		public int IdCaixa { get; private set; }
		public bool Receita { get; private set; }
		public float Valor { get; private set; }
	}
}
