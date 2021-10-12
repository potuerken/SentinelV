using Check.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Check.DTO
{
    public class NobetSistemSubeIliskiDTO : IDto
    {
        public NobetSistemSubeIliskiDTO()
        {
            SubeKod = new KodDTO();
        }
        public int Id { get; set; }
        public int NobetSistemId { get; set; }
        public KodDTO SubeKod { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public int IlkKaydedenKullaniciId { get; set; }
        public DateTime? SonKayitTarihi { get; set; }
        public int? SonKaydedenKullaniciId { get; set; }
    }
}
