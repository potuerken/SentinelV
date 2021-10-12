using Check.Concrete;
using Check.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Check.DTO
{
    public class KodDTO : IDto
    {
        public int Id { get; set; }
        public int? KodTipId { get; set; }
        public string Ad { get; set; }
        public short? SiraNo { get; set; }
        public KodTipEnum UstKodId { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public int IlkKaydedenKullaniciId { get; set; }
        public DateTime? SonKayitTarihi { get; set; }
        public int? SonKaydedenKullaniciId { get; set; }
        public bool AktifMi { get; set; }
    }
}
