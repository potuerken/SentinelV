using System;
using System.Collections.Generic;
using System.Text;

namespace Check.DTO
{
    public class IzinMazeretDTO
    {
        public IzinMazeretDTO()
        {
            Personel = new PersonelDTO();
            IzinMazeretKod = new KodDTO();
        }
        public int Id { get; set; }
        public PersonelDTO Personel { get; set; }
        public KodDTO IzinMazeretKod { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public int IlkKaydedenKullaniciId { get; set; }
        public DateTime? SonKayitTarihi { get; set; }
        public int? SonKaydedenKullaniciId { get; set; }
        public string Durumu { get; set; }
    }
}
