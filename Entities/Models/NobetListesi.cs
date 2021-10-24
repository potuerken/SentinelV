using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class NobetListesi
    {
        public NobetListesi()
        {
            NobetListesiDetay = new HashSet<NobetListesiDetay>();
        }

        public int Id { get; set; }
        public int NobetSistemId { get; set; }
        public short Ay { get; set; }
        public short Yil { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public int IlkKaydedenKullaniciId { get; set; }
        public DateTime? SonKayitTarihi { get; set; }
        public string SonKaydedenKullaniciId { get; set; }

        public virtual NobetSistem NobetSistem { get; set; }
        public virtual ICollection<NobetListesiDetay> NobetListesiDetay { get; set; }
    }
}
