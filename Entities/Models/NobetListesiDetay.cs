using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class NobetListesiDetay
    {
        public int Id { get; set; }
        public int NobetListesiId { get; set; }
        public int TurKodId { get; set; }
        public string Saat { get; set; }
        public DateTime Tarih { get; set; }
        public int PersonelId { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public int IlkKaydedenKullaniciId { get; set; }
        public DateTime? SonKayitTarihi { get; set; }
        public int? SonKaydedenKullaniciId { get; set; }

        public virtual NobetListesi NobetListesi { get; set; }
        public virtual Personel Personel { get; set; }
        public virtual Kod TurKod { get; set; }
    }
}
