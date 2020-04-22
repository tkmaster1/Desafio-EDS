using AutoMapper;
using EDS.Domain.Entities;
using EDS.MVC.ViewModels;

namespace EDS.MVC.AutoMapper.CustomProfiles.DomainToViewModelProfile
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName => "ViewModelToDomainMappings";

        public DomainToViewModelMappingProfile()
        {
            // ViewModelToDomain
            Mapper.CreateMap<AssuntoViewModel, Assunto>();
            Mapper.CreateMap<AutorViewModel, Autor>();
            Mapper.CreateMap<LivroAssuntoViewModel, LivroAssunto>();
            Mapper.CreateMap<LivroAutorViewModel, LivroAutor>();
            Mapper.CreateMap<LivroViewModel, Livro>();
        }
    }
}