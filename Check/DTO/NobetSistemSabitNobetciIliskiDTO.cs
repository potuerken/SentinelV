using Check.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
namespace Check.DTO
{
    public class NobetSistemSabitNobetciIliskiDTO : IDto 
    {
        public NobetSistemSabitNobetciIliskiDTO()
        {
            SabitPersonel = new PersonelDTO();
            SabitNobetSistemiKod = new KodDTO();
        }
        public int Id { get; set; }
        public int NobetSistemId { get; set; }
        public PersonelDTO SabitPersonel { get; set; }
        public KodDTO SabitNobetSistemiKod { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public int IlkKaydedenKullaniciId { get; set; }
        public DateTime? SonKayitTarihi { get; set; }
        public int? SonKaydedenKullaniciId { get; set; }
    }
}
