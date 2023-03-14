using AutoMapper;
using TitanServices.Entity;
using TitanServices.Models;

namespace TitanServices.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<SliderType, UpdateSliderType>().ReverseMap();
        }
    }
}
