using Check.Concrete;
using System;
using System.ComponentModel.DataAnnotations;

namespace Check.DTO
{
    public class PersonelDTO : IDto
    {
        public PersonelDTO()
        {
            CinsiyetKod = new KodDTO();
            RutbeKod = new KodDTO();
            SubeKod = new KodDTO();
        }

        public int Id { get; set; }
        
        [Display(Name = "Sicil")]
        public string Sicil { get; set; }

        [Display(Name = "TC Kimlik No")]
        public string Tckn { get; set; }

        [Display(Name = "Ad")]
        public string Ad { get; set; }

        [Display(Name = "Soyad")]
        public string Soyad { get; set; }

        [Display(Name = "Cinsiyet")]
        public KodDTO CinsiyetKod { get; set; }

        [Display(Name = "Rütbe")]
        public KodDTO RutbeKod { get; set; }

        [Display(Name = "Şube")]
        public KodDTO SubeKod { get; set; }

        [Display(Name = "Nöbet Tutabilir Mi")]
        public bool NobetTutabilirMi { get; set; }
        public string NobetDurumu { get; set; }

        [Display(Name = "Çocuk Durumu")]
        public bool CocukDurumu { get; set; }
        public string CocukDurum { get; set; }

        [Display(Name = "Cep Telefonu")]
        public string CepNo { get; set; }

        [Display(Name = "Yakın Cep Telefonu")]
        public string YakinCepNo { get; set; }

        [Display(Name = "Dahili Telefonu")]
        public string Dahili { get; set; }

        [Display(Name = "Birimde Başlama Tarihi")]
        public DateTime BirimBaslamaTarihi { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public DateTime? SonKayitTarihi { get; set; }

        public string TamAd
        {
            get
            {
                return Ad + " " + Soyad;
            }
        }

        public int IlkKaydedenKullaniciId { get; set; }
        public int? SonKaydedenKullaniciId { get; set; }
        public bool AktifMi { get; set; }

    }
}
