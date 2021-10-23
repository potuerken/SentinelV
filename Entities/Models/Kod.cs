using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class Kod
    {
        public Kod()
        {
            InverseUstKod = new HashSet<Kod>();
            NobetSistemRutbeIliski = new HashSet<NobetSistemRutbeIliski>();
            NobetSistemSabitNobetciIliski = new HashSet<NobetSistemSabitNobetciIliski>();
            NobetSistemSubeIliski = new HashSet<NobetSistemSubeIliski>();
            PersonelCinsiyetKod = new HashSet<Personel>();
            PersonelRutbeKod = new HashSet<Personel>();
            PersonelSubeKod = new HashSet<Personel>();
        }

        public int Id { get; set; }
        public int? UstKodId { get; set; }
        public int? KodTipId { get; set; }
        public string Ad { get; set; }
        public short? SiraNo { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public int IlkKaydedenKullaniciId { get; set; }
        public DateTime? SonKayitTarihi { get; set; }
        public int? SonKaydedenKullaniciId { get; set; }

        public virtual KodTip KodTip { get; set; }
        public virtual Kod UstKod { get; set; }
        public virtual ICollection<Kod> InverseUstKod { get; set; }
        public virtual ICollection<NobetSistemRutbeIliski> NobetSistemRutbeIliski { get; set; }
        public virtual ICollection<NobetSistemSabitNobetciIliski> NobetSistemSabitNobetciIliski { get; set; }
        public virtual ICollection<NobetSistemSubeIliski> NobetSistemSubeIliski { get; set; }
        public virtual ICollection<Personel> PersonelCinsiyetKod { get; set; }
        public virtual ICollection<Personel> PersonelRutbeKod { get; set; }
        public virtual ICollection<Personel> PersonelSubeKod { get; set; }
    }
}
