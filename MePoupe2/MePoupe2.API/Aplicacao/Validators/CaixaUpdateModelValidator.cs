using FluentValidation;
using MePoupe2.API.Aplicacao.UpdateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Aplicacao.Validators
{
	public class CaixaUpdateModelValidator : AbstractValidator<CaixaUpdateModel>
	{
		public CaixaUpdateModelValidator()
		{
			RuleFor(c => c.Nome)
				.NotEmpty().WithMessage("O nome do caixa não deve estar vazio.")
				.MinimumLength(3).WithMessage("O nome do caixa deve ter no mínimo 3 caracteres.")
				.MaximumLength(50).WithMessage("O nome do caixa deve ter no máximo 50 caracteres.");
		}
	}
}
