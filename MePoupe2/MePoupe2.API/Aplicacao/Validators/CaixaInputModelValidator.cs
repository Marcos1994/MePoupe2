using FluentValidation;
using MePoupe2.API.Aplicacao.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Aplicacao.Validators
{
	public class CaixaInputModelValidator : AbstractValidator<CaixaInputModel>
	{
		public CaixaInputModelValidator()
		{
			RuleFor(c => c.Nome)
				.NotEmpty().WithMessage("O nome do caixa não deve estar vazio.")
				.MinimumLength(3).WithMessage("O nome do caixa deve ter no mínimo 3 caracteres.")
				.MaximumLength(50).WithMessage("O nome do caixa deve ter no máximo 50 caracteres.");
			RuleFor(c => c.Quantia)
				.GreaterThanOrEqualTo(0).WithMessage("O Caixa não pode ser cadastrado com quantias negativas.");
		}
	}
}
