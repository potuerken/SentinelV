using Check.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Check.DTO
{
    public class NobetListesiDetayDTO : IDto
    {
        public NobetListesiDetayDTO()
        {
            NobetListesi = new NobetListesiDTO();
            TurKod = new KodDTO();
            Personel = new PersonelDTO();
        }
        public int Id { get; set; }
        public NobetListesiDTO NobetListesi { get; set; }
        public KodDTO TurKod { get; set; }
        public string Saat { get; set; }
        public DateTime Tarih { get; set; }
        public string STarih { get { return Tarih.ToShortDateString(); } }
        public PersonelDTO Personel { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public int IlkKaydedenKullaniciId { get; set; }
        public DateTime? SonKayitTarihi { get; set; }
        public int? SonKaydedenKullaniciId { get; set; }

    }
}
