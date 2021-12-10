using MePoupe2.API.Persistencia.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Persistencia.Interfaces
{
	public interface ILancamentoRepository : IRepository
	{
		IEnumerable<Lancamento> GetAll(int idCaixa);
		IEnumerable<Lancamento> GetAll(int idCaixa, int estado);
		IEnumerable<Lancamento> GetAll(int idCaixa, bool receita);
		IEnumerable<Lancamento> GetParcelas(int idLancamentoParcelado);
		Lancamento GetById(int id);
		LancamentoParcelado GetLancamentoParcelado(int id);
		void Add(Lancamento lancamento);
		void Add(LancamentoParcelado lancamentoParcelado);
		void Update(Lancamento lancamento);
		void Delete(Lancamento lancamento);
		void Delete(LancamentoParcelado lancamentoParcelado);
	}
}
