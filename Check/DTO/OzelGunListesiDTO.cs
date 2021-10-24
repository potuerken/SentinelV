using Check.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Check.DTO
{
    public class OzelGunListesiDTO : IDto
    {
        public int Id { get; set; }
        public string OzelGunAdi { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public int IlkKaydedenKullaniciId { get; set; }
        public DateTime? SonKayitTarihi { get; set; }
        public int? SonKaydedenKullaniciId { get; set; }
    }
}
