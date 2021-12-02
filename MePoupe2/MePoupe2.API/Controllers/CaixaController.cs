using MePoupe2.API.DTOs;
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
