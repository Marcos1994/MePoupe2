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
			RuleFor(l => l.Nome)
				.NotEmpty().WithMessage("O nome do lancamento não deve estar vazio.")
				.MinimumLength(3).WithMessage("O nome do lancamento deve ter no mínimo 3 caracteres.")
				.MaximumLength(50).WithMessage("O nome do lancamento deve ter no máximo 50 caracteres.");
			RuleFor(l => l.Categoria)
				.NotEmpty().WithMessage("O nome da categoria não deve estar vazio.")
				.MinimumLength(3).WithMessage("O nome da categoria deve ter no mínimo 3 caracteres.")
				.MaximumLength(50).WithMessage("O nome da categoria deve ter no máximo 50 caracteres.");
			RuleFor(l => l.Valor)
				.GreaterThan(0).WithMessage("O valor do lançamento deve ser maior que 0.");
			RuleFor(l => l.Parcelas)
				.Must(p => p.Count > 0).WithMessage("Um lançamento parcelado deve ter pelo menos 1 parcela.");
		}
	}
}
