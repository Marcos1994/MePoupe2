using MePoupe2.API.Persistencia.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Persistencia.Interfaces
{
	public interface ICaixaReposiroty : IRepository
	{
		IEnumerable<Caixa> GetAll(int idDono);
		Caixa GetById(int id);
		void Add(Caixa caixa);
		void Update(Caixa caixa);
		void Delete(Caixa caixa);
	}
}
