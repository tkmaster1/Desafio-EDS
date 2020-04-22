using AutoMapper;
using EDS.MVC.AutoMapper.CustomProfiles.DomainToViewModelProfile;
using EDS.MVC.AutoMapper.CustomProfiles.ViewModelToDomainProfile;

namespace EDS.MVC.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}