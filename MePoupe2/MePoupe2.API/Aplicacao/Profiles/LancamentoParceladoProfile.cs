using AutoMapper;
using MePoupe2.API.Aplicacao.InputModels;
using MePoupe2.API.Aplicacao.ViewModels;
using MePoupe2.API.Persistencia.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace MePoupe2.API.Aplicacao.Profiles
{
	public class LancamentoParceladoProfile : Profile
	{
		public LancamentoParceladoProfile()
		{
			CreateMap<LancamentoParceladoInputModel, LancamentoParcelado>();
			CreateMap<LancamentoParcelado, LancamentoParceladoViewModel>();
			CreateMap<Lancamento, LancamentoParceladoInputModel>();
			CreateMap<LancamentoParcelado, LancamentoParceladoViewModel>().IncludeMembers(p => p.Parcelas.FirstOrDefault());
			CreateMap<Lancamento, LancamentoParceladoViewModel>(MemberList.None);
        }
	}
}
