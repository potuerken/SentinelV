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
            CreateMap<PersonelDTO, Personel>()
                .ForMember(a => a.IlkKayitTarihi, o => o.MapFrom(s => s.IlkKayitTarihi))
                .ForMember(a => a.IlkKaydedenKullaniciId, o => o.MapFrom(s => s.IlkKaydedenKullaniciId));

            CreateMap<Kod, KodDTO>();
            CreateMap<KodDTO, Kod>();

            CreateMap<NobetSistemSabitNobetciIliskiDTO, NobetSistemSabitNobetciIliski>();
            CreateMap<NobetSistemSabitNobetciIliski, NobetSistemSabitNobetciIliskiDTO>();

            CreateMap<NobetSistemDTO, NobetSistem>();
            CreateMap<NobetSistem, NobetSistemDTO>();

            CreateMap<NobetSistemRutbeIliskiDTO, NobetSistemRutbeIliski>();
            CreateMap<NobetSistemRutbeIliski, NobetSistemRutbeIliskiDTO>();
        }
    }
}
