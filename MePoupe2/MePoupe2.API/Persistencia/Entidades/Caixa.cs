using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Persistencia.Entidades
{
	public class Caixa
	{
		public Caixa()
		{

		}

		public Caixa(int idDono, string nome, string descricao, float quantia, int? idFaturaCartaoCredito, bool ativo)
		{
			IdDono = idDono;
			Nome = nome;
			Descricao = descricao;
			Quantia = quantia;
			IdFaturaCartaoCredito = idFaturaCartaoCredito;
			Ativo = ativo;
			Lancamentos = new List<Lancamento>();
		}

		public int Id { get; private set; }
		public int IdDono { get; private set; }
		public string Nome { get; private set; }
		public string Descricao { get; private set; }
		public float Quantia { get; private set; }
		public int? IdFaturaCartaoCredito { get; private set; }
		public bool Ativo { get; private set; }
		public List<Lancamento> Lancamentos { get; private set; }

		public void Update(string nome, string descricao, float quantia, bool ativo)
		{
			Nome = nome;
			Descricao = descricao;
			Quantia = quantia;
			Ativo = ativo;
		}
	}
}
