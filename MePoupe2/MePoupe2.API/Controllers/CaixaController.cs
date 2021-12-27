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
		private int _idUsuario;
		private readonly ICaixaService caixaService;
		private readonly ILancamentoService lancamentoService;

		public CaixaController(ICaixaService caixaService, ILancamentoService lancamentoService)
		{
			_idUsuario = 1;
			this.caixaService = caixaService;
			this.lancamentoService = lancamentoService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok(caixaService.ListarCaixas(_idUsuario));
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var caixa = caixaService.CarregarCaixa(id);
			if (caixa == null)
				return NotFound();
			caixa.Lancamentos.AddRange(lancamentoService.ListarPendentes(id));
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
			caixaService.AtualizarCaixa(model);
			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, bool ativo)
		{
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
