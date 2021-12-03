using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Entidades
{
	public abstract class LancamentoBaseModel
	{
		protected LancamentoBaseModel(int id, string nome, string categoria, CaixaModel caixa, bool receita, float valor)
		{
			Id = id;
			Nome = nome;
			Categoria = categoria;
			Caixa = caixa;
			Receita = receita;
			Valor = valor;
		}

		public int Id { get; private set; }
		public string Nome { get; private set; }
		public string Categoria { get; private set; }
		public CaixaModel Caixa { get; private set; }
		public bool Receita { get; private set; }
		public float Valor { get; private set; }
	}
}
