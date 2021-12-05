using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Persistencia.Entidades
{
	public class Caixa
	{
		public Caixa(int dono, string nome, string descricao, float quantia, int? idFaturaCartaoCredito, bool ativo)
		{
			Dono = dono;
			Nome = nome;
			Descricao = descricao;
			Quantia = quantia;
			IdFaturaCartaoCredito = idFaturaCartaoCredito;
			Ativo = ativo;
			Lancamentos = new List<Lancamento>();
		}

		public int Id { get; private set; }
		public int Dono { get; private set; }
		public string Nome { get; private set; }
		public string Descricao { get; private set; }
		public float Quantia { get; private set; }
		public int? IdFaturaCartaoCredito { get; private set; }
		public bool Ativo { get; private set; }
		public List<Lancamento> Lancamentos { get; private set; }

		public void Atualizar(string nome, string descricao)
		{
			Nome = nome;
			Descricao = descricao;
		}

		public void Ativar()
		{
			Ativo = true;
		}
		public void Desativar()
		{
			Ativo = false;
		}
	}
}
