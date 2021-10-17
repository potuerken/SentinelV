using Check.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;

namespace Check.DTO
{
    public class NobetSistemDTO : IDto
    {
        public NobetSistemDTO()
        {
            RutbeIliskiListesi = new List<NobetSistemRutbeIliskiDTO>();
            SabitNobetciListesi = new List<NobetSistemSabitNobetciIliskiDTO>();
            SubeIliskiListesi = new List<NobetSistemSubeIliskiDTO>();
            SubeListesi = new List<int>();
            RutbeListesi = new List<int>();
        }
        public int Id { get; set; }
        public string Ad { get; set; }
        public List<NobetSistemRutbeIliskiDTO> RutbeIliskiListesi { get; set; }
        public List<int> RutbeListesi { get;set; }
        public List<NobetSistemSabitNobetciIliskiDTO> SabitNobetciListesi { get; set; }
        public List<NobetSistemSubeIliskiDTO> SubeIliskiListesi { get; set; }
        public List<int> SubeListesi { get; set; }
        public string HaftaIciGunduzSaat { get; set; }
        public short HaftaIciGunduzNobetciSayisi { get; set; }
        public string HaftaIciGeceSaat { get; set; }
        public short? HaftaIciGeceNobetciSayisi { get; set; }
        public bool HaftaIciYedekNobetciOlacakMi { get; set; }
        public string HaftaSonuGunduzSaat { get; set; }
        public short HaftaSonuGunduzNobetciSayisi { get; set; }
        public string HaftaSonuGeceSaat { get; set; }
        public short? HaftaSonuGeceNobetciSayisi { get; set; }
        public bool HaftaSonuYedekNobetciOlacakMi { get; set; }
        public string ResmiTatilGunduzSaat { get; set; }
        public short ResmiTatilGunduzNobetciSayisi { get; set; }
        public string ResmiTatilGeceSaat { get; set; }
        public short? ResmiTatilGeceNobetciSayisi { get; set; }
        public bool ResmiTatilYedekNobetciOlacakMi { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public int IlkKaydedenKullaniciId { get; set; }
        public DateTime? SonKayitTarihi { get; set; }
        public int? SonKaydedenKullaniciId { get; set; }
    }
}
