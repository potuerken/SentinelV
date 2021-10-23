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

            CreateMap<NobetSistemDTO, NobetSistem>()
                .ForMember(a=>a.NobetSistemSubeIliski, o=>o.MapFrom(s=>s.SubeIliskiListesi))
                .ForMember(a=>a.NobetSistemRutbeIliski, o=>o.MapFrom(s=>s.RutbeIliskiListesi));

            CreateMap<NobetSistem, NobetSistemDTO>()
                .ForMember(a => a.SubeIliskiListesi, o => o.MapFrom(s => s.NobetSistemSubeIliski))
                .ForMember(a => a.RutbeIliskiListesi, o => o.MapFrom(s => s.NobetSistemRutbeIliski))
                .ForMember(a => a.SabitNobetciListesi, o => o.MapFrom(s => s.NobetSistemSabitNobetciIliski));


            CreateMap<NobetSistemRutbeIliskiDTO, NobetSistemRutbeIliski>();
            CreateMap<NobetSistemRutbeIliski, NobetSistemRutbeIliskiDTO>();

            CreateMap<NobetSistemSubeIliskiDTO, NobetSistemSubeIliski>();
            CreateMap<NobetSistemSubeIliski, NobetSistemSubeIliskiDTO>();


            CreateMap<IzinMazeretDTO, IzinMazeret>();
            CreateMap<IzinMazeret, IzinMazeretDTO>()
                .ForMember(a => a.Durumu, o => o.MapFrom(s => (s.BitisTarihi > System.DateTime.Today && s.BaslangicTarihi < System.DateTime.Today) ? "Devam Ediyor" : (s.BitisTarihi < System.DateTime.Today && s.BaslangicTarihi < System.DateTime.Today) ?  "İzin Tamamlanmış" : "İzin Başlamamış"));

        }
    }
}
