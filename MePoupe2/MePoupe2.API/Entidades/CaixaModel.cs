using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Entidades
{
	public class CaixaModel
	{
		public CaixaModel(int id, int dono, string nome, string descricao, float quantia, bool faturaCartaoCredito)
		{
			Id = id;
			Dono = dono;
			Nome = nome;
			Descricao = descricao;
			Quantia = quantia;
			FaturaCartaoCredito = faturaCartaoCredito;
		}

		public int Id { get; private set; }
		public int Dono { get; private set; }
		public string Nome { get; private set; }
		public string Descricao { get; private set; }
		public float Quantia { get; private set; }
		public bool FaturaCartaoCredito { get; private set; }
	}
}
