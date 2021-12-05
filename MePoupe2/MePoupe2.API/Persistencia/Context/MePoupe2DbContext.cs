using MePoupe2.API.Persistencia.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Persistencia.Context
{
	public class MePoupe2DbContext : DbContext
	{
		public MePoupe2DbContext(DbContextOptions<MePoupe2DbContext> options) : base(options)
		{

		}

		public DbSet<Caixa> Caixas { get; set; }
		public DbSet<Lancamento> Lancamentos { get; set; }
		public DbSet<LancamentoParcelado> LancamentosParcelados { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			/*--------- Caixas ---------*/
			modelBuilder.Entity<Caixa>()
				.ToTable("tb_Caixas")
				.HasKey(c => c.Id);

			modelBuilder.Entity<Caixa>()
				.HasMany(c => c.Lancamentos)
				.WithOne()
				.HasForeignKey(l => l.IdCaixa);



			/*--------- Lancamentos ---------*/
			modelBuilder.Entity<Lancamento>()
				.ToTable("tb_Lancamentos")
				.HasKey(l => l.Id);



			/*--------- Lancamentos Parcelados ---------*/
			modelBuilder.Entity<LancamentoParcelado>()
				.ToTable("tb_LancamentosParcelados")
				.HasKey(l => l.Id);

			modelBuilder.Entity<LancamentoParcelado>()
				.HasMany(lp => lp.Parcelas)
				.WithOne()
				.HasForeignKey(l => l.IdLancamentoParcelado)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
