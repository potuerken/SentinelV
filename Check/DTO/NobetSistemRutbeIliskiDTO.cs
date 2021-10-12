using Check.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Check.DTO
{
    public class NobetSistemRutbeIliskiDTO : IDto
    {
        public NobetSistemRutbeIliskiDTO()
        {
            RutbeKod = new KodDTO();
        }
        public int Id { get; set; }
        public int NobetSistemId { get; set; }
        public KodDTO RutbeKod { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public int IlkKaydedenKullaniciId { get; set; }
        public DateTime? SonKayitTarihi { get; set; }
        public int? SonKaydedenKullaniciId { get; set; }
    }
}
