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
	public class LancamentoRepository : Repository, ILancamentoRepository
	{
		private readonly MePoupe2DbContext dbContext;

		public LancamentoRepository(MePoupe2DbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		protected override DbContext GetContext()
		{
			return dbContext;
		}

		public IEnumerable<Lancamento> GetAll(int idCaixa)
		{
			return (from l in dbContext.Lancamentos where l.IdCaixa == idCaixa select l).ToList();
		}
		

		public IEnumerable<Lancamento> GetAll(int idCaixa, int estado)
		{
			return (from l in dbContext.Lancamentos where l.IdCaixa == idCaixa && l.Estado == estado select l).ToList();
		}

		public IEnumerable<Lancamento> GetAll(int idCaixa, bool receita)
		{
			bool _receita = Convert.ToBoolean(receita);
			return (from l in dbContext.Lancamentos where l.IdCaixa == idCaixa && l.Receita == _receita select l).ToList();
		}

		public IEnumerable<Lancamento> GetParcelas(int idLancamentoParcelado)
		{
			return (from l in dbContext.Lancamentos where l.IdLancamentoParcelado == idLancamentoParcelado select l).ToList();
		}

		public Lancamento GetById(int id)
		{
			return dbContext.Lancamentos.First(l => l.Id == id);
		}
		public LancamentoParcelado GetLancamentoParcelado(int id)
		{
			return dbContext.LancamentosParcelados.First(l => l.Id == id);
		}

		public void Add(Lancamento lancamento)
		{
			dbContext.Lancamentos.Add(lancamento);
			dbContext.SaveChanges();
		}

		public void Add(LancamentoParcelado lancamentoParcelado)
		{
			dbContext.LancamentosParcelados.Add(lancamentoParcelado);
			dbContext.SaveChanges();
		}

		public void Update(Lancamento lancamento)
		{
			dbContext.Lancamentos.Update(lancamento);
			dbContext.SaveChanges();
		}

		public void Update(LancamentoParcelado lancamentoParcelado)
		{
			dbContext.LancamentosParcelados.Update(lancamentoParcelado);
			dbContext.SaveChanges();
		}

		public void Delete(Lancamento lancamento)
		{
			dbContext.Lancamentos.Remove(lancamento);
			dbContext.SaveChanges();
		}

		public void Delete(LancamentoParcelado lancamentoParcelado)
		{
			dbContext.LancamentosParcelados.Remove(lancamentoParcelado);
			dbContext.SaveChanges();
		}
	}
}
