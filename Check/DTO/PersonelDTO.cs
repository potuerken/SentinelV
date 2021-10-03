using Check.Concrete;
using System;
using System.ComponentModel.DataAnnotations;

namespace Check.DTO
{
    public class PersonelDTO : BaseEntity, IDto
    {
        public PersonelDTO()
        {
            CinsiyetKod = new KodDTO();
            RutbeKod = new KodDTO();
            SubeKod = new KodDTO();
        }
        [Display(Name = "Sicili")]
        public string Sicil { get; set; }

        [Display(Name = "TCKN")]
        public string Tckn { get; set; }

        [Display(Name = "Ad")]
        public string Ad { get; set; }

        [Display(Name = "Soyad")]
        public string Soyad { get; set; }

        [Display(Name = "Cinsiyeti")]
        public KodDTO CinsiyetKod { get; set; }

        [Display(Name = "Rütbesi")]
        public KodDTO RutbeKod { get; set; }

        [Display(Name = "Şubesi")]
        public KodDTO SubeKod { get; set; }

        [Display(Name = "Nöbet Tutabilir Mi")]
        public bool NobetTutabilirMi { get; set; }

        public string NobetDurumu { get; set; }

        [Display(Name = "Çocuk Durumu")]
        public bool CocukDurumu { get; set; }
        public string CocukDurum { get; set; }

        [Display(Name = "Cep Telefonu")]
        public string CepNo { get; set; }

        [Display(Name = "Dahili Telefonu")]
        public string Dahili { get; set; }

        [Display(Name = "Birimde Başlama Tarihi")]
        public DateTime BirimBaslamaTarihi { get; set; }
    }
}
