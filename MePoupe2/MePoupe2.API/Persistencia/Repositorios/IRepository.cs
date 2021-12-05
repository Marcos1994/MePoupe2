using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Persistencia.Repositorios
{
	public interface IRepository
	{
		void StartTransaction(string transactionName);
		void RollbackTransaction(string transactionName);
		void FinishTransaction();
	}
}
