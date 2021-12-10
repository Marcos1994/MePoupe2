using MePoupe2.API.Persistencia.Context;
using MePoupe2.API.Persistencia.Entidades;
using MePoupe2.API.Persistencia.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Persistencia.Repositorios
{
	public class CaixaRepository : Repository, ICaixaRepository
	{
		private readonly MePoupe2DbContext dbContext;
		public CaixaRepository(MePoupe2DbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		protected override DbContext GetContext()
		{
			return dbContext;
		}

		public IEnumerable<Caixa> GetAll(int idDono)
		{
			return dbContext.Caixas.Where(c => c.IdDono == idDono).ToList();
		}

		public Caixa GetById(int id)
		{
			return dbContext.Caixas.FirstOrDefault(c => c.Id == id);
		}

		public void Add(Caixa caixa)
		{
			dbContext.Caixas.Add(caixa);
			dbContext.SaveChanges();
		}

		public void Update(Caixa caixa)
		{
			dbContext.Caixas.Update(caixa);
			dbContext.SaveChanges();
		}

		public void Delete(Caixa caixa)
		{
			dbContext.Caixas.Remove(caixa);
			dbContext.SaveChanges();
		}

		public float GetQuantia(int idCaixa)
		{
			float quantia = dbContext.Lancamentos
				.Where(l => l.IdCaixa == idCaixa && l.Estado == 1)
				.Sum(l => (l.Receita) ? l.Valor : -l.Valor);
			return quantia;
		}
	}
}
