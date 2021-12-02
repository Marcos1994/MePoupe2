using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.DTOs
{
	public record CaixaInputModel
	{
		public int Id { get; private set; }
		public int Dono { get; private set; }
		public string Nome { get; private set; }
		public string Descricao { get; private set; }
		public float Quantia { get; private set; }
		public bool CartaoCredito { get; private set; }
	}
}
