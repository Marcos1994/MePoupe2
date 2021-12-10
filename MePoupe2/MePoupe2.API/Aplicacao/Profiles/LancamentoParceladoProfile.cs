﻿using AutoMapper;
using MePoupe2.API.Aplicacao.InputModels;
using MePoupe2.API.Aplicacao.ViewModels;
using MePoupe2.API.Persistencia.Entidades;

namespace MePoupe2.API.Aplicacao.Profiles
{
	public class LancamentoParceladoProfile : Profile
	{
		public LancamentoParceladoProfile()
		{
			CreateMap<LancamentoParceladoInputModel, LancamentoParcelado>();
			CreateMap<LancamentoParcelado, LancamentoParceladoViewModel>();
		}
	}
}
