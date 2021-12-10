using AutoMapper;
using MePoupe2.API.Aplicacao.InputModels;
using MePoupe2.API.Aplicacao.UpdateModels;
using MePoupe2.API.Aplicacao.ViewModels;
using MePoupe2.API.Persistencia.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MePoupe2.API.Aplicacao.Profiles
{
	public class LancamentoProfile : Profile
	{
		public LancamentoProfile()
		{
			CreateMap<LancamentoInputModel, Lancamento>();
			//CreateMap<LancamentoUpdateModel, Lancamento>();
			CreateMap<Lancamento, LancamentoBasicViewModel>();
			CreateMap<Lancamento, LancamentoViewModel>();
		}
	}
}
