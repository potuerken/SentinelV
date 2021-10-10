using AutoMapper;
using Check.DTO;
using Entities.Models;

namespace Business.Mapper.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Personel, PersonelDTO>();
            CreateMap<PersonelDTO, Personel>();

            CreateMap<Kod, KodDTO>();
            CreateMap<KodDTO, Kod>();
        }
    }
}
