using AutoMapper;
using EntityLayer.Concrete;
using VegaLedProject.Dtos.LoginDto;
using VegaLedProject.Dtos.ProjelerimizDto;
using VegaLedProject.Dtos.RegisterDto;

namespace VegaLedProject.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();
            CreateMap<LoginUserDto, AppUser>().ReverseMap();  

            CreateMap<CreateProjeDto, Hizmetlerimiz>().ReverseMap();
            CreateMap<ResultProjeDto, Hizmetlerimiz>().ReverseMap();
            CreateMap<UpdateProjeDto, Hizmetlerimiz>().ReverseMap();
        }
    }
}
