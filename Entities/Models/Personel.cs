using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class Personel
    {
        public Personel()
        {
            IzinMazeret = new HashSet<IzinMazeret>();
            NobetSistemSabitNobetciIliski = new HashSet<NobetSistemSabitNobetciIliski>();
        }

        public int Id { get; set; }
        public string Sicil { get; set; }
        public string Tckn { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int CinsiyetKodId { get; set; }
        public int RutbeKodId { get; set; }
        public int SubeKodId { get; set; }
        public bool NobetTutabilirMi { get; set; }
        public bool CocukDurumu { get; set; }
        public string CepNo { get; set; }
        public string YakinCepNo { get; set; }
        public string Dahili { get; set; }
        public DateTime? BirimBaslamaTarihi { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public int IlkKaydedenKullaniciId { get; set; }
        public DateTime? SonKayitTarihi { get; set; }
        public int? SonKaydedenKullaniciId { get; set; }

        public virtual Kod CinsiyetKod { get; set; }
        public virtual Kod RutbeKod { get; set; }
        public virtual Kod SubeKod { get; set; }
        public virtual ICollection<IzinMazeret> IzinMazeret { get; set; }
        public virtual ICollection<NobetSistemSabitNobetciIliski> NobetSistemSabitNobetciIliski { get; set; }
    }
}
