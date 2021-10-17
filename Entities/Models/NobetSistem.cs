using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class NobetSistem
    {
        public NobetSistem()
        {
            NobetSistemRutbeIliski = new HashSet<NobetSistemRutbeIliski>();
            NobetSistemSabitNobetciIliski = new HashSet<NobetSistemSabitNobetciIliski>();
            NobetSistemSubeIliski = new HashSet<NobetSistemSubeIliski>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }
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

        public virtual ICollection<NobetSistemRutbeIliski> NobetSistemRutbeIliski { get; set; }
        public virtual ICollection<NobetSistemSabitNobetciIliski> NobetSistemSabitNobetciIliski { get; set; }
        public virtual ICollection<NobetSistemSubeIliski> NobetSistemSubeIliski { get; set; }
    }
}
