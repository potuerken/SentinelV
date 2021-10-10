using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class HardKod
    {
        public HardKod()
        {
            InverseUstKod = new HashSet<HardKod>();
            KodTip = new HashSet<KodTip>();
        }

        public int Id { get; set; }
        public int? UstKodId { get; set; }
        public string Ad { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public int IlkKaydedenKullaniciId { get; set; }
        public DateTime? SonKayitTarihi { get; set; }
        public int? SonKaydedenKullaniciId { get; set; }

        public virtual HardKod UstKod { get; set; }
        public virtual ICollection<HardKod> InverseUstKod { get; set; }
        public virtual ICollection<KodTip> KodTip { get; set; }
    }
}
