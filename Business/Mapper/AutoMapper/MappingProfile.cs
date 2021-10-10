using AutoMapper;
using Check.DTO;
using Entities.Models;

namespace Business.Mapper.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Personel, PersonelDTO>()
                .ForMember(a => a.CocukDurum, o => o.MapFrom(s => s.CocukDurumu == true ? "Var" : "Yok"))
                .ForMember(a => a.NobetDurumu, o => o.MapFrom(s => s.NobetTutabilirMi == true ? "Tutabilir" : "Tutamaz"));
            CreateMap<PersonelDTO, Personel>();

            CreateMap<Kod, KodDTO>();
            CreateMap<KodDTO, Kod>();
        }
    }
}
