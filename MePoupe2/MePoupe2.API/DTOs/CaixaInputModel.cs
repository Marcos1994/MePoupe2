﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.DTOs
{
	public record CaixaInputModel
	{
		public int Id { get; set; }
		public int Dono { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public float Quantia { get; set; }
		public bool FaturaCartaoCredito { get; set; }
	}
}
