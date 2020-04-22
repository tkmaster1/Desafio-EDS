using AutoMapper;
using EDS.Domain.Entities;
using EDS.MVC.ViewModels;

namespace EDS.MVC.AutoMapper.CustomProfiles.ViewModelToDomainProfile
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName => "DomainToViewModelMappings";

        public ViewModelToDomainMappingProfile()
        {
            // DomainToViewModel
            Mapper.CreateMap<Assunto, AssuntoViewModel>();
            Mapper.CreateMap<Autor, AutorViewModel>();
            Mapper.CreateMap<LivroAutor, LivroAutorViewModel>();
            Mapper.CreateMap<LivroAssunto, LivroAssuntoViewModel>();
            Mapper.CreateMap<Livro, LivroViewModel>();
        }
    }
}