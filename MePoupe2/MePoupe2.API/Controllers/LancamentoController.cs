using MePoupe2.API.Aplicacao.InputModels;
using MePoupe2.API.Aplicacao.Interfaces;
using MePoupe2.API.Aplicacao.UpdateModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LancamentoController : ControllerBase
	{
		private readonly ILancamentoService lancamentoService;

		public LancamentoController(ILancamentoService lancamentoService)
		{
			this.lancamentoService = lancamentoService;
		}

		[HttpGet("{idCaixa}")]
		public IActionResult GetAll(int idCaixa)
		{
			return Ok(lancamentoService.ListarTodos(idCaixa));
		}

		[HttpGet("{idLancamento}")]
		public IActionResult GetById(int idLancamento)
		{
			return Ok();

			var lancamento = lancamentoService.CarregarLancamento(idLancamento);
			if (lancamento == null)
				return NotFound();
			return Ok(lancamento);
		}

		[HttpPost]
		public IActionResult Post(LancamentoParceladoInputModel model)
		{
			var lancamento = lancamentoService.CriarLancamento(model);
			return CreatedAtAction(nameof(GetById), new { id = lancamento.Id }, lancamento);
		}

		[HttpPut]
		public IActionResult Put(CaixaUpdateModel model)
		{
			throw new NotImplementedException();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			throw new NotImplementedException();
		}
	}
}
