using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class PersonelNobetDetay
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public short PazartesiNobetSayisi { get; set; }
        public short SaliNobetSayisi { get; set; }
        public short CarsambaNobetSayisi { get; set; }
        public short PersembeNobetSayisi { get; set; }
        public short CumaNobetSayisi { get; set; }
        public short CumartesiNobetSayisi { get; set; }
        public short PazarNobetSayisi { get; set; }
        public short OzelGunNobetSayisi { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public int IlkKaydedenKullaniciId { get; set; }
        public DateTime? SonKayitTarihi { get; set; }
        public int? SonKaydedenKullaniciId { get; set; }

        public virtual Personel Personel { get; set; }
    }
}
