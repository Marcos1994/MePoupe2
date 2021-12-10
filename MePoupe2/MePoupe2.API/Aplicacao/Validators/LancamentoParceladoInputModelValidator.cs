using FluentValidation;
using MePoupe2.API.Aplicacao.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Aplicacao.Validators
{
	public class LancamentoParceladoInputModelValidator : AbstractValidator<LancamentoParceladoInputModel>
	{
		public LancamentoParceladoInputModelValidator()
		{
			RuleFor(l => l.Parcelas)
				.Must(p => p.Count > 0);
		}
	}
}
