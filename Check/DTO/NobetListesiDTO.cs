using Check.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Check.DTO
{
    public class NobetListesiDTO : IDto
    {
        public NobetListesiDTO()
        {
            NobetSistem = new NobetSistemDTO();
        }
        public int Id { get; set; }
        public NobetSistemDTO NobetSistem { get; set; }
        public short Ay { get; set; }
        public short Yil { get; set; }
        public DateTime DenemeTarihi { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public int IlkKaydedenKullaniciId { get; set; }
        public DateTime? SonKayitTarihi { get; set; }
        public string SonKaydedenKullaniciId { get; set; }
    }
}
