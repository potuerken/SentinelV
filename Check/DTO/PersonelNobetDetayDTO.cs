using Check.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Check.DTO
{
    public class PersonelNobetDetayDTO : IDto
    {
        public PersonelNobetDetayDTO()
        {
            Personel = new PersonelDTO();
        }
        public int Id { get; set; }
        public PersonelDTO Personel { get; set; }
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
    }
}
