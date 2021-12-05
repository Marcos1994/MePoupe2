using MePoupe2.API.Aplicacao.InputModels;
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
		private readonly MePoupe2DbContext dbContext;

		public CaixaController(MePoupe2DbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			return Ok();
		}

		[HttpPost]
		public IActionResult Post(CaixaInputModel model)
		{
			return CreatedAtAction(nameof(GetById), new { id=1 }, model);
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, CaixaInputModel model)
		{
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			return NoContent();
		}
	}
}
