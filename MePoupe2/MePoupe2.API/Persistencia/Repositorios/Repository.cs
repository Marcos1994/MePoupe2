using MePoupe2.API.Persistencia.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Persistencia.Repositorios
{
	public abstract class Repository : IRepository
	{
		protected IDbContextTransaction transacao;
		protected abstract DbContext GetContext();
		public void StartTransaction(string transactionName)
		{
			if (transacao == null)
				transacao = GetContext().Database.BeginTransaction();
			transacao.CreateSavepoint(transactionName);
		}
		public void RollbackTransaction(string transactionName)
		{
			if (transacao == null)
				throw new Exception("Tranzação não iniciada.");
			transacao.RollbackToSavepoint(transactionName);
		}
		public void FinishTransaction()
		{
			if (transacao == null)
				throw new Exception("Tranzação não iniciada.");
			transacao.Commit();
		}
	}
}
