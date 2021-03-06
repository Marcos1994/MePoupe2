using FluentValidation.AspNetCore;
using MePoupe2.API.Aplicacao.Interfaces;
using MePoupe2.API.Aplicacao.Profiles;
using MePoupe2.API.Aplicacao.Servicos;
using MePoupe2.API.Aplicacao.Validators;
using MePoupe2.API.Persistencia;
using MePoupe2.API.Persistencia.Context;
using MePoupe2.API.Persistencia.Interfaces;
using MePoupe2.API.Persistencia.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<ICaixaService, CaixaService>();
			services.AddScoped<ILancamentoService, LancamentoService>();

			services.AddScoped<ICaixaRepository, CaixaRepository>();
			services.AddScoped<ILancamentoRepository, LancamentoRepository>();

			services.AddDbContext<MePoupe2DbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("MePoupe2Cs")));
			services.AddScoped<MePoupe2DbContext>();

			services.AddAutoMapper(typeof(CaixaProfile));
			services.AddAutoMapper(typeof(LancamentoProfile));
			services.AddAutoMapper(typeof(LancamentoParceladoProfile));

			services.AddControllers()
				.AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CaixaInputModelValidator>())
				.AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CaixaUpdateModelValidator>())
				.AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<LancamentoParceladoInputModelValidator>());

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "MePoupe2.API", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MePoupe2.API v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
