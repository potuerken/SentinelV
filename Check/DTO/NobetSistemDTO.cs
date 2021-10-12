using Check.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Check.DTO
{
    public class NobetSistemDTO : IDto
    {
        public NobetSistemDTO()
        {
            RutbeIliskiListesi = new List<NobetSistemRutbeIliskiDTO>();
            SabitNobetciListesi = new List<NobetSistemSabitNobetciIliskiDTO>();
            SubeIliskiListesi = new List<NobetSistemSubeIliskiDTO>();
        }
        public int Id { get; set; }
        public string Ad { get; set; }
        public List<NobetSistemRutbeIliskiDTO> RutbeIliskiListesi { get; set; }
        public List<NobetSistemSabitNobetciIliskiDTO> SabitNobetciListesi { get; set; }
        public List<NobetSistemSubeIliskiDTO> SubeIliskiListesi { get; set; }
        public TimeSpan PazartesiGunduzBaslangicSaati { get; set; }
        public TimeSpan PazartesiGunduzBitisSaati { get; set; }
        public TimeSpan? PazartesiGeceBaslangicSaati { get; set; }
        public TimeSpan? PazartesiGeceBitisSaati { get; set; }
        public short PazartesiGunduzNobetciSayisi { get; set; }
        public short? PazartesiGeceNobetciSayisi { get; set; }
        public TimeSpan SaliGunduzBaslangicSaati { get; set; }
        public TimeSpan SaliGunduzBitisSaati { get; set; }
        public TimeSpan? SaliGeceBaslangicSaati { get; set; }
        public TimeSpan? SaliGeceBitisSaati { get; set; }
        public short SaliGunduzNobetciSayisi { get; set; }
        public short? SaliGeceNobetciSayisi { get; set; }
        public TimeSpan ÇarşambaGunduzBaslangicSaati { get; set; }
        public TimeSpan ÇarşambaGunduzBitisSaati { get; set; }
        public TimeSpan? ÇarşambaGeceBaslangicSaati { get; set; }
        public TimeSpan? ÇarşambaGeceBitisSaati { get; set; }
        public short ÇarşambaGunduzNobetciSayisi { get; set; }
        public short? ÇarşambaGeceNobetciSayisi { get; set; }
        public TimeSpan PerşembeGunduzBaslangicSaati { get; set; }
        public TimeSpan PerşembeGunduzBitisSaati { get; set; }
        public TimeSpan? PerşembeGeceBaslangicSaati { get; set; }
        public TimeSpan? PerşembeGeceBitisSaati { get; set; }
        public short PerşembeGunduzNobetciSayisi { get; set; }
        public short? PerşembeGeceNobetciSayisi { get; set; }
        public TimeSpan CumaGunduzBaslangicSaati { get; set; }
        public TimeSpan CumaGunduzBitisSaati { get; set; }
        public TimeSpan? CumaGeceBaslangicSaati { get; set; }
        public TimeSpan? CumaGeceBitisSaati { get; set; }
        public short CumaGunduzNobetciSayisi { get; set; }
        public short? CumaGeceNobetciSayisi { get; set; }
        public TimeSpan CumartesiGunduzBaslangicSaati { get; set; }
        public TimeSpan CumartesiGunduzBitisSaati { get; set; }
        public TimeSpan? CumartesiGeceBaslangicSaati { get; set; }
        public TimeSpan? CumartesiGeceBitisSaati { get; set; }
        public short CumartesiGunduzNobetciSayisi { get; set; }
        public short? CumartesiGeceNobetciSayisi { get; set; }
        public TimeSpan PazarGunduzBaslangicSaati { get; set; }
        public TimeSpan PazarGunduzBitisSaati { get; set; }
        public TimeSpan? PazarGeceBaslangicSaati { get; set; }
        public TimeSpan? PazarGeceBitisSaati { get; set; }
        public short PazarGunduzNobetciSayisi { get; set; }
        public short? PazarGeceNobetciSayisi { get; set; }
        public bool HaftaIciYedekNobetciOlacakMi { get; set; }
        public bool HaftaSonuYedekNobetciOlacakMi { get; set; }
        public bool OzelGunlerdeNobetciOlacakMi { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public int IlkKaydedenKullaniciId { get; set; }
        public DateTime SonKayitTarihi { get; set; }
        public int SonKaydedenKullaniciId { get; set; }
    }
}
