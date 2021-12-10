using AutoMapper;
using MePoupe2.API.Aplicacao.InputModels;
using MePoupe2.API.Aplicacao.UpdateModels;
using MePoupe2.API.Aplicacao.ViewModels;
using MePoupe2.API.Persistencia.Entidades;

namespace MePoupe2.API.Aplicacao.Profiles
{
	public class CaixaProfile : Profile
	{
		public CaixaProfile()
		{
			CreateMap<CaixaInputModel, Caixa>();
			CreateMap<CaixaUpdateModel, Caixa>();
			CreateMap<Caixa, CaixaBasicViewModel>();
			CreateMap<Caixa, CaixaViewModel>();
		}
	}
}
