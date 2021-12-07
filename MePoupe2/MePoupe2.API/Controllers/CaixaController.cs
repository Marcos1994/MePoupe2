using MePoupe2.API.Aplicacao.InputModels;
using MePoupe2.API.Aplicacao.Interfaces;
using MePoupe2.API.Aplicacao.UpdateModels;
using MePoupe2.API.Persistencia;
using MePoupe2.API.Persistencia.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CaixaController : ControllerBase
	{
		private readonly ICaixaService caixaService;

		public CaixaController(ICaixaService caixaService)
		{
			this.caixaService = caixaService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok(caixaService.ListarCaixas(1));
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var caixa = caixaService.CarregarCaixa(id);
			if (caixa == null)
				return NotFound();
			return Ok(caixa);
		}

		[HttpPost]
		public IActionResult Post(CaixaInputModel model)
		{
			var caixa = caixaService.CriarCaixa(model);
			return CreatedAtAction(nameof(GetById), new { id=caixa.Id }, caixa);
		}

		[HttpPut]
		public IActionResult Put(CaixaUpdateModel model)
		{
			var caixa = caixaService.CarregarCaixa(model.Id);
			if (caixa == null)
				return NotFound();
			caixaService.AtualizarCaixa(model);
			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, bool ativo)
		{
			var caixa = caixaService.CarregarCaixa(id);
			if (caixa == null)
				return NotFound();

			try
			{
				caixaService.AtivarCaixa(id, ativo);
			}
			catch
			{
				return BadRequest();
			}
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var caixa = caixaService.CarregarCaixa(id);
			if (caixa == null)
				return NotFound();

			try
			{
				caixaService.ExcluirCaixa(id);
			}
			catch
			{
				return BadRequest();
			}
			return Ok();
		}
	}
}
