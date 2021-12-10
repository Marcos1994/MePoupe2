using AutoMapper;
using MePoupe2.API.Aplicacao.InputModels;
using MePoupe2.API.Aplicacao.UpdateModels;
using MePoupe2.API.Aplicacao.ViewModels;
using MePoupe2.API.Persistencia.Entidades;

namespace MePoupe2.API.Aplicacao.Profiles
{
	public class LancamentoProfile : Profile
	{
		public LancamentoProfile()
		{
			CreateMap<LancamentoInputModel, Lancamento>().IncludeMembers(l => l.Lancamento);
			CreateMap<LancamentoParceladoInputModel, Lancamento>(MemberList.None);
			CreateMap<Lancamento, LancamentoBasicViewModel>();
			CreateMap<Lancamento, LancamentoViewModel>();
		}
	}
}
