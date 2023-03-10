using AutoMapper;
using SONRISA_BACKEND.Entity;
using SONRISA_BACKEND.Models;

namespace SONRISA_BACKEND.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<User, RegisterEntity>().ReverseMap();
            CreateMap<User, LoginEntity>().ReverseMap();
            CreateMap<User, UpdateEntity>();
        }
    }
}
