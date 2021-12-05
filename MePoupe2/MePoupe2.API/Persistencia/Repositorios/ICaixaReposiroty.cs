﻿using MePoupe2.API.Persistencia.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Persistencia.Repositorios
{
	public interface ICaixaReposiroty : IRepository
	{
		IEnumerable<Caixa> GetAll(int idUsuario);
		IEnumerable<Caixa> GetAllActive(int idUsuario);
		Caixa GetById(int id);
		void Add(Caixa caixa);
		void Update(Caixa caixa);
		void Delete(Caixa caixa);
	}
}
