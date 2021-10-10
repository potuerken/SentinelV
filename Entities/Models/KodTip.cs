using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class KodTip
    {
        public KodTip()
        {
            InverseUstKod = new HashSet<KodTip>();
            Kod = new HashSet<Kod>();
        }

        public int Id { get; set; }
        public int? UstKodId { get; set; }
        public int? HardKodId { get; set; }
        public string Ad { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public int IlkKaydedenKullaniciId { get; set; }
        public DateTime? SonKayitTarihi { get; set; }
        public int? SonKaydedenKullaniciId { get; set; }

        public virtual HardKod HardKod { get; set; }
        public virtual KodTip UstKod { get; set; }
        public virtual ICollection<KodTip> InverseUstKod { get; set; }
        public virtual ICollection<Kod> Kod { get; set; }
    }
}
